using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FirebaseTutorial
{
    public partial class Form1 : Form
    {

        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "eLaD9VNfw6n4cRnDNYStNSMh8iil7YmqkARmg1sn",
            BasePath = "https://csharpworkshop-f8081-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            ReGenerateDataTable();
            if (client != null)
            {
                DbConnectStatus.Text = "connected";
                DbConnectStatus.ForeColor = Color.MediumSeaGreen;

                string autoIncrement = (await GetCurrentAutoId() + 1).ToString();
                studentId.Text = autoIncrement;
            }
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            var student = new Student { 
                Id = studentId.Text,
                FirstName = studentFirstName.Text,
                LastName = studentLastName.Text
            };
            SetResponse response = await client.SetTaskAsync("Student/" + studentId.Text, student);
            await UpdateAutoId(studentId.Text);

            ClearTextBox();
            ReGenerateDataTable();
        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Student studentResponse = await GetStudentById(searchBox.Text);
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
            await UpdateStudent(studentId.Text, student);
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
            await UpdateStudent(studentId.Text, student);
            ClearTextBox();
            ReGenerateDataTable();
        }


        private async void DeleteAllBtn_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Student/");
            await UpdateAutoId("0");
            ClearTextBox();
            ReGenerateDataTable();
        }
        private async void ClearTextBox() {
            studentId.Text = (await GetCurrentAutoId() + 1).ToString();
            studentFirstName.Text = "";
            studentLastName.Text = "";
            //dataShow.Rows[0].Selected = false;
        }
        private void ClearDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
        }
        private async void ShowDataTable()
        {
            for (int i = 1; i <= await GetCurrentAutoId(); i++)
            {
                Student studentResponse = await GetStudentById(i.ToString());
                if (studentResponse.IsActive)
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = studentResponse.Id;
                    row["FirstName"] = studentResponse.FirstName;
                    row["LastName"] = studentResponse.LastName;
                    dt.Rows.Add(row);
                }
            }
            dataShow.DataSource = dt;
            dataShow = CreateRemoveStudentButton(dataShow);
        }


        private void ReGenerateDataTable()
        {
            ClearDataTable();
            ShowDataTable();
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
                //string selectedStudentId = selectedRow.Cells["Id"].Value.ToString();
                Student student = new Student
                {
                    Id = selectedRow.Cells["Id"].Value.ToString(),
                    FirstName = selectedRow.Cells["FirstName"].Value.ToString(),
                    LastName = selectedRow.Cells["LastName"].Value.ToString(),
                    IsActive = false
                };

                await UpdateStudent(selectedRow.Cells["Id"].Value.ToString(), student);
                ClearTextBox();
                ReGenerateDataTable();
            }
        }

        private async Task<int> GetCurrentAutoId()
        {
            FirebaseResponse autoResponse = await client.GetTaskAsync("Auto");
            return Convert.ToInt32(autoResponse.ResultAs<AutoIncrement>().Counter);
        }
        private async Task<int> UpdateAutoId(string newAutoId)
        {
            await client.UpdateTaskAsync("Auto", new AutoIncrement { Counter = newAutoId });
            FirebaseResponse autoResponse = await client.GetTaskAsync("Auto");
            return Convert.ToInt32(autoResponse.ResultAs<AutoIncrement>().Counter);
        }

        private async Task<Student> GetStudentById(string studentId)
        {
            FirebaseResponse response = await client.GetTaskAsync("Student/" + studentId);
            return response.ResultAs<Student>();
        }
        private async Task<Student> UpdateStudent(string studentId, Student student)
        {
            FirebaseResponse response = await client.UpdateTaskAsync("Student/" + studentId, student);
            return response.ResultAs<Student>();
        }
    }
}
