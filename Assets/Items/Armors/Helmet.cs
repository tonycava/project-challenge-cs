using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Helmet : Equipment
{
    public Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/Helmet.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public Helmet()
    {

    }
}