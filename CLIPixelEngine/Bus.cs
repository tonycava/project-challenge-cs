namespace CLIPixelEngine.Engine.Bus;

public enum Actions
{
  //input
  BUTTON_PRESS,

  //movement
  COLLISION,
  MOVEMENT,

  //scene
  CHANGE_MAP
}

public enum ActionType
{
  INPUT,
  RENDER,
  SCENE
}

public class MessageBus
{
  public Queue<Message> Mqueue = new();

  /// <summary>
  ///   Add a message to the Queue
  /// </summary>
  /// <param name="type">message type ( Input,Render,Scene )</param>
  /// <param name="action">action used ( ButtonPressed,Movement )</param>
  /// <param name="value">value of the action ( Z,analog input )</param>
  public void AddMessage(ActionType type, Actions action, string value)
  {
    Mqueue.Enqueue(new Message(type, action, value));
    Engine.messageReceiver.HandleMessage();
  }
}

public class Message
{
  public Actions Action;
  public ActionType Type;
  public string Value;

  public Message(ActionType type, Actions action, string value)
  {
    Type = type;
    Action = action;
    Value = value;
  }
}