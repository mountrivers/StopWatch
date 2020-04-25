using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private bool onGoing = false;
        private bool isMove = true;
        private Point fPt;
        private DateTime startTime, stockTime;
        public Form1()
        {
            InitializeComponent();
        }

        public TimeSpan TimeSpan { get; private set; }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(onGoing == false)
            {
                TimeSpan temp = DateTime.Now - stockTime;
                startTime = new DateTime() + temp;
                timer1.Enabled = true;
                onGoing = true;
            }

        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (onGoing == true)
            {
                stockTime = DateTime.Parse(StopWatch.Text);
                onGoing = false;
                timer1.Enabled = false;
            }
        }

        /* timer. 현재 시간 */
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan = new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
            StopWatch.Text = TimeSpan.ToString("hh\\:mm\\:ss");
        }



        /* 창 이동 */
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
            }

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            fPt = new Point(e.X, e.Y);
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            onGoing = false;
            stockTime = new DateTime();
            StopWatch.Text = "00:00:00";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        /* 종료 버튼 */
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
