using CLIPixelEngine.Engine.Bus;

namespace CLIPixelEngine.Engine
{
  public class Clock
  {
    public void Start()
    {
    }

    public void Update()
    {
      Engine.logicEngine.Update();
    }
  }
}