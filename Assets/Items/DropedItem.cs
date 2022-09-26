using CLIPixelEngine.Engine;
using CLIPixelEngine.Engine.Generic;

namespace Game.EntityHandler.Items;

public class DropedItem : Entity
{
  public Equipment item;

  public DropedItem(Equipment equipment)
  {
    item = equipment;
    Position = Engine.entities["player"][0].Position;
  }
}