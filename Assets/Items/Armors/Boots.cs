using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Boots : Equipment
{
  public Boots()
  {
    sprite = new Bitmap("./Assets/Items/Armors/Boots.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
  public override object Clone()
  {
    return new Boots();
  }
}