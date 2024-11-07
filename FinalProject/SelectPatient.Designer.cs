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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnToPatientDemo = new System.Windows.Forms.Button();
            this.TBSearchPatients = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(531, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnToPatientDemo
            // 
            this.btnToPatientDemo.Location = new System.Drawing.Point(621, 340);
            this.btnToPatientDemo.Name = "btnToPatientDemo";
            this.btnToPatientDemo.Size = new System.Drawing.Size(137, 59);
            this.btnToPatientDemo.TabIndex = 1;
            this.btnToPatientDemo.Text = "Patient Demographics";
            this.btnToPatientDemo.UseVisualStyleBackColor = true;
            this.btnToPatientDemo.Click += new System.EventHandler(this.btnToPatientDemo_Click);
            // 
            // TBSearchPatients
            // 
            this.TBSearchPatients.Location = new System.Drawing.Point(619, 197);
            this.TBSearchPatients.Name = "TBSearchPatients";
            this.TBSearchPatients.Size = new System.Drawing.Size(141, 21);
            this.TBSearchPatients.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter ID or Last Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search Paitent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBSearchPatients);
            this.Controls.Add(this.btnToPatientDemo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SelectPatient";
            this.Text = "Select Patient";
            this.Load += new System.EventHandler(this.SelectPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnToPatientDemo;
        private System.Windows.Forms.TextBox TBSearchPatients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

