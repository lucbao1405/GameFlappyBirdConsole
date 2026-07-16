using System;
using System.Collections.Generic;
using System.Threading;

namespace game_flappy_bird
{
    class Program
    {
        static void Main(string[] args)
        {
            //thiết lập cửa sổ Console
            Console.Title = "Flappy Bird Console";
            Console.CursorVisible = false;

            Console.WindowWidth = 80;
            Console.WindowHeight = 25;
            Console.BufferWidth = 80;
            Console.BufferHeight = 25;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //gọi gamemanager lên để chạy
            GameManager game = new GameManager();
            game.Start();
        }
    }
}