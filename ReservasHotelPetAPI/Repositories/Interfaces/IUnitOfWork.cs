namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAnimalRepository AnimalRepository { get; }
        ITutorRepository TutorRepository { get; }
        IReservaRepository ReservaRepository { get; }
        Task CommitAsync();

    }
}
