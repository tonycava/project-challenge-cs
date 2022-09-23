using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Threading.Tasks;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Test;

namespace CLIPixelEngine.Engine
{
  public class MessageLinker
  {
    public void InputHandler(Actions action, string value)
    {
      switch (action)
      {
        case Actions.BUTTON_PRESS:
          ButtonPress(value);
          break;
      }
    }

    private void ButtonPress(string value)
    {
      switch (value)
      {
        case "Z":
          Engine.logger.Log("Key Z was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"], 0, 2))
          {
            Engine.entities["player"].Position.y -= 2;
            Engine.entities["player"].Rotation = 0;
          }

          break;
        case "D":
          Engine.logger.Log("Key D was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"], 1, 2))
          {
            Engine.entities["player"].Position.x += 2;
            Engine.entities["player"].Rotation = 1;
          }

          break;
        case "S":
          Engine.logger.Log("Key S was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"], 2, 2))
          {
            if (Engine.logicEngine.IsTouchingEnemy(Engine.entities))
            {
              Engine.logger.Log("colliding");
            }


            Engine.entities["player"].Rotation = 2;
            Engine.entities["player"].Position.y += 2;
          }

          break;
        case "Q":
          Engine.logger.Log("Key Q was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"], 3, 2))
          {
            Engine.entities["player"].Position.x -= 2;
            Engine.entities["player"].Rotation = 3;
          }
          break;
      }
    }

    public void RenderHandler(Actions action, string value)
    {
    }

    public void DialogueHandler(Actions action, string value)
    {
    }
  }

  public class MessageReceiver
  {
    private bool _isFollowing = true;
    private int _processedFrame = 0;
    public int CurrentFrame = 0;

    //TODO: add the different Class exemple Input* input;

    /// <summary>
    /// Read the bus and process its message
    /// </summary>
    /// <returns></returns>
    public Task HandleMessage()
    {
      if (Engine.bus.Mqueue.Count == 0) return Task.CompletedTask;

      do
      {
        Message message = Engine.bus.Mqueue.Dequeue();

        switch (message.Type)
        {
          case ActionType.INPUT:
            Engine.messageLinker.InputHandler(message.Action, message.Value);
            break;
          case ActionType.RENDER:
            Engine.messageLinker.RenderHandler(message.Action, message.Value);
            break;
        }
      } while (Engine.bus.Mqueue.Count != 0);
      // while (_processedFrame != CurrentFrame)
      // _processedFrame = CurrentFrame;

      Engine.logicEngine.Update();
      return Task.CompletedTask;
    }
  }
}