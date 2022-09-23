using System.Drawing;

namespace Game.EntityHandler.Items;

public abstract class Equipment
{
    public string name { get; set; }
    public Bitmap sprite;
    public int damage_bonus { get; }
    public int defense_bonus { get; }
    public uint id { get; set; }
}