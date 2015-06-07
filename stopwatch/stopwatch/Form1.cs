﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using Hotkeys;

namespace stopwatch
{
    public partial class Form1 : Form
    {
        private Hotkeys.GlobalHotkeys ghk;
        private Hotkeys.GlobalHotkeys ghw;
        public Form1()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkeys(Constants.CTRL , Keys.F, this);
            ghw = new Hotkeys.GlobalHotkeys(Constants.CTRL , Keys.G, this);
            ghk.Register();
            ghw.Register();
        }


        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        protected void TimeHandlerStart() {

            if (listBox1.Items.Count != 0) timer1.Start();
            else MessageBox.Show("Please add a Segment before starting your run");
            
        }
        protected void TimeHandlerStop()
        {

            timer1.Stop();

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                switch (GetKey(m.LParam)) { 
                 
                    case Keys.F:

                        TimeHandlerStart();

                    break;
                    
                    case Keys.G:
                        TimeHandlerStop();
                        break;

                    
                }
               
            base.WndProc(ref m);
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

    }
}

