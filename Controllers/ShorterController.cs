using Microsoft.AspNetCore.Mvc;
using UrlShort.Models;

namespace UrlShort.Controllers
{
    public class ShorterController : Controller
    {
        private readonly IShorterService _service;

        public ShorterController(IShorterService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction(actionName: nameof(Create));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string mainUrl)
        {
            var shortUrl = new ShortModel
            {
                MainUrl = mainUrl
            };

            _service.Save(shortUrl);

            return RedirectToAction(actionName: nameof(Show), routeValues: new { id = shortUrl.Id });
        }

        public IActionResult Show(int? id)
        {
            if (!id.HasValue) 
            {
                return NotFound();
            }

            var shortUrl = _service.GetById(id.Value);

            if (shortUrl == null) 
            {
                return NotFound();
            }

            ViewData["Path"] = ShortUrler.Encode(shortUrl.Id);

            return View(shortUrl);
        }

        [HttpGet("/Shorter/Go/{path:required}", Name = "Shorter_Go")]
        public IActionResult Go(string path)
        {
            if (path == null)
            {
                return NotFound();
            }

            var shortUrl = _service.GetByPath(path);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return Redirect(shortUrl.MainUrl);
        }
    }
}
