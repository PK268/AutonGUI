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
    }
}
