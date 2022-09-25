using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CLIPixelEngine.Engine.Generic;
using Game.Test;

namespace CLIPixelEngine.Engine
{
  public class Logic
  {
    /// <summary>
    /// Contains the logic of what will happen every frame.
    /// </summary>
    public async void Update()
    {
      Engine.camera.Position.x = Engine.entities["player"][0].Position.y;
      Engine.camera.Position.y = Engine.entities["player"][0].Position.x;

      await Engine.renderer.Draw();
    }

    /// <summary>
    /// Returns true if the entity does not collide with
    /// something where it will land.
    /// </summary>
    /// <param name="entity">The entity that is trying to move</param>
    /// <param name="direction">The direction it is moving U=0 R=1 D=2 L=3</param>
    /// <param name="distance">The distance it will try to move</param>
    /// <returns></returns>
    public bool TryMove(Entity entity, int direction, int distance) //work as intended
    {
      if (Engine.renderer._map.ColPath == "") return true;

      Bitmap collisionTexture = new Bitmap(Engine.renderer._map.ColPath);

      int moveY = direction == 2 ? 1 : 0 + direction == 0 ? -1 : 0;
      int moveX = direction == 1 ? 1 : 0 + direction == 3 ? -1 : 0;

      Vector2Int move = new Vector2Int(distance * moveX, distance * moveY);

      bool u0 = IsOOB(entity, move, new Vector2Int(0, 0), collisionTexture);
      bool u1 = IsOOB(entity, move, new Vector2Int(0, 3), collisionTexture);
      bool u2 = IsOOB(entity, move, new Vector2Int(1, 0), collisionTexture);
      bool u3 = IsOOB(entity, move, new Vector2Int(0, -1), collisionTexture);
      bool u4 = IsOOB(entity, move, new Vector2Int(-1, 0), collisionTexture);

      int s0 = u0 ? Collide(entity, move, new Vector2Int(-1, 0), collisionTexture) : 0;
      int s1 = u1 ? Collide(entity, move, new Vector2Int(0, 3), collisionTexture) : 0;
      int s2 = u2 ? Collide(entity, move, new Vector2Int(1, 0), collisionTexture) : 0;
      int s3 = u3 ? Collide(entity, move, new Vector2Int(0, -1), collisionTexture) : 0;
      int s4 = u4 ? Collide(entity, move, new Vector2Int(-1, 0), collisionTexture) : 0;
      int sample = s0 + s1 + s2 + s3 + s4;

      return sample == 0;
    }

    /// <summary>
    /// check if entity is out of bound
    /// </summary>
    /// <param name="entity">the entity to check</param>
    /// <param name="move">the vector of movement</param>
    /// <param name="add">offset of the check</param>
    /// <param name="col">the map collider</param>
    /// <returns></returns>
    public bool IsOOB(Entity entity, Vector2Int move, Vector2Int add, Bitmap col)
    {
      return entity.Position.y + move.y > 0 &&
             entity.Position.y + move.y < col.Height &&
             entity.Position.x + move.x > 0 &&
             entity.Position.x + move.x < col.Width;
    }

    /// <summary>
    /// check if the given entity is collinding with the current map
    /// </summary>
    /// <param name="entity">the entity to check</param>
    /// <param name="move">the vector of movement</param>
    /// <param name="add">offset of the check</param>
    /// <param name="col">the map collider</param>
    /// <returns></returns>
    public int Collide(Entity entity, Vector2Int move, Vector2Int add, Bitmap col)
    {
      return col.GetPixel(entity.Position.x + move.x + add.x, entity.Position.y + move.y + add.y).R;
    }

    /// <summary>
    /// Return the entity in the given types the given entity collide with
    /// </summary>
    /// <param name="entity">entity to check colision</param>
    /// <param name="types">types of entity to collide with ( "enemy","item" )</param>
    /// <param name="dir">the direction of the movement</param>
    /// <param name="dist">the distance traveled</param>
    /// <returns>collided entity</returns>
    public Entity CollideWithType(Entity character, List<string> types, int dir = 0, int dist = 0)
    {
      int moveY = dir == 2 ? 1 : 0 + dir == 0 ? -1 : 0;
      int moveX = dir == 1 ? 1 : 0 + dir == 3 ? -1 : 0;
      Vector2Int move = new Vector2Int(dist * moveX, dist * moveY);

      foreach (var type in types)
      {
        foreach (var entity in Engine.entities[type])
        {
          Vector2Int newPos = new Vector2Int(character.Position.x + move.x, character.Position.y + move.y);
          double distanceToEntity2 = Calc.DistanceToBox(newPos, entity.Position, new Vector2Int(4, 4));
          if (distanceToEntity2 <= 0)
          {
            if (entity as LivingEntity != null)
            {
              LivingEntity livingEntity = (LivingEntity) entity;
              Character livingCharacter = (Character) character;
              livingEntity.DealDamage(livingCharacter.damage, livingEntity, livingCharacter);

              Console.WriteLine(
                $"You hit the blubble and the monster hit you and you now have {livingCharacter.life} HP");
              Console.WriteLine("If you want to fight continue in the direction of the monster");
              Console.WriteLine("Otherwise leave in the opposite direction ");

              string dropped = livingEntity.inventory.Count > 0
                ? $"The enemy is dead and drop you an {livingEntity.inventory.ElementAt(0).name}"
                : "The enemy is dead and drop you nothinh";

              Console.Write(livingEntity.life <= 0
                ? $"{dropped}"
                : $"Current Entity Life {livingEntity.life}");


              Thread.Sleep(2000);
              return entity;
            }
            else if (entity as EquipementEntity != null)
            {
              EquipementEntity equipementEntity = (EquipementEntity) entity;
              Character livingCharacter = (Character) character;

              Console.WriteLine($"You just took the item {equipementEntity.equipment.name}");

              if (livingCharacter.inventory.Count == 1)
              {
                Console.WriteLine("Sorry your inventory is you can not pick up this item");
              }
              else
              {
                livingCharacter.inventory.Add(equipementEntity.equipment);
                Engine.entities["items"].Remove(equipementEntity);   
              }
              
              Thread.Sleep(2000);
              return equipementEntity;
            }
            // Console.WriteLine("Or use an heal potion using the key U !");
          }
        }
      }

      return null;
    }
  }
}