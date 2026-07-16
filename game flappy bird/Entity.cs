using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace game_flappy_bird
{
    public abstract class Entity
    {
        //thuộc tính vị trí
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Entity(int x, int y)
        {
            X = x;
            Y = y;
        }
        //set kích thước của vật thể
        public int Width { get; set; } = 1;
        public int Height { get; set; } = 1;

        //kiểm tra hoạt động
        public bool IsActive { get; set; } = true;
        public virtual void Update(float dt) { }
        public abstract void Draw();
        public abstract void Clear();
        public ConsoleColor color { get; set; } = ConsoleColor.White;
    }
}
