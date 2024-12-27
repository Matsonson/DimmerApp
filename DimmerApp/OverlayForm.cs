using DimmerApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

    public OverlayForm(Screen screen, AppConfig config)
    {

        this.FormBorderStyle = FormBorderStyle.None;
        this.Bounds = screen.Bounds;
        this.Opacity = config.Opacity;

        Color setColor= Color.FromName(config.Color);
        if (!setColor.IsKnownColor)
        {
            setColor = ColorTranslator.FromHtml("#" + config.Color);
        }

        this.BackColor = setColor;
        this.ShowInTaskbar = false;
        this.StartPosition = FormStartPosition.Manual;
        this.TopMost = true;

        // Make the form layered and click-through
        uint exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
        SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);

    }

}
