using Domain_модельдері_мен_ViewModels.Models;
using Domain_модельдері_мен_ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Domain_модельдері_мен_ViewModels.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new ProductCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProductCreateViewModel model)
        {
            if (string.Equals(model.Name?.Trim(), "demo", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(nameof(model.Name), "Бұл атау демонстрация үшін бұғатталған.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Product product = model.ToDomainModel();

            TempData["SuccessMessage"] = $"«{product.Name}» тауары валидациядан сәтті өтті.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
