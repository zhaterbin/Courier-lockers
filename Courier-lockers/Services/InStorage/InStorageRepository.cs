using Courier_lockers.Data;

namespace Courier_lockers.Services.InStorage
{
    public class InStorageRepository : IInStorageRepository
    {
        private readonly ServiceDbContext _context;
        public InStorageRepository(ServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


    }
}
