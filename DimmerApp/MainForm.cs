
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

        public MainForm()
        {
            this.Text = "Select Screen";
            this.Width = 300;
            this.Height = 200;
            this.BackColor = AppColors.DarkThemeBackground;
            this.ForeColor = AppColors.DarkThemeText;

            screenComboBox = new ComboBox
            {
                Left = 50,
                Top = 20,
                Width = 200,
                BackColor = AppColors.ComboBoxBackground,
                ForeColor = AppColors.DarkThemeText,
                FlatStyle = FlatStyle.Flat,
            };
            applyButton = new Button
            {
                Text = "Apply",
                Left = 100,
                Top = 60,
                Width = 100,
                BackColor = AppColors.ButtonBackground,
                ForeColor = AppColors.DarkThemeText,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = AppColors.ButtonBorder },
            };
            editConfigButton = new Button
            {
                Text = "Edit Config",
                Left = 100,
                Top = 100,
                Width = 100,
                BackColor = AppColors.ButtonBackground,
                ForeColor = AppColors.DarkThemeText,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = AppColors.ButtonBorder },
            };

            // Populate ComboBox with available screens
            foreach (var screen in Screen.AllScreens)
            {
                screenNames.Add(screen.DeviceName);
            }

            screenComboBox.DataSource = screenNames;
            if (screenComboBox.Items.Count > 0)
            {
                screenComboBox.SelectedIndex = 0;
            }

            applyButton.Click += ApplyButton_Click;
            editConfigButton.Click += EditConfigButton_Click;

            this.Controls.Add(screenComboBox);
            this.Controls.Add(applyButton);
            this.Controls.Add(editConfigButton);

            windowChecker = new WindowChecker();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (screenComboBox.SelectedIndex >= 0)
            {
                Screen selectedScreen = Screen.AllScreens[screenComboBox.SelectedIndex];
                float opacity = 0.75f; // Set desired opacity
                var overlay = new OverlayForm(selectedScreen, opacity);
                overlay.Show();
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                MessageBox.Show("Please select a screen.");
            }
        }

        private void EditConfigButton_Click(object sender, EventArgs e)
        {
            var configEditor = new ConfigEditor(screenNames);
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
                while (true)
                {
                    string activeWindowTitle = WindowChecker.GetActiveWindowTitle();
                    if (activeWindowTitle != null && activeWindowTitle.Contains("Home"))
                    {
                        windowMatch = true;
                    }
                    else
                    {
                        windowMatch = false;
                    }
                    Debug.WriteLine(windowMatch.ToString());

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
