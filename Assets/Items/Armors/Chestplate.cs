using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Chestplate : Equipment
{
  public Chestplate()
  {
    name = "Chestplate";
    sprite = new Bitmap("./Assets/Items/Armors/Chestplate.png");
    damage_bonus = 10;
    defense_bonus = 10;
  }

  public override object Clone()
  {
    var chestplate = new Chestplate();
    chestplate.id = id;
    return chestplate;
  }
}