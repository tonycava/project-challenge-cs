using CLIPixelEngine.Engine.Generic;

namespace Game.Test;

public class Enemy
{
  public interface EnemyStats
  {
    public int Damage { get; }
    public int Life { get; set; }

    public void DealDamage(int enemyAttack, Entity entity);
  }
}