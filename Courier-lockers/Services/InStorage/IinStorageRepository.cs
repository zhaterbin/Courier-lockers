namespace Courier_lockers.Services.InStorage
{
    public interface IInStorageRepository
    {
        Task EntryStorage(string incode);
    }
}
