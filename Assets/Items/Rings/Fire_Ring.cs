using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class FireRing : Equipment
{
  public FireRing()
  {
    name = "Fire Ring";
    sprite = new Bitmap("./Assets/Items/Rings/Fire_Ring.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    FireRing fireRing = new FireRing();
    fireRing.id = id;
    return fireRing;
  }
}