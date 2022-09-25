using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Spear : Equipment
{
  public Spear()
  {
    name = "Spear";
    sprite = new Bitmap("./Assets/Items/Weapons/Spear.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    Spear spear = new Spear();
    spear.id = id;
    return spear;
  }
}