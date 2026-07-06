using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class GameManager
    {
        private Bird bird = new Bird();
        private PipeManager pipeManager = new PipeManager();
        private bool isGameOver = false;
        private int score = 0;

        public void Run()
        {
            //Màn hình bắt đầu
            Console.Clear();
            Console.WriteLine("NHAN PHIM SPACE DE BAT DAU");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            //Vòng lặp chính
            while (!isGameOver)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) bird.Jump();

                bird.Move();
                pipeManager.UpdatePipes();

                //Tính điểm: cộng điểm mỗi khi vượt qua cột (dựa trên X)
                score = pipeManager.GetScore();

                if (bird.Y <= 0 || bird.Y >= 19 || pipeManager.CheckCollision(bird)) isGameOver = true;

                Console.Clear();
                bird.Draw();
                pipeManager.DrawPipes();
                Console.SetCursorPosition(0, 0);
                Console.Write("SCORE: " + score);

                Thread.Sleep(80);
            }

            //Màn hình kết thúc
            Console.Clear();
            Console.WriteLine("GAME OVER! DIEM CUA BAN: " + score);
        }
    }
}

