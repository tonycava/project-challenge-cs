using Game.EntityHandler.Items.Rings;

namespace Game.EntityHandler.Items;

public class EquipementManager
{
    public static EquipementManager singleton;
    public Dictionary<uint, Equipment> equipments = new Dictionary<uint, Equipment>();

    public EquipementManager() {
        if (singleton == null)
        {
            singleton = this;
        }
        RegisterAll();
    }

    public void RegisterAll()
    {
        uint id = 0;
        Register(id++, new fire_ring());
        Register(id++, new ice_ring());
    }

    public void Register(uint equipementId, Equipment equipment)
    {
        equipment.id = equipementId;
        equipments.Add(equipementId, equipment);
    }
}