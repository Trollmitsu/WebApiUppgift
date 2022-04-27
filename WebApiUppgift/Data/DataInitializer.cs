using Microsoft.EntityFrameworkCore;

namespace WebApiUppgift.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedAnnonser();
        }

        private void SeedAnnonser()
        {
            if (!_context.Annonser.Any(e => e.Title == "Test1"))
            {
                _context.Annonser.Add(new Annonser
                {
                    Description = "första annonsen",
                    Title = "Test1"
                });
            }
            if (!_context.Annonser.Any(e => e.Title == "Test2"))
            {
                _context.Annonser.Add(new Annonser
                {
                    Description = "andra annonsen",
                    Title = "Test2"
                });
            }


            if (!_context.Annonser.Any(e => e.Title == "Test3"))
            {
                    _context.Annonser.Add(new Annonser {
                    Description = "tredje annonsen",
                    Title = "Test3"
                });
            }

            _context.SaveChanges();
        }
    }
}
