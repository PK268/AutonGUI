namespace AutonGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            OverUnderBG = new PictureBox();
            SaveButton = new Button();
            SaveLocation = new TextBox();
            SourceFileTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            IntakeVelocityTextBox = new TextBox();
            label3 = new Label();
            UpdateNodeButton = new Button();
            CenterIntakeButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).BeginInit();
            SuspendLayout();
            // 
            // OverUnderBG
            // 
            OverUnderBG.Image = (Image)resources.GetObject("OverUnderBG.Image");
            OverUnderBG.Location = new Point(0, 0);
            OverUnderBG.Name = "OverUnderBG";
            OverUnderBG.Size = new Size(639, 634);
            OverUnderBG.SizeMode = PictureBoxSizeMode.Zoom;
            OverUnderBG.TabIndex = 0;
            OverUnderBG.TabStop = false;
            OverUnderBG.Click += OverUnderBG_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(666, 28);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // SaveLocation
            // 
            SaveLocation.Location = new Point(666, 63);
            SaveLocation.Name = "SaveLocation";
            SaveLocation.Size = new Size(125, 27);
            SaveLocation.TabIndex = 2;
            // 
            // SourceFileTextBox
            // 
            SourceFileTextBox.Location = new Point(666, 105);
            SourceFileTextBox.Name = "SourceFileTextBox";
            SourceFileTextBox.Size = new Size(125, 27);
            SourceFileTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(797, 70);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 4;
            label1.Text = "dest file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(797, 112);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 5;
            label2.Text = "source file";
            // 
            // IntakeVelocityTextBox
            // 
            IntakeVelocityTextBox.Location = new Point(666, 253);
            IntakeVelocityTextBox.Name = "IntakeVelocityTextBox";
            IntakeVelocityTextBox.Size = new Size(125, 27);
            IntakeVelocityTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(797, 253);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 7;
            label3.Text = "Intake Veloctiy (0 = off)";
            // 
            // UpdateNodeButton
            // 
            UpdateNodeButton.Location = new Point(666, 208);
            UpdateNodeButton.Name = "UpdateNodeButton";
            UpdateNodeButton.Size = new Size(125, 29);
            UpdateNodeButton.TabIndex = 8;
            UpdateNodeButton.Text = "Update Node";
            UpdateNodeButton.UseVisualStyleBackColor = true;
            UpdateNodeButton.Click += UpdateNodeButton_Click;
            // 
            // CenterIntakeButton
            // 
            CenterIntakeButton.AutoSize = true;
            CenterIntakeButton.Location = new Point(666, 327);
            CenterIntakeButton.Name = "CenterIntakeButton";
            CenterIntakeButton.Size = new Size(168, 24);
            CenterIntakeButton.TabIndex = 9;
            CenterIntakeButton.TabStop = true;
            CenterIntakeButton.Text = "Center around intake";
            CenterIntakeButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 638);
            Controls.Add(CenterIntakeButton);
            Controls.Add(UpdateNodeButton);
            Controls.Add(label3);
            Controls.Add(IntakeVelocityTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SourceFileTextBox);
            Controls.Add(SaveLocation);
            Controls.Add(SaveButton);
            Controls.Add(OverUnderBG);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox OverUnderBG;
        private Button SaveButton;
        private TextBox SaveLocation;
        private TextBox SourceFileTextBox;
        private Label label1;
        private Label label2;
        private TextBox IntakeVelocityTextBox;
        private Label label3;
        private Button UpdateNodeButton;
        private RadioButton CenterIntakeButton;
    }
}