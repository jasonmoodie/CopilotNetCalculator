using Microsoft.AspNetCore.Mvc;
using CopilotNetCalculator.Models;

namespace CopilotNetCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: /Calculator/
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Calculator/Calculate        [HttpPost]
        public IActionResult Calculate(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    switch (model.Operation)
                    {
                        case "Add":
                            model.Result = model.Add();
                            break;
                        case "Subtract":
                            model.Result = model.Subtract();
                            break;
                        case "Multiply":
                            model.Result = model.Multiply();
                            break;
                        case "Divide":
                            model.Result = model.Divide();
                            break;
                        // TODO: Add case here
                    }
                }
                catch (DivideByZeroException)
                {
                    ModelState.AddModelError("", "Cannot divide by zero");
                    model.Result = 0;
                }
            }
            return View("Index", model);
        }
    }
}