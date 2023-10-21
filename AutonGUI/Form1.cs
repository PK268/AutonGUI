using Newtonsoft.Json;

using System;
using System.CodeDom;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AutonGUI
{
    public partial class Form1 : Form
    {
        const double resizeX = 2.14669051878;
        const double resizeY = 2.14669051878;
        static int steps;
        static int lastSelectedStep;
        public struct Node
        {
            public int index;
            public Point coordinate;
            public bool offset;
            public int intakeVelocity;
            public bool reverse;
            public int deg;
            public int delay;
            public Node()
            {
                reverse = true;
                intakeVelocity = 0;
                deg = 0;
                delay = 0;
            }
            public Node(int index, Point coordinate, bool offset, int intakeVelocity)
            {
                reverse = true;
                this.offset = offset;
                this.index = index;
                this.coordinate = coordinate;
                this.intakeVelocity = intakeVelocity;
            }
        }
        static LinkedList<Node> moveOrder = new LinkedList<Node>();
        static Point zero = new Point(300, 100);
        public Form1()
        {
            InitializeComponent();
            steps = 0;
            lastSelectedStep = 0;
        }

        private void OverUnderBG_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {

                case MouseButtons.Left:
                    // Left click
                    break;

                case MouseButtons.Right:

                    Point globalMousePos = Control.MousePosition;
                    Point newNodePos = PointToClient(globalMousePos);
                    newNodePos.Offset(0, -559); //-559 to make 0,0 the bottom left instead of the top left.
                    newNodePos.X = newNodePos.X;
                    newNodePos.Y = Math.Abs(newNodePos.Y); //Making sure the offset operation didnt make negatives
                    moveOrder.AddLast(new Node(steps, new Point((int)((newNodePos.X) * resizeX) - zero.X, (int)((newNodePos.Y) * resizeY)-zero.Y), false, 0));

                    var button = new Button();
                    Controls.Add(button);
                    button.Location = PointToClient(new Point(globalMousePos.X - 15, globalMousePos.Y - 15));
                    button.BringToFront();
                    button.Size = new Size(30, 30);
                    button.Text = "" + steps;
                    button.Name = "" + steps;
                    button.Click += (sender, e) => { ShowStepInfo(Convert.ToInt32(sender.GetType().GetProperty("Name").GetValue(sender, null))); };

                    Nodes.Items.Add($"{"" + steps} {new Point((int)(newNodePos.X * resizeX) - zero.X, (int)(newNodePos.Y * resizeY) - zero.Y)}");

                    steps++;
                    // Right click
                    break;
            }
        }
        private void SimulateRightClick(Node n)
        {
            Point newNodePos = new Point((int)(((n.coordinate.X) + zero.X) / resizeX) - 15 , Math.Abs(559 - (int)((n.coordinate.Y + zero.Y) / resizeY)) - 15);

            var button = new Button();
            Controls.Add(button);
            button.Location = newNodePos;
            button.BringToFront();
            button.Size = new Size(30, 30);
            button.Text = "" + steps;
            button.Name = "" + steps;
            button.Click += (sender, e) => { ShowStepInfo(Convert.ToInt32(sender.GetType().GetProperty("Name").GetValue(sender, null))); };

            Nodes.Items.Add($"{"" + steps} {new Point(n.coordinate.X, n.coordinate.Y)}");

            steps++;
        }
        public void ShowStepInfo(int index)
        {
            for (int i = 0; i < steps; i++)
            {
                this.Controls.Find("" + i, true).First().BackColor = Color.White;
            }
            Control indexButton = this.Controls.Find("" + index, true).First();
            indexButton.BackColor = Color.Red;
            lastSelectedStep = index;
            LinkedListNode<Node> traversal = moveOrder.First;
            for (int i = 0; i < index; i++)
            {
                traversal = traversal.Next;
            }
            IntakeVelocityTextBox.Text = "" + traversal.Value.intakeVelocity;
            CenterIntakeButton.Checked = traversal.Value.offset;
            ReverseButton.Checked = traversal.Value.reverse;
            Xcord.Value = (int)(traversal.Value.coordinate.X);
            Ycord.Value = (int)(traversal.Value.coordinate.Y);
            DegRotateTextBox.Text = "" + traversal.Value.deg;
            DelayTextBox.Text = "" + traversal.Value.delay;
        }

        //AKA the compiler
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var file = System.IO.File.Create(SaveLocation.Text);
            file.Close();
            string source = File.ReadAllText(SourceFileTextBox.Text);
            string[] split = source.Split("[GUIMARKER]");
            string commands = "";
            foreach (Node n in moveOrder)
            {                  //turning it into feet * 12in         getting inches leftover from feet
                int xInches = ((n.coordinate.X / 100) * 12) + (int)(12 * ((float)(n.coordinate.X % 100) / 100));
                int yInches = ((n.coordinate.Y / 100) * 12) + (int)(12 * ((float)(n.coordinate.Y % 100) / 100));
                if (!n.offset)
                    commands += $"\t\tchassis->driveToPoint({{{xInches}_in, {yInches}_in}}, {n.reverse});\n";
                else
                    commands += $"\t\tchassis->driveToPoint({{{xInches}_in, {yInches}_in}}, {n.reverse}, 7_in);\n";
                if (n.deg != 0)
                    commands += $"\t\tchassis->turnToAngle({n.deg}_deg);\n";
                if (n.intakeVelocity != 0)
                    commands += $"\t\tintake.moveVelocity({n.intakeVelocity});\n";
                if (n.delay != 0)
                    commands += $"\t\tpros::delay({n.delay});\n";

            }
            File.WriteAllText(SaveLocation.Text, split[0] + commands + split[1]);
        }

        private void UpdateNodeButton_Click(object sender, EventArgs e)
        {
            LinkedListNode<Node> traversal = moveOrder.First;
            for (int i = 0; i < lastSelectedStep; i++)
            {
                traversal = traversal.Next;
            }
            try { traversal.ValueRef.intakeVelocity = int.Parse(IntakeVelocityTextBox.Text); }
            catch { traversal.ValueRef.intakeVelocity = 0; ShowStepInfo(lastSelectedStep); }

            traversal.ValueRef.offset = CenterIntakeButton.Checked;
            traversal.ValueRef.reverse = ReverseButton.Checked;
            traversal.ValueRef.coordinate = new Point((int)Xcord.Value, (int)Ycord.Value);
            Controls.Find("" + lastSelectedStep, true).First().Location = new Point((int)(((double)Xcord.Value + zero.X) / resizeX) - 15, Math.Abs((int)(((double)Ycord.Value + zero.Y) / resizeY) - 559 + 15));
            try { traversal.ValueRef.deg = int.Parse(DegRotateTextBox.Text); }
            catch { traversal.ValueRef.deg = 0; ShowStepInfo(lastSelectedStep); }
            try{ traversal.ValueRef.delay = int.Parse(DelayTextBox.Text); }
            catch { traversal.ValueRef.delay = 0; ShowStepInfo(lastSelectedStep); }

            Nodes.Items[lastSelectedStep] = lastSelectedStep + " " + new Point(traversal.ValueRef.coordinate.X, traversal.ValueRef.coordinate.Y);
            }

        private void Nodes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int index = int.Parse(Nodes.SelectedItems[0].ToString().Split(' ').First());
            lastSelectedStep = index;
            ShowStepInfo(index);
        }

        private void DestFileButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            SaveLocation.Text = DestinationFileDialog1.FileName;
        }

        private void SourceFileButton_Click(object sender, EventArgs e)
        {
            SourceFileDialog2.ShowDialog(this);
            SourceFileTextBox.Text = SourceFileDialog2.FileName;
        }

        private void SaveJsonButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            string endJson = DestinationFileDialog1.FileName;
            File.WriteAllText(endJson, JsonConvert.SerializeObject(moveOrder));
        }

        private void LoadJsonButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            string endJson = DestinationFileDialog1.FileName;
            LinkedList<Node> read = JsonConvert.DeserializeObject<LinkedList<Node>>(File.ReadAllText(endJson));
            moveOrder = read;
            foreach (Node n in read)
            {
                SimulateRightClick(n);
            }
        }
    }
}