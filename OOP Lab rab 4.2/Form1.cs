using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab_rab_4._2
{
    public partial class Form1 : Form
    {
        Model model;

        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observer += new System.EventHandler(this.UpdateFromModel);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValue1(Decimal.ToInt32(numericUpDown1.Value));
            /*if (numericUpDown1.Value <= numericUpDown2.Value)
                numericUpDown2.Value = numericUpDown1.Value - 1;
            textBox1.Text = numericUpDown1.Value.ToString();
            label1.Text = numericUpDown1.Value.ToString();*/
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValue2(Decimal.ToInt32(numericUpDown2.Value));
            /*if (numericUpDown2.Value >= numericUpDown1.Value)
                numericUpDown1.Value = numericUpDown1.Value + 1;
            textBox2.Text = numericUpDown2.Value.ToString();
            label2.Text = numericUpDown2.Value.ToString();*/
        }

        private void UpdateFromModel(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.getValue1();
            textBox1.Text = model.getValue1().ToString();
            label1.Text = model.getValue1().ToString();
            numericUpDown2.Value = model.getValue2();
            textBox2.Text = model.getValue2().ToString();
            label2.Text = model.getValue2().ToString();
        }
    }

    public class Model
    {
        private int value1;
        private int value2;
        public System.EventHandler observer;

        public void setValue1(int value)
        {
            value1 = value;
            if (value1 <= value2)
            {
                value2 = value1 - 1;
            }
            observer.Invoke(this, null);
        }
        public void setValue2(int value)
        {
            value2 = value;
            if (value2 >= value1)
            {
                value1 = value2 + 1;
            }
            observer.Invoke(this, null);
        }
        public int getValue1()
        {
            return value1;
        }

        public int getValue2()
        {
            return value2;
        }
    }

}