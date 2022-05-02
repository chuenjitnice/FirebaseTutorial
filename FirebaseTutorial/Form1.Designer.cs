
namespace FirebaseTutorial
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentId = new System.Windows.Forms.TextBox();
            this.studentFirstName = new System.Windows.Forms.TextBox();
            this.studentLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.DbConnectStatus = new System.Windows.Forms.Label();
            this.dataShow = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // studentId
            // 
            this.studentId.Location = new System.Drawing.Point(114, 80);
            this.studentId.Name = "studentId";
            this.studentId.ReadOnly = true;
            this.studentId.Size = new System.Drawing.Size(180, 20);
            this.studentId.TabIndex = 0;
            // 
            // studentFirstName
            // 
            this.studentFirstName.Location = new System.Drawing.Point(114, 120);
            this.studentFirstName.Name = "studentFirstName";
            this.studentFirstName.Size = new System.Drawing.Size(180, 20);
            this.studentFirstName.TabIndex = 1;
            // 
            // studentLastName
            // 
            this.studentLastName.Location = new System.Drawing.Point(114, 160);
            this.studentLastName.Name = "studentLastName";
            this.studentLastName.Size = new System.Drawing.Size(180, 20);
            this.studentLastName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last name";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.submitButton.ForeColor = System.Drawing.Color.Snow;
            this.submitButton.Location = new System.Drawing.Point(114, 200);
            this.submitButton.Margin = new System.Windows.Forms.Padding(0);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(80, 30);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Save";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(40, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Student information";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(359, 44);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(300, 20);
            this.searchBox.TabIndex = 8;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(669, 42);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 24);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.updateButton.ForeColor = System.Drawing.Color.Snow;
            this.updateButton.Location = new System.Drawing.Point(214, 200);
            this.updateButton.Margin = new System.Windows.Forms.Padding(0);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(80, 30);
            this.updateButton.TabIndex = 10;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Red;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.deleteButton.ForeColor = System.Drawing.Color.Snow;
            this.deleteButton.Location = new System.Drawing.Point(114, 240);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(180, 30);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.BackColor = System.Drawing.Color.Crimson;
            this.deleteAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.deleteAllButton.ForeColor = System.Drawing.Color.Snow;
            this.deleteAllButton.Location = new System.Drawing.Point(114, 280);
            this.deleteAllButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(180, 40);
            this.deleteAllButton.TabIndex = 12;
            this.deleteAllButton.Text = "Delete All";
            this.deleteAllButton.UseVisualStyleBackColor = false;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // DbConnectStatus
            // 
            this.DbConnectStatus.AutoSize = true;
            this.DbConnectStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DbConnectStatus.ForeColor = System.Drawing.Color.Coral;
            this.DbConnectStatus.Location = new System.Drawing.Point(12, 339);
            this.DbConnectStatus.Name = "DbConnectStatus";
            this.DbConnectStatus.Size = new System.Drawing.Size(81, 13);
            this.DbConnectStatus.TabIndex = 13;
            this.DbConnectStatus.Text = "unconnected";
            this.DbConnectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataShow
            // 
            this.dataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataShow.Location = new System.Drawing.Point(359, 82);
            this.dataShow.Name = "dataShow";
            this.dataShow.ReadOnly = true;
            this.dataShow.Size = new System.Drawing.Size(380, 238);
            this.dataShow.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.dataShow);
            this.Controls.Add(this.DbConnectStatus);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentLastName);
            this.Controls.Add(this.studentFirstName);
            this.Controls.Add(this.studentId);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirebaseForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentId;
        private System.Windows.Forms.TextBox studentFirstName;
        private System.Windows.Forms.TextBox studentLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Label DbConnectStatus;
        private System.Windows.Forms.DataGridView dataShow;
    }
}

