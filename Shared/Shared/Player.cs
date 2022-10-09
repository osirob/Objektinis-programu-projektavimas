using Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared
{
    public class Player :Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isReady { get; set; }
        public int X;
        public int Y;

        public override void UpdateCordinatesFirstPlayer(string cordinates)
        {
            throw new NotImplementedException();
        }


        //Coordinates and all the other stuff
    }
}
