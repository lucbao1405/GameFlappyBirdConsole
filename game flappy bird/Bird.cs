using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class Bird : Entity
    {
        public Bird(int x, int y) { X = x; Y = y; Icon = 'O'; }
        public override void Draw() { Console.SetCursorPosition(X, Y); Console.Write(Icon); }
        public override void Move() { Y++; } // Rơi tự do
        public void Jump() { Y -= 2; }
    }
}
