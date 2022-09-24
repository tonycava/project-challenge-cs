using System;
using System.Collections.Generic;
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
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 0, 2))
          {
            Engine.logger.Log("can move up\n");

            Entity? entity =
              Engine.logicEngine.CollideWithType(Engine.entities["player"][0], new List<string>() {"enemy"}, 0, 2);

            if (entity == null)
            {
              Engine.entities["player"][0].Position.y -= 2;
              Engine.entities["player"][0].Rotation = 0;
            }
          }

          break;

        case "D":
          Engine.logger.Log("Key D was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 1, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy"}, 2, 2) == null)
            {
              Engine.entities["player"][0].Position.x += 2;
              Engine.entities["player"][0].Rotation = 1;
            }
          }

          break;

        case "S":
          Engine.logger.Log("Key S was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 2, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy"}, 2, 2) == null)
            {
              Engine.logger.Log("TOUCHINGGGGGGGGGGGGGGGGGGGGG");
              Engine.entities["player"][0].Position.y += 2;
              Engine.entities["player"][0].Rotation = 2;
            }
          }

          break;

        case "Q":
          Engine.logger.Log("Key Q was pressed\n");
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 3, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy"}, 3, 2) == null)
            {
              Engine.entities["player"][0].Position.x -= 2;
              Engine.entities["player"][0].Rotation = 3;
            }
          }

          break;
      }
    }

    /// <summary>
    /// Render message handler
    /// </summary>
    /// <param name="action">action to do</param>
    /// <param name="value">value of action</param>
    public void RenderHandler(Actions action, string value)
    {
    }

    /// <summary>
    /// Dialogue message handler
    /// </summary>
    /// <param name="action">action to do</param>
    /// <param name="value">value of action</param>
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
        if (Engine.activeOverlays.Contains("main menu"))
        {
          if (message.Type == ActionType.INPUT) Engine.activeOverlays.Remove("main menu");
          continue;
        }

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