using Game.EntityHandler.Items.Armors;
using Game.EntityHandler.Items.Rings;
using Game.EntityHandler.Items.Weapons;

namespace Game.EntityHandler.Items;

public class EquipmentManager
{
  public static EquipmentManager singleton;
  public Dictionary<uint, Equipment> equipments = new Dictionary<uint, Equipment>();

  public EquipmentManager() {
    if (singleton == null)
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
    
    Register(id++, new Bow());
    Register(id++, new Dagger());
    Register(id++, new Spear());
    Register(id++, new Sword());
    Register(id++, new Wand());
    
    Register(id++, new Helmet());
    Register(id++, new Chestplate());
    Register(id++, new Leggins());
    Register(id++, new Boots());
  }

  public void Register(uint equipmentId, Equipment equipment)
  {
    equipment.id = equipmentId;
    equipments.Add(equipmentId, equipment);
  }
    
  public Equipment getEquipment(uint equipmentId)
  {
    Equipment equipment = null;
    equipments.TryGetValue(equipmentId, out equipment);
    return equipment;
  }
}