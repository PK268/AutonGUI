using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

using System;
using System.CodeDom;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace AutonGUI
{
    public partial class AutonGUI : Form
    {
        const double resizeX = 2.14669051878;
        const double resizeY = 2.14669051878;
        static int steps = 0;
        static int lastSelectedStep = 0;
        public class SaveData
        {
            public Point SpawnPoint { get; set; }
            public double SpawnAngle { get; set; }
            public string DestFile { get; set; }
            public string SourceFile { get; set; }
            public List<Node> MoveOrder { get; set; }

            public SaveData(Point spawnPoint,string destFile, string sourceFile, List<Node> moveOrder, double spawnAngle)
            {
                SpawnPoint = spawnPoint;
                DestFile = destFile;
                SourceFile = sourceFile;
                MoveOrder = moveOrder;
                SpawnAngle = spawnAngle;
            }
        }
        public class Node
        {
            public int index { get; set; }
            public Point coordinate { get; set; }
            public bool offset { get; set; }
            public int intakeVelocity { get; set; }
            public bool reverse { get; set; }
            public int deg { get; set; }
            public int delay { get; set; }
            public Node()
            {
                reverse = false;
                intakeVelocity = 0;
                deg = 0;
                delay = 0;
            }
            public Node(int index, Point coordinate, bool offset, int intakeVelocity)
            {
                reverse = false;
                this.offset = offset;
                this.index = index;
                this.coordinate = coordinate;
                this.intakeVelocity = intakeVelocity;
            }
        }
        static List<Node> moveOrder = new List<Node>();
        static Point zero = new Point(300, 100);
        static double zeroAngle = 0;
        public AutonGUI()
        {
            InitializeComponent();
        }
        double GetNextAngle(Point current, Point destination, double currentHeading, bool backwards)
        {
            double angle = 0;
            double rTD = (double)180 / Math.PI;

            if (current.X == destination.X) //if point is directly behind robot
            {
                if (destination.Y < current.Y)
                {
                    angle = 180;
                }
                else
                {
                    angle = 0;
                }
            }
            else if (current.Y == destination.Y) //if point is directly to the left or directly to the right of the robot
            {
                if (destination.X < current.X)
                {
                    angle = -90;
                }
                else
                {
                    angle = 90;
                }
            }
            else //if point is not on axis
            {
                if (current.Y < destination.Y) //if point is in quad 1 or 2
                {
                    if (current.X < destination.X) // if point is in quad 1
                    {
                        angle = Math.Atan((double)(destination.X - current.X) / (destination.Y - current.Y));
                        angle *= rTD;
                    }
                    else if (current.X > destination.X) //if point is in quad 2
                    {
                        angle = (Math.Atan((double)(destination.X - current.X) / (destination.Y - current.Y)));
                        angle *= rTD;
                    }
                }
                else if (current.Y - destination.Y > 0) //if point is in quad 3 or 4
                {
                    if (current.X > destination.X) // if point is in quad 3
                    {
                        angle = Math.Atan((double)(destination.X - current.X) / (destination.Y - current.Y));
                        angle *= rTD;
                        angle -= 180;
                    }
                    else if (current.X < destination.X) //if point is in quad 4
                    {
                        angle = -1 * Math.Atan((double)(destination.X - current.X) / (destination.Y - current.Y));
                        angle *= rTD;
                        angle = 180 - angle;
                    }
                }
            }
            /*
                by this point we have an angle as if the robot was pointed up the y axis. Now let's
                correct for the robot's current heading so we don't overturn
             */

            angle = angle - currentHeading;
            if (angle > 180)
            {
                angle = -1 * (180 + currentHeading + 90 + (90 - (angle + currentHeading)));
            }
            else if (angle < -180)
            {
                angle = (180 - (currentHeading - 90)) + (90 + (angle + currentHeading));
            }

            /*
                now we have a correct angle to turn. Now we need to account for if we're about to turn backwards
             */

            if (backwards)
            {
                if (angle < 0)
                {
                    angle += 180;
                }
                else if (angle > 0)
                {
                    angle -= 180;
                }
            }
            return angle;
        }
        private double PointDistance(Point current, Point destination)
        {
            return Math.Sqrt(Math.Pow(destination.Y - current.Y, 2) + Math.Pow(destination.X - current.X, 2));
        }
        private void CreateNode(Point location)
        {
            var button = new Button();
            Controls.Add(button);
            button.Location = location;
            button.BringToFront();
            button.Size = new Size(30, 30);
            button.Text = "" + steps;
            button.Name = "" + steps;
            button.Click += (sender, e) => { ShowStepInfo(Convert.ToInt32(sender.GetType().GetProperty("Name").GetValue(sender, null))); };
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
                    newNodePos.Y = Math.Abs(newNodePos.Y); //Making sure the offset operation didnt make negatives
                    moveOrder.Add(new Node(steps, new Point((int)((newNodePos.X) * resizeX) - zero.X, (int)((newNodePos.Y) * resizeY) - zero.Y), false, 0));
                    CreateNode(PointToClient(new Point(globalMousePos.X - 15, globalMousePos.Y - 15)));
                    Nodes.Items.Add($"{"" + steps} {new Point((int)(newNodePos.X * resizeX) - zero.X, (int)(newNodePos.Y * resizeY) - zero.Y)}");
                    steps++;
                    // Right click
                    break;
                default:
                    break;
            }
        }
        private void SimulateRightClick(Node n)
        {
            Point newNodePos = new Point((int)(((n.coordinate.X) + zero.X) / resizeX) - 15, Math.Abs(559 - (int)((n.coordinate.Y + zero.Y) / resizeY)) - 15);
            CreateNode(newNodePos);
            Nodes.Items.Add($"{"" + steps} {new Point(n.coordinate.X, n.coordinate.Y)}");
            steps++;
        }
        public void ShowStepInfo(int index)
        {
            if (Nodes.Items.Count > index && (lastSelectedStep != index))
            {
                Nodes.SelectedIndex = index;
            }
            for (int i = 0; i < steps; i++)
            {
                this.Controls.Find("" + i, true).First().BackColor = Color.White;
            }
            Control indexButton = this.Controls.Find("" + index, true).First();
            indexButton.BackColor = Color.Red;
            lastSelectedStep = index;
            Node traversal = moveOrder[index];
            IntakeVelocityTextBox.Text = "" + traversal.intakeVelocity;
            CenterIntakeButton.Checked = traversal.offset;
            ReverseButton.Checked = traversal.reverse;
            Xcord.Value = (int)(traversal.coordinate.X);
            Ycord.Value = (int)(traversal.coordinate.Y);
            DegRotateTextBox.Text = "" + traversal.deg;
            DelayTextBox.Text = "" + traversal.delay;
        }

        //AKA the compiler
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var file = System.IO.File.Create(SaveLocation.Text);
            file.Close();
            string source = File.ReadAllText(SourceFileTextBox.Text);
            string[] split = source.Split("[GUIMARKER]");
            StringBuilder stringBuilder = new StringBuilder();
            Point currentPos = new Point(); //gridUnits X,Y
            double heading = zeroAngle; //degrees -180 -> 180 range
            foreach (Node n in moveOrder)
            {                  //turning it into feet * 12in         getting inches leftover from feet
                //int xInches = ((n.coordinate.X / 100) * 12) + (int)(12 * ((float)(n.coordinate.X % 100) / 100));
                //int yInches = ((n.coordinate.Y / 100) * 12) + (int)(12 * ((float)(n.coordinate.Y % 100) / 100));

                /*
                 commands:

                chassis->moveDistance([distance]);
                chassis->turnAngle([angle]);
                 */

                Point destination = new Point(n.coordinate.X, n.coordinate.Y);
                double distance = PointDistance(currentPos, destination); //in grid units
                double angle = GetNextAngle(currentPos, destination, heading, n.reverse); //in deg
                if (n.reverse)
                {
                    distance = -1 * distance;
                }

                //Replacement for angle != 0 according to codacy, comapring floating point can cause errors
                if (angle < -0.01 || angle > 0.01)
                {
                    stringBuilder.AppendLine($"\t\tchassis->turnAngle({angle}_deg);");
                }
                if (distance < -0.01 || distance > 0.01)
                {
                    stringBuilder.AppendLine($"\t\tchassis->moveDistance({distance / 100 * 12}_in);");
                }

                /*
                if (!n.offset)
                    commands += $"\t\tchassis->driveToPoint({{{xInches}_in, {yInches}_in}}, {n.reverse.ToString().ToLower()});\n";
                else
                    commands += $"\t\tchassis->driveToPoint({{{xInches}_in, {yInches}_in}}, {n.reverse.ToString().ToLower()}, 7_in);\n";
                */
                /*
                if (n.deg != 0)
                    commands += $"\t\tchassis->turnToAngle({n.deg}_deg);\n";
                */
                if (n.intakeVelocity != 0)
                {
                    stringBuilder.AppendLine($"\t\tintake.moveVelocity({n.intakeVelocity});");
                }
                if (n.delay != 0)
                {
                    stringBuilder.AppendLine($"\t\tpros::delay({n.delay});");
                }
                currentPos = destination;
                heading = heading + angle;
            }
            File.WriteAllText(SaveLocation.Text, split[0] + stringBuilder + split[1]);
        }

        private void UpdateNodeButton_Click(object sender, EventArgs e)
        {
            Node traversal = moveOrder[Nodes.SelectedIndex];
            try { traversal.intakeVelocity = int.Parse(IntakeVelocityTextBox.Text); }
            catch { traversal.intakeVelocity = 0; ShowStepInfo(lastSelectedStep); }

            traversal.offset = CenterIntakeButton.Checked;
            traversal.reverse = ReverseButton.Checked;
            traversal.coordinate = new Point((int)Xcord.Value, (int)Ycord.Value);
            Controls.Find("" + lastSelectedStep, true).First().Location = new Point((int)(((double)Xcord.Value + zero.X) / resizeX) - 15, Math.Abs((int)(((double)Ycord.Value + zero.Y) / resizeY) - 559 + 15));
            try { traversal.deg = int.Parse(DegRotateTextBox.Text); }
            catch { traversal.deg = 0; ShowStepInfo(lastSelectedStep); }
            try { traversal.delay = int.Parse(DelayTextBox.Text); }
            catch { traversal.delay = 0; ShowStepInfo(lastSelectedStep); }

            Nodes.Items[lastSelectedStep] = lastSelectedStep + " " + new Point(traversal.coordinate.X, traversal.coordinate.Y);
        }

        private void Nodes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Nodes.SelectedItems.Count != 0)
            {
                int index = int.Parse(Nodes.SelectedItems[0].ToString().Split(' ').First());
                lastSelectedStep = index;
                ShowStepInfo(index);
            }
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
            SaveData sd = new SaveData(zero,SaveLocation.Text,SourceFileTextBox.Text,moveOrder,(double)SpawnAngleUpDown.Value);
            File.WriteAllText(endJson, JsonConvert.SerializeObject(sd));
        }

        private void LoadJsonButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            string endJson = DestinationFileDialog1.FileName;
            SaveData read = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(endJson));
            moveOrder = read.MoveOrder;
            SourceFileTextBox.Text = read.SourceFile;
            SaveLocation.Text = read.DestFile;
            zero = read.SpawnPoint;
            SpawnXUpDown.Value = zero.X;
            SpawnYUpDown.Value = zero.Y;
            SpawnAngleUpDown.Value = (decimal)read.SpawnAngle;
            SpawnUpdateButton_Click(null,null);
            foreach (Node n in moveOrder)
            {
                SimulateRightClick(n);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Nodes.SelectedItems.Count != 0)
            {
                int index = Nodes.SelectedIndex;
                moveOrder.RemoveAt(index);
                Control[] toRemove = Controls.Find("" + index, true);
                Controls.Remove(toRemove.Last());
                Nodes.ClearSelected();
                Nodes.Items.RemoveAt(index);
                CorrectNames();
                steps--;
                lastSelectedStep = -1;
            }
        }

        private void CorrectNames()
        {
            int count = 0;
            int deficit = 0;
            for (int i = 0; i <= steps; i++)
            {
                if (count != i)
                {
                    deficit = i - count;
                }
                if (Controls.Find("" + i, true).Length != 0)
                {
                    Controls.Find("" + i, true)[0].Text = "" + (i - deficit);
                    Controls.Find("" + i, true)[0].Name = "" + (i - deficit);
                    Nodes.Items[i - deficit] = "" + (i - deficit) + " {X=" + moveOrder[i - deficit].coordinate.X + ",Y=" + moveOrder[i - deficit].coordinate.Y + "}";
                    count++;
                }
            }
        }

        private void SpawnUpdateButton_Click(object sender, EventArgs e)
        {
            Point oldZero = zero;
            zero = new Point((int)SpawnXUpDown.Value, (int)SpawnYUpDown.Value);

            SP.Location = new Point(
                    (int)((zero.X / resizeX) - 15),
                    Math.Abs(559 - (int)((zero.Y) / resizeY)) - 15
                    );
            zeroAngle = (double)SpawnAngleUpDown.Value;

            Point difference = new Point(zero.X - oldZero.X, zero.Y - oldZero.Y);
            for (int i = 0; i < Nodes.Items.Count; i++)
            {
                Nodes.Items[i] = $"{i} {{X={moveOrder[i].coordinate.X},Y={moveOrder[i].coordinate.Y}}}";
            }
            foreach (Node n in moveOrder)
            {
                n.coordinate = new Point(n.coordinate.X - difference.X + 1, n.coordinate.Y - difference.Y + 1); //Idk why its plus one but it works
            }
        }
    }
}