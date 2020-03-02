using FileManager.Common.Layer;
using FileManager.DataAccess.Data;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        private readonly IStudentDao studentDao;
        private readonly frmMain frmMain;
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
            var newStudent = new Student();
            newStudent.Id = int.Parse(txtId.Text);
            newStudent.Name = txtName.Text;
            newStudent.LastName = txtLastName.Text;
            newStudent.Age = int.Parse(txtAge.Text);
            studentDao.Create(newStudent);
            frmMain.RefreshStudentList();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
