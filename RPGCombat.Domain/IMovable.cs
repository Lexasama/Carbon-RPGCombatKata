namespace RPGCombat.Domain
{
    public interface IMovable
    {
        Position Position { get; set; }
        int X { get; }
        int Y { get; }
    }
}