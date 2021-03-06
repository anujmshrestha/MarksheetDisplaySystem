﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marksheet
{
    public partial class Frm_Add_student : Form
    {
        class_studnet_details studentDetails = new class_studnet_details();
        public Frm_Add_student()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                studentDetails.Roll = Convert.ToInt32(txtRoll.Text);
                errorProvider1.Dispose();
                if (txtFirstName.Text  == "")
                    errorProvider1.SetError(txtFirstName, "can not be null");
                else 
                {
                    studentDetails.FName = txtFirstName.Text;
                    errorProvider1.Dispose();
                    if (txtLastName.Text=="" )
                        errorProvider1.SetError(txtLastName ,"can not be null");
                    else 
                    {
                        studentDetails.LName = txtLastName.Text;
                        errorProvider1.Dispose();

                        if (rdbMale.Checked == true)
                            studentDetails.Gender = "Male";
                        else
                            studentDetails.Gender = "Female";
                        studentDetails.DOB = dtpDOB.Value;
                        studentDetails.Address = txtAddress.Text;
                        studentDetails.Phone = txtPhone.Text;
                        if (studentDetails.Add_Student_Details() == "inserted")
                            MessageBox.Show("The data has been successfully added!","Success",MessageBoxButtons.OK , MessageBoxIcon.Information);
                        else
                           if ( MessageBox.Show("The data of roll:'"+studentDetails.Roll +"' already exists\n"+"Do you want to update the information? ","The Data already exists.",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                            MessageBox.Show(studentDetails.Update_Student_Details(),"Update!",MessageBoxButtons.OK ,MessageBoxIcon.Information );


                        txtAddress.Text = "";
                        txtFirstName .Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtRoll.Text = "";
                    }
                }
                
            }
            catch { errorProvider1.SetError(txtRoll, "not valid"); }

            See_All_Students();
        }

        private void Frm_Add_student_Load(object sender, EventArgs e)
        {
            See_All_Students(); 
            
        }
        private void See_All_Students()

    {
        DataTable dt = new DataTable();
        dt = studentDetails.Get_All_Student_Details();
        dgvStudentDetails.DataSource = dt;

    }

        private void dgvStudentDetails_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected Student's Deteails? ", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                studentDetails.Roll = Convert.ToInt32 (dgvStudentDetails.CurrentRow.Cells["Student_Roll"].Value);
               MessageBox.Show ( studentDetails.Delete_Student_Details(),"Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information );
                See_All_Students();
            }
        }
    }

}
