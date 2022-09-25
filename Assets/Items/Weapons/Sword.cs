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
    Sword sword = new Sword();
    sword.id = id;
    return sword;
  }
}