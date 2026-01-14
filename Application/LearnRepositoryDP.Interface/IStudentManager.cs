using LearnRepositoryDP.Models;
using System.Data;

namespace LearnRepositoryDP.Interface
{
    public interface IStudentManager
    {
        public DataTable Get_AllStudents();
        public DataTable Get_StudentById(int StudentId);
        public DataTable Save_Student(Student obj);
    }
}
