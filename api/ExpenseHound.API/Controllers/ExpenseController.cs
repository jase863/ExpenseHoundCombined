using ExpenseHound.API.Models;
using ExpenseHound.API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ExpenseHound.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }


        // GET: api/Expense
        [HttpGet]
        public ActionResult<List<Expense>> Get()
        {
            return _expenseService.Get();
        }


        // Get: api/Expense/5
        [HttpGet("{id:length(24)}", Name = "GetExpense")]
        public ActionResult<Expense> Get(string id)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }


        // POST: api/Expense
        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            _expenseService.Create(expense);
            return CreatedAtAction(nameof(Get), new { Id = expense.Id }, expense);
        }


        // PUT: api/Expense/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Expense expenseIn)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            _expenseService.Update(id, expenseIn);

            return NoContent();
        }
    }
}
