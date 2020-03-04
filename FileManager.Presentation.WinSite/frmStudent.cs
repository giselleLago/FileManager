using FileManager.Common.Layer.Entities;
using FileManager.DataAccess.Data.Services;
using log4net;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        private readonly IStudentDao studentDao;
        private readonly frmMain frmMain;
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmStudent));
        public frmStudent(IStudentDao studentDao, frmMain frmMain)
        {
            InitializeComponent();
            this.studentDao = studentDao;
            this.frmMain = frmMain;
        }

        public frmStudent()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            if (ValidateAll())
            {
                try
                {
                    var newStudent = new Student();
                    newStudent.Id = int.Parse(txtId.Text);
                    newStudent.Name = txtName.Text;
                    newStudent.LastName = txtLastName.Text;
                    newStudent.Age = int.Parse(txtAge.Text);
                    studentDao.Create(newStudent);
                    frmMain.RefreshStudentList();
                    Close();
                }
                catch (Exception ex)
                {
                    logger.Error("An error has occurred creating the student.", ex);
                    MessageBox.Show("An error has occurred creating the student.");
                }
                
            }
            else
            {
                MessageBox.Show("Student not valid");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateAll()
        {
            if (ValidateId() && ValidateName() && ValidateLastName() && ValidateAge())
            {
                return true;
            }
            return false;
        }

        private bool ValidateId()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                return false;
            }
            return true;
        }
        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            return true;
        }
        private bool ValidateLastName()
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                return false;
            }
            return true;
        }
        private bool ValidateAge()
        {
            if (string.IsNullOrEmpty(txtAge.Text))
            {
                return false;
            }
            return true;
        }
    }
}
