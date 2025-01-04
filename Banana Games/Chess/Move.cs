using System;
using System.Collections.Generic;
using System.Text;

namespace Banana_Games.Chess
{
    public class Move
    {
        //Hareketin Başladığı ve bittiği kareleri temsil ederiz.
        public int StartTile { get; set; } // get ve set tanımlanmadığım için normal variable gibi düşünebilriz.
        public int EndTile { get; set; }

        //yapıcı metottur. Diğer classlarda çağırdığımda değer atamak zorunda kalmamak ve daha anlaşılır yapı için kullandım.
        public Move() { }

        // sınıfın özelliklerine (property'lerine) başlangıç değerleri atamak için kullandım.
        public Move(int startTile, int endTile)
        {
            this.StartTile = startTile;
            this.EndTile = endTile;
        }
    }
}
