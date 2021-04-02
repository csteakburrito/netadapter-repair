using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetAdapter
{
    public partial class FormRestartConfirmation : Form
    {
        public int ButtonPressed = 0;
        private int Timeout = 60;

        public FormRestartConfirmation(int argTimeout)
        {
            InitializeComponent();
            Timeout = argTimeout;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonPressed = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonPressed = 2;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timeout > 0)
            {
                Timeout = Timeout - 1;
                button1.Text = "Restart (in " + Timeout + " seconds)";
            }
            else
            {
                ButtonPressed = 1;
                this.Close();
            }
        }
    }
}
