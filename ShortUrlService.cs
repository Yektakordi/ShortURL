using UrlShort.Data;
using UrlShort.Models;

namespace UrlShort
{
    public class ShorterService : IShorterService
    {
        private readonly UrlDBContext _context;

        public ShorterService(UrlDBContext context)
        {
            _context = context;
        }

        public ShortModel GetById(int id)
        {
            return _context.ShortUrls.Find(id);
        }

        public ShortModel GetByPath(string path)
        {
            return _context.ShortUrls.Find(ShortUrler.Decode((path)));
        }

        public ShortModel GetByOriginalUrl(string mainUrl)
        {
            foreach (var shortUrl in _context.ShortUrls) {
                if (shortUrl.MainUrl == mainUrl) {
                    return shortUrl;
                }
            }

            return null;
        }

        public int Save(ShortModel shortUrl)
        {
            _context.ShortUrls.Add(shortUrl);
            _context.SaveChanges();

            return shortUrl.Id;
        }
    }
}
