using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class chestplate : Equipment
{
    public override Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/chestplate.png"); }
    }
    public int damage_bonus { get {return 10;} }
    public int defense_bonus { get {return 10;} }

    public chestplate()
    {

    }
}