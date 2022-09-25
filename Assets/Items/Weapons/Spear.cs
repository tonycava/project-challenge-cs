﻿using System.Drawing;

namespace Game.EntityHandler.Items.Weapons;

public class Spear : Equipment
{
  public Spear()
  {
    name = "Spear";
    sprite = new Bitmap("./Assets/Items/Weapons/Spear.png");
    damage_bonus = 5;
    defense_bonus = 0;
  }
    
  public override object Clone()
  {
    Spear bow = new Spear();
    bow.id = id;
    return new Spear();
  }
}