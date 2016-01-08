using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace x86
{
    public class frm_ww : Form
  {
    private IContainer components;
  
  
  
    private TextBox textBox2;
    private Label label2;
    private Button button3;
    private Button button4;
   

    public frm_ww()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ww));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(604, 21);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "店铺名称";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(514, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(622, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frm_ww
            // 
            this.ClientSize = new System.Drawing.Size(720, 136);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ww";
            this.Load += new System.EventHandler(this.frm_ww_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void button1_Click(object sender, EventArgs e)
    {
      
    }

    private void button2_Click(object sender, EventArgs e)
    {
      
    }

    private void frm_ww_Load(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (this.textBox2.Text.Trim().Length < 3)
        {
            int num1 = (int)MessageBox.Show("不能少于3个字符");
        }
        else
        {
            if (MessageBox.Show("您确定这个旺旺“" + this.textBox2.Text.Trim() + "”是您所要添加的吗，必须一字不差哦!", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            string str = this.textBox2.Text.Replace("'", "‘").Replace("--", "——");
            usersClass usersClass = new usersClass();
            if (usersClass.search_WW_2(str))
            {
                int num2 = (int)MessageBox.Show("当前旺旺已经注册过!");
            }
            else
            {
                usersClass.update_ww(str, sys.LoginUser.ID);
                UsersTBSturct loginUser = sys.LoginUser;
                loginUser.WW = loginUser.WW + "|" + str;
                sys.LoginUser = loginUser;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
  }
}
