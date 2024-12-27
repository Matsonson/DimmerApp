
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DimmerApp { 
public class MainForm : Form
    {
        private WindowChecker windowChecker;
        public static AppConfig savedConfig;
        private Button editConfigButton;
        private List<string> screenNames = new List<string>();
        private OverlayManager overlayManager;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public MainForm()
        {
            this.Text = "Screen dimmer";
            this.Width = 300;
            this.Height = 200;

            windowChecker = new WindowChecker();
            overlayManager = new OverlayManager(this); // Pass the form instance

            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application; // Set your icon here
            notifyIcon.Text = "DimmerApp";
            notifyIcon.Visible = true;

            // Initialize ContextMenu
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Show", null, ShowForm);
            contextMenu.Items.Add("Exit", null, ExitApplication);
            notifyIcon.ContextMenuStrip = contextMenu;

            notifyIcon.DoubleClick += ShowForm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AppColors.ApplyFormStyle(this);

            editConfigButton = new Button
            {
                Text = "Edit Config",
                Left = 100,
                Top = 100,
                Width = 100,
            };
            AppColors.ApplyButtonStyle(editConfigButton);

            editConfigButton.Click += EditConfigButton_Click;

            this.Controls.Add(editConfigButton);

            // Hide the form initially
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // ApplyOverlay();
        }

        private void EditConfigButton_Click(object sender, EventArgs e)
        {
            var configEditor = new ConfigEditor(overlayManager);
            configEditor.Show();
        }

        public void LoadConfig()
        {
            savedConfig = ConfigManager.LoadConfig("config.json");
        }

        private async void GetActiveWindow()
        {
            if (savedConfig == null)
            {
                LoadConfig();
            }

            overlayManager.GetActiveWindow(savedConfig);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GetActiveWindow();
        }

        private void ShowForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            notifyIcon.Visible = false;
        }
    }
}
