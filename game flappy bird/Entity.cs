using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public abstract class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Icon { get; set; }
        public abstract void Draw();
        public abstract void Move();
    }
}
