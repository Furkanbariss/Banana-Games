


namespace Banana_Games.Sudoku
{
    internal class NumpadGrid4Dialog
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }
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