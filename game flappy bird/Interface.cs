
namespace game_flappy_bird
{
    public interface IDrawable
    {
        void Draw();
        void Clear();
    }
    public interface IUpdatable
    {
        void Update(float dt);
    }

    public interface ICollidable
    {
        MyRectangle GetBounds();
    }
}
