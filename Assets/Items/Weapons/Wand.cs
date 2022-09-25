using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Wand : Equipment
{
  public Wand()
  {
    name = "Wand";
    sprite = new Bitmap("./Assets/Items/Weapons/Wand.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }

  public override object Clone()
  {
    Wand wand = new Wand();
    wand.id = id;
    return wand;
  }
}