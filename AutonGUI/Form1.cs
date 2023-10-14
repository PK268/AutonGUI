using System;
using System.Reflection;

namespace AutonGUI
{
    public partial class Form1 : Form
    {
        static int steps;
        static int lastSelectedStep;
        public struct Node
        {
            public int index;
            public Point coordinate;
            public bool offset;
            public int intakeVelocity;
            public Node()
            {
                intakeVelocity = 0;
            }
            public Node(int index, Point coordinate, bool offset, int intakeVelocity)
            {
                this.offset = offset;
                this.index = index;
                this.coordinate = coordinate;
                this.intakeVelocity = intakeVelocity;
            }
        }
        static LinkedList<Node> moveOrder = new LinkedList<Node>();
        public Form1()
        {
            InitializeComponent();
            steps = 0;
            lastSelectedStep = 0;
        }

        private void OverUnderBG_Click(object sender, EventArgs e)
        {
            Point globalMousePos = Control.MousePosition;
            Point newNodePos = PointToClient(globalMousePos);
            newNodePos.Offset(0, -630); //-628 to make 0,0 the bottom left instead of the top left.
            newNodePos.X = Math.Abs(newNodePos.X);
            newNodePos.Y = Math.Abs(newNodePos.Y); //Making sure the offset operation didnt make negatives
            moveOrder.AddLast(new Node(steps, newNodePos, false, 0));

            var button = new Button();
            Controls.Add(button);
            button.Location = PointToClient(new Point(globalMousePos.X - 15, globalMousePos.Y - 15));
            button.BringToFront();
            button.Size = new Size(30, 30);
            button.Text = "" + steps;
            button.Name = "" + steps;
            button.Click += (sender, e) => { ShowStepInfo(Convert.ToInt32(sender.GetType().GetProperty("Name").GetValue(sender, null))); };
            steps++;
            //GraphicsExtensions.FillCircle();
        }
        public void ShowStepInfo(int index)
        {
            for (int i = 0; i < index; i++)
            {
                this.Controls.Find("" + i, true).First().ForeColor = Color.Black;
            }
            Control indexButton = this.Controls.Find("" + index, true).First();
            indexButton.ForeColor = Color.Red;
            lastSelectedStep = index;
            LinkedListNode<Node> traversal = moveOrder.First;
            for (int i = 0; i < index; i++)
            {
                traversal = traversal.Next;
            }
            IntakeVelocityTextBox.Text = "" + traversal.Value.intakeVelocity;
            CenterIntakeButton.Checked = traversal.Value.offset;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var file = System.IO.File.Create(SaveLocation.Text);
            file.Close();
            string source = File.ReadAllText(SourceFileTextBox.Text);
            string[] split = source.Split("[GUIMARKER]");
            string commands = "";
            foreach (Node n in moveOrder)
            {
                int xInches = ((n.coordinate.X / 100) * 12) + (int)(12 * ((float)(n.coordinate.X % 100) / 100));
                int yInches = ((n.coordinate.Y / 100) * 12) + (int)(12 * ((float)(n.coordinate.Y % 100) / 100));
                if (!n.offset)
                    commands += $"\t\tchassis->driveToPoint({{{n.coordinate.X}_in, {n.coordinate.Y}_in}}, true);\n";
                else
                    commands += $"\t\tchassis->driveToPoint({{{n.coordinate.X}_in, {n.coordinate.Y}_in}}, true, 7_in);\n";
                if (n.intakeVelocity != 0)
                {
                    commands += $"\t\tintake.moveVelocity({n.intakeVelocity});\n";
                }
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
            traversal.ValueRef.intakeVelocity = int.Parse(IntakeVelocityTextBox.Text);

            traversal.ValueRef.offset = CenterIntakeButton.Checked;
        }
    }
}