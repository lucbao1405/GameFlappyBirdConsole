using game_flappy_bird;
using System;
using System.Threading;

namespace game_flappy_bird
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 20);
            new GameManager().Run();
        }
    }
}