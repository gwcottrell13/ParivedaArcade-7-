using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Will_s_pariveda_7th_attempt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PilotEscape escapeView = new PilotEscape();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PilotEscapeButton_Click(object sender, EventArgs e)
        {
            escapeView.Show();
        }
    }
}
