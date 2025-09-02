namespace ReservasHotelPetAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAnimalRepository AnimalRepository { get; }
        ITutorRepository TutorRepository { get; }
        void Commit();

    }
}
