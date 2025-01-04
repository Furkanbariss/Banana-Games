using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 
     Bu sayfada Sabit ve Değiştirilmeyecek değerler tanımladım.(taraflar,Taşlar ve Hareketler).
     Aynı kategoride veriler tanımlayacağım için ve ilerde kafa karişikliğini önlemek için. Enum kullandım.
*/
namespace Banana_Games.Chess
{
    public enum Player
    {
        Black,
        White,
    }

    public enum Type { 
    
        // Beyaz taşlar
        wRook, //kale
        wKnight, //At
        wBishop, //fil
        wQueen, // vezir
        wKing, //Şah
        wPawn, // piyon

        // siyah taşlar
        bRook,
        bKnight,
        bBishop,
        bQueen,
        bKing,
        bPawn,
        
    }

    //  0-63 arasındaki tek boyutlu bir konumu iki boyutlu X ve Y kordinatlarına çevirdim. kullanıcı daha kolay anlayabilsin diye
    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinate(int location) {

            y = location / 8;
            x = location - (y * 8); 
        }
    }

    public struct Vectors
    {
        // at'ın hareketleri
        public const int AtUpLeft = 15;
        public const int AtUpRight = 17;
        public const int AtDownLeft = -17;
        public const int AtDownRight = -15;
        public const int AtLeftUp = 6;
        public const int AtLeftDown = -10;
        public const int AtRightUp = 10;
        public const int AtRightDown = -6;

        //Diğer Taşlar
        public const int up = 8;
        public const int down = -8;
        public const int left = -1;
        public const int right = 1;
        public const int upLeft = 7;
        public const int upRight = 9;
        public const int lowLeft = -9;
        public const int lowRight = -7;
    }
}
