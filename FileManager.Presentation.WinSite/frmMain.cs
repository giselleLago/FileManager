using FileManager.Business.Services;
using FileManager.Common.Layer;
using log4net;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmMain : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmMain));
        private IStudentService studentService;

        public frmMain()
        {
            InitializeComponent();
            studentService = new StudentService();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbxDataFormat.SelectedIndex = 0;
        }

        private void cbxDataFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDataFormat.SelectedIndex == 0)
            {
                studentService.DataFormat = DataFormat.JSON;
            }
            else
            {
                studentService.DataFormat = DataFormat.XML;
            }
            RefreshStudentList();
        }

        public void RefreshStudentList()
        {
            try
            {
                var studentList = studentService.GetAll();
                lvwStudents.Items.Clear();
                foreach (var item in studentList)
                {
                    string[] newItem = { item.Id.ToString(), item.Name, item.LastName, item.Age.ToString() };
                    var result = new ListViewItem(newItem);
                    lvwStudents.Items.Add(result);
                }
            }
            catch (Exception ex)
            {
                logger.Error("An error has occurred listing the students.", ex);
                MessageBox.Show("An error has occurred listing the students.");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var studentForm = new frmStudent(studentService, this);
            studentForm.ShowDialog();
        }
    }
}
