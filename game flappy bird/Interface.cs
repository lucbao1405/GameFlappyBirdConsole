
// Đưa các interface về cùng namespace game_flappy_bird để dễ sử dụng
namespace game_flappy_bird
{
    // Giao diện cho đối tượng có thể vẽ
    public interface IDrawable
    {
        void Draw();
        void Clear();
    }

    // Giao diện cho đối tượng có thể cập nhật mỗi frame
    public interface IUpdatable
    {
        void Update(float dt);
    }

    // Giao diện cho đối tượng có thể va chạm
    // Trả về MyRectangle (struct trong cùng namespace) để tránh phụ thuộc System.Drawing
    public interface ICollidable
    {
        MyRectangle GetBounds();
    }
}
