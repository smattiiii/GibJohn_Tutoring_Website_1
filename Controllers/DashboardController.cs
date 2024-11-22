using GibJohn_Tutoring_Website_1.Data;
using GibJohn_Tutoring_Website_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace GibJohn_Tutoring_Website_1.Controllers
{
    public class DashboardController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Increment(string label)
        {
            var data = _context.ClickData.FirstOrDefault(d => d.Label == label);

            if (data == null)
            {
                data = new ClickData { Label = label, Count = 1 };
                _context.ClickData.Add(data);
            }
            else
            {
                data.Count++;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetClickData()
        {
            var data = _context.ClickData.ToList();
            return Json(data);
        }
    }
}
