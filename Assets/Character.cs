using CLIpixelEngine.Engine.Generic;

namespace Game.EntityHandler
{
    public class Character : ICharacter, IEquipment
    {
        public int hp
        {
            get { return hp; }
            set { hp = value; }
        }
        
        public int stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public Vector2 position
        {
            get { return position; }
            set { position = value; }
        }

        public uint head
        {
            get { return head; }
            set { head = value; }
        }
        public uint uBody
        {
            get { return uBody; }
            set { uBody = value; }
        }
        public uint leg
        {
            get { return leg; }
            set { leg = value; }
        }
        public uint feet 
        {
            get { return feet; }
            set { feet = value; }
        }
        
        public uint hand 
        {
            get { return hand; }
            set { hand = value; }
        }
        
        public uint ring1
        {
            get { return ring1; }
            set { ring2 = value; }
        }
        public uint ring2 
        {
            get { return ring2; }
            set { ring2 = value; }
        }
        
        public uint E1
        {
            get { return E1; }
            set { E1 = value; }
        }
        public uint E2 
        {
            get { return E2; }
            set { E2 = value; }
        }
        public uint E3
        {
            get { return E3; }
            set { E3 = value; }
        }
        public uint E4
        {
            get { return E4; }
            set { E4 = value; }
        }
        public uint E5
        {
            get { return E5; }
            set { E5 = value; }
        }
        public uint E6
        {
            get { return E6; }
            set { E6 = value; }
        }
    }
}