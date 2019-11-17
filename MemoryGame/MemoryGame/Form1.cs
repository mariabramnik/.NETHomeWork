using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace MemoryGame
{
    public partial class Form1 : Form
    {
        bool flagPlayer = true;
        bool flag = false;
        int size = 0;
        Button[,] buttonArr;
        List<int> list;
        List<int> randomList = new List<int>();
        int x = 0;
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer aTimer1;
        private static System.Timers.Timer aTimer2;
        string btnPress = "";
        Button btmp;
        Button btmp1;
        Button bprev;
        bool result = false;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check that the user entered the field size correctly;
            #region
            string str = comboBox1.SelectedItem.ToString();
            int num = Int32.Parse(str);
            size = num;
            int count = 0;
            #endregion
            //  Clean and prepare the form for a new game;
            #region
            Control[] arr = new Control[this.Controls.Count];
            Button b = new Button();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                arr[i] = Controls[i];
            }
            foreach (var contr in arr)
            {
                if (contr.GetType() == b.GetType())
                {
                    contr.Dispose();
                }
            }

           pictureBox1.Top = 271;
           pictureBox1.Height = 68;
           pictureBox2.Top = 271;
           pictureBox2.Height = 68;
            #endregion
           //fill the list with pairs of numbers
            MatrixFilling();
            //dynamically create a game field from buttons with text in form of numbers
            #region
            buttonArr = new Button[num, num];
            
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    count++;
                    string countStr = count.ToString();
                    Button button = new Button();
                    button.Name = countStr;
                    button.Text = randomList[x].ToString();
                    x++;                 
                    button.Size = new System.Drawing.Size(37, 37);
                    button.Left = (1 + button.Width) * i;
                    button.Top = (1 + button.Height) * j + 60;
                    button.Click += MyMethod;
                    this.Controls.Add(button);
                    buttonArr[i, j] = button;
                   

                }
                
            }
            #endregion
            // Create a timer with a 1.5 second interval.
            aTimer = new System.Timers.Timer(1500);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;


        }
        //fill the list randomly with pairs of numbers
        #region
        private void  MatrixFilling()
        {
          //how many pairs of numbers do we need
            int numbOfDigits = size * size / 2;
            int[] arr = new int[size * size];
             for (int i = 0; i < numbOfDigits;i++)
            {
                arr[i] = i + 1;
                arr[i + numbOfDigits] = arr[i];
            }
            list = arr.ToList();
            while(list.Count > 0)
            {
                int res = RandomFilling(list);
                randomList.Add(res);

            }

        }
        //randomly remove the numbers from list 
        private int RandomFilling(List<int>list)
        {
            var res = list[rand.Next(list.Count)];
            list.Remove(res);
            return res;
        }
        #endregion
        //at the beginning of the game after 1.5.seconds hide the text from the button
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            foreach (Button butt in buttonArr)
            {
                butt.ForeColor = System.Drawing.Color.Bisque;

            }
        }
        //if the player has not guessed, then briefly show the text of the current button, 
        //and then hide again
        private void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {

            
            btmp.ForeColor = System.Drawing.Color.Bisque;

            
        }
        //if the player has not guessed, then briefly show the text of the previous button, 
        //and then hide again
        private void OnTimedEvent3(Object source, ElapsedEventArgs e)
        {


            btmp1.ForeColor = System.Drawing.Color.Bisque;


        }
        //if the player has not guessed, then briefly show all the text, 
        //and then hide again
        private void OnTimedEvent4(Object source, ElapsedEventArgs e)
        {
            foreach (Button butt in buttonArr)
            {
                if (butt.Enabled != false)
                {
                    butt.ForeColor = System.Drawing.Color.Bisque;
                }

            }
        }
        //By Click the button
        private void MyMethod(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            // flag shows even or odd step
            if(flag == false)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            //flagPlayer shows whose step
            if(flagPlayer == true)
            {
                label3.Visible = false;
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label3.Visible = true;
            }
            //if guessed
            //the button cannot be pressed and the figure of the player(pictureBox) is growing
            if(btnPress != "" && bt.Text == btnPress)
            {
                bt.Enabled = false;
                bprev.Enabled = false;
                if (flagPlayer == true)
                {
                    pictureBox1.Height = pictureBox1.Height + 20;
                    pictureBox1.Top = pictureBox1.Top - 20;
                    
                }
                else
                {
                    pictureBox2.Height = pictureBox2.Height + 20;
                    pictureBox2.Top = pictureBox2.Top - 20;
                   
                }
              
                    btnPress = "";
                  
                
 
            }
            //if not guessed
            if(btnPress != "" && bt.Text != btnPress)
            {
                TextAppear(bt);
                HideText(bprev);
                // step moves to another player
                if (flagPlayer == true)
                {
                    flagPlayer = false;
                }
                else
                {
                    flagPlayer = true;
                }
                
                btnPress = "";
                bprev = null;
                AllMatrixAppear();
                
            }
            if (flag == true)
            {
                btnPress = bt.Text;
                bprev = bt;
  
            }

            //check if the game is over
            result = CheckEndGame();
            if(result == true)
            {
                if(pictureBox1.Top < pictureBox2.Top)
                {
                    MessageBox.Show("End Of The Game !!!The Blue won the game!!!");
                    
                }
                else
                {
                    MessageBox.Show("End Of The Game !!!The Rad won the game!!!");
                }
            }
        }
        //refresh the button text in our memory
        public void TextAppear(Button btn)
        {
            btmp = btn;
            btmp.ForeColor = System.Drawing.Color.Black;
            // Create a timer with a one second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent2;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
        public void HideText(Button btn)
        {
            btmp1 = btn;
            btmp1.ForeColor = System.Drawing.Color.Black;
            // Create a timer with a one second interval.
            aTimer1 = new System.Timers.Timer(800);
            // Hook up the Elapsed event for the timer. 
            aTimer1.Elapsed += OnTimedEvent3;
            aTimer1.AutoReset = false;
            aTimer1.Enabled = true;
        }
        public bool CheckEndGame()
        {
            bool res = true;
            foreach (Button butt in buttonArr)
            {
                if (butt.Enabled != false)
                {
                    res = false;
                }

            }
            return res;
        }
        //refresh the all buttons text in our memory
        public void AllMatrixAppear()
        {
            foreach (Button butt in buttonArr)
            {

                    butt.ForeColor = System.Drawing.Color.Black;
 

            }
           
            // Create a timer with a 1.5 second interval.
            aTimer2 = new System.Timers.Timer(1500);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent4;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

    }
}
