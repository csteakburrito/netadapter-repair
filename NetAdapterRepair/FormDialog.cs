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
    public partial class FormDialog : Form
    {
        public int ButtonPressed = 0;
        public string Value = "";

        public FormDialog(string title, string text, string defaultValue, string button1text, string button2text, string button3text, string button4text)
        {
            InitializeComponent();
            this.Text = title;
            labelText.Text = text;
            button1.Text = button1text;
            button2.Text = button2text;
            button3.Text = button3text;
            button4.Text = button4text;
            textBox.Text = defaultValue;

            // Hide buttons if there is no label
            button1.Visible = !button1text.Equals("");
            button2.Visible = !button2text.Equals("");
            button3.Visible = !button3text.Equals("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value = textBox.Text;
            ButtonPressed = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Value = textBox.Text;
            ButtonPressed = 2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Value = textBox.Text;
            ButtonPressed = 3;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Value = textBox.Text;
            ButtonPressed = 4;
            this.Close();
        }
    }
}
