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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            UpdateButtonCS = new Button();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            CodeSettingsInfoButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(341, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "chassis";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(341, 84);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            textBox2.Text = "intake";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(175, 171);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(58, 23);
            textBox3.TabIndex = 2;
            // 
            // UpdateButtonCS
            // 
            UpdateButtonCS.Location = new Point(196, 216);
            UpdateButtonCS.Name = "UpdateButtonCS";
            UpdateButtonCS.Size = new Size(89, 35);
            UpdateButtonCS.TabIndex = 4;
            UpdateButtonCS.Text = "Update";
            UpdateButtonCS.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(292, 171);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(58, 23);
            textBox4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(122, 174);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 6;
            label1.Text = "Length:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(247, 174);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Width:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(183, 87);
            label3.Name = "label3";
            label3.Size = new Size(153, 15);
            label3.TabIndex = 8;
            label3.Text = "MotorGroup variable name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(23, 51);
            label4.Name = "label4";
            label4.Size = new Size(306, 15);
            label4.TabIndex = 9;
            label4.Text = "std::shared_ptr<OdomChassisController> variable name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(190, 19);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 10;
            label5.Text = "Codegen settigns";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(187, 132);
            label6.Name = "label6";
            label6.Size = new Size(102, 15);
            label6.TabIndex = 11;
            label6.Text = "Robot dimentions";
            // 
            // CodeSettingsInfoButton
            // 
            CodeSettingsInfoButton.Location = new Point(447, 66);
            CodeSettingsInfoButton.Name = "CodeSettingsInfoButton";
            CodeSettingsInfoButton.Size = new Size(25, 23);
            CodeSettingsInfoButton.TabIndex = 12;
            CodeSettingsInfoButton.Text = "?";
            CodeSettingsInfoButton.UseVisualStyleBackColor = true;
            CodeSettingsInfoButton.Click += CodeSettingsInfoButton_Click;
            // 
            // CodeSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(479, 276);
            Controls.Add(CodeSettingsInfoButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(UpdateButtonCS);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "CodeSettings";
            Text = "CodeSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button UpdateButtonCS;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button CodeSettingsInfoButton;
    }
}