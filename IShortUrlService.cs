using UrlShort.Models;

namespace UrlShort
{
    public interface IShorterService
    {
        ShortModel GetById(int id);

        ShortModel GetByPath(string path);

        ShortModel GetByOriginalUrl(string MainUrl);

        int Save(ShortModel shortUrl);
    }
}
