using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class Bird
    {
        public int X { get; set; } = 5; 
        public int Y { get; set; } = 10;
        public void Move() { Y++; }
        public void Jump() { Y -= 2; }
        public void Draw() { Console.SetCursorPosition(X, Y); Console.Write(">|>"); }
    }
}
