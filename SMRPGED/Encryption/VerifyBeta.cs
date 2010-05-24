using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace SMRPGED.Encryption
{
    public partial class VerifyBeta : Form
    {
        Timer clock;
        float red, green, blue;
        bool colorDirection = true; // darker
        WebClient client = new WebClient();

        Form1 f1;

        public VerifyBeta(Form1 f1)
        {
            InitializeComponent();

            this.label1.BackColor = Color.Orange;

            this.f1 = f1;

            clock = new Timer();
            clock.Interval = 1000 / 30;
            clock.Tick += new EventHandler(clock_Tick);
            clock.Start();

            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            
        }
        private void VerifyVersion(byte[] dl)
        {
            int tester = (dl[3] << 24) + (dl[2] << 16) + (dl[1] << 8) + dl[0];

            tester ^= 0x3a9b4ca8;

            if (tester == 0x5dde6fa9)
            {
                Random r = new Random();
                this.label1.Text = "                                 Beta Verified                                 ";
                pass = true;
                MessageBox.Show("Beta Version verifyied by author, Confirmation code: " + (tester + 0x126523 ^ r.Next(0x7FFFFFFF)).ToString("X8"), "LAZY SHELL");
                Pass();
            }
            else
            {
                this.label1.Text = "                            Beta Verification Failed                           ";
                pass = false;
                MessageBox.Show("This beta version has NOT been verified \nNote: This is due to the authors deactivation of beta versions or a lack of internet connection", "LAZY SHELL");
                Fail();
            }
        }
        private void Pass()
        {
            this.Close();
        }
        private void Fail()
        {
            f1.BetaFailValidation();
        }

        private void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                VerifyVersion(e.Result);
            }
            catch
            {
                return;
            }
        }

        bool pass;
        private void clock_Tick(object sender, EventArgs e)
        {
            if (pass)
            {
                if (red > 185 || red < 89)
                {
                    if (colorDirection)
                    {
                        red = 89;
                        green = 99;
                        blue = 219;
                        colorDirection = false;
                    }
                    else
                    {
                        red = 185;
                        green = 189;
                        blue = 240;
                        colorDirection = true;
                    }
                }

                if (colorDirection) // get darker
                {
                    red -= 96 / 30;
                    green -= 90 / 30;
                    blue -= 21 / 30;
                }
                else // Get Lighter
                {
                    red += 96 / 30;
                    green += 90 / 30;
                    blue += 21 / 30;
                }
            }
            else // Fail
            {
                if (red > 221 || red < 89)
                {
                    if (colorDirection)
                    {
                        red = 247;
                        green = 134;
                        blue = 128;
                        colorDirection = false;
                    }
                    else
                    {
                        red = 221;
                        green = 26;
                        blue = 15;
                        colorDirection = true;
                    }
                }

                if (colorDirection) // get darker
                {
                    red -= 26 / 30;
                    green -= 108 / 30;
                    blue -= 107 / 30;
                }
                else // Get Lighter
                {
                    red += 26 / 30;
                    green += 108 / 30;
                    blue += 107 / 30;
                }
            }
            this.label1.BackColor = Color.FromArgb(Math.Abs((byte)red), Math.Abs((byte)green), Math.Abs((byte)blue));
        }


        public void TestBetaVersion(bool beta)
        {
            if (beta)
            {
                client = new System.Net.WebClient();
                Uri link = new Uri("http://members.shaw.ca/SMRPGED/BETAVERIFY.bin");
                this.Refresh();
                //client.DownloadDataAsync(link);

                byte[] temp;
                try
                {
                    temp = client.DownloadData(link);
                    VerifyVersion(temp);
                }
                catch
                {
                    VerifyVersion(new byte[]{0,0,0,0});
                }
            }
        }

    }
}