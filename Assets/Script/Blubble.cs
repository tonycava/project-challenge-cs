using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;

namespace Game.Test
{
  public class Blubble : Enemy.EnemyStats
  {
    public int _damage = 10;
    public int _life = 30;

    public int Damage
    {
      get { return _damage; }
    }

    public int Life
    {
      get { return _life; }
      set { _life = value; }
    }

    public void DealDamage(int enemyAttack, Entity entity)
    {
      _life -= enemyAttack;
      if (_life <= 0)
      {
        Engine.entities["enemy"].Remove(entity);
      }
    }
  }
}