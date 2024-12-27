using System.Drawing;
using System.Windows.Forms;

namespace DimmerApp { 
    public static class AppColors
    {
        public static readonly Color DarkThemeBackground = Color.FromArgb(45, 45, 48);
        public static readonly Color DarkThemeText = Color.White;
        public static readonly Color ComboBoxBackground = Color.FromArgb(30, 30, 30);
        public static readonly Color ButtonBackground = Color.FromArgb(28, 28, 28);
        public static readonly Color ButtonBorder = Color.FromArgb(20, 20, 20);

        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = DarkThemeBackground;
            form.ForeColor = DarkThemeText;
        }

        public static void ApplyButtonStyle(Button button)
        {
            button.BackColor = ButtonBackground;
            button.ForeColor = DarkThemeText;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = ButtonBorder;
        }


    public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.BackColor = ComboBoxBackground;
            comboBox.ForeColor = DarkThemeText;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                e.Graphics.FillRectangle(new SolidBrush(ComboBoxBackground), e.Bounds);

                if (e.Index >= 0)
                {
                    var text = comboBox.GetItemText(comboBox.Items[e.Index]);
                    TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, DarkThemeText);
                }

                e.DrawFocusRectangle();
            };

            comboBox.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, comboBox.Width, comboBox.Height);
                e.Graphics.FillRectangle(new SolidBrush(ComboBoxBackground), rect);
                e.Graphics.DrawRectangle(new Pen(ButtonBorder), rect);
            };
        }

    public static void ApplyTextBoxStyle(TextBox textBox)
        {
            textBox.BackColor = ComboBoxBackground;
            textBox.ForeColor = DarkThemeText;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyNumericUpDownStyle(NumericUpDown numericUpDown)
        {
            numericUpDown.BackColor = ComboBoxBackground;
            numericUpDown.ForeColor = DarkThemeText;
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
        }




    }



}

