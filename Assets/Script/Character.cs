using System.Diagnostics;
using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Items;

namespace Game.Test
{
  public class Character : LivingEntity
  {
    public Character()
    {
      damage = 10;
      life = 50;
    }

    public Character(Vector2Int position, string path) : base(position, path)
    {
      damage = 10;
      life = 50;
    }

    public override void DealDamage(int enemyAttack, LivingEntity currentEntity, LivingEntity Attacker)
    {
      life -= enemyAttack;
      
      if (life <= 0) Process.GetCurrentProcess().Kill();
    }

    public override void Attack(LivingEntity currentEntity, LivingEntity Attacker)
    {
      Attacker.DealDamage(damage, Attacker, currentEntity);
    }
  }
}