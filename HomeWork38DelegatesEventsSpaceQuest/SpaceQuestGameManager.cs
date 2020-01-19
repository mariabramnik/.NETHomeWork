using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork38DelegatesEventsSpaceQuest
{
    class SpaceQuestGameManager
    {
        public static bool flag = true;
        int _currentLevel = 1;
        private int _goodSpaceShipHitPoints = 10;
        private int _shipXLocation = 50;
        private int _shipYLocation  = 50;
        private int _numberOfBadShips = 10;
        private bool _timerStartStop = false;
        public event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;
        public event EventHandler<TimerEventArgs> TimerStartStop;
        public SpaceQuestGameManager(int goodSpaceShipHitPoints, int shipXLocation, int shipYLocation, int numberOfBadShips)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _numberOfBadShips = numberOfBadShips;
        }
        public void MoveSpaceShip(int newX,int newY)
        {
            _shipXLocation =  newX;
            _shipYLocation = newY;
            OnGoodSpaceShipLocationChanged(_shipXLocation, _shipYLocation);

        }
        public void GoodSpaceShipGotDamaged(int damage)
        {
            _goodSpaceShipHitPoints -= damage;
            OnGoodSpaceShipHPChanged();
            if(_goodSpaceShipHitPoints <= 0 )
            {
                Console.WriteLine("The end");
                Console.WriteLine("You lose.");
                Console.Write("To exit press e  "); Console.Write("To continue press c  ");
                _timerStartStop = false;
                OnTimerStartStop();
                string answer = Console.ReadLine();
                if (answer == "c")
                {
                    Console.WriteLine("Start a new game,GOOD LOOK!");
                    _currentLevel = 1;
                    _goodSpaceShipHitPoints = 10;
                    _shipXLocation = 50;
                    _shipYLocation = 50;
                    _numberOfBadShips = 10;
                    _timerStartStop = true;
                    OnTimerStartStop();
                }
                else
                {
                    flag = false;
                    return;

                }
                _currentLevel = 1;
                _goodSpaceShipHitPoints = 10;
                _shipXLocation = 50;
                _shipYLocation = 50;
                _numberOfBadShips = 10;
                OnGoodSpaceShipDestroyed();
            }
        }
        public void GoodSpaceShipGotExtraHp(int extra)
        {
            _goodSpaceShipHitPoints += extra;
            OnGoodSpaceShipHPChanged();
        }
        public void EnemyShipsDestroyed(int numberOfBadShipsDestroyed)
        {
            _numberOfBadShips -= numberOfBadShipsDestroyed;
            _goodSpaceShipHitPoints += 1;
            OnBadShipsExploded();
            if(_numberOfBadShips == 0 || _numberOfBadShips < 0)
            {
                if (_currentLevel == 3)
                {
                    Console.WriteLine("The end");
                    Console.WriteLine("Congratulations! You won.");
                    Console.Write("To exit press e  "); Console.Write("To continue press c  ");
                    _timerStartStop = false;
                    OnTimerStartStop();
                    string answer = Console.ReadLine();
                    if (answer == "c")
                    {
                        Console.WriteLine("Start a new game,GOOD LOOK!");
                        _currentLevel = 1;
                        _goodSpaceShipHitPoints = 10;
                        _shipXLocation = 50;
                        _shipYLocation = 50;
                        _numberOfBadShips = 10;
                        _timerStartStop = true;
                        OnTimerStartStop();
                    }

                    else
                    {
                        flag = false;
                    }

                }
                _currentLevel += 1;
                 OnLevelUpReached();
                 _goodSpaceShipHitPoints = 10;
                 _numberOfBadShips = 10 + _currentLevel * 3;
                

            }
        }
        
 

        public void OnGoodSpaceShipHPChanged()
        {
            if(GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this, new PointsEventArgs { HitPoints = _goodSpaceShipHitPoints });
            }
        }
        public void OnGoodSpaceShipLocationChanged(int _x,int _y)
        {
            GoodSpaceShipLocationChanged.Invoke(this, new LocationEventArgs { X = _x, Y = _y });
        }
        public void OnGoodSpaceShipDestroyed()
        {

            GoodSpaceShipDestroyed.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
        }
        public void OnBadShipsExploded()
        {
            int currentBadShipsNumber = 10 - _numberOfBadShips;
            BadShipsExploded.Invoke(this, new BadShipsExplodedEventArgs { BadShipsExploded = currentBadShipsNumber });
         
        }
        public void OnLevelUpReached()
        {
            LevelUpReached.Invoke(this, new LevelEventArgs { level = _currentLevel });
        }
        public void OnTimerStartStop()
        {
            TimerStartStop.Invoke(this, new TimerEventArgs { startStop = _timerStartStop });
        }

    }
}
