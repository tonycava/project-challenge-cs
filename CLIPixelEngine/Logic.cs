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
      
      bool u0 = IsOOB(entity,move,new Vector2Int(0,0),collisionTexture);
      bool u1 = IsOOB(entity,move,new Vector2Int(0,3),collisionTexture);
      bool u2 = IsOOB(entity,move,new Vector2Int(1,0),collisionTexture);
      bool u3 = IsOOB(entity,move,new Vector2Int(0,-1),collisionTexture);
      bool u4 = IsOOB(entity,move,new Vector2Int(-1,0),collisionTexture);

      Engine.logger.Log("" + u0 + "\n");
      
      int s0 = u0 ? Collide(entity,move,new Vector2Int(-1, 0), collisionTexture) : 0;
      int s1 = u1 ? Collide(entity,move,new Vector2Int(0,3),collisionTexture) : 0;
      int s2 = u2 ? Collide(entity,move,new Vector2Int(1,0),collisionTexture) : 0;
      int s3 = u3 ? Collide(entity,move,new Vector2Int(0,-1),collisionTexture) : 0;
      int s4 = u4 ? Collide(entity,move,new Vector2Int(-1,0),collisionTexture) : 0;
      int sample = s0 + s1 + s2 + s3 + s4;
      
      Engine.logger.Log("Collid \n");
      
      return sample == 0;
    }

    public bool IsOOB (Entity entity,Vector2Int move,Vector2Int add,Bitmap col)
    {
      return entity.Position.y + move.y > 0 &&
               entity.Position.y + move.y < col.Height &&
               entity.Position.x + move.x > 0 &&
               entity.Position.x + move.x < col.Width;
    }

    public int Collide(Entity entity, Vector2Int move, Vector2Int add, Bitmap col)
    {
      return col.GetPixel(entity.Position.x + move.x + add.x, entity.Position.y + move.y + add.y).R;
    }

    public bool CollidWithType(Entity entity, List<string> types,int dir,int dist)
    {
      int moveY = dir == 2 ? 1 : 0 + dir == 0 ? -1 : 0;
      int moveX = dir == 1 ? 1 : 0 + dir == 3 ? -1 : 0;
      Vector2Int move = new Vector2Int(dist * moveX, dist * moveY);
      
      foreach (var type in types)
      {
        foreach (var entity2 in Engine.entities[type])
        {
          Vector2Int entityPos = new Vector2Int(entity.Position.x + move.x, entity.Position.y + move.y);
          if (Calc.Distance(entityPos, entity2.Position) < 8)
          {
            Engine.logger.Log("collided with ennemy \n");
            return true;
          }
        }
      }

      return false;
    }
  }
}