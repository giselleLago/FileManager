﻿using FileManager.Business.DTOs;
using FileManager.Business.Services;
using FileManager.Common.Layer.Entities;
using log4net;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        private readonly IStudentService studentService;
        private readonly frmMain frmMain;
        private readonly StudentDto student;
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmStudent));

        public frmStudent(IStudentService studentService, frmMain frmMain, StudentDto student)
        {
            InitializeComponent();
            this.studentService = studentService;
            this.frmMain = frmMain;
            this.student = student;
        }
        public frmStudent(IStudentService studentService, frmMain frmMain)
        {
            InitializeComponent();
            this.studentService = studentService;
            this.frmMain = frmMain;
        }

        public frmStudent()
        {
            InitializeComponent();
        }

        private void Create()
        {
            if (ValidateAll())
            {
                try
                {
                    var newStudent = new StudentDto
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        LastName = txtLastName.Text,
                        Age = int.Parse(txtAge.Text)
                    };
                    studentService.Create(newStudent);
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

        private void Update()
        {
            if (ValidateAll())
            {
                try
                {
                    var newStudent = new StudentDto
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        LastName = txtLastName.Text,
                        Age = int.Parse(txtAge.Text)
                    };
                    studentService.Update(newStudent);
                    frmMain.RefreshStudentList();
                    Close();
                }
                catch (Exception ex)
                {
                    logger.Error("An error has occurred updating the student.", ex);
                    MessageBox.Show("An error has occurred updating the student.");
                }

            }
            else
            {
                MessageBox.Show("Student not valid");
            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            if (student == null)
            {
                Create();
            }
            else
            {
                Update();
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

        private void frmStudent_Load(object sender, EventArgs e)
        {
            if (student != null)
            {
                txtId.Text = student.Id.ToString();
                txtName.Text = student.Name;
                txtLastName.Text = student.LastName;
                txtAge.Text = student.Age.ToString();
                txtId.Enabled = false;
            }
        }
    }
}
