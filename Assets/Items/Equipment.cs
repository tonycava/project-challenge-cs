using System.Drawing;

namespace Game.EntityHandler.Items;

public abstract class Equipment
{
    public abstract Bitmap sprite { get; }
    public int damage_bonus { get; }
    public int defense_bonus { get; }
    public uint id { get; set; }
}