namespace CLIPixelEngine.Engine
{
  public class Logic
  {
    public async void Update()
    {
      //TODO: Logic handling
      
      await Engine.messageReceiver.HandleMessage();
      
      await Engine.renderer.Draw();

    }
  }
}