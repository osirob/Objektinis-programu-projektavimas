namespace Shared.Shared
{
    public interface ICollectable
    {
        int Id { get; set; }
        int XCoord { get; set; }
        int YCoord { get; set; }
        string Tag { get; set; }
    }
}
