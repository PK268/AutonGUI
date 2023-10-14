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
            ReverseButton = new RadioButton();
            Nodes = new ListBox();
            Xcord = new NumericUpDown();
            Ycord = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Xcord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ycord).BeginInit();
            SuspendLayout();
            // 
            // OverUnderBG
            // 
            OverUnderBG.Image = (Image)resources.GetObject("OverUnderBG.Image");
            OverUnderBG.Location = new Point(0, 0);
            OverUnderBG.Margin = new Padding(3, 2, 3, 2);
            OverUnderBG.Name = "OverUnderBG";
            OverUnderBG.Size = new Size(559, 559);
            OverUnderBG.SizeMode = PictureBoxSizeMode.Zoom;
            OverUnderBG.TabIndex = 0;
            OverUnderBG.TabStop = false;
            OverUnderBG.Click += OverUnderBG_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(583, 21);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // SaveLocation
            // 
            SaveLocation.Location = new Point(583, 47);
            SaveLocation.Margin = new Padding(3, 2, 3, 2);
            SaveLocation.Name = "SaveLocation";
            SaveLocation.Size = new Size(110, 23);
            SaveLocation.TabIndex = 2;
            // 
            // SourceFileTextBox
            // 
            SourceFileTextBox.Location = new Point(583, 79);
            SourceFileTextBox.Margin = new Padding(3, 2, 3, 2);
            SourceFileTextBox.Name = "SourceFileTextBox";
            SourceFileTextBox.Size = new Size(110, 23);
            SourceFileTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(697, 52);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 4;
            label1.Text = "dest file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(697, 84);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "source file";
            // 
            // IntakeVelocityTextBox
            // 
            IntakeVelocityTextBox.Location = new Point(583, 190);
            IntakeVelocityTextBox.Margin = new Padding(3, 2, 3, 2);
            IntakeVelocityTextBox.Name = "IntakeVelocityTextBox";
            IntakeVelocityTextBox.Size = new Size(110, 23);
            IntakeVelocityTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(697, 190);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 7;
            label3.Text = "Intake Veloctiy (0 = off)";
            // 
            // UpdateNodeButton
            // 
            UpdateNodeButton.Location = new Point(583, 156);
            UpdateNodeButton.Margin = new Padding(3, 2, 3, 2);
            UpdateNodeButton.Name = "UpdateNodeButton";
            UpdateNodeButton.Size = new Size(109, 22);
            UpdateNodeButton.TabIndex = 8;
            UpdateNodeButton.Text = "Update Node";
            UpdateNodeButton.UseVisualStyleBackColor = true;
            UpdateNodeButton.Click += UpdateNodeButton_Click;
            // 
            // CenterIntakeButton
            // 
            CenterIntakeButton.AutoSize = true;
            CenterIntakeButton.Location = new Point(583, 245);
            CenterIntakeButton.Margin = new Padding(3, 2, 3, 2);
            CenterIntakeButton.Name = "CenterIntakeButton";
            CenterIntakeButton.Size = new Size(136, 19);
            CenterIntakeButton.TabIndex = 9;
            CenterIntakeButton.TabStop = true;
            CenterIntakeButton.Text = "Center around intake";
            CenterIntakeButton.UseVisualStyleBackColor = true;
            // 
            // ReverseButton
            // 
            ReverseButton.AutoSize = true;
            ReverseButton.Location = new Point(583, 222);
            ReverseButton.Margin = new Padding(3, 2, 3, 2);
            ReverseButton.Name = "ReverseButton";
            ReverseButton.Size = new Size(105, 19);
            ReverseButton.TabIndex = 10;
            ReverseButton.TabStop = true;
            ReverseButton.Text = "Drive in reverse";
            ReverseButton.UseVisualStyleBackColor = true;
            // 
            // Nodes
            // 
            Nodes.FormattingEnabled = true;
            Nodes.ItemHeight = 15;
            Nodes.Location = new Point(578, 315);
            Nodes.Name = "Nodes";
            Nodes.Size = new Size(266, 229);
            Nodes.TabIndex = 13;
            Nodes.SelectedIndexChanged += Nodes_SelectedIndexChanged_1;
            // 
            // Xcord
            // 
            Xcord.Location = new Point(609, 276);
            Xcord.Name = "Xcord";
            Xcord.Size = new Size(56, 23);
            Xcord.TabIndex = 14;
            // 
            // Ycord
            // 
            Ycord.Location = new Point(697, 276);
            Ycord.Name = "Ycord";
            Ycord.Size = new Size(61, 23);
            Ycord.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(589, 278);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 16;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(679, 278);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 17;
            label5.Text = "Y";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 560);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Ycord);
            Controls.Add(Xcord);
            Controls.Add(Nodes);
            Controls.Add(ReverseButton);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).EndInit();
            ((System.ComponentModel.ISupportInitialize)Xcord).EndInit();
            ((System.ComponentModel.ISupportInitialize)Ycord).EndInit();
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
        private RadioButton ReverseButton;
        private ListBox Nodes;
        private NumericUpDown Xcord;
        private NumericUpDown Ycord;
        private Label label4;
        private Label label5;
    }
}