using apiStudent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiStudent.IService
{
    public interface IStudent
    {
        Student addStudent(Student student);

        Student editStudent(int id, Student student);

        Task<Student> GetStudent(int id);

        List<Student> GetallStudent();
        void DeleteStudent(Student student);
    }
}
