using Courier_lockers.Services.Cell;
using Microsoft.AspNetCore.Mvc;

namespace Courier_lockers.Controllers.InStorage
{
    [ApiController]
    [Route("api/InStorage/[action]")]
    public class InStorageController : ControllerBase
    {
        private readonly ICellRepository _cellRepository;
        public InStorageController(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository ?? throw new ArgumentNullException(nameof(_cellRepository)); ;
        }
    }
}
