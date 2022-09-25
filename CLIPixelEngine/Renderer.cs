using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Items;
using Game.Maps;
using Game.Test;

namespace CLIPixelEngine.Engine
{
  public class Renderer
  {
    public static IntPtr _handle;
    public Map _map;
    private static int _mode;

    private int _startAtX;
    private int _endAtX;

    private int _startAtY;
    private int _endAtY;

    private string _frame;
    private const int _sizeOfSprite = 8;

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    /// <summary>
    /// Create an handle to the console to use colors
    /// </summary>
    private static void SetupConsole()
    {
      _handle = GetStdHandle(-11);
      GetConsoleMode(_handle, out _mode);
      SetConsoleMode(_handle, _mode | 0x4);
    }

    /// <summary>
    /// Create the Bitmap of the selected map
    /// </summary>
    /// <param name="pathToMap">the name of the map directory</param>
    /// <returns>return the bitmap of the map</returns>
    private Bitmap GetMap(string pathToMap) => new Bitmap(pathToMap);

    /// <summary>
    /// Select the map to use
    /// </summary>
    /// <param name="map">name of the map directory</param>
    public void SetMap(Map map) => _map = map;

    /// <summary>
    /// set camera to a new position
    /// </summary>
    /// <param name="position">Vector2Int of the new position</param>
    public void PutCameraAt(Vector2Int position) => Engine.camera.Position = position;

    /// <summary>
    /// Draw the current frame
    /// </summary>
    /// <returns></returns>
    public Task Draw()
    {
      ConsoleHelper.SetCurrentFont("Consolas", 10);

      Bitmap Map = GetMap(_map.Path);
      if (_handle == IntPtr.Zero) SetupConsole();

      // Draw enemy and my sprites
      DrawEntities(Map);

      // Clear frame to redraw the new updated map
      Console.CursorTop = 0;
      Console.Clear();

      _frame = "";

      _startAtX = Engine.camera.Position.x - Engine.camera.Fov.x;
      _endAtX = Engine.camera.Position.x + Engine.camera.Fov.x;

      _startAtY = Engine.camera.Position.y - Engine.camera.Fov.y;
      _endAtY = Engine.camera.Position.y + Engine.camera.Fov.y;

      _endAtX = _endAtX > _map.Size.y ? _map.Size.y : _endAtX;
      _startAtX = _endAtX == _map.Size.y ? _map.Size.y - Engine.camera.Fov.x * 2 : _startAtX;

      _endAtY = _endAtY > _map.Size.x ? _map.Size.x : _endAtY;
      _startAtY = _endAtY == _map.Size.x ? _map.Size.x - Engine.camera.Fov.y * 2 : _startAtY;

      _startAtX = _startAtX < 0 ? 0 : _startAtX;
      _endAtX = _startAtX == 0 ? _startAtX + Engine.camera.Fov.x * 2 : _endAtX;

      _startAtY = _startAtY < 0 ? 0 : _startAtY;
      _endAtY = _startAtY == 0 ? _startAtY + Engine.camera.Fov.y * 2 : _endAtY;

      DrawOverlay(Map, _startAtX, _startAtY);

      for (int y = _startAtX; y < _endAtX; y++)
      {
        for (int x = _startAtY; x < _endAtY; x++)
        {
          byte r = Map.GetPixel(x, y).R;
          byte g = Map.GetPixel(x, y).G;
          byte b = Map.GetPixel(x, y).B;

          _frame += "\x1b[48;2;" + r + ";" + g + ";" + b + "m  ";
        }

        _frame += "\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m\n";
      }

      Console.Write(_frame);
      return Task.CompletedTask;
    }

    /// <summary>
    /// Draw all entities that are present in the Engine.entities list
    /// </summary>
    /// <param name="Map">the current map</param>
    private void DrawEntities(Bitmap map)
    {
      foreach (var list in Engine.entities)
      {
        foreach (var entity in list.Value)
        {
          DrawEntity(map, entity);
        }
      }
    }

    /// <summary>
    /// draw the given entity on the map
    /// </summary>
    /// <param name="map">current map</param>
    /// <param name="entity">the entity to draw</param>
    private void DrawEntity(Bitmap map, Entity entity)
    {
      for (int x = 0; x < _sizeOfSprite; x++)
      {
        for (int y = 0; y < _sizeOfSprite; y++)
        {
          entity.invertX = entity.Rotation == 3 ? true : entity.invertX;
          entity.invertX = entity.Rotation == 1 ? false : entity.invertX;

          //Check if pixel is OOB
          if (entity.Position.x - 4 + x < _map.Size.x
              && entity.Position.y - 4 + y < _map.Size.y
              && entity.Position.x - 3 + x > 0
              && entity.Position.y - 3 + y > 0)
          {
            Color spriteColor = entity.Sprite.GetPixel(entity.invertX ? 7 - x : 0 + x, y);
            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
            {
              map.SetPixel(entity.Position.x - 4 + x
                , entity.Position.y - 3 + y
                , spriteColor);
            }
          }
        }
      }
    }

    /// <summary>
    /// draw the current overlay
    /// </summary>
    /// <param name="map">the current map</param>
    /// <param name="startX">start of the camera x position</param>
    /// <param name="startY">start of the camera y position</param>
    private void DrawOverlay(Bitmap map, int startX, int startY)
    {
      foreach (var overlayName in Engine.activeOverlays)
      {
        Bitmap overlay = Engine.overlays[overlayName].Image;
        for (int y = 0; y < Engine.camera.Fov.x * 2; y++)
        {
          for (int x = 0; x < Engine.camera.Fov.y * 2; x++)
          {
            Color spriteColor = overlay.GetPixel(x, y);

            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
              map.SetPixel(startY + x, startX + y, spriteColor);
          }
        }

        if (overlayName == "inventory")
        {
          Character livingCharacter = (Character) Engine.entities["player"][0];
          if (livingCharacter.inventory.Count == 0) continue;

          int numberOfRingAlreadyDraw = 0;


          foreach (var item in livingCharacter.inventory)
          {
            Engine.logger.Log(item.name);
            Engine.logger.Log(item.id.ToString());
            
            if (item.name.Contains("Ring")) numberOfRingAlreadyDraw += 1;
            DrawItemInInventory(item, overlay, numberOfRingAlreadyDraw);
          }
        }
      }
    }

    private void DrawItemInInventory(Equipment equipment, Bitmap overlay, int numberOfRingAlreadyDraw)
    {
      Dictionary<uint, int[]> posInInventory = new Dictionary<uint, int[]>
      {
        {2, new[] {14, 33}},
        {3, new[] {14, 33}},
        {4, new[] {14, 33}},
        {5, new[] {14, 33}},
        {6, new[] {14, 33}},

        {7, new[] {15, 9}},
        
        {8, new[] {14, 14}},
        
        {9, new[] {14, 19}},
        
        {10, new[] {14, 26}},
      };

      Bitmap ring = equipment.sprite;

      for (int x = 0; x < _sizeOfSprite; x++)
      {
        for (int y = 0; y < _sizeOfSprite; y++)
        {
          Color spriteColor = ring.GetPixel(x, y);

          if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
          {
            if (equipment.name.Contains("Ring"))
            {
              overlay.SetPixel(24 + 9 * numberOfRingAlreadyDraw - 9 - 4 + x
                , 12 - 4 + y
                , spriteColor);
              continue;
            }
            overlay.SetPixel(posInInventory[equipment.id][0] - 4 + x
              , posInInventory[equipment.id][1] - 4 + y
              , spriteColor);
          }
        }
      }
    }
  }
}