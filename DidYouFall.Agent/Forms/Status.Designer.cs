namespace DidYouFall.Agent.Forms
{
    partial class Status
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
            this.DgvHD = new System.Windows.Forms.DataGridView();
            this.LblCPUTitle = new System.Windows.Forms.Label();
            this.LblTotalMemoryTitle = new System.Windows.Forms.Label();
            this.lblUsageMemoryTitle = new System.Windows.Forms.Label();
            this.LblCPU = new System.Windows.Forms.Label();
            this.LblTotalMemory = new System.Windows.Forms.Label();
            this.LblAvaibleMemory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHD)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvHD
            // 
            this.DgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHD.Location = new System.Drawing.Point(12, 75);
            this.DgvHD.Name = "DgvHD";
            this.DgvHD.Size = new System.Drawing.Size(348, 150);
            this.DgvHD.TabIndex = 0;
            // 
            // LblCPUTitle
            // 
            this.LblCPUTitle.AutoSize = true;
            this.LblCPUTitle.Location = new System.Drawing.Point(12, 9);
            this.LblCPUTitle.Name = "LblCPUTitle";
            this.LblCPUTitle.Size = new System.Drawing.Size(29, 13);
            this.LblCPUTitle.TabIndex = 1;
            this.LblCPUTitle.Text = "CPU";
            // 
            // LblTotalMemoryTitle
            // 
            this.LblTotalMemoryTitle.AutoSize = true;
            this.LblTotalMemoryTitle.Location = new System.Drawing.Point(227, 9);
            this.LblTotalMemoryTitle.Name = "LblTotalMemoryTitle";
            this.LblTotalMemoryTitle.Size = new System.Drawing.Size(74, 13);
            this.LblTotalMemoryTitle.TabIndex = 2;
            this.LblTotalMemoryTitle.Text = "Total Memory:";
            // 
            // lblUsageMemoryTitle
            // 
            this.lblUsageMemoryTitle.AutoSize = true;
            this.lblUsageMemoryTitle.Location = new System.Drawing.Point(211, 44);
            this.lblUsageMemoryTitle.Name = "lblUsageMemoryTitle";
            this.lblUsageMemoryTitle.Size = new System.Drawing.Size(90, 13);
            this.lblUsageMemoryTitle.TabIndex = 3;
            this.lblUsageMemoryTitle.Text = "AvailableMemory:";
            // 
            // LblCPU
            // 
            this.LblCPU.AutoSize = true;
            this.LblCPU.Location = new System.Drawing.Point(47, 9);
            this.LblCPU.Name = "LblCPU";
            this.LblCPU.Size = new System.Drawing.Size(35, 13);
            this.LblCPU.TabIndex = 4;
            this.LblCPU.Text = "label1";
            // 
            // LblTotalMemory
            // 
            this.LblTotalMemory.AutoSize = true;
            this.LblTotalMemory.Location = new System.Drawing.Point(307, 9);
            this.LblTotalMemory.Name = "LblTotalMemory";
            this.LblTotalMemory.Size = new System.Drawing.Size(35, 13);
            this.LblTotalMemory.TabIndex = 5;
            this.LblTotalMemory.Text = "label1";
            // 
            // LblAvaibleMemory
            // 
            this.LblAvaibleMemory.AutoSize = true;
            this.LblAvaibleMemory.Location = new System.Drawing.Point(307, 44);
            this.LblAvaibleMemory.Name = "LblAvaibleMemory";
            this.LblAvaibleMemory.Size = new System.Drawing.Size(35, 13);
            this.LblAvaibleMemory.TabIndex = 6;
            this.LblAvaibleMemory.Text = "label1";
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 262);
            this.Controls.Add(this.LblAvaibleMemory);
            this.Controls.Add(this.LblTotalMemory);
            this.Controls.Add(this.LblCPU);
            this.Controls.Add(this.lblUsageMemoryTitle);
            this.Controls.Add(this.LblTotalMemoryTitle);
            this.Controls.Add(this.LblCPUTitle);
            this.Controls.Add(this.DgvHD);
            this.Name = "Status";
            this.Text = "Status";
            ((System.ComponentModel.ISupportInitialize)(this.DgvHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvHD;
        private System.Windows.Forms.Label LblCPUTitle;
        private System.Windows.Forms.Label LblTotalMemoryTitle;
        private System.Windows.Forms.Label lblUsageMemoryTitle;
        private System.Windows.Forms.Label LblCPU;
        private System.Windows.Forms.Label LblTotalMemory;
        private System.Windows.Forms.Label LblAvaibleMemory;

    }
}