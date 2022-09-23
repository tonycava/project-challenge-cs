using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;
using Project_CS.Assets.Script;

namespace Game.Test
{
  public class Blubble : Enemy.EnemyStats
  {
    private int _damage = 10;
    
    public int Damage
    {
      get { return _damage; }
      set { _damage = value;  }
    }

    public static void Test()
    {
      Engine.logger.Log("Im here");
    }
  }
}