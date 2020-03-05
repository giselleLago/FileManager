using FileManager.Business.DTOs;
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
            else if (cbxDataFormat.SelectedIndex == 1)
            {
                studentService.DataFormat = DataFormat.XML;
            }
            else
            {
                studentService.DataFormat = DataFormat.TXT;
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

        private void cmsList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvwStudents.SelectedItems.Count == 0)
            {
                updateToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                updateToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = lvwStudents.SelectedItems[0];
            var student = new StudentDto
            {
                Id = int.Parse(item.SubItems[0].Text),
                Name = item.SubItems[1].Text,
                LastName = item.SubItems[2].Text,
                Age = int.Parse(item.SubItems[3].Text)
            };
            
            var studentForm = new frmStudent(studentService, this, student);
            studentForm.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = lvwStudents.SelectedItems[0];
            var dialogResult = MessageBox.Show("Are you sure you want delete?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                studentService.Delete(int.Parse(item.SubItems[0].Text));
                item.Remove();
            }
        }
    }
}
