using FinanceApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : Controller
    {
        [HttpPost("AddInvestment")]
        public async Task<IActionResult> Add([FromBody] InvestmentCreationRequest request)
        {
            return View();
        }
    }
}
