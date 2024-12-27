
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DimmerApp { 
public class MainForm : Form
    {
        private WindowChecker windowChecker;
        public static AppConfig config;
        private ComboBox screenComboBox;
        private Button applyButton;
        private Button editConfigButton;
        private List<string> screenNames = new List<string>();
        private bool windowMatch = false;
        private List<OverlayForm> overlays = new List<OverlayForm>();

        public MainForm()
        {
            this.Text = "Select Screen";
            this.Width = 300;
            this.Height = 200;

            windowChecker = new WindowChecker();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AppColors.ApplyFormStyle(this);

            applyButton = new Button
            {
                Text = "Apply",
                Left = 100,
                Top = 60,
                Width = 100,
            };
            AppColors.ApplyButtonStyle(applyButton);

            editConfigButton = new Button
            {
                Text = "Edit Config",
                Left = 100,
                Top = 100,
                Width = 100,
            };
            AppColors.ApplyButtonStyle(editConfigButton);

            applyButton.Click += ApplyButton_Click;
            editConfigButton.Click += EditConfigButton_Click;

            this.Controls.Add(screenComboBox);
            this.Controls.Add(applyButton);
            this.Controls.Add(editConfigButton);

        }


        private void ApplyButton_Click(object sender, EventArgs e)
        {
            //ApplyOverlay();
        }

        private void ApplyOverlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ApplyOverlay));
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
            Debug.WriteLine("Overlay applied.");
        }

        private void Clearoverlay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Clearoverlay));
                return;
            }

            foreach (OverlayForm overlay in overlays)
            {
                overlay.Close();
            }
            overlays.Clear();
            Debug.WriteLine("Overlay cleared.");
        }

        private void EditConfigButton_Click(object sender, EventArgs e)
        {
            var configEditor = new ConfigEditor();
            configEditor.Show();
        }

        public void LoadConfig()
        {
            config = ConfigManager.LoadConfig("config.json");
        }

        private async void GetActiveWindow()
        {
            if (config == null)
            {
                LoadConfig();
            }

            await Task.Run(async () =>
            {
                bool overlayApplied = false;

                while (true)
                {
                    try
                    {
                        string activeWindowTitle = WindowChecker.GetActiveWindowTitle();
                        if (activeWindowTitle != null && activeWindowTitle.Contains("Home"))
                        {
                            if (!overlayApplied)
                            {
                                windowMatch = true;
                                ApplyOverlay();
                                overlayApplied = true;
                            }
                        }
                        else
                        {
                            if (overlayApplied)
                            {
                                windowMatch = false;
                                Clearoverlay();
                                overlayApplied = false;
                            }
                        }
                        Debug.WriteLine(windowMatch.ToString());
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Exception in GetActiveWindow: {ex.Message}");
                    }

                    await Task.Delay(1000);
                }
            });
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GetActiveWindow();
        }
    }
}
