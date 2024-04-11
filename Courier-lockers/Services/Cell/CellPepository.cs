using Courier_lockers.Data;
using Courier_lockers.Repos.Cell;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace Courier_lockers.Services.Cell
{
    public class CellPepository  :ICellRepository
    {
        private readonly ServiceDbContext _context;
        public CellPepository(ServiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ActionResult<CellReqReturn> GetCellArea(CellRequst cellRequst)
        {
            CellReqReturn cellReqReturn = new ();
            var kvPairs = _context.Cells.Where(f => f.CELL_X == cellRequst.AreaCode).Select(v => new CellX_Y_Z
            {
                Cell_Type = v.CELL_TYPE,
                Cell_Status = v.CELL_STATUS,
                Run_Status = v.RUN_STATUS,
                Shelf_Type = v.SHELF_TYPE,
                Cell_Code = v.CELL_CODE,
                Cell_X = v.CELL_X,
                Cell_Y = v.CELL_Y,
                Cell_Z = v.CELL_Z
            })
            .ToList().GroupBy(x=>x.Cell_X)
            .ToDictionary(
                k => k.Key,
                v => v.ToList()
            );
            foreach (var item in kvPairs)
            {
                cellReqReturn.Area = item.Key;
                cellReqReturn.GetX_Y_Zs = item.Value;
            }
            return cellReqReturn;

        }

        public async Task<int> GetCellCodeId()
        {
            var cell= await  _context.Cells.Where(f => f.CELL_TYPE == "Normal" && f.CELL_STATUS == "Nohave" && f.RUN_STATUS == "Enable" && f.SHELF_TYPE == "Sgoods")
                .OrderBy(f => f.CELL_Z).ThenBy(f => f.CELL_X).ThenBy(f => f.CELL_Y).FirstOrDefaultAsync();

            return cell != null ? cell.CELL_ID : 0;
        }

        public async  Task<bool> UpTabaleXYZ()
        {
           var st= await _context.Cells.Where(f => true).ToListAsync();

            foreach (var item in st)
            {
                var strings=item.CELL_CODE.Split("-");
                item.CELL_X = strings[0];
                item.CELL_Y = strings[1];
                item.CELL_Z = strings[2];
                _context.Update(item);
            }
            return await _context.SaveChangesAsync()>0;
        }
    }
}
