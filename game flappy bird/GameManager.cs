using System;

namespace game_flappy_bird
{
    public class GameManager
    {
        //khởi tạo các đối tượng và biến
        private Bird _bird;
        private List<Pipe> _pipes;
        private bool _isRunning = true;
        private int _score = 0;
        public static float gameSpeed = 10;

        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;
            _bird = new Bird(5, 10);
            _pipes = new List<Pipe>();
            float lastTime = Environment.TickCount;

            while (_isRunning)
            {
                float currentTime = Environment.TickCount;
                float dt = (currentTime - lastTime) / 1000f;
                lastTime = currentTime;

                //làm sạch khung hình cũ
                _bird.Clear();
                foreach (var p in _pipes) p.Clear();

                //gọi phương thức nhảy
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar) _bird.Jump();
                }

                _bird.Update(dt);
                foreach (var pipe in _pipes)
                {
                    pipe.Update(dt);
                    if (CheckCollision(_bird, pipe)) _isRunning = false;
                    if (!pipe.Passed && pipe.X < _bird.X)
                    {
                        _score++;
                        pipe.Passed = true;

                    }
                }

                //xử lý danh sách cột
                _pipes.RemoveAll(p => !p.IsActive);
                if (_pipes.Count == 0 || _pipes[_pipes.Count - 1].X < 40)
                    _pipes.Add(new Pipe(Console.WindowWidth - 1));

                if (!_bird.IsActive) _isRunning = false;

                //vẽ lại chim
                _bird.Draw();
                foreach (var p in _pipes) p.Draw();
                Thread.Sleep(16);

                //khi va cham/roi
                if (!_isRunning)
                {
                    int centerX = Console.WindowWidth / 2 - 5;
                    int centerY = Console.WindowHeight / 2;

                    Console.SetCursorPosition(centerX, centerY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" GAME OVER ");

                    Console.SetCursorPosition(centerX, centerY + 1);
                    Console.Write($" Diem: {_score} ");
                    Console.ResetColor();

                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    Console.Write("Nhan Space de choi lai, Esc de thoat...");
                    while (true)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Spacebar)
                        {
                            _score = 0;
                            _pipes.Clear();
                            _bird = new Bird(5, 10);
                            _isRunning = true;
                            Console.Clear();
                            //cập nhật lại thời gian
                            lastTime = Environment.TickCount;
                            break;
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
                }
                Console.Title = $"Game Flappy Bird                                           Score: {_score}";
            }
        }
        private bool CheckCollision(Bird bird, Pipe pipe)
        {
            //lấy bounding box của chim (trả về MyRectangle)
            MyRectangle bRect = bird.GetBounds();

            //tạo 2 vùng va chạm cho ống (phần ống trên và phần ống dưới)
            MyRectangle topPipe = new MyRectangle(pipe.X, 0, 2, pipe.Y);
            MyRectangle botPipe = new MyRectangle(pipe.X, pipe.Y + pipe.GapSize, 2, Console.WindowHeight - (pipe.Y + pipe.GapSize));

            //nếu không an toàn thì là va chạm -> trả về true
            return !bRect.IsSafe(topPipe, botPipe);
        }
    }
}