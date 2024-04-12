using Courier_lockers.Repos.InStorage;

namespace Courier_lockers.Services.InStorage
{
    public interface IInStorageRepository
    {
        Task EntryStorage(ReqStorage reqStorage);
    }
}
