namespace x86
{
    partial class Wotuijiande
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.申请提现金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.我推荐的人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.当前状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.申请提现金额,
            this.我推荐的人,
            this.申请时间,
            this.当前状态});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(444, 330);
            this.dataGridView2.TabIndex = 1;
            // 
            // 申请提现金额
            // 
            this.申请提现金额.DataPropertyName = "申请提现金额";
            this.申请提现金额.HeaderText = "申请提现金额";
            this.申请提现金额.Name = "申请提现金额";
            this.申请提现金额.ReadOnly = true;
            // 
            // 我推荐的人
            // 
            this.我推荐的人.DataPropertyName = "我推荐的人";
            this.我推荐的人.HeaderText = "我推荐的人";
            this.我推荐的人.Name = "我推荐的人";
            this.我推荐的人.ReadOnly = true;
            // 
            // 申请时间
            // 
            this.申请时间.DataPropertyName = "申请时间";
            this.申请时间.HeaderText = "申请时间";
            this.申请时间.Name = "申请时间";
            this.申请时间.ReadOnly = true;
            // 
            // 当前状态
            // 
            this.当前状态.DataPropertyName = "当前状态";
            this.当前状态.HeaderText = "当前状态";
            this.当前状态.Name = "当前状态";
            this.当前状态.ReadOnly = true;
            // 
            // Wotuijiande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 330);
            this.Controls.Add(this.dataGridView2);
            this.MaximumSize = new System.Drawing.Size(460, 368);
            this.Name = "Wotuijiande";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "我的提现";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Wotuijiande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请提现金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 我推荐的人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 当前状态;

    }
}