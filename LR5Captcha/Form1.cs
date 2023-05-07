using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR5Captcha
{
    public partial class Form1 : Form
    {

        private void NewCaptcha()
        {
            int k = random.Next(min, max);
            label1.Text = EquationGenerator.Generate(k);
            this.Text = EquationGenerator.Evaluate(label1.Text);
        }

        private static Random random = new Random();
        private static int min = 3;
        private static int max = 7;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Captcha";
            NewCaptcha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input.CompareTo(EquationGenerator.Evaluate(label1.Text)) == 0)
            {
                MessageBox.Show("Captcha solved!");
                Environment.Exit(0);
            }
            else
            {
                textBox1.Text = string.Empty;
                NewCaptcha();
            }
        }
    }
}
