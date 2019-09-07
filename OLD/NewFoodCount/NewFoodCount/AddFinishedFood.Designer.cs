namespace NewFoodCount
{
    partial class AddFinishedFood
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblProts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.numProtein = new System.Windows.Forms.NumericUpDown();
            this.numCarbohydrate = new System.Windows.Forms.NumericUpDown();
            this.numFat = new System.Windows.Forms.NumericUpDown();
            this.numCalorific = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numProtein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarbohydrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalorific)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblProts
            // 
            this.lblProts.AutoSize = true;
            this.lblProts.Location = new System.Drawing.Point(12, 41);
            this.lblProts.Name = "lblProts";
            this.lblProts.Size = new System.Drawing.Size(38, 13);
            this.lblProts.TabIndex = 2;
            this.lblProts.Text = "Белки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Углеводы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Жиры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Калорийность";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numProtein
            // 
            this.numProtein.DecimalPlaces = 2;
            this.numProtein.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numProtein.Location = new System.Drawing.Point(97, 39);
            this.numProtein.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numProtein.Name = "numProtein";
            this.numProtein.Size = new System.Drawing.Size(146, 20);
            this.numProtein.TabIndex = 12;
            // 
            // numCarbohydrate
            // 
            this.numCarbohydrate.DecimalPlaces = 2;
            this.numCarbohydrate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCarbohydrate.Location = new System.Drawing.Point(97, 65);
            this.numCarbohydrate.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numCarbohydrate.Name = "numCarbohydrate";
            this.numCarbohydrate.Size = new System.Drawing.Size(146, 20);
            this.numCarbohydrate.TabIndex = 13;
            // 
            // numFat
            // 
            this.numFat.DecimalPlaces = 2;
            this.numFat.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFat.Location = new System.Drawing.Point(97, 91);
            this.numFat.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numFat.Name = "numFat";
            this.numFat.Size = new System.Drawing.Size(146, 20);
            this.numFat.TabIndex = 14;
            // 
            // numCalorific
            // 
            this.numCalorific.DecimalPlaces = 2;
            this.numCalorific.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCalorific.Location = new System.Drawing.Point(97, 117);
            this.numCalorific.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numCalorific.Name = "numCalorific";
            this.numCalorific.Size = new System.Drawing.Size(146, 20);
            this.numCalorific.TabIndex = 15;
            // 
            // AddFinishedFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 173);
            this.Controls.Add(this.numCalorific);
            this.Controls.Add(this.numFat);
            this.Controls.Add(this.numCarbohydrate);
            this.Controls.Add(this.numProtein);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProts);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "AddFinishedFood";
            this.Text = "Добавление продукта";
            ((System.ComponentModel.ISupportInitialize)(this.numProtein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarbohydrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalorific)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblProts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numProtein;
        private System.Windows.Forms.NumericUpDown numCarbohydrate;
        private System.Windows.Forms.NumericUpDown numFat;
        private System.Windows.Forms.NumericUpDown numCalorific;
    }
}