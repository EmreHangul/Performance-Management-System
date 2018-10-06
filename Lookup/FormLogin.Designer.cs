namespace Lookup
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxŞifre = new System.Windows.Forms.TextBox();
            this.labelŞifreÇalışan = new System.Windows.Forms.Label();
            this.labelsifreyönetici = new System.Windows.Forms.Label();
            this.buttonÇalışan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(145, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospital ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(302, 19);
            this.textBoxID.MaxLength = 4;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(109, 20);
            this.textBoxID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(145, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // textBoxŞifre
            // 
            this.textBoxŞifre.Location = new System.Drawing.Point(302, 59);
            this.textBoxŞifre.Name = "textBoxŞifre";
            this.textBoxŞifre.Size = new System.Drawing.Size(109, 20);
            this.textBoxŞifre.TabIndex = 3;
            this.textBoxŞifre.UseSystemPasswordChar = true;
            // 
            // labelŞifreÇalışan
            // 
            this.labelŞifreÇalışan.AutoSize = true;
            this.labelŞifreÇalışan.Location = new System.Drawing.Point(52, 110);
            this.labelŞifreÇalışan.Name = "labelŞifreÇalışan";
            this.labelŞifreÇalışan.Size = new System.Drawing.Size(84, 13);
            this.labelŞifreÇalışan.TabIndex = 9;
            this.labelŞifreÇalışan.Text = "labelŞifreÇalışan";
            this.labelŞifreÇalışan.Visible = false;
            // 
            // labelsifreyönetici
            // 
            this.labelsifreyönetici.AutoSize = true;
            this.labelsifreyönetici.Location = new System.Drawing.Point(160, 110);
            this.labelsifreyönetici.Name = "labelsifreyönetici";
            this.labelsifreyönetici.Size = new System.Drawing.Size(84, 13);
            this.labelsifreyönetici.TabIndex = 10;
            this.labelsifreyönetici.Text = "labelsifreyönetici";
            this.labelsifreyönetici.Visible = false;
            // 
            // buttonÇalışan
            // 
            this.buttonÇalışan.Location = new System.Drawing.Point(302, 151);
            this.buttonÇalışan.Name = "buttonÇalışan";
            this.buttonÇalışan.Size = new System.Drawing.Size(113, 46);
            this.buttonÇalışan.TabIndex = 12;
            this.buttonÇalışan.Text = "Sign In";
            this.buttonÇalışan.UseVisualStyleBackColor = true;
            this.buttonÇalışan.Click += new System.EventHandler(this.buttonÇalışan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 46);
            this.button1.TabIndex = 13;
            this.button1.Text = "Change Password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonÇalışan);
            this.Controls.Add(this.labelsifreyönetici);
            this.Controls.Add(this.labelŞifreÇalışan);
            this.Controls.Add(this.textBoxŞifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign-in";
            this.Load += new System.EventHandler(this.FormGiriş_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxŞifre;
        private System.Windows.Forms.Label labelŞifreÇalışan;
        private System.Windows.Forms.Label labelsifreyönetici;
        private System.Windows.Forms.Button buttonÇalışan;
        private System.Windows.Forms.Button button1;
    }
}