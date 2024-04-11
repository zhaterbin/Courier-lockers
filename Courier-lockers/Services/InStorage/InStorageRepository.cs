using Courier_lockers.Data;
using Courier_lockers.Entities;
using Courier_lockers.Services.Cell;

namespace Courier_lockers.Services.InStorage
{
    public class InStorageRepository : IInStorageRepository
    {
        private readonly ServiceDbContext _context;
        private readonly ICellRepository _cellRepository;
        public InStorageRepository(ServiceDbContext context, ICellRepository cellRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cellRepository = cellRepository ?? throw new ArgumentNullException(nameof(cellRepository));
        }

        public async Task EntryStorage(string incode)
        {
            var db = _context.Database.BeginTransaction();
            var bselt = false;
            try
            {
                var ite=await _cellRepository.GetCellCodeId();
                _context.storages.Add(new Storage
                {
                    
                });
                _context.opearterIns.Add(new OpearterIn {
                    Operator_Name = "S神",
                    Storage_ID=1,
                });
                db.Commit();
            }catch(Exception ex)
            {
                bselt= true;
                await Console.Out.WriteLineAsync(ex.Message);
            }
            finally
            {
                if (bselt)
                {
                    db.Rollback();
                }
            }
        }
    }
}
