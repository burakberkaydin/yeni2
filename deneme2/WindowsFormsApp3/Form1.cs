using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000;  //set interval to 2 seconds
            timer.Tick += Timer_Tick;  //wire up event handler;
            timer.Start();  //start the timer
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            myButton.Location = new Point(myButton.Location.X + 1, myButton.Location.Y);

    //Stop the timer once the button reaches the right edge
            if (myButton.Location.X + myButton.Width >= ClientSize.Width)
            {
                timer.Stop();
            }
        }
    }
}
