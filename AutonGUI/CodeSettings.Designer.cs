namespace AutonGUI
{
    partial class CodeSettings
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
            CSVariableTextBox = new TextBox();
            CSVariableTextBox2 = new TextBox();
            CSLengthTextBox = new TextBox();
            CSUpdateButton = new Button();
            CSWidthTextBox = new TextBox();
            CSLengthLabel = new Label();
            CSWidthLabel = new Label();
            CSVariableLabel2 = new Label();
            CSVariableLabel = new Label();
            CSCodegenSettingsLabel = new Label();
            CSRobotDimentionsLabel = new Label();
            CSInfoButton = new Button();
            SuspendLayout();
            // 
            // CSVariableTextBox
            // 
            CSVariableTextBox.Location = new Point(341, 48);
            CSVariableTextBox.Name = "CSVariableTextBox";
            CSVariableTextBox.Size = new Size(100, 23);
            CSVariableTextBox.TabIndex = 0;
            CSVariableTextBox.Text = "chassis";
            // 
            // CSVariableTextBox2
            // 
            CSVariableTextBox2.Location = new Point(341, 84);
            CSVariableTextBox2.Name = "CSVariableTextBox2";
            CSVariableTextBox2.Size = new Size(100, 23);
            CSVariableTextBox2.TabIndex = 1;
            CSVariableTextBox2.Text = "intake";
            // 
            // CSLengthTextBox
            // 
            CSLengthTextBox.Location = new Point(145, 177);
            CSLengthTextBox.Name = "CSLengthTextBox";
            CSLengthTextBox.Size = new Size(58, 23);
            CSLengthTextBox.TabIndex = 2;
            // 
            // CSUpdateButton
            // 
            CSUpdateButton.Location = new Point(196, 216);
            CSUpdateButton.Name = "CSUpdateButton";
            CSUpdateButton.Size = new Size(89, 35);
            CSUpdateButton.TabIndex = 4;
            CSUpdateButton.Text = "Update";
            CSUpdateButton.UseVisualStyleBackColor = true;
            CSUpdateButton.Click += CSUpdateButton_Click;
            // 
            // CSWidthTextBox
            // 
            CSWidthTextBox.Location = new Point(278, 177);
            CSWidthTextBox.Name = "CSWidthTextBox";
            CSWidthTextBox.Size = new Size(58, 23);
            CSWidthTextBox.TabIndex = 5;
            // 
            // CSLengthLabel
            // 
            CSLengthLabel.AutoSize = true;
            CSLengthLabel.ForeColor = Color.White;
            CSLengthLabel.Location = new Point(135, 159);
            CSLengthLabel.Name = "CSLengthLabel";
            CSLengthLabel.Size = new Size(68, 15);
            CSLengthLabel.TabIndex = 6;
            CSLengthLabel.Text = "Length (in):";
            // 
            // CSWidthLabel
            // 
            CSWidthLabel.AutoSize = true;
            CSWidthLabel.ForeColor = Color.White;
            CSWidthLabel.Location = new Point(278, 159);
            CSWidthLabel.Name = "CSWidthLabel";
            CSWidthLabel.Size = new Size(63, 15);
            CSWidthLabel.TabIndex = 7;
            CSWidthLabel.Text = "Width (in):";
            // 
            // CSVariableLabel2
            // 
            CSVariableLabel2.AutoSize = true;
            CSVariableLabel2.ForeColor = Color.White;
            CSVariableLabel2.Location = new Point(183, 87);
            CSVariableLabel2.Name = "CSVariableLabel2";
            CSVariableLabel2.Size = new Size(153, 15);
            CSVariableLabel2.TabIndex = 8;
            CSVariableLabel2.Text = "MotorGroup variable name:";
            // 
            // CSVariableLabel
            // 
            CSVariableLabel.AutoSize = true;
            CSVariableLabel.ForeColor = Color.White;
            CSVariableLabel.Location = new Point(23, 51);
            CSVariableLabel.Name = "CSVariableLabel";
            CSVariableLabel.Size = new Size(306, 15);
            CSVariableLabel.TabIndex = 9;
            CSVariableLabel.Text = "std::shared_ptr<OdomChassisController> variable name:";
            // 
            // CSCodegenSettingsLabel
            // 
            CSCodegenSettingsLabel.AutoSize = true;
            CSCodegenSettingsLabel.ForeColor = Color.White;
            CSCodegenSettingsLabel.Location = new Point(190, 19);
            CSCodegenSettingsLabel.Name = "CSCodegenSettingsLabel";
            CSCodegenSettingsLabel.Size = new Size(100, 15);
            CSCodegenSettingsLabel.TabIndex = 10;
            CSCodegenSettingsLabel.Text = "Codegen Settings";
            // 
            // CSRobotDimentionsLabel
            // 
            CSRobotDimentionsLabel.AutoSize = true;
            CSRobotDimentionsLabel.ForeColor = Color.White;
            CSRobotDimentionsLabel.Location = new Point(190, 128);
            CSRobotDimentionsLabel.Name = "CSRobotDimentionsLabel";
            CSRobotDimentionsLabel.Size = new Size(102, 15);
            CSRobotDimentionsLabel.TabIndex = 11;
            CSRobotDimentionsLabel.Text = "Robot dimentions";
            // 
            // CSInfoButton
            // 
            CSInfoButton.Location = new Point(447, 66);
            CSInfoButton.Name = "CSInfoButton";
            CSInfoButton.Size = new Size(25, 23);
            CSInfoButton.TabIndex = 12;
            CSInfoButton.Text = "?";
            CSInfoButton.UseVisualStyleBackColor = true;
            CSInfoButton.Click += CodeSettingsInfoButton_Click;
            // 
            // CodeSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(479, 276);
            Controls.Add(CSInfoButton);
            Controls.Add(CSRobotDimentionsLabel);
            Controls.Add(CSCodegenSettingsLabel);
            Controls.Add(CSVariableLabel);
            Controls.Add(CSVariableLabel2);
            Controls.Add(CSWidthLabel);
            Controls.Add(CSLengthLabel);
            Controls.Add(CSWidthTextBox);
            Controls.Add(CSUpdateButton);
            Controls.Add(CSLengthTextBox);
            Controls.Add(CSVariableTextBox2);
            Controls.Add(CSVariableTextBox);
            Name = "CodeSettings";
            Text = "CodeSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CSVariableTextBox;
        private TextBox CSVariableTextBox2;
        private TextBox CSLengthTextBox;
        private Button CSUpdateButton;
        private TextBox CSWidthTextBox;
        private Label CSLengthLabel;
        private Label CSWidthLabel;
        private Label CSVariableLabel2;
        private Label CSVariableLabel;
        private Label CSCodegenSettingsLabel;
        private Label CSRobotDimentionsLabel;
        private Button CSInfoButton;
    }
}