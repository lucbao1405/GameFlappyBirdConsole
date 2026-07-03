using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
    public class GameManager
    {
        private Bird bird = new Bird(5, 10);
        private List<Pipe> pipes = new List<Pipe>();
        private Random rnd = new Random();
        private bool isGameOver = false;

        public void Run()
        {
            while (!isGameOver)
            {
                if (Console.KeyAvailable) { var k = Console.ReadKey(true).Key; if (k == ConsoleKey.Spacebar) bird.Jump(); }

                bird.Move();
                UpdatePipes();
                CheckCollision();

                Console.Clear();
                bird.Draw();
                foreach (var p in pipes) p.Draw();

                Thread.Sleep(80);
            }
            Console.Clear();
            Console.WriteLine("GAME OVER!");
        }

        private void UpdatePipes()
        {
            if (pipes.Count == 0 || pipes[pipes.Count - 1].X < 30)
                pipes.Add(new Pipe(59, rnd.Next(2, 12)));

            foreach (var p in pipes) p.Move();
            if (pipes.Count > 0 && pipes[0].X < 0) pipes.RemoveAt(0);
        }

        private void CheckCollision()
        {
            if (bird.Y <= 0 || bird.Y >= 19) isGameOver = true;
            foreach (var p in pipes)
                if (bird.X == p.X && (bird.Y < p.GapY || bird.Y > p.GapY + p.GapSize)) isGameOver = true;
        }
    }
}
