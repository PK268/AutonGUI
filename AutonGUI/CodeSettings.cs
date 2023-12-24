using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonGUI
{
    public partial class CodeSettings : Form
    {
        public CodeSettings()
        {
            InitializeComponent();
        }

        private void CodeSettingsInfoButton_Click(object sender, EventArgs e)
        {
            Process helpPage = new Process();
            helpPage.StartInfo.UseShellExecute = true;
            helpPage.StartInfo.FileName = "https://github.com/PK268/AutonGUI/wiki/";
            helpPage.Start();
        }

        private void CSUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                AutonGUI.OdomChassisControllerVariableName = CSVariableTextBox.Text;
                AutonGUI.IntakeMotorGroupVariableName = CSVariableTextBox2.Text;
                AutonGUI.RobotSize = new Tuple<double, double>(double.Parse(CSWidthTextBox.Text), double.Parse(CSLengthTextBox.Text));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
