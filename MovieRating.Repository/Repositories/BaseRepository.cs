namespace MovieRating.Repository
{
    public class BaseRepository
    {
        protected Context _context { get; set; }

        protected BaseRepository(Context context)
        {
            _context = context;
        }

    }
}
