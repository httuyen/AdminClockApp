namespace AdminClockApp
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtUserAd = new DevExpress.XtraEditors.TextEdit();
            this.txtPassAd = new DevExpress.XtraEditors.TextEdit();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserAd
            // 
            this.txtUserAd.EditValue = "username";
            this.txtUserAd.Location = new System.Drawing.Point(109, 50);
            this.txtUserAd.Name = "txtUserAd";
            this.txtUserAd.Size = new System.Drawing.Size(146, 20);
            this.txtUserAd.TabIndex = 0;
            // 
            // txtPassAd
            // 
            this.txtPassAd.EditValue = "password";
            this.txtPassAd.EnterMoveNextControl = true;
            this.txtPassAd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassAd.Location = new System.Drawing.Point(109, 87);
            this.txtPassAd.Name = "txtPassAd";
            this.txtPassAd.Properties.PasswordChar = '*';
            this.txtPassAd.Size = new System.Drawing.Size(146, 20);
            this.txtPassAd.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPassAd);
            this.Controls.Add(this.txtUserAd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassAd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUserAd;
        private DevExpress.XtraEditors.TextEdit txtPassAd;
        private System.Windows.Forms.Button button1;
    }
}