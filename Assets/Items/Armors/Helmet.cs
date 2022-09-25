using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Helmet : Equipment
{
  public Helmet()
  {
    name = "Helmet";
    sprite = new Bitmap("./Assets/Items/Armors/Helmet.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    Helmet helmet = new Helmet();
    helmet.id = id;
    return helmet;
  }
}