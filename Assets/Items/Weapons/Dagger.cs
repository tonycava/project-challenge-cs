﻿using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Dagger : Equipment
{
  public Dagger()
  {
    name = "Dagger";
    sprite = new Bitmap("./Assets/Items/Weapons/Dagger.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    Dagger bow = new Dagger();
    bow.id = id;
    return new Dagger();
  }
}