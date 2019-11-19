using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimonGame1.Properties;
using System.Media;
using System.Threading;

namespace SimonGame1
{
    public partial class Form1 : Form
    {
        //pictures initialization
        #region
        Image BtnBlue = Resources.bt1;
        Image BtnGreen = Resources.bt2;
        Image BtnOrange = Resources.bt3;
        Image BtnRed = Resources.bt4;
        Image BtnStart = Resources.btStart;
        Image Gold = Resources.gold;
        #endregion

        int count = 0;
        bool flag = false;
        Random rand = new Random();
        int[] arrCount = new int[4] { 1, 2, 3, 4 };
        PictureBox[] pbArr;
        PictureBox currentPictureBox = new PictureBox();
        Image imageTmp;
        Image imageGold;
        SoundPlayer sp = new SoundPlayer();
        int[] arrNumbers1;
        int[] arrNumbers2;
        List<int> listNumbers2 = new List<int>();


        public Form1()
        {
            InitializeComponent();

         // insert background pictures into pictureBox elements
          //pictures look like buttons
            #region
            pictureBox1.Image = BtnBlue;
            pictureBox2.Image = BtnGreen;
            pictureBox3.Image = BtnOrange;
            pictureBox4.Image = BtnRed;
            pictureBox5.Image = BtnStart;
            imageGold = Gold;
            #endregion
            textBox1.Text = "HELLO";

        }
        //beginning of the game
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pbArr = new PictureBox[4] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            List<PictureBox> pbList = pbArr.ToList();
            pictureBox5.Enabled = false;
            Exercise();
        }
        //  Each time the melody is extended by one sound and one flashing button
        public void Exercise()
        {
            Cursor = Cursors.WaitCursor;
            Thread.Sleep(1000);
            listNumbers2.Clear();
            textBox1.Hide();
            count++;
            arrNumbers1 = new int[count];
            for(int i = 0; i < count; i++)
            {            
               int number =  Blinking();
                arrNumbers1[i] = number;

            }
            // The flag=true indicates that it is now the player’s turn to
            //repeat the melody.
            flag = true;
            Cursor = Cursors.Default;

        }
        //flashing buttons
        public int Blinking()
        {
            int num = arrCount[rand.Next(arrCount.Length)];
            currentPictureBox = pbArr[num - 1];
            imageTmp = currentPictureBox.Image;
            currentPictureBox.Image = Gold;
            currentPictureBox.Update();
            Thread.Sleep(100);
            currentPictureBox.Image = imageTmp;
            currentPictureBox.Update();
            MySound(num);
            Thread.Sleep(1000);
            return num;           
        }

     // each button has a sound
        public void MySound(int num)
        {
            switch (num)
            {
                case 1:
                sp.Stream = Properties.Resources._do;
                break;          
                case 2:
                    sp.Stream = Resources.fa;
                    break;
                case 3:
                    sp.Stream = Resources.lja;
                    break;
                case 4:
                    sp.Stream = Resources.si;
                    break;
                default:
                    sp.Stream = Properties.Resources._do;
                    break;
            }
            sp.Play();
        }
        // when a player presses a button
        #region
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MySound(1);
            MyBlincking(pictureBox1);
            listNumbers2.Add(1);
            if (listNumbers2.Count == count)
            {
                Answer();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySound(2);
            MyBlincking(pictureBox2);
            listNumbers2.Add(2);
            if (listNumbers2.Count == count)
            {

                Answer();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MyBlincking(pictureBox3);
            MySound(3);
            listNumbers2.Add(3);
            if (listNumbers2.Count == count)
            {
                Answer();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MyBlincking(pictureBox4);
            MySound(4);
            listNumbers2.Add(4);
            if (listNumbers2.Count == count)
            {
                Answer();
            }
        }
        #endregion

        // compare the player’s response with the original melody
        public void Answer()
        {
            textBox1.Visible = true; 
            bool res = true;
            arrNumbers2 = listNumbers2.ToArray();
            for(int i = 0; i < count; i++)
            {
                if (arrNumbers1[i] != arrNumbers2[i])
                {
                    res = false;
                }
            }
           if(res == true)
            {
                textBox1.ForeColor = System.Drawing.Color.Red;
                textBox1.Text = "YESSS!!!";
                textBox1.Update();
                Thread.Sleep(1000);
                Exercise();
            }
            else
            {
                pictureBox5.Enabled = true;
                textBox1.Text = "Oops!!";
                count = 0;
            }
            flag = false;
           
  

        }
    //  flashing button when pressed by player
        public void MyBlincking(PictureBox pb)
        {
           
            imageTmp = pb.Image;
            pb.Image = Gold;
            pb.Update();
            Thread.Sleep(100);
            pb.Image = imageTmp;
            pb.Update();


        }
        

    }
}
