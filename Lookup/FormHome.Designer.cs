namespace Lookup
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonPersonel = new System.Windows.Forms.Button();
            this.buttonYönetici = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPersonel
            // 
            this.buttonPersonel.Location = new System.Drawing.Point(517, 198);
            this.buttonPersonel.Name = "buttonPersonel";
            this.buttonPersonel.Size = new System.Drawing.Size(129, 55);
            this.buttonPersonel.TabIndex = 8;
            this.buttonPersonel.Text = "Personnel";
            this.buttonPersonel.UseVisualStyleBackColor = true;
            this.buttonPersonel.Click += new System.EventHandler(this.buttonPersonel_Click);
            // 
            // buttonYönetici
            // 
            this.buttonYönetici.Location = new System.Drawing.Point(246, 198);
            this.buttonYönetici.Name = "buttonYönetici";
            this.buttonYönetici.Size = new System.Drawing.Size(130, 55);
            this.buttonYönetici.TabIndex = 9;
            this.buttonYönetici.Text = "Administrator";
            this.buttonYönetici.UseVisualStyleBackColor = true;
            this.buttonYönetici.Click += new System.EventHandler(this.buttonYönetici_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(177, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(703, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Note: This project is over and now users can enter with \"Hospital ID:emre\" and \"P" +
    "assword:12345\" through Administrator entrance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(177, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(586, 45);
            this.label4.TabIndex = 16;
            this.label4.Text = "The original project was in Turkish and now partly transitioned into English. Cou" +
    "ld further be improved later.\r\n\r\n\r\n";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(905, 495);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonYönetici);
            this.Controls.Add(this.buttonPersonel);
            this.MaximumSize = new System.Drawing.Size(921, 534);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonPersonel;
        private System.Windows.Forms.Button buttonYönetici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

