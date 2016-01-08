using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace x86
{
    public class idForm : Form
  {
    private IContainer components;
    private TextBox idurl;
    private Label label1;
    private Button button1;
    private Button button2;
    public string alls0;
    public string alls1;
    private string url;

    public string Url
    {
      get
      {
        return this.url;
      }
      set
      {
        this.url = value;
      }
    }

    public idForm()
    {
      this.components = (IContainer) null;
     
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (idForm));
      this.idurl = new TextBox();
      this.label1 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.SuspendLayout();
      this.idurl.Location = new Point(12, 43);
      this.idurl.Name = "idurl";
      this.idurl.Size = new Size(641, 21);
      this.idurl.TabIndex = 12;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(16, 17);
      this.label1.Name = "label1";
      this.label1.Size = new Size(173, 12);
      this.label1.TabIndex = 13;
      this.label1.Text = "请粘贴您的产品地址到输入框内";
      this.button1.DialogResult = DialogResult.OK;
      this.button1.Location = new Point(469, 81);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 14;
      this.button1.Text = "确定";
      this.button1.UseVisualStyleBackColor = true;
      // ISSUE: method pointer
      this.button1.Click += new EventHandler(button1_Click);
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(559, 81);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 15;
      this.button2.Text = "取消";
      this.button2.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(672, 116);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.idurl);
   
      this.MaximizeBox = false;
      this.Name = "idForm";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "输入";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.alls0 = this.idurl.Text;
      if (this.alls0 != "" && (this.alls0.IndexOf("http://item.taobao.com/item.htm") != -1 || this.alls0.IndexOf("http://detail.tmall.com/item.htm") != -1))
      {
        this.alls1 = this.alls0.Substring(this.alls0.IndexOf("id=") + 3);
        this.url = this.alls1.IndexOf("&") == -1 ? this.alls1 : this.alls1.Substring(0, this.alls1.IndexOf("&"));
      }
      if (this.alls0 != "" && this.alls0.IndexOf("http://item.jd.com") != -1)
      {
        this.alls1 = this.alls0.Substring(this.alls0.IndexOf("com/") + 4);
        this.url = this.alls1.Substring(0, this.alls1.IndexOf(".html"));
      }
      if (!(this.alls0 != "") || this.alls0.IndexOf("http://detail.1688.com") == -1)
        return;
      this.alls1 = this.alls0.Substring(this.alls0.IndexOf("offer/") + 6);
      this.url = this.alls1.Substring(0, this.alls1.IndexOf(".html"));
    }
  }
}
