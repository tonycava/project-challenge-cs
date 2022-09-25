using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Threading.Tasks;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Menu;
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
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 0, 2))
          {

            Entity? entity =
              Engine.logicEngine.CollideWithType(Engine.entities["player"][0], new List<string>() {"enemy", "items"}, 0,
                2);

            if (entity == null)
            {
              Engine.entities["player"][0].Position.y -= 2;
              Engine.entities["player"][0].Rotation = 0;
            }
          }

          break;
        case "D":
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 1, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy", "items"}, 2, 2) == null)
            {
              Engine.entities["player"][0].Position.x += 2;
              Engine.entities["player"][0].Rotation = 1;
            }
          }

          break;

        case "S":
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 2, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy", "items"}, 2, 2) == null)
            { ;
              Engine.entities["player"][0].Position.y += 2;
              Engine.entities["player"][0].Rotation = 2;
            }
          }

          break;

        case "Q":
          if (Engine.logicEngine.TryMove(Engine.entities["player"][0], 3, 2))
          {
            if (Engine.logicEngine.CollideWithType(Engine.entities["player"][0]
                  , new List<string>() {"enemy", "items"}, 3, 2) == null)
            {
              Engine.entities["player"][0].Position.x -= 2;
              Engine.entities["player"][0].Rotation = 3;
            }
          }

          break;

        case "E":
          Character livingCharacter = (Character) Engine.entities["player"][0];
          Engine.logger.Log(string.Join("==>", livingCharacter.inventory));

          if (Engine.activeOverlays.Contains("inventory")) Engine.activeOverlays.Remove("inventory");
          else Engine.activeOverlays.Add("inventory");

          break;
      }
    }
    
  }

  public class MessageReceiver
  {
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
        }
      } while (Engine.bus.Mqueue.Count != 0);

      Engine.logicEngine.Update();
      return Task.CompletedTask;
    }
  }
}