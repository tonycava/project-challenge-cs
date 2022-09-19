using System.Dynamic;
using CLIpixelEngine.Game.Generic;

namespace Project_CS.Assets
{
    public interface ICharacter : IEntity
    {
        public int hp { get; set; }
        public int stamina { get; set; }
    }
}