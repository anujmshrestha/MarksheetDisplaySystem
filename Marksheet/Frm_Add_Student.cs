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

                        studentDetails.Gender = rdbMale.Checked;
                        studentDetails.DOB = dtpDOB.Value;
                        studentDetails.Address = txtAddress.Text;
                        studentDetails.Phone = txtPhone.Text;
                        if (studentDetails.Add_Student_Details() == "inserted")
                            MessageBox.Show("Success!");
                        else
                            MessageBox.Show(studentDetails.Update_Student_Details());

                        txtAddress.Text = "";
                        txtFirstName .Text = "";
                        txtLastName.Text = "";
                        txtPhone.Text = "";
                        txtRoll.Text = "";
                    }
                }
                
            }
            catch { errorProvider1.SetError(txtRoll, "not valied"); }
        }
    }
}
