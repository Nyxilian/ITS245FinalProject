namespace FinalProject
{
    partial class SelectPatient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToPatientDemo = new System.Windows.Forms.Button();
            this.btnToAllergyHistory = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.TBSearchPatients = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnToLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tBPhoneNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToPatientDemo
            // 
            this.btnToPatientDemo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToPatientDemo.Location = new System.Drawing.Point(13, 131);
            this.btnToPatientDemo.Name = "btnToPatientDemo";
            this.btnToPatientDemo.Size = new System.Drawing.Size(179, 32);
            this.btnToPatientDemo.TabIndex = 1;
            this.btnToPatientDemo.Text = "Patient Demographics";
            this.btnToPatientDemo.UseVisualStyleBackColor = false;
            this.btnToPatientDemo.Click += new System.EventHandler(this.btnToPatientDemo_Click);
            // 
            // btnToAllergyHistory
            // 
            this.btnToAllergyHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToAllergyHistory.Location = new System.Drawing.Point(13, 207);
            this.btnToAllergyHistory.Name = "btnToAllergyHistory";
            this.btnToAllergyHistory.Size = new System.Drawing.Size(179, 32);
            this.btnToAllergyHistory.TabIndex = 6;
            this.btnToAllergyHistory.Text = "Allergy History";
            this.btnToAllergyHistory.UseVisualStyleBackColor = false;
            this.btnToAllergyHistory.Click += new System.EventHandler(this.btnToAllergyHistory_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Location = new System.Drawing.Point(12, 69);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 59);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update Patient List";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TBSearchPatients
            // 
            this.TBSearchPatients.Location = new System.Drawing.Point(11, 232);
            this.TBSearchPatients.Name = "TBSearchPatients";
            this.TBSearchPatients.Size = new System.Drawing.Size(177, 21);
            this.TBSearchPatients.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter ID or Last Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearchPatient.Location = new System.Drawing.Point(11, 259);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(177, 31);
            this.btnSearchPatient.TabIndex = 5;
            this.btnSearchPatient.Text = "Search Paitent";
            this.btnSearchPatient.UseVisualStyleBackColor = false;
            this.btnSearchPatient.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selected Patient:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.cbPatient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 67);
            this.panel1.TabIndex = 9;
            // 
            // cbPatient
            // 
            this.cbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatient.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPatient.FormattingEnabled = true;
            this.cbPatient.Location = new System.Drawing.Point(258, 12);
            this.cbPatient.Name = "cbPatient";
            this.cbPatient.Size = new System.Drawing.Size(335, 47);
            this.cbPatient.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnToLogin);
            this.panel2.Controls.Add(this.btnToAllergyHistory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnToPatientDemo);
            this.panel2.Location = new System.Drawing.Point(656, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 290);
            this.panel2.TabIndex = 10;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(13, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(179, 32);
            this.button6.TabIndex = 6;
            this.button6.Text = "Family History";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Font = new System.Drawing.Font("Sans Serif Collection", 7F);
            this.button4.Location = new System.Drawing.Point(13, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "General Medical History";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(13, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Patient";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnToLogin
            // 
            this.btnToLogin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToLogin.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToLogin.Location = new System.Drawing.Point(13, 55);
            this.btnToLogin.Name = "btnToLogin";
            this.btnToLogin.Size = new System.Drawing.Size(179, 32);
            this.btnToLogin.TabIndex = 1;
            this.btnToLogin.Text = "Login";
            this.btnToLogin.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Navigation";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSearchPatient);
            this.panel3.Controls.Add(this.TBSearchPatients);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(656, 308);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 304);
            this.panel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(52, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "Action Menu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.tBPhoneNumber);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.tBLastName);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tBFirstName);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(12, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(638, 526);
            this.panel4.TabIndex = 12;
            // 
            // tBPhoneNumber
            // 
            this.tBPhoneNumber.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBPhoneNumber.Location = new System.Drawing.Point(307, 334);
            this.tBPhoneNumber.Name = "tBPhoneNumber";
            this.tBPhoneNumber.ReadOnly = true;
            this.tBPhoneNumber.Size = new System.Drawing.Size(173, 37);
            this.tBPhoneNumber.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(158, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "Phone Number";
            // 
            // tBLastName
            // 
            this.tBLastName.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBLastName.Location = new System.Drawing.Point(307, 234);
            this.tBLastName.Name = "tBLastName";
            this.tBLastName.ReadOnly = true;
            this.tBLastName.Size = new System.Drawing.Size(173, 37);
            this.tBLastName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(193, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 29);
            this.label7.TabIndex = 4;
            this.label7.Text = "Last Name";
            // 
            // tBFirstName
            // 
            this.tBFirstName.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBFirstName.Location = new System.Drawing.Point(307, 134);
            this.tBFirstName.Name = "tBFirstName";
            this.tBFirstName.ReadOnly = true;
            this.tBFirstName.Size = new System.Drawing.Size(173, 37);
            this.tBFirstName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(193, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "First Name";
            // 
            // SelectPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(868, 624);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SelectPatient";
            this.Text = "Select Patient";
            this.Load += new System.EventHandler(this.SelectPatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnToPatientDemo;
        private System.Windows.Forms.Button btnToAllergyHistory;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox TBSearchPatients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnToLogin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBFirstName;
        private System.Windows.Forms.TextBox tBLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBPhoneNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPatient;
    }
}

