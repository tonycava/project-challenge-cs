using System.Drawing;

namespace Game.EntityHandler.Items;

public abstract class Equipment : ICloneable
{
  public Bitmap sprite;
  public string name { get; set; }
  public int damage_bonus { get; set; }
  public int defense_bonus { get; set; }
  public uint id { get; set; }
  public abstract object Clone();
}