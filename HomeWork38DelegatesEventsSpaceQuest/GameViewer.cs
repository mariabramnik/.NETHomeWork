using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork38DelegatesEventsSpaceQuest
{
    class GameViewer
    {
        public void GoodSpaceShipHPChangedEventHandler(object sender, PointsEventArgs args)
        {
           
            Console.WriteLine($"MyCuttentHitPoints : {args.HitPoints}");
        }
        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs args)
        {
            Console.WriteLine($"GoodSpaceShipLocation X = {args.X}  Y = { args.Y}");
        }
        public void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs args)
        {
            Console.WriteLine($"GoodSpaceShipLocation X = {args.X}  Y = { args.Y}");
        }
        public void LevelUpReachedEventHandler(object sender, LevelEventArgs args)
        {
            Console.WriteLine($"My CurrentLevel  : {args.level}");
        }
        public void BadShipsExplodedEventHandler(object sender, BadShipsExplodedEventArgs args)
        {
            Console.WriteLine($"BadShipsExploded : {args.BadShipsExploded}");
        }
    }

}
