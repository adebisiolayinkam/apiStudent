using apiStudent.IService;
using apiStudent.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiStudent.Service
{
    public class StudentService : IStudent
    {
        private StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Student addStudent(Student student)
        {
            var found = _dbContext.StudendTable.SingleOrDefault(x => x.Email == student.Email);
            if(found != null)
            {
                return (null);
            }
            _dbContext.StudendTable.Add(student);
            _dbContext.SaveChanges();
            return (student);
        }

        public void DeleteStudent(Student student)
        {
            _dbContext.StudendTable.Remove(student);
            _dbContext.SaveChanges();
        }

        public Student editStudent(int id,Student student)
        {
            var Found = _dbContext.StudendTable.SingleOrDefault(x => x.Id == id);

            Found.Id = Found.Id;
            Found.Name =  student.Name;
            Found.Email = student.Email;
            Found.Phone = student.Phone;
            Found.Dob = student.Dob;
            _dbContext.StudendTable.Update(Found);
            _dbContext.SaveChanges();

            return Found;
        }

        public List<Student> GetallStudent()
        {
            var allStudents = _dbContext.StudendTable.ToList();
            return allStudents;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = _dbContext.StudendTable.SingleOrDefault(x => x.Id == id);
            return student;
        }
    }
}
