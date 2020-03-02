using FileManager.DataAccess.Data;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmMain : Form
    {
        private IStudentDao studentDao;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbxDataFormat.SelectedIndex = 0;
        }

        private void cbxDataFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDataFormat.SelectedIndex == 0)
            {
                studentDao = StudentDaoFactory.Create(DataFormat.JSON);
            }
            else
            {
                studentDao = StudentDaoFactory.Create(DataFormat.XML);
            }
            RefreshStudentList();
        }

        public void RefreshStudentList()
        {
            var studentList = studentDao.GetAll();
            lvwStudents.Items.Clear();
            foreach (var item in studentList)
            {
                string[] newItem = { item.Id.ToString(), item.Name, item.LastName, item.Age.ToString() };
                var result = new ListViewItem(newItem);
                lvwStudents.Items.Add(result);
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var studentForm = new frmStudent(studentDao, this);
            studentForm.ShowDialog();
        }
    }
}
