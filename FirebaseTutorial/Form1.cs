using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FirebaseTutorial
{
    public partial class Form1 : Form
    {

        DataTable dt;
        readonly FireBaseManagement fireBaseManagement;
        readonly AutoIdManagement autoIdManagement;
        readonly StudentManagement studentManagement;
        public Form1()
        {
            fireBaseManagement = new FireBaseManagement();
            autoIdManagement = new AutoIdManagement();
            studentManagement = new StudentManagement();
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            IFirebaseClient client = fireBaseManagement.InitialFireBase();
            ReGenerateDataTable();
            if (client != null)
            {
                DbConnectStatus.Text = "connected";
                DbConnectStatus.ForeColor = Color.MediumSeaGreen;

                string autoIncrement = (await autoIdManagement.GetCurrentId() + 1).ToString();
                studentId.Text = autoIncrement;
            }
        }


        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student { 
                Id = studentId.Text,
                FirstName = studentFirstName.Text,
                LastName = studentLastName.Text
            };
            await studentManagement.Create(student);
            await autoIdManagement.UpdateId(studentId.Text);

            ClearTextBox();
            ReGenerateDataTable();
        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Student studentResponse = await studentManagement.GetStudentById(searchBox.Text);
                if (studentResponse.IsActive)
                {
                    studentId.Text = studentResponse.Id;
                    studentFirstName.Text = studentResponse.FirstName;
                    studentLastName.Text = studentResponse.LastName;
                }
                else
                {
                    MessageBox.Show("นักศึกษาเลขรหัสนี้ ถูกลบออกจากระบบแล้ว");
                }
            }
            catch
            {
                MessageBox.Show("ไม่มีนักศึกษาเลขรหัสนี้ อยู่ในระบบ");
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = studentId.Text,
                FirstName = studentFirstName.Text,
                LastName = studentLastName.Text
            };
            await studentManagement.Update(studentId.Text, student);
            ClearTextBox();
            ReGenerateDataTable();
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = studentId.Text,
                FirstName = studentFirstName.Text,
                LastName = studentLastName.Text,
                IsActive = false
            };
            await studentManagement.Update(studentId.Text, student);
            ClearTextBox();
            ReGenerateDataTable();
        }


        private async void DeleteAllBtn_Click(object sender, EventArgs e)
        {
            await studentManagement.DeleteAll();
            await autoIdManagement.UpdateId("0");
            ClearTextBox();
            ReGenerateDataTable();
        }
        private async void ClearTextBox() {
            studentId.Text = (await autoIdManagement.GetCurrentId() + 1).ToString();
            studentFirstName.Text = "";
            studentLastName.Text = "";
        }
        private void ClearDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
        }
        private void AddAllDataTable(List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student != null && student.IsActive)
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = student.Id;
                    row["FirstName"] = student.FirstName;
                    row["LastName"] = student.LastName;
                    dt.Rows.Add(row);
                }
            }
            dataShow.DataSource = dt;
            dataShow = CreateRemoveStudentButton(dataShow);
        }

        private async void ReGenerateDataTable()
        {
            List<Student> students = new List<Student>();
            try
            {
                students = await studentManagement.GetAll();
            }
            catch
            {
            }
            ClearDataTable();
            AddAllDataTable(students);
        }
        private DataGridView CreateRemoveStudentButton(DataGridView dataShow)
        {
            DataGridViewButtonColumn removeStudentButton = new DataGridViewButtonColumn();
            removeStudentButton.Name = "remove";
            removeStudentButton.Text = "remove";
            removeStudentButton.UseColumnTextForButtonValue = true;
            if (dataShow.Columns["remove"] == null)
            {
                dataShow.Columns.Insert(3, removeStudentButton);
            }
            dataShow.CellClick += AddEventDataGridRemoveStudentBtn_CellClick;
            return dataShow;
        }
        private async void AddEventDataGridRemoveStudentBtn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataShow.Columns["remove"].Index)
            {
                DataGridViewRow selectedRow = dataShow.Rows[dataShow.SelectedCells[0].RowIndex];
                Student student = new Student
                {
                    Id = selectedRow.Cells["Id"].Value.ToString(),
                    FirstName = selectedRow.Cells["FirstName"].Value.ToString(),
                    LastName = selectedRow.Cells["LastName"].Value.ToString(),
                    IsActive = false
                };

                await studentManagement.Update(selectedRow.Cells["Id"].Value.ToString(), student);
                ClearTextBox();
                ReGenerateDataTable();
            }
        }
    }
}
