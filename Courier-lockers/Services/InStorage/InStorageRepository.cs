using Courier_lockers.Data;
using Courier_lockers.Entities;
using Courier_lockers.Repos.InStorage;
using Courier_lockers.Services.Cell;
using Microsoft.EntityFrameworkCore;

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

        public async Task EntryStorage(ReqStorage reqStorage)
        {
            var db = _context.Database.BeginTransaction();
            var bselt = false;
            try
            {
                var ite=await _cellRepository.GetCellCodeId(reqStorage.idex,reqStorage.ShelfType);
                _context.storages.Add(new Storage
                {
                    CELL_ID= ite,
                    Bar_Code="Test",
                    Bar_Name="Test",
                    Entry_Time =DateTime.Now.ToString(),
                    Storage_Name="WPF国手"
                });
                await _context.SaveChangesAsync();
                _context.opearterIns.Add(new OpearterIn {
                    Operator_Name = "S神",
                    Price=1,
                    Storage_ID= _context.storages.OrderBy(f=>f.STORAGE_ID).FirstOrDefault().STORAGE_ID,
                    Storage_Name="WPF国手",
                    DateTime= DateTime.Now.ToString(),
                    InCode= reqStorage.incode,
                });
                await _context.SaveChangesAsync();
                await _cellRepository.updateStatus(ite);
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
