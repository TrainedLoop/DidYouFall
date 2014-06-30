namespace DidYouFall.Agent.Forms
{
    partial class Configuration
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
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tabPageHdMonitor = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.tabPageServiceMonitor = new System.Windows.Forms.TabPage();
            this.checkedListBoxHDs = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBoxServices = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSelectAllServices = new System.Windows.Forms.Button();
            this.buttonClearAllServices = new System.Windows.Forms.Button();
            this.buttonClearAllHDs = new System.Windows.Forms.Button();
            this.buttonSelectAllHDs = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControlConfig.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageHdMonitor.SuspendLayout();
            this.tabPageServiceMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Controls.Add(this.tabPageLogin);
            this.tabControlConfig.Controls.Add(this.tabPageHdMonitor);
            this.tabControlConfig.Controls.Add(this.tabPageServiceMonitor);
            this.tabControlConfig.Location = new System.Drawing.Point(7, 7);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(441, 382);
            this.tabControlConfig.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.textBoxPassword);
            this.tabPageLogin.Controls.Add(this.textBoxEmail);
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Controls.Add(this.label4);
            this.tabPageLogin.Controls.Add(this.textBoxServer);
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(433, 356);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tabPageHdMonitor
            // 
            this.tabPageHdMonitor.Controls.Add(this.buttonClearAllHDs);
            this.tabPageHdMonitor.Controls.Add(this.buttonSelectAllHDs);
            this.tabPageHdMonitor.Controls.Add(this.label3);
            this.tabPageHdMonitor.Controls.Add(this.checkedListBoxHDs);
            this.tabPageHdMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageHdMonitor.Name = "tabPageHdMonitor";
            this.tabPageHdMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHdMonitor.Size = new System.Drawing.Size(433, 356);
            this.tabPageHdMonitor.TabIndex = 1;
            this.tabPageHdMonitor.Text = "HDs Monitor";
            this.tabPageHdMonitor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(81, 62);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(332, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(81, 119);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(332, 20);
            this.textBoxEmail.TabIndex = 7;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(81, 171);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(332, 20);
            this.textBoxPassword.TabIndex = 8;
            // 
            // tabPageServiceMonitor
            // 
            this.tabPageServiceMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageServiceMonitor.Controls.Add(this.buttonClearAllServices);
            this.tabPageServiceMonitor.Controls.Add(this.buttonSelectAllServices);
            this.tabPageServiceMonitor.Controls.Add(this.label5);
            this.tabPageServiceMonitor.Controls.Add(this.checkedListBoxServices);
            this.tabPageServiceMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageServiceMonitor.Name = "tabPageServiceMonitor";
            this.tabPageServiceMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServiceMonitor.Size = new System.Drawing.Size(433, 356);
            this.tabPageServiceMonitor.TabIndex = 2;
            this.tabPageServiceMonitor.Text = "Services Monitor";
            // 
            // checkedListBoxHDs
            // 
            this.checkedListBoxHDs.FormattingEnabled = true;
            this.checkedListBoxHDs.Location = new System.Drawing.Point(20, 64);
            this.checkedListBoxHDs.Name = "checkedListBoxHDs";
            this.checkedListBoxHDs.Size = new System.Drawing.Size(407, 229);
            this.checkedListBoxHDs.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Discos";
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Location = new System.Drawing.Point(20, 64);
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(407, 229);
            this.checkedListBoxServices.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Serviços";
            // 
            // buttonSelectAllServices
            // 
            this.buttonSelectAllServices.Location = new System.Drawing.Point(309, 299);
            this.buttonSelectAllServices.Name = "buttonSelectAllServices";
            this.buttonSelectAllServices.Size = new System.Drawing.Size(118, 23);
            this.buttonSelectAllServices.TabIndex = 5;
            this.buttonSelectAllServices.Text = "Selecionar Todos";
            this.buttonSelectAllServices.UseVisualStyleBackColor = true;
            this.buttonSelectAllServices.Click += new System.EventHandler(this.buttonSelectAllServices_Click);
            // 
            // buttonClearAllServices
            // 
            this.buttonClearAllServices.Location = new System.Drawing.Point(214, 299);
            this.buttonClearAllServices.Name = "buttonClearAllServices";
            this.buttonClearAllServices.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAllServices.TabIndex = 6;
            this.buttonClearAllServices.Text = "Limpar";
            this.buttonClearAllServices.UseVisualStyleBackColor = true;
            this.buttonClearAllServices.Click += new System.EventHandler(this.buttonClearAllServices_Click);
            // 
            // buttonClearAllHDs
            // 
            this.buttonClearAllHDs.Location = new System.Drawing.Point(214, 299);
            this.buttonClearAllHDs.Name = "buttonClearAllHDs";
            this.buttonClearAllHDs.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAllHDs.TabIndex = 8;
            this.buttonClearAllHDs.Text = "Limpar";
            this.buttonClearAllHDs.UseVisualStyleBackColor = true;
            this.buttonClearAllHDs.Click += new System.EventHandler(this.buttonClearAllHDs_Click);
            // 
            // buttonSelectAllHDs
            // 
            this.buttonSelectAllHDs.Location = new System.Drawing.Point(309, 299);
            this.buttonSelectAllHDs.Name = "buttonSelectAllHDs";
            this.buttonSelectAllHDs.Size = new System.Drawing.Size(118, 23);
            this.buttonSelectAllHDs.TabIndex = 7;
            this.buttonSelectAllHDs.Text = "Selecionar Todos";
            this.buttonSelectAllHDs.UseVisualStyleBackColor = true;
            this.buttonSelectAllHDs.Click += new System.EventHandler(this.buttonSelectAllHDs_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(358, 409);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 1;
            this.BtnConfirm.Text = "Salvar";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(25, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Sair";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 457);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.tabControlConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.tabControlConfig.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            this.tabPageHdMonitor.ResumeLayout(false);
            this.tabPageHdMonitor.PerformLayout();
            this.tabPageServiceMonitor.ResumeLayout(false);
            this.tabPageServiceMonitor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageHdMonitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBoxHDs;
        private System.Windows.Forms.TabPage tabPageServiceMonitor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListBoxServices;
        private System.Windows.Forms.Button buttonClearAllHDs;
        private System.Windows.Forms.Button buttonSelectAllHDs;
        private System.Windows.Forms.Button buttonClearAllServices;
        private System.Windows.Forms.Button buttonSelectAllServices;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button btnClose;

    }
}