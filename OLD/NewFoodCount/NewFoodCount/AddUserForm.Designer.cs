namespace NewFoodCount
{
    partial class AddUserForm
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.mcBirthDate = new System.Windows.Forms.MonthCalendar();
            this.lblGrowth = new System.Windows.Forms.Label();
            this.txtGrowth = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblUserPurpose = new System.Windows.Forms.Label();
            this.cmbUserPurpose = new System.Windows.Forms.ComboBox();
            this.lblTrainingCount = new System.Windows.Forms.Label();
            this.cmbTrainingCount = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Имя пользователя";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(147, 6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(12, 66);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(86, 13);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Дата рождения";
            // 
            // mcBirthDate
            // 
            this.mcBirthDate.Location = new System.Drawing.Point(147, 67);
            this.mcBirthDate.Name = "mcBirthDate";
            this.mcBirthDate.ShowToday = false;
            this.mcBirthDate.ShowTodayCircle = false;
            this.mcBirthDate.TabIndex = 3;
            // 
            // lblGrowth
            // 
            this.lblGrowth.AutoSize = true;
            this.lblGrowth.Location = new System.Drawing.Point(12, 244);
            this.lblGrowth.Name = "lblGrowth";
            this.lblGrowth.Size = new System.Drawing.Size(31, 13);
            this.lblGrowth.TabIndex = 4;
            this.lblGrowth.Text = "Рост";
            // 
            // txtGrowth
            // 
            this.txtGrowth.Location = new System.Drawing.Point(147, 241);
            this.txtGrowth.Name = "txtGrowth";
            this.txtGrowth.Size = new System.Drawing.Size(121, 20);
            this.txtGrowth.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(12, 36);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(27, 13);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Пол";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.cmbGender.Location = new System.Drawing.Point(147, 33);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 7;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(12, 271);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(73, 13);
            this.lblWeight.TabIndex = 8;
            this.lblWeight.Text = "Текущий вес";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(147, 268);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(121, 20);
            this.txtWeight.TabIndex = 9;
            // 
            // lblUserPurpose
            // 
            this.lblUserPurpose.AutoSize = true;
            this.lblUserPurpose.Location = new System.Drawing.Point(12, 298);
            this.lblUserPurpose.Name = "lblUserPurpose";
            this.lblUserPurpose.Size = new System.Drawing.Size(33, 13);
            this.lblUserPurpose.TabIndex = 10;
            this.lblUserPurpose.Text = "Цель";
            // 
            // cmbUserPurpose
            // 
            this.cmbUserPurpose.FormattingEnabled = true;
            this.cmbUserPurpose.Items.AddRange(new object[] {
            "Снижение веса",
            "Удержание веса",
            "Увеличение веса",
            "Сушка"});
            this.cmbUserPurpose.Location = new System.Drawing.Point(147, 295);
            this.cmbUserPurpose.Name = "cmbUserPurpose";
            this.cmbUserPurpose.Size = new System.Drawing.Size(121, 21);
            this.cmbUserPurpose.TabIndex = 11;
            // 
            // lblTrainingCount
            // 
            this.lblTrainingCount.AutoSize = true;
            this.lblTrainingCount.Location = new System.Drawing.Point(12, 326);
            this.lblTrainingCount.Name = "lblTrainingCount";
            this.lblTrainingCount.Size = new System.Drawing.Size(128, 13);
            this.lblTrainingCount.TabIndex = 12;
            this.lblTrainingCount.Text = "Количество тренировок";
            // 
            // cmbTrainingCount
            // 
            this.cmbTrainingCount.FormattingEnabled = true;
            this.cmbTrainingCount.Items.AddRange(new object[] {
            "0",
            "1",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbTrainingCount.Location = new System.Drawing.Point(147, 323);
            this.cmbTrainingCount.Name = "cmbTrainingCount";
            this.cmbTrainingCount.Size = new System.Drawing.Size(121, 21);
            this.cmbTrainingCount.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 384);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbTrainingCount);
            this.Controls.Add(this.lblTrainingCount);
            this.Controls.Add(this.cmbUserPurpose);
            this.Controls.Add(this.lblUserPurpose);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtGrowth);
            this.Controls.Add(this.lblGrowth);
            this.Controls.Add(this.mcBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Name = "AddUserForm";
            this.Text = "Добавить пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.MonthCalendar mcBirthDate;
        private System.Windows.Forms.Label lblGrowth;
        private System.Windows.Forms.TextBox txtGrowth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblUserPurpose;
        private System.Windows.Forms.ComboBox cmbUserPurpose;
        private System.Windows.Forms.Label lblTrainingCount;
        private System.Windows.Forms.ComboBox cmbTrainingCount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}