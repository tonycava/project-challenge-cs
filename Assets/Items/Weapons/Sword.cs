using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Sword : Equipment
{
  public Sword()
  {
    name = "Sword";
    sprite = new Bitmap("./Assets/Items/Weapons/Sword.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    Sword bow = new Sword();
    bow.id = id;
    return new Sword();
  }
}