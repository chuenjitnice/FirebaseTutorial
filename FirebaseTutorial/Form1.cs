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

        IFirebaseConfig config = new FirebaseConfig
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

                FirebaseResponse autoId = await client.GetTaskAsync("Auto/");
                string autoIncrement = (Convert.ToInt32(autoId.ResultAs<AutoIncrement>().counter) + 1).ToString();
                studentId.Text = autoIncrement;
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var student = new Student { 
                id = studentId.Text,
                firstName = studentFirstName.Text,
                lastName = studentLastName.Text
            };
            SetResponse response = await client.SetTaskAsync("Student/" + studentId.Text, student);
            FirebaseResponse autoResponse = await client.UpdateTaskAsync("Auto", new AutoIncrement { counter = studentId.Text });

            ClearTextBox();
            ReGenerateDataTable();
            //Student data = response.ResultAs<Student>();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Student/" + searchBox.Text);
            Student studentResponse = response.ResultAs<Student>();
            studentId.Text = studentResponse.id;
            studentFirstName.Text = studentResponse.firstName;
            studentLastName.Text = studentResponse.lastName;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                id = studentId.Text,
                firstName = studentFirstName.Text,
                lastName = studentLastName.Text
            };
            FirebaseResponse response = await client.UpdateTaskAsync("Student/" + studentId.Text, student);
            ClearTextBox();
            ReGenerateDataTable();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Student/" + studentId.Text);
            ClearTextBox();
            ReGenerateDataTable();
        }

        private async void deleteAllButton_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Student/");
            FirebaseResponse autoResponse = await client.UpdateTaskAsync("Auto", new AutoIncrement { counter = "0" });
            studentId.Text = "0";
            ClearTextBox();
            ReGenerateDataTable();
        }
        private void ClearTextBox() {
            studentId.Text = (Convert.ToInt32(studentId.Text)+1).ToString();
            studentFirstName.Text = "";
            studentLastName.Text = "";
        }
        private void ClearDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("firstName");
            dt.Columns.Add("lastName");
        }
        private async void ShowDataTable()
        {
            FirebaseResponse autoResponse = await client.GetTaskAsync("Auto");
            int studentCount = Convert.ToInt32(autoResponse.ResultAs<AutoIncrement>().counter);
            for(int i = 1; i <= studentCount ; i++)
            {
                try
                {
                    FirebaseResponse response;
                    response = await client.GetTaskAsync("Student/" + i);
                    Student studentResponse = response.ResultAs<Student>();
                    DataRow row = dt.NewRow();
                    row["id"] = studentResponse.id;
                    row["firstName"] = studentResponse.firstName;
                    row["lastName"] = studentResponse.lastName;
                    dt.Rows.Add(row);
                }
                catch
                {
                    continue;
                }
            }
            dataShow.DataSource = dt;
        }
        private void ReGenerateDataTable()
        {
            ClearDataTable();
            ShowDataTable();
        }
    }
}
