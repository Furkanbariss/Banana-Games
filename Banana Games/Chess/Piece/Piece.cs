using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Banana_Games.Chess.Piece
{
    public abstract class Piece // Taşların ortak özelliklerini ve davranışlarını bir temel sınıf altında toplamak. için abstract kullandım. 
    {
        private Type _piece;  // Taşın türü.Type enum'unda tanımlanmıştır (ConstantVariable.cs).
        private Player _player; // Taşın hangi oyuncuya ait olduğu. 
        private bool _moved;  // Taşın daha önce hareket edip etmediğini tutar. rok ve piyonların ilk hareketinde kullanılacak.

        public Coordinate _position; // Taşın tahtadaki konumunu saklar

        // taşın temel bilgilerini dışarıdan okunabilir hale getirmek için get kullandım.
        public Type GetPiece { get => _piece; }
        public Player Player { get => _player; }
        public bool Moved { get => _moved; }

        //Taşın hareket edip etmediğini dışarıdan değiştirmek için
        public void SetMoved(bool moved)
        {
            _moved = moved;
        }

        //Taşın tahtadaki yerini günceller.
        public void ChangePosition(int position)
        {
            _position = new Coordinate(position);
        }

        // Başlangıçta daha az satırda kodla değer atamak için yazdık.
        public Piece(Type piece, Player player, int position)
        {
            _position = new Coordinate(position);
            _player = player;
            this._piece = piece; // istersek böylede yazabiliriz ama gerek yok.
            _moved = false;
        }

        public abstract List<int> LegalMoves(int tile, Board board);
    }
}
