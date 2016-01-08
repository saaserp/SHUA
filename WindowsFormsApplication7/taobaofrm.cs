using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace x86
{
     public class taobaofrm : Form
  {
    private string url;
    private IContainer components;
    private Panel panel1;
    private Button btncancle;
    private Button btnok;
    private Label label1;
    private WebBrowser webBrowser1;

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

    public taobaofrm()
    {
      this.components = (IContainer) null;
   
      this.InitializeComponent();
    }

    private void taobaofrm_Load(object sender, EventArgs e)
    {
      this.webBrowser1.Navigate(this.url);
    }

    private void btnok_Click(object sender, EventArgs e)
    {
      if (sys.LoginUser.hyDj <= 7)
      {
        int num = (int) MessageBox.Show("亲,此功能只为VIP8以上会员开放，请关闭自定义搜索路径功能后发布任务");
        this.url = "";
      }
      else
        this.url = this.webBrowser1.Url.AbsoluteUri;
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      foreach (HtmlElement htmlElement in this.webBrowser1.Document.Links)
        htmlElement.SetAttribute("target", "_self");
      foreach (HtmlElement htmlElement in this.webBrowser1.Document.Forms)
        htmlElement.SetAttribute("target", "_self");
    }

    private void webBrowser1_NewWindow_1(object sender, CancelEventArgs e)
    {
      e.Cancel = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (taobaofrm));
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.btncancle = new Button();
      this.btnok = new Button();
      this.webBrowser1 = new WebBrowser();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = SystemColors.GrayText;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.btncancle);
      this.panel1.Controls.Add((Control) this.btnok);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 637);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1241, 47);
      this.panel1.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("微软雅黑", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label1.ForeColor = Color.White;
      this.label1.ImageAlign = ContentAlignment.TopLeft;
      this.label1.Location = new Point(27, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(653, 19);
      this.label1.TabIndex = 1;
      this.label1.Text = "请在网页上操作一遍搜索路径，但不要进店，操作完成后点击确定。若产品排名靠后的，介意多搜索几页";
      this.btncancle.DialogResult = DialogResult.Cancel;
      this.btncancle.Location = new Point(1098, 6);
      this.btncancle.Name = "btncancle";
      this.btncancle.Size = new Size(90, 35);
      this.btncancle.TabIndex = 0;
      this.btncancle.Text = "取消";
      this.btncancle.UseVisualStyleBackColor = true;
      this.btnok.DialogResult = DialogResult.OK;
      this.btnok.Location = new Point(982, 6);
      this.btnok.Name = "btnok";
      this.btnok.Size = new Size(90, 35);
      this.btnok.TabIndex = 0;
      this.btnok.Text = "确定";
      this.btnok.UseVisualStyleBackColor = true;
      // ISSUE: method pointer
      this.btnok.Click += new EventHandler(btnok_Click);
      this.webBrowser1.AllowWebBrowserDrop = false;
      this.webBrowser1.Dock = DockStyle.Fill;
      this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
      this.webBrowser1.Location = new Point(0, 0);
      this.webBrowser1.MinimumSize = new Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.ScriptErrorsSuppressed = true;
      this.webBrowser1.Size = new Size(1241, 637);
      this.webBrowser1.TabIndex = 1;
      this.webBrowser1.Url = new Uri("", UriKind.Relative);
      // ISSUE: method pointer
      this.webBrowser1.NewWindow += new CancelEventHandler(webBrowser1_NewWindow_1);
      // ISSUE: method pointer
      this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
      this.AcceptButton = (IButtonControl) this.btnok;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1241, 684);
      this.Controls.Add((Control) this.webBrowser1);
      this.Controls.Add((Control) this.panel1);
    
      this.Name = "taobaofrm";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "卡属性对宝贝权重提升很快，按照自己的路径设置好后点击确定";
      // ISSUE: method pointer
      this.Load += new EventHandler(taobaofrm_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
