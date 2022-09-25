using Game.EntityHandler.Items;

namespace CLIPixelEngine.Engine.Generic;

public class EquipementEntity : Entity
{
  public Equipment equipment;
  public EquipementEntity(Equipment equipment) : base()
  {
    this.equipment = equipment;
    this.Sprite = equipment.sprite;
  }
}