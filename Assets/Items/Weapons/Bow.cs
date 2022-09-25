using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Bow : Equipment
{
  public Bow()
  {
    id = 3;
    name = "Bow";
    sprite = new Bitmap("./Assets/Items/Weapons/Bow.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    Bow bow = new Bow();
    bow.id = id;
    return new Bow();
  }
}