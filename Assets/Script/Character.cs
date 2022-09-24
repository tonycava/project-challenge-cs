using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;

namespace Game.Test
{
  public class Character : Enemy.EnemyStats
  {
    public int _damage = 15;
    public int _life = 50;

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
      Engine.logger.Log("here");

      _life -= enemyAttack;
      if (_life <= 0)
      {
        Engine.logger.Log("char");
        Engine.entities["enemy"].Remove(entity);
      }
    }
  }
}