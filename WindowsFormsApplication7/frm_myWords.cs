using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace x86
{
   public class frm_myWords : Form
  {
    private IContainer components;
    private Panel panel1;
    private Label label3;
    private Label label2;
    private Label label1;
    private DateTimePicker dateTimePicker2;
    private DateTimePicker dateTimePicker1;
    private Button button1;
    private DataGridView grid_myTask;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem 确定ToolStripMenuItem;
    private DataGridViewTextBoxColumn 编号;
    private DataGridViewTextBoxColumn 开始时间;
    private DataGridViewTextBoxColumn 接手时间;
    private DataGridViewTextBoxColumn 状态;
    private DataGridViewTextBoxColumn 目标;
    private DataGridViewTextBoxColumn 搜不到;
    private DataGridViewTextBoxColumn 进度;
    private DataGridViewTextBoxColumn 来源;
    private DataGridViewTextBoxColumn 店铺旺旺;
    private DataGridViewTextBoxColumn 搜索关键字;
    private DataGridViewTextBoxColumn 实付;
    private DataGridViewTextBoxColumn 原价1;
    private DataGridViewTextBoxColumn userId;
    private DataGridViewTextBoxColumn pageNum;
    private DataGridViewTextBoxColumn dq;
    private DataGridViewTextBoxColumn spid;
    private DataGridViewTextBoxColumn downNum1;
    private DataGridViewTextBoxColumn downNum2;
    private DataGridViewTextBoxColumn jdTime1;
    private DataGridViewTextBoxColumn jdTime2;

    public frm_myWords()
    {
      this.components = (IContainer) null;
     
      this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.search();
    }

    private void search()
    {
      MyWordsClass myWordsClass1 = new MyWordsClass();
      DataGridView dataGridView = this.grid_myTask;
      MyWordsClass myWordsClass2 = myWordsClass1;
      int userId = sys.LoginUser.ID;
      DateTime dateTime = this.dateTimePicker1.Value;
      string rq = dateTime.ToString("yyyy-MM-dd 00:00:00");
      dateTime = this.dateTimePicker2.Value;
      string rq2 = dateTime.ToString("yyyy-MM-dd 23:59:59");
      DataTable myTask = myWordsClass2.getMyTask(userId, rq, rq2);
      dataGridView.DataSource = (object) myTask;
    }

    private void frm_myWords_Load(object sender, EventArgs e)
    {
      this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
      this.dateTimePicker2.Value = DateTime.Now;
      this.search();
    }

    private void grid_myTask_DoubleClick(object sender, EventArgs e)
    {
      if (this.grid_myTask.SelectedRows.Count <= 0)
        return;
      sys.myWordsId = Convert.ToInt32(this.grid_myTask.SelectedRows[0].Cells["编号"].Value.ToString().Trim());
      this.DialogResult = DialogResult.OK;
    }

    private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.grid_myTask.SelectedRows.Count <= 0)
        return;
      new MyWordsClass().DeleteRecord(Convert.ToInt32(this.grid_myTask.SelectedRows[0].Cells["编号"].Value.ToString().Trim()));
      this.search();
    }

    private void grid_myTask_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      try
      {
        if (e.RowIndex >= 0)
        {
          this.grid_myTask.ClearSelection();
          this.grid_myTask.Rows[e.RowIndex].Selected = true;
          this.grid_myTask.CurrentCell = this.grid_myTask.Rows[e.RowIndex].Cells[e.ColumnIndex];
          ContextMenuStrip contextMenuStrip = this.contextMenuStrip1;
          Point mousePosition = Control.MousePosition;
          int x = mousePosition.X;
          mousePosition = Control.MousePosition;
          int y = mousePosition.Y;
          contextMenuStrip.Show(x, y);
        }
      }
      catch
      {
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle16 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frm_myWords));
      this.panel1 = new Panel();
      this.button1 = new Button();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.dateTimePicker2 = new DateTimePicker();
      this.dateTimePicker1 = new DateTimePicker();
      this.grid_myTask = new DataGridView();
      this.编号 = new DataGridViewTextBoxColumn();
      this.开始时间 = new DataGridViewTextBoxColumn();
      this.接手时间 = new DataGridViewTextBoxColumn();
      this.状态 = new DataGridViewTextBoxColumn();
      this.目标 = new DataGridViewTextBoxColumn();
      this.搜不到 = new DataGridViewTextBoxColumn();
      this.进度 = new DataGridViewTextBoxColumn();
      this.来源 = new DataGridViewTextBoxColumn();
      this.店铺旺旺 = new DataGridViewTextBoxColumn();
      this.搜索关键字 = new DataGridViewTextBoxColumn();
      this.实付 = new DataGridViewTextBoxColumn();
      this.原价1 = new DataGridViewTextBoxColumn();
      this.userId = new DataGridViewTextBoxColumn();
      this.pageNum = new DataGridViewTextBoxColumn();
      this.dq = new DataGridViewTextBoxColumn();
      this.spid = new DataGridViewTextBoxColumn();
      this.downNum1 = new DataGridViewTextBoxColumn();
      this.downNum2 = new DataGridViewTextBoxColumn();
      this.jdTime1 = new DataGridViewTextBoxColumn();
      this.jdTime2 = new DataGridViewTextBoxColumn();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.确定ToolStripMenuItem = new ToolStripMenuItem();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.grid_myTask).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.dateTimePicker2);
      this.panel1.Controls.Add((Control) this.dateTimePicker1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 331);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(928, 66);
      this.panel1.TabIndex = 0;
      this.button1.Location = new Point(671, 16);
      this.button1.Name = "button1";
      this.button1.Size = new Size(64, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "查询";
      this.button1.UseVisualStyleBackColor = true;
      // ISSUE: method pointer
      this.button1.Click += new EventHandler(button1_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label3.Location = new Point(507, 20);
      this.label3.Name = "label3";
      this.label3.Size = new Size(21, 14);
      this.label3.TabIndex = 1;
      this.label3.Text = "—";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label2.Location = new Point(321, 20);
      this.label2.Name = "label2";
      this.label2.Size = new Size(63, 14);
      this.label2.TabIndex = 1;
      this.label2.Text = "发布日期";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label1.Location = new Point(22, 25);
      this.label1.Name = "label1";
      this.label1.Size = new Size(231, 14);
      this.label1.TabIndex = 1;
      this.label1.Text = "双击对应的行可以让关键字自动填入";
      this.dateTimePicker2.Location = new Point(534, 18);
      this.dateTimePicker2.Name = "dateTimePicker2";
      this.dateTimePicker2.Size = new Size(111, 21);
      this.dateTimePicker2.TabIndex = 0;
      this.dateTimePicker1.Location = new Point(390, 18);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(111, 21);
      this.dateTimePicker1.TabIndex = 0;
      this.grid_myTask.AllowUserToAddRows = false;
      this.grid_myTask.AllowUserToResizeRows = false;
      this.grid_myTask.BackgroundColor = Color.Azure;
      this.grid_myTask.BorderStyle = BorderStyle.None;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle1.BackColor = Color.SkyBlue;
      gridViewCellStyle1.Font = new Font("Tahoma", 9f);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.grid_myTask.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.grid_myTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid_myTask.Columns.AddRange((DataGridViewColumn) this.编号, (DataGridViewColumn) this.开始时间, (DataGridViewColumn) this.接手时间, (DataGridViewColumn) this.状态, (DataGridViewColumn) this.目标, (DataGridViewColumn) this.搜不到, (DataGridViewColumn) this.进度, (DataGridViewColumn) this.来源, (DataGridViewColumn) this.店铺旺旺, (DataGridViewColumn) this.搜索关键字, (DataGridViewColumn) this.实付, (DataGridViewColumn) this.原价1, (DataGridViewColumn) this.userId, (DataGridViewColumn) this.pageNum, (DataGridViewColumn) this.dq, (DataGridViewColumn) this.spid, (DataGridViewColumn) this.downNum1, (DataGridViewColumn) this.downNum2, (DataGridViewColumn) this.jdTime1, (DataGridViewColumn) this.jdTime2);
      this.grid_myTask.Dock = DockStyle.Fill;
      this.grid_myTask.GridColor = Color.SkyBlue;
      this.grid_myTask.Location = new Point(0, 0);
      this.grid_myTask.MultiSelect = false;
      this.grid_myTask.Name = "grid_myTask";
      this.grid_myTask.ReadOnly = true;
      this.grid_myTask.RowHeadersVisible = false;
      this.grid_myTask.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.grid_myTask.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
      this.grid_myTask.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
      this.grid_myTask.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.grid_myTask.RowTemplate.Height = 23;
      this.grid_myTask.RowTemplate.ReadOnly = true;
      this.grid_myTask.RowTemplate.Resizable = DataGridViewTriState.False;
      this.grid_myTask.ScrollBars = ScrollBars.Vertical;
      this.grid_myTask.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.grid_myTask.Size = new Size(928, 331);
      this.grid_myTask.TabIndex = 5;
      // ISSUE: method pointer
      this.grid_myTask.DoubleClick += new EventHandler(grid_myTask_DoubleClick);
      // ISSUE: method pointer
      this.grid_myTask.CellMouseDown += new DataGridViewCellMouseEventHandler(grid_myTask_CellMouseDown);
      this.编号.DataPropertyName = "id";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.编号.DefaultCellStyle = gridViewCellStyle2;
      this.编号.FillWeight = 70f;
      this.编号.HeaderText = "编号";
      this.编号.Name = "编号";
      this.编号.ReadOnly = true;
      this.编号.Visible = false;
      this.编号.Width = 60;
      this.开始时间.DataPropertyName = "sendTime";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle3.ForeColor = Color.Black;
      this.开始时间.DefaultCellStyle = gridViewCellStyle3;
      this.开始时间.HeaderText = "发布时间";
      this.开始时间.Name = "开始时间";
      this.开始时间.ReadOnly = true;
      this.接手时间.DataPropertyName = "startTime";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle4.Format = "C2";
      gridViewCellStyle4.NullValue = (object) null;
      this.接手时间.DefaultCellStyle = gridViewCellStyle4;
      this.接手时间.FillWeight = 110f;
      this.接手时间.HeaderText = "接手时间";
      this.接手时间.Name = "接手时间";
      this.接手时间.ReadOnly = true;
      this.接手时间.Visible = false;
      this.状态.DataPropertyName = "Stu";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle5.ForeColor = Color.Red;
      this.状态.DefaultCellStyle = gridViewCellStyle5;
      this.状态.HeaderText = "状态";
      this.状态.Name = "状态";
      this.状态.ReadOnly = true;
      this.状态.Visible = false;
      this.状态.Width = 60;
      this.目标.DataPropertyName = "pageNum";
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.目标.DefaultCellStyle = gridViewCellStyle6;
      this.目标.FillWeight = 80f;
      this.目标.HeaderText = "搜索页数";
      this.目标.Name = "目标";
      this.目标.ReadOnly = true;
      this.目标.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.目标.Width = 80;
      this.搜不到.DataPropertyName = "noFind";
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.搜不到.DefaultCellStyle = gridViewCellStyle7;
      this.搜不到.HeaderText = "搜不到";
      this.搜不到.Name = "搜不到";
      this.搜不到.ReadOnly = true;
      this.搜不到.Visible = false;
      this.搜不到.Width = 70;
      this.进度.DataPropertyName = "jd";
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.进度.DefaultCellStyle = gridViewCellStyle8;
      this.进度.HeaderText = "进度";
      this.进度.Name = "进度";
      this.进度.ReadOnly = true;
      this.进度.Visible = false;
      this.进度.Width = 60;
      this.来源.DataPropertyName = "comeType";
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.来源.DefaultCellStyle = gridViewCellStyle9;
      this.来源.FillWeight = 80f;
      this.来源.HeaderText = "如何进店";
      this.来源.Name = "来源";
      this.来源.ReadOnly = true;
      this.来源.Width = 80;
      this.店铺旺旺.DataPropertyName = "ww";
      this.店铺旺旺.HeaderText = "店铺旺旺";
      this.店铺旺旺.Name = "店铺旺旺";
      this.店铺旺旺.ReadOnly = true;
      this.店铺旺旺.Width = 80;
      this.搜索关键字.DataPropertyName = "keyword";
      this.搜索关键字.HeaderText = "搜索关键字";
      this.搜索关键字.Name = "搜索关键字";
      this.搜索关键字.ReadOnly = true;
      this.实付.DataPropertyName = "jsPrice";
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.实付.DefaultCellStyle = gridViewCellStyle10;
      this.实付.HeaderText = "实付";
      this.实付.Name = "实付";
      this.实付.ReadOnly = true;
      this.实付.Visible = false;
      this.实付.Width = 60;
      this.原价1.DataPropertyName = "allPrice";
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.原价1.DefaultCellStyle = gridViewCellStyle11;
      this.原价1.HeaderText = "原价";
      this.原价1.Name = "原价1";
      this.原价1.ReadOnly = true;
      this.原价1.Visible = false;
      this.原价1.Width = 60;
      this.userId.DataPropertyName = "userId";
      this.userId.HeaderText = "userId";
      this.userId.Name = "userId";
      this.userId.ReadOnly = true;
      this.userId.Visible = false;
      this.pageNum.DataPropertyName = "pageNum";
      this.pageNum.HeaderText = "pageNum";
      this.pageNum.Name = "pageNum";
      this.pageNum.ReadOnly = true;
      this.pageNum.Visible = false;
      this.dq.DataPropertyName = "dq";
      this.dq.FillWeight = 80f;
      this.dq.HeaderText = "地区";
      this.dq.Name = "dq";
      this.dq.ReadOnly = true;
      this.dq.Width = 80;
      this.spid.DataPropertyName = "spid";
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.spid.DefaultCellStyle = gridViewCellStyle12;
      this.spid.HeaderText = "产品ID";
      this.spid.Name = "spid";
      this.spid.ReadOnly = true;
      this.spid.Width = 80;
      this.downNum1.DataPropertyName = "downNum1";
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.downNum1.DefaultCellStyle = gridViewCellStyle13;
      this.downNum1.FillWeight = 80f;
      this.downNum1.HeaderText = "浏览最低个数";
      this.downNum1.Name = "downNum1";
      this.downNum1.ReadOnly = true;
      this.downNum1.Width = 80;
      this.downNum2.DataPropertyName = "downNum2";
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.downNum2.DefaultCellStyle = gridViewCellStyle14;
      this.downNum2.FillWeight = 80f;
      this.downNum2.HeaderText = "浏览最高个数";
      this.downNum2.Name = "downNum2";
      this.downNum2.ReadOnly = true;
      this.downNum2.Width = 80;
      this.jdTime1.DataPropertyName = "jdTime1";
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.jdTime1.DefaultCellStyle = gridViewCellStyle15;
      this.jdTime1.HeaderText = "进店浏览最小时间";
      this.jdTime1.Name = "jdTime1";
      this.jdTime1.ReadOnly = true;
      this.jdTime1.Width = 80;
      this.jdTime2.DataPropertyName = "jdTime2";
      gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.jdTime2.DefaultCellStyle = gridViewCellStyle16;
      this.jdTime2.HeaderText = "进店浏览最大时间";
      this.jdTime2.Name = "jdTime2";
      this.jdTime2.ReadOnly = true;
      this.jdTime2.Width = 80;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.确定ToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(101, 26);
      this.确定ToolStripMenuItem.Name = "确定ToolStripMenuItem";
      this.确定ToolStripMenuItem.Size = new Size(100, 22);
      this.确定ToolStripMenuItem.Text = "删除";
      // ISSUE: method pointer
      this.确定ToolStripMenuItem.Click += new EventHandler(确定ToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(928, 397);
      this.Controls.Add((Control) this.grid_myTask);
      this.Controls.Add((Control) this.panel1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "frm_myWords";
      this.Text = "我的词库";
      // ISSUE: method pointer
      this.Load += new EventHandler(frm_myWords_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.grid_myTask).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
