namespace Game.EntityHandler
{
    public interface ICharacter : IEntity
    {
        public int hp { get; set; }
        public int stamina { get; set; }
    }
}