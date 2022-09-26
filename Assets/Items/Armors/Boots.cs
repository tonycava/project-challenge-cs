using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Boots : Equipment
{
  public Boots()
  {
    name = "Boots";
    sprite = new Bitmap("./Assets/Items/Armors/Boots.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }

  public override object Clone()
  {
    var boots = new Boots();
    boots.id = id;
    return boots;
  }
}