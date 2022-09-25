using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Leggings : Equipment
{
  public Leggings()
  {
    name = "Leggings";
    sprite = new Bitmap("./Assets/Items/Armors/Leggins.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    Leggings bow = new Leggings();
    bow.id = id;
    return new Leggings();
  }
}