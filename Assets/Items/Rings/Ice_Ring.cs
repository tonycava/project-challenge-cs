using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class IceRing : Equipment
{
  public IceRing()
  {
    name = "Ice Ring";
    sprite = new Bitmap("./Assets/Items/Rings/Ice_Ring.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    IceRing bow = new IceRing();
    bow.id = id;
    return new IceRing();
  }
}