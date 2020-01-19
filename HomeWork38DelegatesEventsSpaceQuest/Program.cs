using System;
using System.Threading;

namespace HomeWork38DelegatesEventsSpaceQuest
{
    class Program
    {
        //this timer is needed to access the timer from the outside.
        static Timer timerG;
        // timer starts this function
        static void elapsedFunction(object obj)
        {
            Random ran = new Random();
            int value = ran.Next(1, 4);
            Console.WriteLine("Timer");
            SwitchFunction((SpaceQuestGameManager)obj);
        }
        //random choice which function to call
        static void SwitchFunction(SpaceQuestGameManager sqm)
        {
            Random ran = new Random();
            Random ran1 = new Random();
            int value = ran.Next(1, 4);
            switch (value)
            {
                case 1:
                    int x = ran1.Next(0, 100);
                    int y = ran1.Next(0, 100);
                    sqm.MoveSpaceShip(x, y);
                    break;
                case 2:
                    int ememyShipsNum = ran1.Next(1, 10);
                    sqm.EnemyShipsDestroyed(ememyShipsNum);
                    break;
                case 3:
                    int demaged = ran1.Next(1, 5);
                    sqm.GoodSpaceShipGotDamaged(demaged);
                    break;

                case 4:
                    int extra = ran1.Next(1, 10);
                    sqm.GoodSpaceShipGotDamaged(extra);
                    break;

            }
            Thread.Sleep(500);
        }
        // timer switching
        static void timerStartStop(object sender, TimerEventArgs args)
        {         
            if (args.startStop)
            {
                //timer restart
                timerG.Change(0, 1000);
            }
            else
            {
                //timer interrupt
                timerG.Change(Timeout.Infinite, Timeout.Infinite);
            }

        }
        static void Main(string[] args)
        {
       
            GameViewer gv = new GameViewer();
            SpaceQuestGameManager sqm = new SpaceQuestGameManager(10, 50, 50, 10);
            Timer timer = new Timer(elapsedFunction, sqm, 0, 1000);
            timerG = timer;
            sqm.GoodSpaceShipLocationChanged += gv.GoodSpaceShipLocationChangedEventHandler;
            sqm.GoodSpaceShipHPChanged += gv.GoodSpaceShipHPChangedEventHandler;
            sqm.GoodSpaceShipDestroyed += gv.GoodSpaceShipDestroyedEventHandler;
            sqm.BadShipsExploded += gv.BadShipsExplodedEventHandler;
            sqm.LevelUpReached += gv.LevelUpReachedEventHandler;
            sqm.TimerStartStop += timerStartStop;

            while (SpaceQuestGameManager.flag)
            {
                SwitchFunction(sqm);
            }

            timer.Dispose();
           // Console.ReadLine();
        }
    }
}
