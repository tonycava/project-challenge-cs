using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Sword : Equipment
{
    public override Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Weapons/Sword.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 0;} }

    public Sword()
    {

    }
}