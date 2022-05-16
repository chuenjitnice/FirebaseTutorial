using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseTutorial
{
    class StudentManagement
    {
        readonly IFirebaseClient client;
        public StudentManagement()
        {
            client = new FireBaseManagement().InitialFireBase();
        }

        public async Task<Student> GetStudentById(string studentId)
        {
            FirebaseResponse response = await client.GetTaskAsync("Student/" + studentId);
            return response.ResultAs<Student>();
        }
        public async Task<List<Student>> GetAll()
        {
            FirebaseResponse studentsResponse = await client.GetTaskAsync("Student/");
            List<Student> students = studentsResponse.ResultAs<List<Student>>();
            students.RemoveAt(0);
            return students;
        }

        public async Task<Student> Create(Student student)
        {
            SetResponse response = await client.SetTaskAsync("Student/" + student.Id, student);
            return response.ResultAs<Student>();
        }
        public async Task<Student> Update(string studentId, Student student)
        {
            FirebaseResponse response = await client.UpdateTaskAsync("Student/" + studentId, student);
            return response.ResultAs<Student>();
        }

        public async Task<Student> DeleteAll()
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Student/");
            return response.ResultAs<Student>();
        }
    }
}
