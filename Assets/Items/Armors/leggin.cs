using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class leggin : Equipment
{
    public override Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/leggin.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public leggin()
    {

    }
}