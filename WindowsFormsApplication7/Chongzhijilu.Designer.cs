namespace x86
{
    partial class Chongzhijilu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chongzhijilu));
            this.gridview_chongzhijilu = new System.Windows.Forms.DataGridView();
            this.支付宝交易流水号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提交时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用途 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_chongzhijilu)).BeginInit();
            this.SuspendLayout();
            // 
            // gridview_chongzhijilu
            // 
            this.gridview_chongzhijilu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_chongzhijilu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.支付宝交易流水号,
            this.金额,
            this.提交时间,
            this.状态,
            this.用途});
            this.gridview_chongzhijilu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridview_chongzhijilu.Location = new System.Drawing.Point(0, 0);
            this.gridview_chongzhijilu.Name = "gridview_chongzhijilu";
            this.gridview_chongzhijilu.RowTemplate.Height = 23;
            this.gridview_chongzhijilu.Size = new System.Drawing.Size(845, 262);
            this.gridview_chongzhijilu.TabIndex = 1;
            // 
            // 支付宝交易流水号
            // 
            this.支付宝交易流水号.DataPropertyName = "支付宝交易流水号";
            this.支付宝交易流水号.HeaderText = "支付宝交易流水号";
            this.支付宝交易流水号.Name = "支付宝交易流水号";
            this.支付宝交易流水号.ReadOnly = true;
            this.支付宝交易流水号.Width = 200;
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "金额";
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.Width = 200;
            // 
            // 提交时间
            // 
            this.提交时间.DataPropertyName = "提交时间";
            this.提交时间.HeaderText = "提交时间";
            this.提交时间.Name = "提交时间";
            this.提交时间.ReadOnly = true;
            this.提交时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.提交时间.Width = 200;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "状态";
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            // 
            // 用途
            // 
            this.用途.DataPropertyName = "用途";
            this.用途.HeaderText = "用途";
            this.用途.Name = "用途";
            this.用途.ReadOnly = true;
            // 
            // Chongzhijilu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 262);
            this.Controls.Add(this.gridview_chongzhijilu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chongzhijilu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chongzhijilu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Chongzhijilu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_chongzhijilu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridview_chongzhijilu;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支付宝交易流水号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提交时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用途;
    }
}