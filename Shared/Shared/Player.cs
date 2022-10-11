//using Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isReady { get; set; }
        public int X;
        public int Y;

        /*
        public override void UpdateCordinatesFirstPlayer(string cordinates)
        {
            string[] splited = cordinates.Split(',');

            X = Convert.ToInt32(splited[0]);
            Y = Convert.ToInt32(splited[1]);
        }

        */
        //Coordinates and all the other stuff
    }
}
