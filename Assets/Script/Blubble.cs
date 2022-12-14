using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Items;

namespace Game.Test;

public class Blubble : LivingEntity
{
  public Blubble()
  {
    damage = 10;
    life = 30;
  }

  public Blubble(Vector2Int position, string path) : base(position, path)
  {
    damage = 10;
    life = 30;
    inventory.Add((Equipment) EquipmentManager.singleton.getEquipment(1).Clone());
  }

  public override void DealDamage(int enemyAttack, LivingEntity currentEntity, LivingEntity Attacker)
  {
    life -= enemyAttack;
    if (life <= 0)
    {
      Engine.entities["enemy"].Remove(currentEntity);
      onDeath();
    }
    else
    {
      Attack(currentEntity, Attacker);
    }
  }

  public override void Attack(LivingEntity currentEntity, LivingEntity Attacker)
  {
    Attacker.DealDamage(damage, Attacker, currentEntity);
  }
}