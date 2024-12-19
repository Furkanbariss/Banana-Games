


namespace Banana_Games.Sudoku
{
    internal class NumpadGrid9Dialog
    {
        public int Height { get; internal set; }
        public int Width { get; internal set; }
        public Point Location { get; internal set; }
        public Action<object, FormClosedEventArgs> FormClosed { get; internal set; }
        public int Value { get; internal set; }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}