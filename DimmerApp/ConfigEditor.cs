using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DimmerApp
{
    public partial class ConfigEditor : Form
    {
        private AppConfig oldConfig;
        private AppConfig currentConfig;
        private List<string> currentScreenNames;
        private Color selectedColor;
        private bool colorValid = false;

        public ConfigEditor()
        {
            currentScreenNames = Screen.AllScreens.Select(s => s.DeviceName).ToList();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AppColors.ApplyFormStyle(this);
            AppColors.ApplyButtonStyle(saveConfigButton);
            AppColors.ApplyButtonStyle(cancelButton);
            AppColors.ApplyButtonStyle(loadConfigBtn);
            AppColors.ApplyComboBoxStyle(defaultScreenCB);
            AppColors.ApplyTextBoxStyle(windowTitlesTB);
            AppColors.ApplyNumericUpDownStyle(opacityNumberUpDown);
            AppColors.ApplyTextBoxStyle(colorTextBox);
            AppColors.ApplyButtonStyle(colorPickerButton);

            LoadConfig(null, null);

            saveConfigButton.Click += SaveConfig;
            cancelButton.Click += Cancel;
            loadConfigBtn.Click += LoadConfig;
        }

        private void PopulateProperties()
        {
            if (oldConfig == null)
            {
                defaultScreenCB.DataSource = currentScreenNames ?? new List<string>();
                defaultScreenCB.SelectedIndex = 0;
                windowTitlesTB.Text = String.Empty;
                partialMatchCheckBox.Checked = true;
                colorTextBox.Text = "000000";
                opacityNumberUpDown.Value = 75;
            }
            else
            {
                defaultScreenCB.DataSource = currentScreenNames ?? new List<string>();
                defaultScreenCB.SelectedItem = oldConfig.DefaultScreen;
                windowTitlesTB.Text = string.Join(",", oldConfig.WindowTitles);
                partialMatchCheckBox.Checked = oldConfig.CommaSeparateWindowTitles;
                colorTextBox.Text = oldConfig.Color.ToString();
                opacityNumberUpDown.Value = (decimal)oldConfig.Opacity * 100;
            }
        }

        private void LoadConfig(object sender, EventArgs e)
        {
            try
            {
                oldConfig = ConfigManager.LoadConfig("config.json");
            }
            catch
            {
                MessageBox.Show("Error loading configuration file. Using default values.");
            }
            PopulateProperties();
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            if (!colorValid)
            {
                MessageBox.Show("Invalid color format. Please enter a valid color.");
                return;
            }
            currentConfig = new AppConfig
            {
                DefaultScreen = defaultScreenCB.SelectedItem.ToString(),
                WindowTitles = windowTitlesTB.Text.Split(',').Select(x => x.Trim()).ToArray(),
                CommaSeparateWindowTitles = partialMatchCheckBox.Checked,
                Color = colorTextBox.Text,
                Opacity = (float)opacityNumberUpDown.Value / 100
            };
            ConfigManager.SaveConfig("config.json", currentConfig);
        }

        private void ColorPickerButton_Click(object sender, EventArgs e)
        {
            if (tintColorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = tintColorDialog.Color;
                colorTextBox.Text = selectedColor.ToArgb().ToString("X");
            }
        }

        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TryParseColor(colorTextBox.Text))
            {
                colorHintLabel.ForeColor = selectedColor;
            }
            else
            {
                colorHintLabel.ForeColor = Color.Black;
            }
        }

        private bool TryParseColor(string color)
        {
            try
            {
                selectedColor = Color.FromName(color);
                if (!selectedColor.IsKnownColor)
                {
                    selectedColor = ColorTranslator.FromHtml("#" + color);
                }
                colorValid = true;
                return true;
            }
            catch
            {
                colorValid = false;
                return false;
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigEditor_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(defaultScreenCB, "Select the screen on which the overlay will NOT be displayed.");
            toolTip1.SetToolTip(windowTitlesTB, "Enter a comma-separated list of window titles to trigger the dim.");
            toolTip1.SetToolTip(partialMatchCheckBox, "Check to match window titles partially.");
            toolTip1.SetToolTip(colorTextBox, "Enter the color of the overlay in hexadecimal or html format.");
            toolTip1.SetToolTip(opacityNumberUpDown, "Set the opacity of the overlay.");
            toolTip1.SetToolTip(saveConfigButton, "Save the current configuration.");
            toolTip1.SetToolTip(cancelButton, "Discard changes and close the editor.");
            toolTip1.SetToolTip(loadConfigBtn, "Load the configuration from the config.json-file.");
        }

        private void ConfigEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.config = ConfigManager.LoadConfig("config.json");
        }
    }
}
