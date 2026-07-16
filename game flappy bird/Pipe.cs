namespace game_flappy_bird
{
    public class Pipe : Entity, IUpdatable, ICollidable
    {
        private int _OldX;
        private float _xReal;
        public int GapSize { get; set; } = 4;
        public bool Passed { get; set; } = false;
        public Pipe(int x) : base(x, 0)
        {
            Random rnd = new Random();
            _xReal = x;
            Y = rnd.Next(2, Console.WindowHeight - GapSize - 2);
            _OldX = x;
            this.Width = 2;
            this.Height = GapSize;
        }

        public override void Update(float dt)
        {
            _OldX = X;
            _xReal -= (GameManager.gameSpeed * dt);
            X = (int)_xReal;
            if (X < 0) IsActive = false;
        }

        public override void Draw()
        {
            //chỉ vẽ nếu ống nằm trong vùng màn hình
            if (X < 0 || X >= Console.WindowWidth) return;

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Y; i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("||");
            }
            for (int i = Y + GapSize; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("||");
            }
            Console.ResetColor();
        }
        public override void Clear()
        {
            if (_OldX < 0 || _OldX >= Console.WindowWidth) return;
            //xóa sạch cột tại vị trí cũ bằng cách quét toàn bộ chiều cao màn hình
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(_OldX, i);
                Console.Write("  ");
            }
        }

        public MyRectangle GetBounds()
        {
            //khe gap an toàn
            return new MyRectangle(X, Y, Width, Height);
        }
        
    }
}