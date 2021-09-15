using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace PlayGame
{
    
    public partial class Form1 : Form
    {
        int timer;
        SoundPlayer countDownSound;
        SoundPlayer startSound;
        int loopNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            textBox1.Hide();
            StartGame();
        }

        private void StartGame()
        {
            startButton.Hide(); //Hide the button
            countDownSound = new SoundPlayer(Properties.Resources.countDownSound);
            startSound = new SoundPlayer(Properties.Resources.startSound);

            loopNum = timer;
            RefreshText();

        }

        private void RefreshText()
        {
            for (int i = 0; i < loopNum; i++)
            {
                countDownSound.Play();
                startText.Text = "Game Starting in: " + timer;
                Refresh();
                timer--;
                Thread.Sleep(1000);

                if (timer == 0)
                {
                    startSound.Play();
                    startText.Text = "Go!!!";
                    this.BackColor = Color.Chartreuse;
                    Refresh();
                }
            }
            
        }

        private void startText_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string timerString = textBox1.Text;
            timer = Int32.Parse(timerString);
        }
    }
}
