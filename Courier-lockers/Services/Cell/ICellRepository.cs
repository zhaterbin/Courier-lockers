﻿using Courier_lockers.Repos.Cell;
using Microsoft.AspNetCore.Mvc;

namespace Courier_lockers.Services.Cell
{
    public interface ICellRepository
    {
        ActionResult<CellReqReturn> GetCellArea(CellRequst cellRequst);
        Task<bool> UpTabaleXYZ();

        Task<int> GetCellCodeId(string idex,string Sheft);
        Task updateStatus(int ite);
    }
}
