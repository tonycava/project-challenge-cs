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
    public ActionType Type;
    public Actions Action;
    public string Value;

    public Message(ActionType type, Actions action, string value)
    {
      Type = type;
      Action = action;
      Value = value;
    }
  }
}