namespace DimmerApp
{
    partial class ConfigEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.defaultScreenCB = new System.Windows.Forms.ComboBox();
            this.windowTitlesTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.partialMatchCheckBox = new System.Windows.Forms.CheckBox();
            this.tintColorDialog = new System.Windows.Forms.ColorDialog();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opacityNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loadConfigBtn = new System.Windows.Forms.Button();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.colorHintLabel = new System.Windows.Forms.Label();
            this.screenInfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumberUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultScreenCB
            // 
            this.defaultScreenCB.FormattingEnabled = true;
            this.defaultScreenCB.Location = new System.Drawing.Point(26, 35);
            this.defaultScreenCB.Name = "defaultScreenCB";
            this.defaultScreenCB.Size = new System.Drawing.Size(121, 21);
            this.defaultScreenCB.TabIndex = 0;
            // 
            // windowTitlesTB
            // 
            this.windowTitlesTB.Location = new System.Drawing.Point(26, 96);
            this.windowTitlesTB.Name = "windowTitlesTB";
            this.windowTitlesTB.Size = new System.Drawing.Size(434, 20);
            this.windowTitlesTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Primary screen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Window title list (comma separated):";
            // 
            // partialMatchCheckBox
            // 
            this.partialMatchCheckBox.AutoSize = true;
            this.partialMatchCheckBox.Checked = true;
            this.partialMatchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.partialMatchCheckBox.Location = new System.Drawing.Point(26, 122);
            this.partialMatchCheckBox.Name = "partialMatchCheckBox";
            this.partialMatchCheckBox.Size = new System.Drawing.Size(108, 17);
            this.partialMatchCheckBox.TabIndex = 4;
            this.partialMatchCheckBox.Text = "Use partial match";
            this.partialMatchCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(26, 175);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.Size = new System.Drawing.Size(100, 20);
            this.colorTextBox.TabIndex = 5;
            this.colorTextBox.TextChanged += new System.EventHandler(this.ColorTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tint color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tint opacity [%]";
            // 
            // opacityNumberUpDown
            // 
            this.opacityNumberUpDown.Location = new System.Drawing.Point(26, 231);
            this.opacityNumberUpDown.Name = "opacityNumberUpDown";
            this.opacityNumberUpDown.Size = new System.Drawing.Size(100, 20);
            this.opacityNumberUpDown.TabIndex = 9;
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(334, 293);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(75, 23);
            this.saveConfigButton.TabIndex = 10;
            this.saveConfigButton.Text = "Save config";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(415, 293);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // loadConfigBtn
            // 
            this.loadConfigBtn.Location = new System.Drawing.Point(253, 293);
            this.loadConfigBtn.Name = "loadConfigBtn";
            this.loadConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.loadConfigBtn.TabIndex = 12;
            this.loadConfigBtn.Text = "Load config";
            this.loadConfigBtn.UseVisualStyleBackColor = true;
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.Location = new System.Drawing.Point(143, 176);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(75, 23);
            this.colorPickerButton.TabIndex = 13;
            this.colorPickerButton.Text = "Color picker";
            this.colorPickerButton.UseVisualStyleBackColor = true;
            this.colorPickerButton.Click += new System.EventHandler(this.ColorPickerButton_Click);
            // 
            // colorHintLabel
            // 
            this.colorHintLabel.AutoSize = true;
            this.colorHintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorHintLabel.Location = new System.Drawing.Point(122, 176);
            this.colorHintLabel.Name = "colorHintLabel";
            this.colorHintLabel.Size = new System.Drawing.Size(25, 20);
            this.colorHintLabel.TabIndex = 14;
            this.colorHintLabel.Text = "⬛";
            // 
            // ConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 328);
            this.Controls.Add(this.colorHintLabel);
            this.Controls.Add(this.colorPickerButton);
            this.Controls.Add(this.loadConfigBtn);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.opacityNumberUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorTextBox);
            this.Controls.Add(this.partialMatchCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.windowTitlesTB);
            this.Controls.Add(this.defaultScreenCB);
            this.Name = "ConfigEditor";
            this.Text = "ConfigEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigEditor_FormClosed);
            this.Load += new System.EventHandler(this.ConfigEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opacityNumberUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox defaultScreenCB;
        private System.Windows.Forms.TextBox windowTitlesTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox partialMatchCheckBox;
        private System.Windows.Forms.ColorDialog tintColorDialog;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown opacityNumberUpDown;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loadConfigBtn;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Label colorHintLabel;
        private System.Windows.Forms.ToolTip screenInfoToolTip;
    }
}