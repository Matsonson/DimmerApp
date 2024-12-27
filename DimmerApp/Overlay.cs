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
        this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark theme background color
        this.ForeColor = System.Drawing.Color.White; // Dark theme text color

        screenComboBox = new ComboBox
        {
            Left = 50,
            Top = 20,
            Width = 200,
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
            ForeColor = System.Drawing.Color.White,
            FlatStyle = FlatStyle.Flat,
        };
        applyButton = new Button
        {
            Text = "Apply",
            Left = 100,
            Top = 60,
            Width = 100,
            BackColor = System.Drawing.Color.FromArgb(28, 28, 28),
            ForeColor = System.Drawing.Color.White,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderColor = System.Drawing.Color.FromArgb(20, 20, 20) } // Darker border color
        };

        // Populate ComboBox with available screens
        foreach (var screen in Screen.AllScreens)
        {
            screenComboBox.Items.Add(screen.DeviceName);
        }

        if (screenComboBox.Items.Count > 0)
        {
            screenComboBox.SelectedIndex = 0;
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
            this.WindowState = FormWindowState.Minimized;
        }
        else
        {
            MessageBox.Show("Please select a screen.");
        }
    }
}

