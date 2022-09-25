using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Spear : Equipment
{
  public Spear()
  {
    sprite = new Bitmap("./Assets/Items/Weapons/Spear.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    return new Spear();
  }
}