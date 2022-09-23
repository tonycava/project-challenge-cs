using Game.EntityHandler.Items.Rings;

namespace Game.EntityHandler.Items;

public class EquipmentManager
{
    public static EquipmentManager singleton;
    public Dictionary<uint, Equipment> equipments = new Dictionary<uint, Equipment>();

    public EquipmentManager() {
        if (singleton is not  null)
        {
            singleton = this;
        }
        RegisterAll();
    }

    public void RegisterAll()
    {
        uint id = 0;
        Register(id++, new FireRing());
        Register(id++, new IceRing());
    }

    public void Register(uint equipementId, Equipment equipment)
    {
        equipment.id = equipementId;
        equipments.Add(equipementId, equipment);
    }
}