using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stopwatch
{
    public partial class Form1 : Form
    {
        private KeyHandler ghk;
        private KeyHandler ghW;
        public int element = 0;

        private void HandleHotkey()
        {
            if (listBox1.Items.Count >= 1)
            {
              
                timer1.Start();

            }
            else
            {
                MessageBox.Show("Please add a Segment to start the timer");
                textBox1.Focus();
            }
            if (timer1.Enabled && timer.Text != "TIMER")
            {
                //listBox1.Items.IndexOf
            }
            
        }
        private void HandleStop() { MessageBox.Show("fuck you"); }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0X2D)
            {

                HandleHotkey();
          
            }
            if (m.Msg == 0x0100) { HandleStop(); }
            base.WndProc(ref m);
        }
        
        public Form1()
        {
            InitializeComponent();
            ghk = new KeyHandler(Keys.Insert, this);
            ghk.Register();
            ghW = new KeyHandler(Keys.Home, this);
            ghW.Register();
        }

        int hour, min, sec, ms = 00;

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Please enter the name of the Segment to add");
                textBox1.Focus();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Text = hour + ":" + min + ":" + sec + ":" + ms;
            ms++;
            if (ms > 10) { sec++; ms = 0; } else { ms++; }
            if (sec > 60) { min++; sec = 0; }
            if (min > 60) { hour++; min = 0; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
