using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IStudentService
    {
        IQueryable<StudentModel> Query();
        bool Add(StudentModel model);
        bool Update(StudentModel model);
        bool Delete(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly Db _db;

        public StudentService(Db db)
        {
            _db = db;
        }

        //Burasıda okey 
        public bool Add(StudentModel model)
        {
            if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()) &&
                _db.Students.Any(s => s.Surname.ToUpper() == model.Surname.ToUpper().Trim()))
                return false;
            Student entity = new Student()
            {
                GradeId = model.GradeId ?? 1,
                Name = model.Name.Trim(),
                Surname = model.Surname.Trim(),
                UniversityExamRank = model.UniversityExamRank,
                CumulativeGpa = model.CumulativeGpa,
            };
            _db.Students.Add(entity);
            _db.SaveChanges();
            return true;
        }

        //Burası okey
        public bool Delete(int id)
        {
            Student entity = _db.Students.SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return false;
            _db.Students.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        //burasıda tamam
        public IQueryable<StudentModel> Query()
        {
            return _db.Students.Include(s => s.Grade)
                .OrderByDescending(s => s.CumulativeGpa).ThenBy(s => s.Name).ThenBy(s => s.Surname)
                .Select(s => new StudentModel()
                {
                    GradeId = s.GradeId,
                    GradeOutput = s.Grade.Year,
                    Id = s.Id,
                    Name = s.Name,
                    Surname = s.Surname,
                    UniversityExamRank = s.UniversityExamRank,
                    CumulativeGpa = s.CumulativeGpa,
                });
        }


        public bool Update(StudentModel model)
        {
            if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() &&
            _db.Students.Any(s => s.Surname.ToUpper() == model.Surname.ToUpper().Trim() && s.Id != model.Id)))
                return false;
            Student existingEntity = _db.Students.SingleOrDefault(s => s.Id == model.Id);
            if (existingEntity is null)
                return false;
            existingEntity.GradeId = model.GradeId ?? 0;
            existingEntity.Name = model.Name.Trim();
            existingEntity.Surname = model.Surname;
            existingEntity.UniversityExamRank = model.UniversityExamRank;
            existingEntity.CumulativeGpa = model.CumulativeGpa;
            _db.Students.Update(existingEntity);
            _db.SaveChanges();
            return true;
        }
    }
}
