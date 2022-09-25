using Game.EntityHandler.Items;

namespace CLIPixelEngine.Engine.Generic;

public abstract class LivingEntity : Entity
{
  public LivingEntity() : base()
  {
    inventory = new List<Equipment>();
  }
  public LivingEntity(Vector2Int position, string path) : base(position, path)
  {
    inventory = new List<Equipment>();
  }
    
  public int life { get; set; }
  public int damage { get; set; }
    
  public List<Equipment> inventory { get; set; }
  

  public abstract void DealDamage(int enemyAttack, LivingEntity currentEntity, LivingEntity attacker);
  public abstract void Attack(LivingEntity currentEntity, LivingEntity attacker);

  public void onDeath()
  {
    List<Entity> equipementEntities = new List<Entity>();
    foreach (Equipment equipment in inventory)
    {
      EquipementEntity equipementEntity = new EquipementEntity(equipment);
      equipementEntity.Position = Position;
      equipementEntities.Add(equipementEntity);
    }
    if(Engine.entities.ContainsKey("items"))
    {
      Engine.entities["items"].AddRange(equipementEntities);
    }
    else
    {
      Engine.entities.Add("items", equipementEntities);
    }
    Engine.renderer.Draw();
  }
}