using CLIPixelEngine.Engine.Bus;

namespace CLIPixelEngine.Engine
{
    
    public class Linker
    {
        public static void InputHandler(Actions action,string value)
        {
            
        }
        
        public static void RenderHandler(Actions action,string value)
        {
            
        }
        
        public static void DialogueHandler(Actions action,string value)
        {
            
        }
    }

    public class Receiver
    {
        //TODO: add the different Class exemple Input* input;
        public async void HandleMessage()
        {
            Message message = Engine.bus.Mqueue.Dequeue();
            switch (message.Type)
            {
                case ActionType.INPUT:
                    Linker.InputHandler(message.Action,message.Value);
                    break;
                case ActionType.RENDER:
                    Linker.RenderHandler(message.Action,message.Value);
                    break;
                
            }
        }
    }
}