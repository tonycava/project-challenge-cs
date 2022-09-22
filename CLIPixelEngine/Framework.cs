using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Threading.Tasks;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;

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
        case "up arrow":
          Engine.entities.ElementAt(0).Position.y -= 1;
          break;
        case "right arrow":
          Engine.entities.ElementAt(0).Position.x += 1;
          break;
        case "down arrow":
          Engine.entities.ElementAt(0).Position.y += 1;
          break;
        case "left arrow":
          Engine.entities.ElementAt(0).Position.x -= 1;
          break;
      }
    }


    public void RenderHandler(Actions action, string value)
    {
    }

    public void SceneHandler(Actions action, string value)
    {
      switch (action)
      {
        case Actions.MOVEMENT:
          Mouvement(value);
          break;
      }
    }


    public void Mouvement(string value)
    {
      switch (value)
      {
        case "up":
          Engine.entities.ElementAt(0).Position.y -= 1;
          break;
        case "right":
          Engine.entities.ElementAt(0).Position.x += 1;
          break;
        case "down":
          Engine.entities.ElementAt(0).Position.y += 1;
          break;
        case "left":
          Engine.entities.ElementAt(0).Position.x -= 1;
          break;
      }
    }


    public void DialogueHandler(Actions action, string value)
    {
    }
  }

  public class MessageReceiver
  {
    private bool _isFollowing = true;

//TODO: add the different Class exemple Input* input;
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

          case ActionType.SCENE:
            Engine.messageLinker.SceneHandler(message.Action, message.Value);
            break;
        }
      } while (Engine.bus.Mqueue.Count != 0);

      Engine.logicEngine.Update();

      return Task.CompletedTask;
    }
  }
}