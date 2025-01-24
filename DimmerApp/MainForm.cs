
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
        private Icon DimmerIcon;
        private WindowChecker windowChecker;
        public static AppConfig savedConfig;
        private Button editConfigButton;
        private OverlayManager overlayManager;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public MainForm()
        {
            DimmerIcon = new Icon("Icon_DimmerApp.ico");

            this.Text = "Screen dimmer";
            this.Width = 300;
            this.Height = 200;

            windowChecker = new WindowChecker();
            overlayManager = new OverlayManager(this);

            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon();

            // Load the icon from the file path
            notifyIcon.Icon = DimmerIcon;
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

            this.Icon = DimmerIcon;

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
            configEditor.FormClosed += ConfigEditor_FormClosed;
            configEditor.Show();
        }

        private void ConfigEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reload the configuration
            LoadConfig();
            // Restart the GetActiveWindow task with the new configuration
            overlayManager.GetActiveWindow(savedConfig);
        }

        public void LoadConfig()
        {
            savedConfig = ConfigManager.LoadConfig("config.json");
        }

        private void GetActiveWindow()
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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}
