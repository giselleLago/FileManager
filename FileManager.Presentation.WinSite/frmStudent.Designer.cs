using System;

namespace FileManager.Presentation.WinSite
{
    partial class frmStudent
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.studentID = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(467, 263);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Location = new System.Drawing.Point(431, 45);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFile.TabIndex = 1;
            // 
            // studentID
            // 
            this.studentID.AutoSize = true;
            this.studentID.Location = new System.Drawing.Point(88, 53);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(21, 13);
            this.studentID.TabIndex = 2;
            this.studentID.Text = "ID:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(71, 98);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 3;
            this.name.Text = "Name:";
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Location = new System.Drawing.Point(48, 145);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(61, 13);
            this.lastName.TabIndex = 4;
            this.lastName.Text = "Last Name:";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Location = new System.Drawing.Point(80, 195);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(29, 13);
            this.age.TabIndex = 5;
            this.age.Text = "Age:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(156, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(156, 188);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(130, 20);
            this.textBox4.TabIndex = 9;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 373);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.age);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.name);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.comboBoxFile);
            this.Controls.Add(this.saveButton);
            this.Name = "frmStudent";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox comboBoxFile;
        private System.Windows.Forms.Label studentID;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

