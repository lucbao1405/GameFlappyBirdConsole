using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace game_flappy_bird
{
    public struct MyRectangle
    {
        public int X, Y, Width, Height;

        public MyRectangle(int x, int y, int width, int height)
        {
            X = x; Y = y; Width = width; Height = height;
        }

        //kiểm tra va chạm bằng hình chữ nhật
        public bool IsSafe(MyRectangle pipeTop, MyRectangle pipeBottom)
        {
            //nếu chim chạm vào ống trên hoặc ống dưới thì là va chạm
            if (this.IntersectsWith(pipeTop) || this.IntersectsWith(pipeBottom))
                return false;
            //không va chạm = safe
            return true;
        }

        public bool IntersectsWith(MyRectangle other)
        {
            return (X < other.X + other.Width &&
                    X + Width > other.X &&
                    Y < other.Y + other.Height &&
                    Y + Height > other.Y);
        }
    }
}
