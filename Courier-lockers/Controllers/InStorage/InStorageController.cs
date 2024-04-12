﻿using Courier_lockers.Repos;
using Courier_lockers.Repos.Cell;
using Courier_lockers.Repos.InStorage;
using Courier_lockers.Services.Cell;
using Courier_lockers.Services.InStorage;
using Microsoft.AspNetCore.Mvc;

namespace Courier_lockers.Controllers.InStorage
{
    [ApiController]
    [Route("api/InStorage/[action]")]
    public class InStorageController : ControllerBase
    {
        private readonly IInStorageRepository _inStorageRepository;
        public InStorageController(IInStorageRepository inStorageRepository)
        {
            _inStorageRepository = inStorageRepository ?? throw new ArgumentNullException(nameof(_inStorageRepository)); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="incode"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Result>> EntercodeInStorage(ReqStorage reqStorage)
        {
            var s=await _inStorageRepository.EntryStorage(reqStorage);
            return Ok(s);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> codeOutStorage(ReqOutStorage reqOutStorage)
        {
            var s = await _inStorageRepository.OutStorage(reqOutStorage);
            return Ok(s);

        }
    }
}
