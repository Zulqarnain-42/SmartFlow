namespace SmartFlow.Masters
{
    partial class Employee
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.departmenttxtbox = new System.Windows.Forms.TextBox();
            this.contracttypetxtbox = new System.Windows.Forms.TextBox();
            this.designationtxtbox = new System.Windows.Forms.TextBox();
            this.educationtxtbox = new System.Windows.Forms.TextBox();
            this.nationalitytxtbox = new System.Windows.Forms.TextBox();
            this.contractexpirylbl = new System.Windows.Forms.Label();
            this.contracttypelbl = new System.Windows.Forms.Label();
            this.departmentlbl = new System.Windows.Forms.Label();
            this.designationlbl = new System.Windows.Forms.Label();
            this.dateofjoininglbl = new System.Windows.Forms.Label();
            this.educationlbl = new System.Windows.Forms.Label();
            this.nationalitylbl = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.contractexpirydate = new System.Windows.Forms.MaskedTextBox();
            this.dateofjoiningdate = new System.Windows.Forms.MaskedTextBox();
            this.employeeidlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 45);
            this.panel1.TabIndex = 0;
            // 
            // headinglbl
            // 
            this.headinglbl.BackColor = System.Drawing.Color.Black;
            this.headinglbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headinglbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headinglbl.Location = new System.Drawing.Point(0, 0);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(740, 45);
            this.headinglbl.TabIndex = 0;
            this.headinglbl.Text = "EMPLOYEE";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departmenttxtbox
            // 
            this.departmenttxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departmenttxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmenttxtbox.Location = new System.Drawing.Point(253, 200);
            this.departmenttxtbox.Name = "departmenttxtbox";
            this.departmenttxtbox.Size = new System.Drawing.Size(380, 32);
            this.departmenttxtbox.TabIndex = 91;
            // 
            // contracttypetxtbox
            // 
            this.contracttypetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contracttypetxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contracttypetxtbox.Location = new System.Drawing.Point(253, 233);
            this.contracttypetxtbox.Name = "contracttypetxtbox";
            this.contracttypetxtbox.Size = new System.Drawing.Size(380, 32);
            this.contracttypetxtbox.TabIndex = 90;
            // 
            // designationtxtbox
            // 
            this.designationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designationtxtbox.Location = new System.Drawing.Point(253, 167);
            this.designationtxtbox.Name = "designationtxtbox";
            this.designationtxtbox.Size = new System.Drawing.Size(380, 32);
            this.designationtxtbox.TabIndex = 89;
            // 
            // educationtxtbox
            // 
            this.educationtxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.educationtxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.educationtxtbox.Location = new System.Drawing.Point(253, 101);
            this.educationtxtbox.Name = "educationtxtbox";
            this.educationtxtbox.Size = new System.Drawing.Size(380, 32);
            this.educationtxtbox.TabIndex = 88;
            // 
            // nationalitytxtbox
            // 
            this.nationalitytxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nationalitytxtbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nationalitytxtbox.Location = new System.Drawing.Point(253, 68);
            this.nationalitytxtbox.Name = "nationalitytxtbox";
            this.nationalitytxtbox.Size = new System.Drawing.Size(380, 32);
            this.nationalitytxtbox.TabIndex = 87;
            // 
            // contractexpirylbl
            // 
            this.contractexpirylbl.AutoSize = true;
            this.contractexpirylbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.contractexpirylbl.Location = new System.Drawing.Point(66, 271);
            this.contractexpirylbl.Name = "contractexpirylbl";
            this.contractexpirylbl.Size = new System.Drawing.Size(152, 23);
            this.contractexpirylbl.TabIndex = 86;
            this.contractexpirylbl.Text = "CONTRACT EXPIRY";
            // 
            // contracttypelbl
            // 
            this.contracttypelbl.AutoSize = true;
            this.contracttypelbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.contracttypelbl.Location = new System.Drawing.Point(65, 238);
            this.contracttypelbl.Name = "contracttypelbl";
            this.contracttypelbl.Size = new System.Drawing.Size(135, 23);
            this.contracttypelbl.TabIndex = 85;
            this.contracttypelbl.Text = "CONTRACT TYPE";
            // 
            // departmentlbl
            // 
            this.departmentlbl.AutoSize = true;
            this.departmentlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.departmentlbl.Location = new System.Drawing.Point(66, 205);
            this.departmentlbl.Name = "departmentlbl";
            this.departmentlbl.Size = new System.Drawing.Size(116, 23);
            this.departmentlbl.TabIndex = 84;
            this.departmentlbl.Text = "DEPARTMENT";
            // 
            // designationlbl
            // 
            this.designationlbl.AutoSize = true;
            this.designationlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.designationlbl.Location = new System.Drawing.Point(65, 172);
            this.designationlbl.Name = "designationlbl";
            this.designationlbl.Size = new System.Drawing.Size(120, 23);
            this.designationlbl.TabIndex = 83;
            this.designationlbl.Text = "DESIGNATION";
            // 
            // dateofjoininglbl
            // 
            this.dateofjoininglbl.AutoSize = true;
            this.dateofjoininglbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.dateofjoininglbl.Location = new System.Drawing.Point(65, 139);
            this.dateofjoininglbl.Name = "dateofjoininglbl";
            this.dateofjoininglbl.Size = new System.Drawing.Size(147, 23);
            this.dateofjoininglbl.TabIndex = 82;
            this.dateofjoininglbl.Text = "DATE OF JOINING";
            // 
            // educationlbl
            // 
            this.educationlbl.AutoSize = true;
            this.educationlbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.educationlbl.Location = new System.Drawing.Point(66, 106);
            this.educationlbl.Name = "educationlbl";
            this.educationlbl.Size = new System.Drawing.Size(103, 23);
            this.educationlbl.TabIndex = 81;
            this.educationlbl.Text = "EDUCATION";
            // 
            // nationalitylbl
            // 
            this.nationalitylbl.AutoSize = true;
            this.nationalitylbl.Font = new System.Drawing.Font("Calibri", 11F);
            this.nationalitylbl.Location = new System.Drawing.Point(65, 73);
            this.nationalitylbl.Name = "nationalitylbl";
            this.nationalitylbl.Size = new System.Drawing.Size(115, 23);
            this.nationalitylbl.TabIndex = 80;
            this.nationalitylbl.Text = "NATIONALITY";
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(253, 350);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(380, 40);
            this.closebtn.TabIndex = 93;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.SpringGreen;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(253, 304);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(380, 40);
            this.savebtn.TabIndex = 92;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // contractexpirydate
            // 
            this.contractexpirydate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contractexpirydate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contractexpirydate.Location = new System.Drawing.Point(253, 266);
            this.contractexpirydate.Mask = "00/00/0000";
            this.contractexpirydate.Name = "contractexpirydate";
            this.contractexpirydate.Size = new System.Drawing.Size(380, 32);
            this.contractexpirydate.TabIndex = 112;
            this.contractexpirydate.ValidatingType = typeof(System.DateTime);
            // 
            // dateofjoiningdate
            // 
            this.dateofjoiningdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateofjoiningdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateofjoiningdate.Location = new System.Drawing.Point(253, 134);
            this.dateofjoiningdate.Mask = "00/00/0000";
            this.dateofjoiningdate.Name = "dateofjoiningdate";
            this.dateofjoiningdate.Size = new System.Drawing.Size(380, 32);
            this.dateofjoiningdate.TabIndex = 113;
            this.dateofjoiningdate.ValidatingType = typeof(System.DateTime);
            // 
            // employeeidlbl
            // 
            this.employeeidlbl.AutoSize = true;
            this.employeeidlbl.Location = new System.Drawing.Point(69, 304);
            this.employeeidlbl.Name = "employeeidlbl";
            this.employeeidlbl.Size = new System.Drawing.Size(93, 16);
            this.employeeidlbl.TabIndex = 114;
            this.employeeidlbl.Text = "employeeidlbl";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(740, 446);
            this.Controls.Add(this.employeeidlbl);
            this.Controls.Add(this.dateofjoiningdate);
            this.Controls.Add(this.contractexpirydate);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.departmenttxtbox);
            this.Controls.Add(this.contracttypetxtbox);
            this.Controls.Add(this.designationtxtbox);
            this.Controls.Add(this.educationtxtbox);
            this.Controls.Add(this.nationalitytxtbox);
            this.Controls.Add(this.contractexpirylbl);
            this.Controls.Add(this.contracttypelbl);
            this.Controls.Add(this.departmentlbl);
            this.Controls.Add(this.designationlbl);
            this.Controls.Add(this.dateofjoininglbl);
            this.Controls.Add(this.educationlbl);
            this.Controls.Add(this.nationalitylbl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLOYEE";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.TextBox departmenttxtbox;
        private System.Windows.Forms.TextBox contracttypetxtbox;
        private System.Windows.Forms.TextBox designationtxtbox;
        private System.Windows.Forms.TextBox educationtxtbox;
        private System.Windows.Forms.TextBox nationalitytxtbox;
        private System.Windows.Forms.Label contractexpirylbl;
        private System.Windows.Forms.Label contracttypelbl;
        private System.Windows.Forms.Label departmentlbl;
        private System.Windows.Forms.Label designationlbl;
        private System.Windows.Forms.Label dateofjoininglbl;
        private System.Windows.Forms.Label educationlbl;
        private System.Windows.Forms.Label nationalitylbl;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.MaskedTextBox contractexpirydate;
        private System.Windows.Forms.MaskedTextBox dateofjoiningdate;
        private System.Windows.Forms.Label employeeidlbl;
    }
}