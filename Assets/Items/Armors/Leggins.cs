using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Leggins : Equipment
{
  public Leggins()
  {
    sprite = new Bitmap("./Assets/Items/Armors/Leggins.png");
    damage_bonus = 5;
    defense_bonus = 5;
  }
    
  public override object Clone()
  {
    return new Leggins();
  }
}