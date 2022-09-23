using System;
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
      Engine.camera.Position.x = Engine.entities["player"].Position.y;
      Engine.camera.Position.y = Engine.entities["player"].Position.x;


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
      Engine.logger.Log(" yes\n");

      Engine.logger.Log(Engine.renderer._map.ColPath);

      Bitmap collisionTexture = new Bitmap(Engine.renderer._map.ColPath);
      
      int moveY = direction == 2 ? 1 : 0 + direction == 0 ? -1 : 0;
      int moveX = direction == 1 ? 1 : 0 + direction == 3 ? -1 : 0;

      Vector2Int move = new Vector2Int(distance * moveX, distance * moveY);

      bool u0 = entity.Position.y + move.y > 0 &&
                entity.Position.y + move.y < collisionTexture.Height &&
                entity.Position.x + move.x > 0 &&
                entity.Position.x + move.x < collisionTexture.Width;
      bool u1 = entity.Position.y + move.y + 3 > 0 &&
                entity.Position.y + move.y + 3 < collisionTexture.Height &&
                entity.Position.x + move.x > 0 &&
                entity.Position.x + move.x < collisionTexture.Width;
      bool u2 = entity.Position.y + move.y > 0 &&
                entity.Position.y + move.y < collisionTexture.Height &&
                entity.Position.x + move.x + 1 > 0 &&
                entity.Position.x + move.x + 1 < collisionTexture.Width;
      bool u3 = entity.Position.y + move.y - 1 > 0 &&
                entity.Position.y + move.y - 1 < collisionTexture.Height &&
                entity.Position.x + move.x > 0 &&
                entity.Position.x + move.x < collisionTexture.Width;
      bool u4 = entity.Position.y + move.y > 0 &&
                entity.Position.y + move.y < collisionTexture.Height &&
                entity.Position.x + move.x - 1 > 0 &&
                entity.Position.x + move.x - 1 < collisionTexture.Width;


      Engine.logger.Log("-> Sampling\n");
      int s0 = u0 ? collisionTexture.GetPixel(entity.Position.x + move.x, entity.Position.y + move.y).R : 0;
      int s1 = u1 ? collisionTexture.GetPixel(entity.Position.x + move.x, entity.Position.y + move.y + 3).R : 0;
      int s2 = u2 ? collisionTexture.GetPixel(entity.Position.x + move.x + 1, entity.Position.y + move.y).R : 0;
      int s3 = u3 ? collisionTexture.GetPixel(entity.Position.x + move.x, entity.Position.y + move.y - 1).R : 0;
      int s4 = u4 ? collisionTexture.GetPixel(entity.Position.x + move.x - 1, entity.Position.y + move.y).R : 0;
      int sample = s0 + s1 + s2 + s3 + s4;

      Engine.logger.Log((sample == 0).ToString() + "\n");
      return sample == 0;
    }


    public bool IsTouchingEnemy(Dictionary<string, Entity> entity)
    {
      Vector2Int character = entity.Values.ElementAt(0).Position;

      for (int i = 1; i < entity.Count; i++)
      {
        int x = entity.ElementAt(i).Value.Position.x;
        int y = entity.ElementAt(i).Value.Position.y;


        Console.WriteLine(character.x - x);
        Console.WriteLine(character.y - y);
      }

      return false;
    }
  }
}