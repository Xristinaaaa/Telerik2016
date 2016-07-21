namespace FurnitureManufacturer.Interfaces
{
    public interface IChair : IFurniture
    {
        int NumberOfLegs { get; }

        void SetHeight(decimal height);
    }
}
