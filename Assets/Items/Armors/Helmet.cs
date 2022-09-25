using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Helmet : Equipment
{
  public Helmet()
  {
    sprite = new Bitmap("./Assets/Items/Armors/Helmet.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    return new Helmet();
  }
}