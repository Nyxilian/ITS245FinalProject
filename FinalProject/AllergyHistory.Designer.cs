namespace FinalProject
{
    partial class AllergyHistory
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkDeleted = new System.Windows.Forms.CheckBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbEndDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAllergen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAllergyID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnToFamilyHistory = new System.Windows.Forms.Button();
            this.btnToGenMedHis = new System.Windows.Forms.Button();
            this.btnToSelectPatient = new System.Windows.Forms.Button();
            this.btnToLogin = new System.Windows.Forms.Button();
            this.btnToAllergyHistory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnToPatientDemo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 42);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 251);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 42);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(12, 203);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(179, 42);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(12, 107);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(179, 42);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(179, 42);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(12, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(252, 527);
            this.panel5.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(230, 500);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.checkDeleted);
            this.panel4.Controls.Add(this.tbDescription);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.tbEndDate);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.tbStartDate);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tbAllergen);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tbPatientID);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tbAllergyID);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(270, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 526);
            this.panel4.TabIndex = 16;
            // 
            // checkDeleted
            // 
            this.checkDeleted.BackColor = System.Drawing.Color.White;
            this.checkDeleted.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDeleted.Location = new System.Drawing.Point(189, 474);
            this.checkDeleted.Name = "checkDeleted";
            this.checkDeleted.Size = new System.Drawing.Size(170, 27);
            this.checkDeleted.TabIndex = 8;
            this.checkDeleted.Text = "Deleted";
            this.checkDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkDeleted.UseVisualStyleBackColor = false;
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.Location = new System.Drawing.Point(189, 396);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(173, 37);
            this.tbDescription.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(10, 399);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 29);
            this.label9.TabIndex = 6;
            this.label9.Text = "AllergyDescription";
            // 
            // tbEndDate
            // 
            this.tbEndDate.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEndDate.Location = new System.Drawing.Point(189, 326);
            this.tbEndDate.Name = "tbEndDate";
            this.tbEndDate.Size = new System.Drawing.Size(173, 37);
            this.tbEndDate.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(34, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "AllergyEndDate";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStartDate.Location = new System.Drawing.Point(189, 253);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(173, 37);
            this.tbStartDate.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(26, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "AllergyStartDate";
            // 
            // tbAllergen
            // 
            this.tbAllergen.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAllergen.Location = new System.Drawing.Point(190, 185);
            this.tbAllergen.Name = "tbAllergen";
            this.tbAllergen.Size = new System.Drawing.Size(173, 37);
            this.tbAllergen.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(99, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Allergen";
            // 
            // tbPatientID
            // 
            this.tbPatientID.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPatientID.Location = new System.Drawing.Point(189, 112);
            this.tbPatientID.Name = "tbPatientID";
            this.tbPatientID.Size = new System.Drawing.Size(173, 37);
            this.tbPatientID.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(91, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "PatientID";
            // 
            // tbAllergyID
            // 
            this.tbAllergyID.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAllergyID.Location = new System.Drawing.Point(189, 38);
            this.tbAllergyID.Name = "tbAllergyID";
            this.tbAllergyID.Size = new System.Drawing.Size(173, 37);
            this.tbAllergyID.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(92, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "AllergyID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnToFamilyHistory);
            this.panel2.Controls.Add(this.btnToGenMedHis);
            this.panel2.Controls.Add(this.btnToSelectPatient);
            this.panel2.Controls.Add(this.btnToLogin);
            this.panel2.Controls.Add(this.btnToAllergyHistory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnToPatientDemo);
            this.panel2.Location = new System.Drawing.Point(656, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 290);
            this.panel2.TabIndex = 15;
            // 
            // btnToFamilyHistory
            // 
            this.btnToFamilyHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToFamilyHistory.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToFamilyHistory.Location = new System.Drawing.Point(13, 245);
            this.btnToFamilyHistory.Name = "btnToFamilyHistory";
            this.btnToFamilyHistory.Size = new System.Drawing.Size(179, 32);
            this.btnToFamilyHistory.TabIndex = 6;
            this.btnToFamilyHistory.Text = "Family History";
            this.btnToFamilyHistory.UseVisualStyleBackColor = false;
            this.btnToFamilyHistory.Click += new System.EventHandler(this.btnToFamilyHistory_Click);
            // 
            // btnToGenMedHis
            // 
            this.btnToGenMedHis.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToGenMedHis.Font = new System.Drawing.Font("Sans Serif Collection", 7F);
            this.btnToGenMedHis.Location = new System.Drawing.Point(13, 169);
            this.btnToGenMedHis.Name = "btnToGenMedHis";
            this.btnToGenMedHis.Size = new System.Drawing.Size(179, 32);
            this.btnToGenMedHis.TabIndex = 4;
            this.btnToGenMedHis.Text = "General Medical History";
            this.btnToGenMedHis.UseVisualStyleBackColor = false;
            this.btnToGenMedHis.Click += new System.EventHandler(this.btnToGenMedHis_Click);
            // 
            // btnToSelectPatient
            // 
            this.btnToSelectPatient.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToSelectPatient.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToSelectPatient.Location = new System.Drawing.Point(13, 93);
            this.btnToSelectPatient.Name = "btnToSelectPatient";
            this.btnToSelectPatient.Size = new System.Drawing.Size(179, 32);
            this.btnToSelectPatient.TabIndex = 2;
            this.btnToSelectPatient.Text = "Select Patient";
            this.btnToSelectPatient.UseVisualStyleBackColor = false;
            this.btnToSelectPatient.Click += new System.EventHandler(this.btnToSelectPatient_Click);
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
            this.btnToLogin.Click += new System.EventHandler(this.btnToLogin_Click);
            // 
            // btnToAllergyHistory
            // 
            this.btnToAllergyHistory.BackColor = System.Drawing.Color.Orange;
            this.btnToAllergyHistory.Enabled = false;
            this.btnToAllergyHistory.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToAllergyHistory.Location = new System.Drawing.Point(13, 207);
            this.btnToAllergyHistory.Name = "btnToAllergyHistory";
            this.btnToAllergyHistory.Size = new System.Drawing.Size(179, 32);
            this.btnToAllergyHistory.TabIndex = 6;
            this.btnToAllergyHistory.Text = "Allergy History";
            this.btnToAllergyHistory.UseVisualStyleBackColor = false;
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
            // btnToPatientDemo
            // 
            this.btnToPatientDemo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnToPatientDemo.Font = new System.Drawing.Font("Sans Serif Collection", 7F);
            this.btnToPatientDemo.Location = new System.Drawing.Point(13, 131);
            this.btnToPatientDemo.Name = "btnToPatientDemo";
            this.btnToPatientDemo.Size = new System.Drawing.Size(179, 32);
            this.btnToPatientDemo.TabIndex = 1;
            this.btnToPatientDemo.Text = "Patient Demographics";
            this.btnToPatientDemo.UseVisualStyleBackColor = false;
            this.btnToPatientDemo.Click += new System.EventHandler(this.btnToPatientDemo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.cbPatient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 67);
            this.panel1.TabIndex = 14;
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
            this.cbPatient.SelectedIndexChanged += new System.EventHandler(this.cbPatient_SelectedIndexChanged);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUndo);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnModify);
            this.panel3.Location = new System.Drawing.Point(657, 308);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 304);
            this.panel3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "Action Menu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllergyHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(865, 621);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AllergyHistory";
            this.Text = "Allergy History";
            this.Load += new System.EventHandler(this.AllergyHistory_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToFamilyHistory;
        private System.Windows.Forms.Button btnToGenMedHis;
        private System.Windows.Forms.Button btnToSelectPatient;
        private System.Windows.Forms.Button btnToLogin;
        private System.Windows.Forms.Button btnToAllergyHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnToPatientDemo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAllergyID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAllergen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkDeleted;
    }
}