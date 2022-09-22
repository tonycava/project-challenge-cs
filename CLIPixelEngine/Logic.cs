using System.Linq;

namespace CLIPixelEngine.Engine
{
  public class Logic
  {
    public async void Update()
    {
      Engine.camera.Position.x = Engine.entities.ElementAt(0).Position.y;
      Engine.camera.Position.y = Engine.entities.ElementAt(0).Position.x;
      
      await Engine.renderer.Draw();
    }
  }
}