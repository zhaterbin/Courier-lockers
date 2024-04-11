using Courier_lockers.Helper;
using Courier_lockers.Repos.Cell;
using Courier_lockers.Services.Cell;
using Microsoft.AspNetCore.Mvc;

namespace Courier_lockers.Controllers
{
    [ApiController]
    [Route("api/Cell/[action]")]
    //[ApiExplorerSettings(GroupName = nameof(ApiVersion.Nole))]
    public class CellController 
    {

        private readonly ICellRepository _cellRepository;
        public CellController(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository ?? throw new ArgumentNullException(nameof(_cellRepository)); ;
        }
        [HttpPost] 
        public async Task<ActionResult<CellReqReturn>>  GetCellArea(CellRequst cellRequst)
        {
            return _cellRepository.GetCellArea(cellRequst);
        }

        [HttpPost]
        public async Task<bool> GetBool()
        {
            return await _cellRepository.UpTabaleXYZ();
        }
    }
}
