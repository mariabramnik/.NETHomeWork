using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker;
        Random ran = new Random();
        int num1 = 0;
        int num2 = 0;
        int res = -1;


        public MainWindow()
        {
            InitializeComponent();
            Label3.Content = "";
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            TextBoxResult.Text = "";
            ButtonStart.IsEnabled = false;
            num1 = ran.Next(1, 9);
            num2 = ran.Next(1, 9);
            res = num1 * num2;
            string str = TextBoxResult.Text;
            TextBox1.Text = num1.ToString();
            TextBox2.Text = num2.ToString();
           // TextBoxResult.Focus();
                   
            Label3.Content = "Enter your answer";

            //create backgroundWorker -  thread's wrapper
            worker = new BackgroundWorker();
            // DoWork - Mainfunction of working thread
            worker.DoWork += worker_DoWork;
            // set to the worker  worker_ProgressChanged function that will be called when calling worker.ReportProgress      
            worker.ProgressChanged += worker_ProgressChanged;
            // set to the worker worker_RunWorkerCompleted function that will be called when thread is completed
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            // flag for ReportsProgress
            worker.WorkerReportsProgress = true;
            // flag what is possible cancellation worker thread
            worker.WorkerSupportsCancellation = true;
            //worker thread start
            worker.RunWorkerAsync();
        }
        //this is a base function of the working thread
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           // from sender get worker
            BackgroundWorker worker = sender as BackgroundWorker;
            //int? res = e.Argument as int?;
            //get current time = start time
            int time = Environment.TickCount;
            //run while current time <= starttime + 5 sec
            while ((time + 5000) > Environment.TickCount)
            {
                //through ReportProgress get access to UI elements and check a response from user
                worker.ReportProgress(0);
                // check if working thread is finished
                if (worker.CancellationPending)
                {
                    // if it is finished, then exit
                    e.Cancel = true;
                    break;
                }
                //we put the working thread to sleep so that the mainThread can update (why do the thrads block each other without a slip?)
                Thread.Sleep(200);
            }
        }
        //checking the response from the user
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //int res = e.ProgressPercentage;
            string str = TextBoxResult.Text;
            if (str == res.ToString())
            {
                Label3.Content = "Answer is correct!!!";
                // if the answer is correct then we cancel the working thread.
                worker.CancelAsync();
            }
        }

        /*private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }*/
        //at the cancel of the working thread this function is called
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             if (e.Cancelled)
            {
                //if the user’s answer was correct, 
                //then we completed the working thread using worker.CancelAsync() and do nothing
              
            }
            else
            {
                // if the user’s answer was not correct, 
                //then we go here and enter the answer. we are in main thread now
                Label3.Content = "Error!!";
                int num1 = int.Parse(TextBox1.Text);
                int num2 = int.Parse(TextBox2.Text);
                TextBoxResult.Text = (num1 * num2).ToString();
            }
            ButtonStart.IsEnabled = true;
           
        }


    }
}
