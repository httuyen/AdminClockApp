namespace AdminClockApp
{
    partial class FormChangePW
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
            this.txtOldP = new DevExpress.XtraEditors.TextEdit();
            this.txtNewP = new DevExpress.XtraEditors.TextEdit();
            this.btnOKPass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCFirmP = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCFirmP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOldP
            // 
            this.txtOldP.Location = new System.Drawing.Point(135, 40);
            this.txtOldP.Name = "txtOldP";
            this.txtOldP.Size = new System.Drawing.Size(130, 20);
            this.txtOldP.TabIndex = 1;
            // 
            // txtNewP
            // 
            this.txtNewP.Location = new System.Drawing.Point(135, 66);
            this.txtNewP.Name = "txtNewP";
            this.txtNewP.Size = new System.Drawing.Size(130, 20);
            this.txtNewP.TabIndex = 2;
            // 
            // btnOKPass
            // 
            this.btnOKPass.Location = new System.Drawing.Point(121, 137);
            this.btnOKPass.Name = "btnOKPass";
            this.btnOKPass.Size = new System.Drawing.Size(75, 23);
            this.btnOKPass.TabIndex = 3;
            this.btnOKPass.Text = "OK";
            this.btnOKPass.UseVisualStyleBackColor = true;
            this.btnOKPass.Click += new System.EventHandler(this.btnOKPass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCFirmP
            // 
            this.txtCFirmP.Location = new System.Drawing.Point(135, 92);
            this.txtCFirmP.Name = "txtCFirmP";
            this.txtCFirmP.Size = new System.Drawing.Size(130, 20);
            this.txtCFirmP.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "New password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirm Password";
            // 
            // FormChangePW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCFirmP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOKPass);
            this.Controls.Add(this.txtNewP);
            this.Controls.Add(this.txtOldP);
            this.Name = "FormChangePW";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.txtOldP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCFirmP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOldP;
        private DevExpress.XtraEditors.TextEdit txtNewP;
        private System.Windows.Forms.Button btnOKPass;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCFirmP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}