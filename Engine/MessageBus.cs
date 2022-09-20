using System.Collections;
using System.Collections.Generic;

namespace CLIpixelEngine.Engine.Bus
{
    
    
    
    public class MessageBus
    {
        //TODO: Fill with enum
        public enum MyEnum
        {
            CHARACTER_MOVEMENT_UP,
            CHARACTER_MOVEMENT_RIGHT,
            CHARACTER_MOVEMENT_DOWN,
            CHARACTER_MOVEMENT_LEFT,
            
            CHARACTER_INTERACTION_ATTACK,
            CHARACTER_CHANGE_MAP_RIGHT,
            
            
        }


        public Queue<int> Mqueue;
    }
}