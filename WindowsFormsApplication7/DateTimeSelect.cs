using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace x86
{
   public class DateTimeSelect : UserControl
  {
    private string begindate;
    private string Enddate;
    private string begintime;
    private string endtime;
    private IContainer components;
    public Label lblCoustmerSet;
    public CheckBox chkdate;
    private Label label1;
    private DateTimePicker dtpEndTime;
    private DateTimePicker dtpBeginDate;
    private DateTimePicker dtpEndDATE;
    private DateTimePicker dtpBeginTime;

    public DateTimeSelect()
    {
      this.components = (IContainer) null;
     
      this.InitializeComponent();
    }

    private void DateTimeSelect_Load(object sender, EventArgs e)
    {
      this.dtpBeginDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
      this.dtpEndDATE.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
      this.dtpBeginTime.Value = Convert.ToDateTime(DateTime.Now.ToString());
      this.dtpEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString());
      this.InitTime();
    }

    private void chkdate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkdate.Checked)
      {
        this.dtpBeginDate.Enabled = true;
        this.dtpEndDATE.Enabled = true;
        this.dtpBeginTime.Enabled = true;
        this.dtpEndTime.Enabled = true;
      }
      else
      {
        this.dtpBeginDate.Enabled = false;
        this.dtpEndDATE.Enabled = false;
        this.dtpBeginTime.Enabled = false;
        this.dtpEndTime.Enabled = false;
      }
    }

    private void dtpBeginDate_CloseUp(object sender, EventArgs e)
    {
      this.begindate = this.dtpBeginDate.Value.ToShortDateString();
    }

    private void dtpEndDATE_CloseUp(object sender, EventArgs e)
    {
      this.Enddate = this.dtpEndDATE.Value.ToShortDateString();
    }

    private void dtpBeginTime_Leave(object sender, EventArgs e)
    {
      DateTime dateTime;
      int num;
      if (this.dtpBeginTime.Value.ToString().Length > 0)
      {
        dateTime = this.dtpBeginTime.Value;
        num = !dateTime.ToString().Contains(" ") ? 1 : 0;
      }
      else
        num = 1;
      if (num != 0)
        return;
      dateTime = this.dtpBeginTime.Value;
      string str = dateTime.ToString();
      dateTime = this.dtpBeginTime.Value;
      string oldValue = dateTime.ToShortDateString();
      string newValue = "";
      this.begintime = str.Replace(oldValue, newValue);
    }

    private void dtpEndTime_Leave(object sender, EventArgs e)
    {
      DateTime dateTime;
      int num;
      if (this.dtpEndTime.Value.ToString().Length > 0)
      {
        dateTime = this.dtpEndTime.Value;
        num = !dateTime.ToString().Contains(" ") ? 1 : 0;
      }
      else
        num = 1;
      if (num != 0)
        return;
      dateTime = this.dtpEndTime.Value;
      string str = dateTime.ToString();
      dateTime = this.dtpEndTime.Value;
      string oldValue = dateTime.ToShortDateString();
      string newValue = "";
      this.endtime = str.Replace(oldValue, newValue);
    }

    private void InitTime()
    {
      this.begindate = this.dtpBeginDate.Value.ToShortDateString();
      this.Enddate = this.dtpEndDATE.Value.ToShortDateString();
      this.dtpBeginTime_Leave((object) null, (EventArgs) null);
      this.dtpEndTime_Leave((object) null, (EventArgs) null);
    }

    public DateTime BeginDateTime()
    {
      return Convert.ToDateTime(this.begindate + this.begintime);
    }

    public DateTime EndDateTime()
    {
      return Convert.ToDateTime(this.Enddate + this.endtime);
    }

    public void setValue(DateTime d)
    {
      this.dtpBeginDate.Value = Convert.ToDateTime(d.ToShortDateString());
      this.dtpBeginTime.Value = Convert.ToDateTime(d.ToString());
      this.InitTime();
    }

    private void dtpBeginDate_ValueChanged(object sender, EventArgs e)
    {
      this.begindate = this.dtpBeginDate.Value.ToShortDateString();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblCoustmerSet = new Label();
      this.chkdate = new CheckBox();
      this.label1 = new Label();
      this.dtpEndTime = new DateTimePicker();
      this.dtpBeginDate = new DateTimePicker();
      this.dtpEndDATE = new DateTimePicker();
      this.dtpBeginTime = new DateTimePicker();
      this.SuspendLayout();
      this.lblCoustmerSet.AutoSize = true;
      this.lblCoustmerSet.Location = new Point(3, 88);
      this.lblCoustmerSet.Name = "lblCoustmerSet";
      this.lblCoustmerSet.Size = new Size(41, 12);
      this.lblCoustmerSet.TabIndex = 13;
      this.lblCoustmerSet.Text = "label2";
      this.chkdate.AutoSize = true;
      this.chkdate.Location = new Point(83, 86);
      this.chkdate.Name = "chkdate";
      this.chkdate.Size = new Size(15, 14);
      this.chkdate.TabIndex = 12;
      this.chkdate.UseVisualStyleBackColor = true;
      // ISSUE: method pointer
      this.chkdate.CheckedChanged += new EventHandler(chkdate_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(159, 80);
      this.label1.Name = "label1";
      this.label1.Size = new Size(17, 12);
      this.label1.TabIndex = 11;
      this.label1.Text = "至";
      this.dtpEndTime.CustomFormat = "HH:mm:ss";
      this.dtpEndTime.Enabled = false;
      this.dtpEndTime.Format = DateTimePickerFormat.Custom;
      this.dtpEndTime.Location = new Point(267, 76);
      this.dtpEndTime.Name = "dtpEndTime";
      this.dtpEndTime.ShowUpDown = true;
      this.dtpEndTime.Size = new Size(84, 21);
      this.dtpEndTime.TabIndex = 10;
      // ISSUE: method pointer
      this.dtpEndTime.Leave += new EventHandler(dtpEndTime_Leave);
      this.dtpBeginDate.CustomFormat = "yyyy-MM-dd";
      this.dtpBeginDate.Format = DateTimePickerFormat.Custom;
      this.dtpBeginDate.Location = new Point(1, 0);
      this.dtpBeginDate.Name = "dtpBeginDate";
      this.dtpBeginDate.Size = new Size(85, 21);
      this.dtpBeginDate.TabIndex = 9;
      // ISSUE: method pointer
      this.dtpBeginDate.ValueChanged += new EventHandler(dtpBeginDate_ValueChanged);
      // ISSUE: method pointer
      this.dtpBeginDate.CloseUp += new EventHandler(dtpBeginDate_CloseUp);
      this.dtpEndDATE.CustomFormat = "yyyy-MM-dd";
      this.dtpEndDATE.Enabled = false;
      this.dtpEndDATE.Format = DateTimePickerFormat.Custom;
      this.dtpEndDATE.Location = new Point(182, 76);
      this.dtpEndDATE.Name = "dtpEndDATE";
      this.dtpEndDATE.Size = new Size(83, 21);
      this.dtpEndDATE.TabIndex = 8;
      // ISSUE: method pointer
      this.dtpEndDATE.CloseUp += new EventHandler(dtpEndDATE_CloseUp);
      this.dtpBeginTime.CustomFormat = "HH:mm:ss";
      this.dtpBeginTime.Format = DateTimePickerFormat.Custom;
      this.dtpBeginTime.Location = new Point(87, 0);
      this.dtpBeginTime.Name = "dtpBeginTime";
      this.dtpBeginTime.ShowUpDown = true;
      this.dtpBeginTime.Size = new Size(82, 21);
      this.dtpBeginTime.TabIndex = 7;
      // ISSUE: method pointer
      this.dtpBeginTime.Leave += new EventHandler(dtpBeginTime_Leave);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.lblCoustmerSet);
      this.Controls.Add((Control) this.chkdate);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.dtpEndTime);
      this.Controls.Add((Control) this.dtpBeginDate);
      this.Controls.Add((Control) this.dtpEndDATE);
      this.Controls.Add((Control) this.dtpBeginTime);
      this.Name = "DateTimeSelect";
      this.Size = new Size(169, 22);
      // ISSUE: method pointer
      this.Load += new EventHandler(DateTimeSelect_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
    
}
