using Business.Models;
using DataAccess.Contexts;

namespace Business.Services
{
    public interface IGradeService
    {
        IQueryable<GradeModel> Query();
    }

    public class GradeService : IGradeService
    {
        private readonly Db _db;

        public GradeService(Db db)
        {
            _db = db;
        }

        public IQueryable<GradeModel> Query()
        {
            return _db.Grades.OrderBy(a => a.Year).Select(a => new GradeModel()
            {
                Id = a.Id,
                Year = a.Year
            });
        }
    }
}
