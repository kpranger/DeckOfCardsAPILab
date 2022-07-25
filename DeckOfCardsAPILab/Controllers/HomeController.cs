using DeckOfCardsAPILab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public DeckOfCardsDAL deckofcardsDAL = new DeckOfCardsDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CardDisplay()
        {
            DeckOfCardsModel result = deckofcardsDAL.GetDeckOfCards();
            if (result.success == false || result.remaining < 5)
            {
                deckofcardsDAL.ShuffleCards();
                return View(result);
            }
            else
            {
                return View(result);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}