using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class Pipe : ICollidable
    {
        public int X { get; set; }
        public int GapY { get; set; }
        public int GapSize { get; set; } = 5;

        public void Draw()
        {
            int height = Console.WindowHeight;
            int maxX = Math.Max(0, Console.WindowWidth - 2);

            if (X < 0 || X > maxX)
                return;


            for (int y = 0; y < GapY; y++)
            {
                Console.SetCursorPosition(X, y);
                Console.Write("||");
            }

  
            for (int y = GapY + GapSize; y < height; y++)
            {
                Console.SetCursorPosition(X, y);
                Console.Write("||");
            }
        }
        public void Move()
        {
            X--;
        }
        public Pipe(int x, int gapY)
        {
            X = x;
            GapY = gapY;
        }
        public bool IsCollidingWith(int birdX, int birdY)
        {
       
            bool sameColumn = (birdX == this.X) || (birdX == this.X + 1);
            if (sameColumn)
            {
    
                if (birdY < GapY || birdY >= GapY + GapSize)
                    return true;
            }
            return false;
        }
    }
}
   