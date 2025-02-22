﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace DimmerApp
{
    public class OverlayManager
    {
        public bool overlayApplied = false;
        public bool previewMode = false;
        private List<OverlayForm> overlays = new List<OverlayForm>();
        private Control uiControl;
        private CancellationTokenSource cancellationTokenSource;

        public OverlayManager(Control control)
        {
            uiControl = control;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void ApplyOverlay(AppConfig config)
        {
            if (uiControl.InvokeRequired)
            {
                uiControl.Invoke(new Action(() => ApplyOverlay(config)));
                return;
            }

            Screen[] screensToDim = Screen.AllScreens;
            screensToDim = screensToDim.Where(s => s.DeviceName != config.DefaultScreen).ToArray();

            foreach (Screen screen in screensToDim)
            {
                var overlay = new OverlayForm(screen, config);
                overlay.Show();
                overlays.Add(overlay);
            }
            overlayApplied = true;
            Debug.WriteLine("Overlay applied.");
        }

        public void Clearoverlay()
        {
            if (uiControl.InvokeRequired)
            {
                uiControl.Invoke(new Action(Clearoverlay));
                return;
            }

            foreach (OverlayForm overlay in overlays)
            {
                overlay.Close();
            }
            overlays.Clear();
            overlayApplied = false;
            Debug.WriteLine("Overlay cleared.");
        }

        public async void GetActiveWindow(AppConfig savedConfig)
        {
            cancellationTokenSource.Cancel(); // Cancel the existing task
            cancellationTokenSource = new CancellationTokenSource(); // Create a new token source

            await Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        string activeWindowTitle = WindowChecker.GetActiveWindowTitle();
                        if (activeWindowTitle == null) { await Task.Delay(1000); continue; }

                        if (IsTitleMatch(activeWindowTitle, savedConfig))
                        {
                            if (!overlayApplied)
                            {
                                ApplyOverlay(savedConfig);
                            }
                        }
                        else
                        {
                            if (overlayApplied && !previewMode)
                            {
                                Clearoverlay();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Exception in GetActiveWindow: {ex.Message}");
                    }

                    await Task.Delay(1000);
                }
            }, cancellationTokenSource.Token);
        }

        private bool IsTitleMatch(string activeWindowTitle, AppConfig config)
        {
            foreach (var title in config.WindowTitles)
            {
                if (config.PartialMatch)
                {
                    if (activeWindowTitle.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                else
                {
                    if (activeWindowTitle.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
