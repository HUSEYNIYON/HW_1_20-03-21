using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsCalculator
{
    public partial class Form1 : Form
    {
        Point moveStart;
        double result = 0;
        string operation = "";
        bool enter_value = false;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Button button1 = new Button
            {
                Location = new Point
                {
                    X = this.Width / 3,
                    Y = this.Height / 3
                }
            };
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button12_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if ((textBox1.Text == "0") || (enter_value))
                 textBox1.Text = "";
            enter_value = false;
            if(button.Text == ",")
            {
                if (!textBox1.Text.Contains(","))
                     textBox1.Text = textBox1.Text + button.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text; 
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                btn_equals.PerformClick();
                enter_value = true;
                operation = button.Text;
                label_show.Text = Convert.ToString(result) + "  " + operation;
            }
            else
            {
                operation = button.Text;
                result = double.Parse(textBox1.Text);
                textBox1.Text = "";
                label_show.Text = Convert.ToString(result) + "  " + operation;
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
            label_show.Text = "";
        }
        private void btn_equals_Click(object sender, EventArgs e)
        {
            label_show.Text = "";
            switch (operation)
            {
                case "+": textBox1.Text = (result + double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (result - double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (result * double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (result / double.Parse(textBox1.Text)).ToString(); break;
                default: break;
            }
            result = double.Parse(textBox1.Text);
            operation = ""; 
        }
        private void backSpace_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                this.Location = new Point(this.Location.X + deltaPos.X, this.Location.Y + deltaPos.Y);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
      
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = (!string.IsNullOrEmpty(textBox1.Text)) ? Math.Sqrt(double.Parse(textBox1.Text)).ToString() : "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "0")
            {
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text)).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.Pow(double.Parse(textBox1.Text), 2).ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text)  * (-1)).ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.Visible = false; 
        }

        private void label3_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
        }
    }
}
