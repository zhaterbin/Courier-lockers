using Courier_lockers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier_lockers.Services
{
    public interface ITest
    {
        Task<List<edpmain>> getAllTest();
    }
}
