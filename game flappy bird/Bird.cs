using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class Bird : Entity
    {
        public Bird() { X = 5; Y = 10; }

        public void Move() { Y++; }
        public void Jump() { Y -= 2; }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(">|>");
        }
    }
}
