using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class ScreenSelectorForm : Form
{
    private ComboBox screenComboBox;
    private Button applyButton;

    public ScreenSelectorForm()
    {
        this.Text = "Select Screen";
        this.Width = 300;
        this.Height = 150;

        screenComboBox = new ComboBox { Left = 50, Top = 20, Width = 200 };
        applyButton = new Button { Text = "Apply", Left = 100, Top = 60, Width = 100 };

        // Populate ComboBox with available screens
        foreach (var screen in Screen.AllScreens)
        {
            screenComboBox.Items.Add(screen.DeviceName);
        }

        applyButton.Click += ApplyButton_Click;

        this.Controls.Add(screenComboBox);
        this.Controls.Add(applyButton);
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        if (screenComboBox.SelectedIndex >= 0)
        {
            Screen selectedScreen = Screen.AllScreens[screenComboBox.SelectedIndex];
            float opacity = 0.75f; // Set desired opacity
            var overlay = new OverlayForm(selectedScreen, opacity);
            overlay.Show();
        }
        else
        {
            MessageBox.Show("Please select a screen.");
        }
    }
}



public class OverlayForm : Form
{
    // Import the necessary function from the User32.dll
    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    private const int GWL_EXSTYLE = -20;
    private const uint WS_EX_TRANSPARENT = 0x00000020;
    private const uint WS_EX_LAYERED = 0x00080000;

    public OverlayForm(Screen screen, float opacity)
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.Bounds = screen.Bounds;
        this.Opacity = opacity;
        this.BackColor = System.Drawing.Color.Black; // Set a solid background color
        this.ShowInTaskbar = false;
        this.StartPosition = FormStartPosition.Manual;
        this.TopMost = true;

        // Make the form layered and click-through
        uint exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
        SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);
    }
}