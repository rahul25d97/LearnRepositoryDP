using LearnRepositoryDP.Interface;
using LearnRepositoryDP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Xml.Linq;

namespace LearnRepositoryDP.Repository
{
    public class StudentManagerRepository : IStudentManager
    {
        private readonly ILogger<StudentManagerRepository> _logger;
        public IConfiguration _configuration;

        public StudentManagerRepository(ILogger<StudentManagerRepository> logger, IConfiguration config)
        {

            _logger = logger;
            _configuration = config;

        }

        public DataTable Get_AllStudents()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("BiappsDBCon"));

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[LRN].[Get_AllStudents]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Get_StudentById(int StudentId)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("BiappsDBCon"));

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[LRN].[Get_StudentById]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("StudentId", StudentId.ToString());

                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Save_Student(Student obj)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("BiappsDBCon"));

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("[LRN].[Save_Student]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("StudentId", obj.StudentId);
                cmd.Parameters.AddWithValue("Name", obj.Name);
                cmd.Parameters.AddWithValue("Department", obj.Department);
                cmd.Parameters.AddWithValue("Address", obj.Address);
                cmd.Parameters.AddWithValue("ContactNo", obj.ContactNo);

                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
