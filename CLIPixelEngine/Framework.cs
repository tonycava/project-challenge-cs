using System;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;

namespace CLIPixelEngine.Engine
{
    public class MessageLinker
    {
        public MessageLinker()
        {
        }

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
                    Console.WriteLine("up arrow pressed");
                    break;
                case "right arrow":
                    Console.WriteLine("right arrow pressed");
                    break;
                case "down arrow":
                    Console.WriteLine("down arrow pressed");
                    break;
                case "left arrow":
                    Console.WriteLine("left arrow pressed");
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
        public MessageReceiver()
        {
        }

        //TODO: add the different Class exemple Input* input;
        public async void HandleMessage()
        {
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
        }
    }
}