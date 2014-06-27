namespace DidYouFall.Agent.Forms
{
    partial class About
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
            this.LblAbout = new System.Windows.Forms.Label();
            this.linkLblTittle = new System.Windows.Forms.LinkLabel();
            this.LblAboutVersionTitle = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblAutoTitle = new System.Windows.Forms.Label();
            this.LinkLblAutor = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LblAbout
            // 
            this.LblAbout.AutoSize = true;
            this.LblAbout.Location = new System.Drawing.Point(3, 19);
            this.LblAbout.Name = "LblAbout";
            this.LblAbout.Size = new System.Drawing.Size(97, 13);
            this.LblAbout.TabIndex = 0;
            this.LblAbout.Text = "Agente Verificador:";
            // 
            // linkLblTittle
            // 
            this.linkLblTittle.AutoSize = true;
            this.linkLblTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblTittle.Location = new System.Drawing.Point(103, 14);
            this.linkLblTittle.Name = "linkLblTittle";
            this.linkLblTittle.Size = new System.Drawing.Size(87, 20);
            this.linkLblTittle.TabIndex = 1;
            this.linkLblTittle.TabStop = true;
            this.linkLblTittle.Text = "DidYouFall";
            this.linkLblTittle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblTittle_LinkClicked);
            // 
            // LblAboutVersionTitle
            // 
            this.LblAboutVersionTitle.AutoSize = true;
            this.LblAboutVersionTitle.Location = new System.Drawing.Point(3, 41);
            this.LblAboutVersionTitle.Name = "LblAboutVersionTitle";
            this.LblAboutVersionTitle.Size = new System.Drawing.Size(43, 13);
            this.LblAboutVersionTitle.TabIndex = 2;
            this.LblAboutVersionTitle.Text = "Versão:";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(43, 41);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(22, 13);
            this.LblVersion.TabIndex = 4;
            this.LblVersion.Text = "0.1";
            // 
            // LblAutoTitle
            // 
            this.LblAutoTitle.AutoSize = true;
            this.LblAutoTitle.Location = new System.Drawing.Point(113, 101);
            this.LblAutoTitle.Name = "LblAutoTitle";
            this.LblAutoTitle.Size = new System.Drawing.Size(59, 13);
            this.LblAutoTitle.TabIndex = 5;
            this.LblAutoTitle.Text = "Criado Por:";
            // 
            // LinkLblAutor
            // 
            this.LinkLblAutor.AutoSize = true;
            this.LinkLblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLblAutor.LinkArea = new System.Windows.Forms.LinkArea(0, 500);
            this.LinkLblAutor.Location = new System.Drawing.Point(167, 99);
            this.LinkLblAutor.Name = "LinkLblAutor";
            this.LinkLblAutor.Size = new System.Drawing.Size(78, 20);
            this.LinkLblAutor.TabIndex = 6;
            this.LinkLblAutor.TabStop = true;
            this.LinkLblAutor.Text = "Daniel Porto";
            this.LinkLblAutor.UseCompatibleTextRendering = true;
            this.LinkLblAutor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLblAutor_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 123);
            this.Controls.Add(this.LinkLblAutor);
            this.Controls.Add(this.LblAutoTitle);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblAboutVersionTitle);
            this.Controls.Add(this.linkLblTittle);
            this.Controls.Add(this.LblAbout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAbout;
        private System.Windows.Forms.LinkLabel linkLblTittle;
        private System.Windows.Forms.Label LblAboutVersionTitle;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblAutoTitle;
        private System.Windows.Forms.LinkLabel LinkLblAutor;
    }
}