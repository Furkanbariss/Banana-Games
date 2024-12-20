using System;
using System.Collections.Generic;
using System.Text;

/* Bu dosya, AI'nin (yapay zekanın) hareket değerlendirmesi için bir temel oluşturur.
 * Bu sınıf sayesinde sadece bir hareketi değil, aynı zamanda bu hareketin tahtadaki değerini (skorunu) da tutabiliyoruz.*/
namespace Banana_Games.Chess
{
    public class MoveWithScore
    {
        public Move Move { get; set; }
        public int Score { get; set; }
        public double CalculationTime { get; set; }  // yapay zekanın hamleyi yapma süresi

        public MoveWithScore(int score) {
            this.Score = score;
            Move = null; // yapay zeka önce puanlamayı yapıyor daha sonra en büyük puanlı hareketi null yerine atıyor.
        }
    }
}
