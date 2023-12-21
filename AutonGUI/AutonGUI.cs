using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

using System;
using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AutonGUI
{
    public partial class AutonGUI : Form
    {
        const double resizeX = 2.14669051878;
        const double resizeY = 2.14669051878;
        static int steps = 0;
        static int lastSelectedStep = -1;
        public class SaveData
        {
            public Point SpawnPoint { get; set; }
            public double SpawnAngle { get; set; }
            public string DestFile { get; set; }
            public string SourceFile { get; set; }
            public List<Node> MoveOrder { get; set; }

            public SaveData(Point spawnPoint, string destFile, string sourceFile, List<Node> moveOrder, double spawnAngle)
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
        static PictureBox head;
        static List<Node> moveOrder = new List<Node>();
        static Point zero = new Point(300, 100);
        static double zeroAngle = 0;
        static Tuple<double, double> robotSize = new Tuple<double, double>(12.8, 15.5); //in inches
        public AutonGUI()
        {
            InitializeComponent();
            var SP = new PictureBox();
            OverUnderBG.Controls.Add(SP);
            SP.Name = "SP";
            SP.SizeMode = PictureBoxSizeMode.Zoom;
            SP.BringToFront();
            RefreshNodeImage(true, Point.Empty, "SP", zeroAngle, 3);
            head = SP;
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
                    Point coordinate = new Point((int)(newNodePos.X * resizeX - zero.X), (int)((559 - newNodePos.Y) * resizeY - zero.Y));
                    CreateNode(coordinate);
                    moveOrder.Add(new Node(steps, coordinate, false, 0));
                    Nodes.Items.Add($"{"" + steps} {coordinate}");
                    steps++;
                    UpdateAllNodeImages();
                    // Right click
                    break;
                default:
                    break;
            }
        }
        private void CreateNode(Point location)
        {
            var nodeToAdd = new PictureBox();
            OverUnderBG.Controls.Add(nodeToAdd);
            nodeToAdd.SizeMode = PictureBoxSizeMode.Zoom;
            nodeToAdd.BringToFront();
            nodeToAdd.Name = "" + steps;
            nodeToAdd.Click += (sender, e) => { ShowStepInfo(Convert.ToInt32(sender.GetType().GetProperty("Name").GetValue(sender, null))); };
            RefreshNodeImage(false, location, "" + steps, 0, 1);
            head = nodeToAdd;
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
                RefreshNodeImage(false, moveOrder[i].coordinate, "" + i, 0, 1);
            }
            Control indexNode = this.Controls.Find("" + index, true).First();
            indexNode.BackColor = Color.Red;
            RefreshNodeImage(false, moveOrder[index].coordinate, "" + index, 0, 2);
            lastSelectedStep = index;
            Node traversal = moveOrder[index];
            IntakeVelocityTextBox.Text = "" + traversal.intakeVelocity;
            CenterIntakeButton.Checked = traversal.offset;
            ReverseButton.Checked = traversal.reverse;
            Xcord.Value = (int)(traversal.coordinate.X);
            Ycord.Value = (int)(traversal.coordinate.Y);
            DegRotateTextBox.Text = "" + traversal.deg;
            DelayTextBox.Text = "" + traversal.delay;
            UpdateAllNodeImages();
        }
        public double InchesToGridUnits(double inches)
        {
            return inches / 12 * 100;
        }
        public Point GridToLocation(Point coordinate)
        {
            double x = (coordinate.X + zero.X) / resizeX;
            double y = (coordinate.Y + zero.Y) / resizeY;
            return new Point((int)x, (int)y);
        }
        public Point GridToLocation(Point coordinate, Point nodeSize)
        {
            double x = (coordinate.X + zero.X) / resizeX;
            double y = (coordinate.Y + zero.Y) / resizeY;
            y = 559 - y;
            x = x - ((double)nodeSize.X / 2);
            y = y - ((double)nodeSize.Y / 2);
            return new Point((int)x, (int)y);
        }
        public void UpdateAllNodeImages()
        {
            Point currentPos = new Point(); //gridUnits X,Y
            double heading = zeroAngle;
            for (int i = 0; i < moveOrder.Count; i++)
            {
                Node n = moveOrder[i];
                Point destination = new Point(n.coordinate.X, n.coordinate.Y); //in grid units
                double angle = GetNextAngle(currentPos, destination, heading, n.reverse);

                int status = 1;
                if (lastSelectedStep == i)
                {
                    status = 2;
                }
                heading = (heading + angle) % 360;
                RefreshNodeImage(false, moveOrder[i].coordinate, "" + i, heading, status);
                currentPos = destination;
            }
        }
        public void RefreshNodeImage(bool spawn, Point location, string label, double angle, int status)
        {
            var NodeToUpdate = (PictureBox)(Controls.Find(label, true)[0]);
            Point NodeSize = GetNodeSize(robotSize, angle);
            NodeToUpdate.Size = new Size(NodeSize);
            Point newNodePos;
            if (spawn)
            {
                newNodePos = new Point((int)((zero.X) / resizeX) - (NodeSize.X / 2), Math.Abs(OverUnderBG.Size.Height - (int)((zero.Y) / resizeY)) - (NodeSize.Y / 2));
            }
            else
            {
                newNodePos = GridToLocation(location, NodeSize);
            }
            NodeToUpdate.Location = newNodePos;
            NodeToUpdate.BackColor = Color.Transparent;
            NodeToUpdate.Image = GetNodeBitmap(robotSize, NodeSize, label, status, angle);
        }
        //status:
        //1=unselected
        //2=selected
        //3=SP
        public Bitmap GetNodeBitmap(Tuple<double, double> robotDimentions, Point containerSize, string label, int status, double angle)
        {
            //Robot dimentions are in inches
            //Container dimentions are in grid units
            //Label is what goes on the rect
            //Status is the color of the rect


            Color color = new Color();
            int resolutionX = 256;
            int resolutionY = 256;
            if (containerSize.Y / containerSize.X < 0)
            {
                resolutionX /= (1 / ((containerSize.Y / containerSize.X)));
            }
            else
            {
                resolutionX = (int)(256 * ((double)containerSize.X / containerSize.Y));
            }
            Bitmap bitmap = new Bitmap(resolutionX, resolutionY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            if (status == 1)
            {
                color = Color.FromKnownColor(KnownColor.Gray);
            }
            else if (status == 2)
            {
                color = Color.FromKnownColor(KnownColor.Red);
            }
            else if (status == 3)
            {
                color = Color.FromKnownColor(KnownColor.DarkSlateGray);
            }
            SolidBrush brush = new SolidBrush(color);
            int width = (int)(resolutionX * ((InchesToGridUnits(robotDimentions.Item1) / (containerSize.X * resizeX))));
            int height = (int)(resolutionY * ((InchesToGridUnits(robotDimentions.Item2) / (containerSize.Y * resizeY))));

            int offsetX = (resolutionX - width) / 2;
            int offsetY = (resolutionY - height) / 2;

            Rectangle rect = new Rectangle(offsetX, offsetY, width, height);
            if (angle != 0)
            {
                g.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
                g.RotateTransform((float)angle);
                g.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
            }

            g.FillRectangle(brush, rect);

            if (angle != 0)
            {
                g.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
                g.RotateTransform(-1 * (float)angle);
                g.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
            }

            //Write text
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (label.Length == 1)
            {
                g.DrawString(label, new Font("Tahoma", (int)(Math.Min(resolutionX, resolutionY) / 5.33333)), Brushes.Black, resolutionX / 3 + (resolutionX / 16), resolutionY / 3);
            }
            else if (label.Length == 2)
            {
                g.DrawString(label, new Font("Tahoma", (int)(Math.Min(resolutionX, resolutionY) / 5.33333)), Brushes.Black, resolutionX / 3 - (resolutionX / 64), resolutionY / 3);
            }
            return bitmap;
        }
        public Point GetNodeSize(Tuple<double, double> robotDimentions, double angle)
        {
            if (angle > 90)
            {
                angle = 90 - (angle % 90);
            }
            if (angle < 0)
            {
                angle = 90 + (angle % -90);
            }
            double x = (robotDimentions.Item1 * Math.Cos(angle * (Math.PI / 180))) + (robotDimentions.Item2 * Math.Sin(angle * (Math.PI / 180)));
            double y = (robotDimentions.Item1 * Math.Sin(angle * (Math.PI / 180))) + (robotDimentions.Item2 * Math.Cos(angle * (Math.PI / 180)));
            x = x / 12 * 100;
            y = y / 12 * 100;
            x = x / resizeX;
            y = y / resizeY;
            return new Point((int)x + 1, (int)y + 1); //+1 because we're converting double to int so we lose the decimal, this always "rounds up" the value
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
            {
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
                heading = (heading + angle) % 360;
            }
            File.WriteAllText(SaveLocation.Text, split[0] + stringBuilder + split[1]);
        }

        private void UpdateNodeButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = Nodes.SelectedIndex;
            if (selectedIndex != -1)
            {
                Node traversal = moveOrder[selectedIndex];
                try { traversal.intakeVelocity = int.Parse(IntakeVelocityTextBox.Text); }
                catch { traversal.intakeVelocity = 0; ShowStepInfo(lastSelectedStep); }

                traversal.offset = CenterIntakeButton.Checked;
                traversal.reverse = ReverseButton.Checked;
                traversal.coordinate = new Point((int)Xcord.Value, (int)Ycord.Value);
                Control c = Controls.Find("" + lastSelectedStep, true).First();
                Console.WriteLine(c.Location);
                c.Location = new Point((int)(((double)Xcord.Value + zero.X) / resizeX - ((double)c.Size.Width / 2)), Math.Abs((int)(((double)Ycord.Value + zero.Y) / resizeY) - OverUnderBG.Size.Height + (c.Size.Width / 2)));
                try { traversal.deg = int.Parse(DegRotateTextBox.Text); }
                catch { traversal.deg = 0; ShowStepInfo(lastSelectedStep); }
                try { traversal.delay = int.Parse(DelayTextBox.Text); }
                catch { traversal.delay = 0; ShowStepInfo(lastSelectedStep); }

                Nodes.Items[lastSelectedStep] = lastSelectedStep + " " + new Point(traversal.coordinate.X, traversal.coordinate.Y);
            }
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
            if (DestinationFileDialog1.FileName != null && DestinationFileDialog1.FileName != "" && !DestinationFileDialog1.FileName.Equals("DestinationFileDialog1"))
            {
                SaveLocation.Text = DestinationFileDialog1.FileName;
            }
        }

        private void SourceFileButton_Click(object sender, EventArgs e)
        {
            SourceFileDialog2.ShowDialog(this);
            if (SourceFileDialog2.FileName != null && SourceFileDialog2.FileName != "" && !SourceFileDialog2.FileName.Equals("SourceFileDialog2"))
            {
                SourceFileTextBox.Text = SourceFileDialog2.FileName;
            }
        }

        private void SaveJsonButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            if (DestinationFileDialog1.FileName != null && DestinationFileDialog1.FileName != "" && !DestinationFileDialog1.FileName.Equals("DestinationFileDialog1"))
            {
                string endJson = DestinationFileDialog1.FileName;
                SaveData sd = new SaveData(zero, SaveLocation.Text, SourceFileTextBox.Text, moveOrder, (double)SpawnAngleUpDown.Value);
                File.WriteAllText(endJson, JsonConvert.SerializeObject(sd));
            }
        }

        private void LoadJsonButton_Click(object sender, EventArgs e)
        {
            DestinationFileDialog1.ShowDialog(this);
            if (DestinationFileDialog1.FileName != null && DestinationFileDialog1.FileName != "" && !DestinationFileDialog1.FileName.Equals("DestinationFileDialog1"))
            {
                string endJson = DestinationFileDialog1.FileName;
                SaveData read = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(endJson));
                moveOrder = read.MoveOrder;
                SourceFileTextBox.Text = read.SourceFile;
                SaveLocation.Text = read.DestFile;
                zero = read.SpawnPoint;
                SpawnXUpDown.Value = zero.X;
                SpawnYUpDown.Value = zero.Y;
                SpawnAngleUpDown.Value = (decimal)read.SpawnAngle;
                SpawnUpdateButton_Click(null, null);
                foreach (Node n in moveOrder)
                {
                    SimulateRightClick(n);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Nodes.SelectedItems.Count != 0)
            {
                int index = Nodes.SelectedIndex;
                moveOrder.RemoveAt(index);
                Control[] toRemove = Controls.Find("" + index, true);
                Controls.Remove(toRemove.First());
                OverUnderBG.Controls.Remove(toRemove.First());
                Nodes.ClearSelected();
                Nodes.Items.RemoveAt(index);
                CorrectNames();
                steps--;
                lastSelectedStep = -1;
                UpdateAllNodeImages();
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
                Control[] c = Controls.Find("" + i, true);
                if (c.Length != 0)
                {
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
            zeroAngle = (double)SpawnAngleUpDown.Value;

            Point difference = new Point(zero.X - oldZero.X, zero.Y - oldZero.Y);
            for (int i = 0; i < Nodes.Items.Count; i++)
            {
                Nodes.Items[i] = $"{i} {{X={moveOrder[i].coordinate.X},Y={moveOrder[i].coordinate.Y}}}";
            }
            foreach (Node n in moveOrder)
            {
                n.coordinate = new Point(n.coordinate.X - difference.X, n.coordinate.Y - difference.Y); //Idk why its plus one but it works
            }
            RefreshNodeImage(true, Point.Empty, "SP", zeroAngle, 3);
        }

        private void OpenCodeSettingsButton_Click(object sender, EventArgs e)
        {
            CodeSettings codeSettings = new CodeSettings();
            codeSettings.Show();
        }
    }
}