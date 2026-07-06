using System;
using System.Collections.Generic;
using System.Text;

namespace game_flappy_bird
{
   
  public interface ICollidable
    {
      bool IsCollidingWith(int x, int y);
    }
    
}
