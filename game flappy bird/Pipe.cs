using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class Pipe
    {
        public int X { get; set; }
        public int GapY { get; set; }
        public int GapSize { get; set; } = 5;

        public Pipe(int x, int gapY) { X = x; GapY = gapY; }
        public void Move() { X--; }
        public void Draw()
        {
            if (X < 0 || X >= 60) return;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(X, i);
                if (i < GapY || i > GapY + GapSize) Console.Write("|");
                else Console.Write(" ");
            }
        }
    }
}
   