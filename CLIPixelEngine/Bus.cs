using System.Collections;
using System.Collections.Generic;

namespace CLIPixelEngine.Engine.Bus
{
    
    public enum Actions
    {
        //input
        BUTTON_PRESS,
        
        //movement
        COLLISION,
        MOVEMENT,
        
        //scene
        CHANGE_MAP,
        
        
    }
    
    public enum ActionType
    {
        INPUT,
        RENDER,
        SCENE,
    }
    
    
    public class MessageBus
    {
        //TODO: Fill with enum
        
        public Queue<Message> Mqueue;
    }
    
    public class Message
    {
        public ActionType type;
        public Actions action;
        public string value;

        public Message(ActionType t,Actions a,string v)
        {
            this.type = t;
            this.action = a;
            this.value = v;
        }
    }
}