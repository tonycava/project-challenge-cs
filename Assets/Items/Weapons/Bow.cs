using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Bow : Equipment
{
  public Bow()
  {
    sprite = new Bitmap("./Assets/Items/Weapons/Bow.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    return new Bow();
  }
}