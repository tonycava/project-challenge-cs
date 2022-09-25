using Game.EntityHandler.Items.Rings;

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