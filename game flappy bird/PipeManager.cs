using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{

    public class PipeManager
    {
        private List<Pipe> pipes = new List<Pipe>();
        private Random rnd = new Random();
        private int score = 0;

        public void UpdatePipes()
        {
            if (pipes.Count == 0 || pipes[pipes.Count - 1].X < 30)
                pipes.Add(new Pipe(59, rnd.Next(2, 12)));

            foreach (var p in pipes)
            {
                // Kiểm tra nếu cột vừa đi qua vị trí chim (X = 5)
                if (p.X == 5) score++;
                p.Move();
            }

            if (pipes.Count > 0 && pipes[0].X < 0) pipes.RemoveAt(0);
        }

        public int GetScore() => score;

        public void DrawPipes() { foreach (var p in pipes) p.Draw(); }

        public bool CheckCollision(Bird bird)
        {
            foreach (var p in pipes)
            {
                if (p.IsCollidingWith(bird.X, bird.Y))
                    return true;
            }
            return false;
        }

    }
}

