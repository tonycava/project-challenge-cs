using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class IceRing : Equipment
{
    private string _name = "Ice Ring";
    public Bitmap sprite;
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }
    
    public string GetName
    {
        get { return _name; }
        set { _name = value; }
    }

    public IceRing()
    {
        name = GetName;
        sprite = new Bitmap("./Assets/Items/Rings/Ice_Ring.png");
    }
}
