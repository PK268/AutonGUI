namespace AutonGUI
{
    partial class AutonGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutonGUI));
            OverUnderBG = new PictureBox();
            SaveButton = new Button();
            SaveLocation = new TextBox();
            SourceFileTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            IntakeVelocityTextBox = new TextBox();
            label3 = new Label();
            UpdateNodeButton = new Button();
            Nodes = new ListBox();
            Xcord = new NumericUpDown();
            Ycord = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            DegRotateTextBox = new TextBox();
            ReverseButton = new CheckBox();
            CenterIntakeButton = new CheckBox();
            DestinationFileDialog1 = new OpenFileDialog();
            SourceFileDialog2 = new OpenFileDialog();
            DestFileButton = new Button();
            SourceFileButton = new Button();
            SaveJsonButton = new Button();
            LoadJsonButton = new Button();
            label7 = new Label();
            DelayTextBox = new TextBox();
            DeleteButton = new Button();
            label8 = new Label();
            SpawnY = new Label();
            SpawnX = new Label();
            SpawnYUpDown = new NumericUpDown();
            SpawnXUpDown = new NumericUpDown();
            SpawnAngleUpDown = new NumericUpDown();
            SpawnAngle = new Label();
            AngleReferencePictureBox = new PictureBox();
            SpawnUpdateButton = new Button();
            OpenCodeSettingsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Xcord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ycord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpawnYUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpawnXUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpawnAngleUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AngleReferencePictureBox).BeginInit();
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
            SaveButton.BackColor = Color.DimGray;
            SaveButton.FlatAppearance.BorderColor = Color.Black;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(583, 21);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
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
            label1.ForeColor = Color.White;
            label1.Location = new Point(697, 52);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "Destination";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(697, 84);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 5;
            label2.Text = "Source";
            // 
            // IntakeVelocityTextBox
            // 
            IntakeVelocityTextBox.Location = new Point(578, 181);
            IntakeVelocityTextBox.Margin = new Padding(3, 2, 3, 2);
            IntakeVelocityTextBox.Name = "IntakeVelocityTextBox";
            IntakeVelocityTextBox.Size = new Size(110, 23);
            IntakeVelocityTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(692, 181);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 7;
            label3.Text = "Intake Veloctiy (0 = off)";
            // 
            // UpdateNodeButton
            // 
            UpdateNodeButton.BackColor = Color.Green;
            UpdateNodeButton.FlatAppearance.BorderColor = Color.Black;
            UpdateNodeButton.FlatAppearance.BorderSize = 0;
            UpdateNodeButton.ForeColor = Color.White;
            UpdateNodeButton.Location = new Point(578, 126);
            UpdateNodeButton.Margin = new Padding(3, 2, 3, 2);
            UpdateNodeButton.Name = "UpdateNodeButton";
            UpdateNodeButton.Size = new Size(109, 22);
            UpdateNodeButton.TabIndex = 8;
            UpdateNodeButton.Text = "Update Node";
            UpdateNodeButton.UseVisualStyleBackColor = false;
            UpdateNodeButton.Click += UpdateNodeButton_Click;
            // 
            // Nodes
            // 
            Nodes.BackColor = Color.White;
            Nodes.ForeColor = Color.Black;
            Nodes.FormattingEnabled = true;
            Nodes.ItemHeight = 15;
            Nodes.Location = new Point(587, 326);
            Nodes.Name = "Nodes";
            Nodes.Size = new Size(129, 184);
            Nodes.TabIndex = 13;
            Nodes.SelectedIndexChanged += Nodes_SelectedIndexChanged_1;
            // 
            // Xcord
            // 
            Xcord.Location = new Point(583, 297);
            Xcord.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            Xcord.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            Xcord.Name = "Xcord";
            Xcord.Size = new Size(56, 23);
            Xcord.TabIndex = 14;
            // 
            // Ycord
            // 
            Ycord.Location = new Point(663, 297);
            Ycord.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            Ycord.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            Ycord.Name = "Ycord";
            Ycord.Size = new Size(61, 23);
            Ycord.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(563, 299);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 16;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(645, 299);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 17;
            label5.Text = "Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(692, 152);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(79, 15);
            label6.TabIndex = 19;
            label6.Text = "Deg to Rotate";
            // 
            // DegRotateTextBox
            // 
            DegRotateTextBox.Enabled = false;
            DegRotateTextBox.Location = new Point(578, 152);
            DegRotateTextBox.Margin = new Padding(3, 2, 3, 2);
            DegRotateTextBox.Name = "DegRotateTextBox";
            DegRotateTextBox.Size = new Size(110, 23);
            DegRotateTextBox.TabIndex = 18;
            // 
            // ReverseButton
            // 
            ReverseButton.AutoSize = true;
            ReverseButton.ForeColor = Color.White;
            ReverseButton.Location = new Point(587, 247);
            ReverseButton.Name = "ReverseButton";
            ReverseButton.Size = new Size(106, 19);
            ReverseButton.TabIndex = 20;
            ReverseButton.Text = "Drive in reverse";
            ReverseButton.UseVisualStyleBackColor = true;
            // 
            // CenterIntakeButton
            // 
            CenterIntakeButton.AutoSize = true;
            CenterIntakeButton.Enabled = false;
            CenterIntakeButton.ForeColor = Color.White;
            CenterIntakeButton.Location = new Point(587, 272);
            CenterIntakeButton.Name = "CenterIntakeButton";
            CenterIntakeButton.Size = new Size(137, 19);
            CenterIntakeButton.TabIndex = 21;
            CenterIntakeButton.Text = "Center around intake";
            CenterIntakeButton.UseVisualStyleBackColor = true;
            // 
            // DestinationFileDialog1
            // 
            DestinationFileDialog1.FileName = "DestinationFileDialog1";
            // 
            // SourceFileDialog2
            // 
            SourceFileDialog2.FileName = "SourceFileDialog2";
            // 
            // DestFileButton
            // 
            DestFileButton.BackColor = Color.DimGray;
            DestFileButton.FlatAppearance.BorderColor = Color.Black;
            DestFileButton.FlatAppearance.BorderSize = 0;
            DestFileButton.ForeColor = Color.White;
            DestFileButton.Location = new Point(764, 47);
            DestFileButton.Name = "DestFileButton";
            DestFileButton.Size = new Size(75, 23);
            DestFileButton.TabIndex = 22;
            DestFileButton.Text = "Open";
            DestFileButton.UseVisualStyleBackColor = false;
            DestFileButton.Click += DestFileButton_Click;
            // 
            // SourceFileButton
            // 
            SourceFileButton.BackColor = Color.DimGray;
            SourceFileButton.FlatAppearance.BorderColor = Color.Black;
            SourceFileButton.FlatAppearance.BorderSize = 0;
            SourceFileButton.ForeColor = Color.White;
            SourceFileButton.Location = new Point(764, 79);
            SourceFileButton.Name = "SourceFileButton";
            SourceFileButton.Size = new Size(75, 23);
            SourceFileButton.TabIndex = 23;
            SourceFileButton.Text = "Open";
            SourceFileButton.UseVisualStyleBackColor = false;
            SourceFileButton.Click += SourceFileButton_Click;
            // 
            // SaveJsonButton
            // 
            SaveJsonButton.BackColor = Color.DimGray;
            SaveJsonButton.FlatAppearance.BorderColor = Color.Black;
            SaveJsonButton.FlatAppearance.BorderSize = 0;
            SaveJsonButton.ForeColor = Color.White;
            SaveJsonButton.Location = new Point(683, 20);
            SaveJsonButton.Margin = new Padding(3, 2, 3, 2);
            SaveJsonButton.Name = "SaveJsonButton";
            SaveJsonButton.Size = new Size(82, 22);
            SaveJsonButton.TabIndex = 24;
            SaveJsonButton.Text = "Save Json";
            SaveJsonButton.UseVisualStyleBackColor = false;
            SaveJsonButton.Click += SaveJsonButton_Click;
            // 
            // LoadJsonButton
            // 
            LoadJsonButton.BackColor = Color.DimGray;
            LoadJsonButton.FlatAppearance.BorderColor = Color.Black;
            LoadJsonButton.FlatAppearance.BorderSize = 0;
            LoadJsonButton.ForeColor = Color.White;
            LoadJsonButton.Location = new Point(764, 20);
            LoadJsonButton.Margin = new Padding(3, 2, 3, 2);
            LoadJsonButton.Name = "LoadJsonButton";
            LoadJsonButton.Size = new Size(82, 22);
            LoadJsonButton.TabIndex = 25;
            LoadJsonButton.Text = "Load Json";
            LoadJsonButton.UseVisualStyleBackColor = false;
            LoadJsonButton.Click += LoadJsonButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(692, 212);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(65, 15);
            label7.TabIndex = 27;
            label7.Text = "Delay After";
            // 
            // DelayTextBox
            // 
            DelayTextBox.Location = new Point(578, 212);
            DelayTextBox.Margin = new Padding(3, 2, 3, 2);
            DelayTextBox.Name = "DelayTextBox";
            DelayTextBox.Size = new Size(110, 23);
            DelayTextBox.TabIndex = 26;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Firebrick;
            DeleteButton.FlatAppearance.BorderColor = Color.Black;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Location = new Point(612, 521);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 28;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(764, 305);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(73, 15);
            label8.TabIndex = 29;
            label8.Text = "Spawn Point";
            // 
            // SpawnY
            // 
            SpawnY.AutoSize = true;
            SpawnY.ForeColor = Color.White;
            SpawnY.Location = new Point(752, 360);
            SpawnY.Name = "SpawnY";
            SpawnY.Size = new Size(14, 15);
            SpawnY.TabIndex = 33;
            SpawnY.Text = "Y";
            // 
            // SpawnX
            // 
            SpawnX.AutoSize = true;
            SpawnX.ForeColor = Color.White;
            SpawnX.Location = new Point(752, 331);
            SpawnX.Name = "SpawnX";
            SpawnX.Size = new Size(14, 15);
            SpawnX.TabIndex = 32;
            SpawnX.Text = "X";
            // 
            // SpawnYUpDown
            // 
            SpawnYUpDown.Location = new Point(772, 358);
            SpawnYUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            SpawnYUpDown.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            SpawnYUpDown.Name = "SpawnYUpDown";
            SpawnYUpDown.Size = new Size(61, 23);
            SpawnYUpDown.TabIndex = 31;
            SpawnYUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // SpawnXUpDown
            // 
            SpawnXUpDown.Location = new Point(772, 329);
            SpawnXUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            SpawnXUpDown.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            SpawnXUpDown.Name = "SpawnXUpDown";
            SpawnXUpDown.Size = new Size(61, 23);
            SpawnXUpDown.TabIndex = 30;
            SpawnXUpDown.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // SpawnAngleUpDown
            // 
            SpawnAngleUpDown.Location = new Point(772, 387);
            SpawnAngleUpDown.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            SpawnAngleUpDown.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            SpawnAngleUpDown.Name = "SpawnAngleUpDown";
            SpawnAngleUpDown.Size = new Size(61, 23);
            SpawnAngleUpDown.TabIndex = 34;
            // 
            // SpawnAngle
            // 
            SpawnAngle.AutoSize = true;
            SpawnAngle.ForeColor = Color.White;
            SpawnAngle.Location = new Point(730, 389);
            SpawnAngle.Name = "SpawnAngle";
            SpawnAngle.RightToLeft = RightToLeft.No;
            SpawnAngle.Size = new Size(38, 15);
            SpawnAngle.TabIndex = 35;
            SpawnAngle.Text = "Angle";
            // 
            // AngleReferencePictureBox
            // 
            AngleReferencePictureBox.BackColor = Color.DimGray;
            AngleReferencePictureBox.Image = Properties.Resources.HeadingGraph;
            AngleReferencePictureBox.Location = new Point(722, 422);
            AngleReferencePictureBox.Name = "AngleReferencePictureBox";
            AngleReferencePictureBox.Size = new Size(134, 137);
            AngleReferencePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            AngleReferencePictureBox.TabIndex = 36;
            AngleReferencePictureBox.TabStop = false;
            // 
            // SpawnUpdateButton
            // 
            SpawnUpdateButton.BackColor = Color.DarkSlateGray;
            SpawnUpdateButton.FlatAppearance.BorderColor = Color.Black;
            SpawnUpdateButton.FlatAppearance.BorderSize = 0;
            SpawnUpdateButton.ForeColor = Color.White;
            SpawnUpdateButton.Location = new Point(737, 272);
            SpawnUpdateButton.Margin = new Padding(3, 2, 3, 2);
            SpawnUpdateButton.Name = "SpawnUpdateButton";
            SpawnUpdateButton.Size = new Size(109, 22);
            SpawnUpdateButton.TabIndex = 38;
            SpawnUpdateButton.Text = "Update Spawn";
            SpawnUpdateButton.UseVisualStyleBackColor = false;
            SpawnUpdateButton.Click += SpawnUpdateButton_Click;
            // 
            // OpenCodeSettingsButton
            // 
            OpenCodeSettingsButton.BackColor = Color.DimGray;
            OpenCodeSettingsButton.ForeColor = Color.White;
            OpenCodeSettingsButton.Location = new Point(697, 108);
            OpenCodeSettingsButton.Name = "OpenCodeSettingsButton";
            OpenCodeSettingsButton.Size = new Size(142, 40);
            OpenCodeSettingsButton.TabIndex = 39;
            OpenCodeSettingsButton.Text = "Open CodeGen Settings";
            OpenCodeSettingsButton.UseVisualStyleBackColor = false;
            OpenCodeSettingsButton.Click += OpenCodeSettingsButton_Click;
            // 
            // AutonGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(856, 560);
            Controls.Add(OpenCodeSettingsButton);
            Controls.Add(SpawnUpdateButton);
            Controls.Add(AngleReferencePictureBox);
            Controls.Add(SpawnAngle);
            Controls.Add(SpawnAngleUpDown);
            Controls.Add(SpawnY);
            Controls.Add(SpawnX);
            Controls.Add(SpawnYUpDown);
            Controls.Add(SpawnXUpDown);
            Controls.Add(label8);
            Controls.Add(DeleteButton);
            Controls.Add(label7);
            Controls.Add(DelayTextBox);
            Controls.Add(LoadJsonButton);
            Controls.Add(SaveJsonButton);
            Controls.Add(SourceFileButton);
            Controls.Add(DestFileButton);
            Controls.Add(CenterIntakeButton);
            Controls.Add(ReverseButton);
            Controls.Add(label6);
            Controls.Add(DegRotateTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Ycord);
            Controls.Add(Xcord);
            Controls.Add(Nodes);
            Controls.Add(UpdateNodeButton);
            Controls.Add(label3);
            Controls.Add(IntakeVelocityTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SourceFileTextBox);
            Controls.Add(SaveLocation);
            Controls.Add(SaveButton);
            Controls.Add(OverUnderBG);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "AutonGUI";
            Text = "34690A Auton GUI v0.4";
            ((System.ComponentModel.ISupportInitialize)OverUnderBG).EndInit();
            ((System.ComponentModel.ISupportInitialize)Xcord).EndInit();
            ((System.ComponentModel.ISupportInitialize)Ycord).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpawnYUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpawnXUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpawnAngleUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AngleReferencePictureBox).EndInit();
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
        private ListBox Nodes;
        private NumericUpDown Xcord;
        private NumericUpDown Ycord;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox DegRotateTextBox;
        private CheckBox ReverseButton;
        private CheckBox CenterIntakeButton;
        private OpenFileDialog DestinationFileDialog1;
        private OpenFileDialog SourceFileDialog2;
        private Button DestFileButton;
        private Button SourceFileButton;
        private Button SaveJsonButton;
        private Button LoadJsonButton;
        private Label label7;
        private TextBox DelayTextBox;
        private Button DeleteButton;
        private Label label8;
        private Label SpawnY;
        private Label SpawnX;
        private NumericUpDown SpawnYUpDown;
        private NumericUpDown SpawnXUpDown;
        private NumericUpDown SpawnAngleUpDown;
        private Label SpawnAngle;
        private PictureBox AngleReferencePictureBox;
        private Button SpawnUpdateButton;
        private Button OpenCodeSettingsButton;
    }
}