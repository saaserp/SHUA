using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Login
{
    public partial class frmReg : Form
    {
        private LoginForm fLogin;

       
        public frmReg(LoginForm fLogin)
        {
            // TODO: Complete member initialization
            this.fLogin = fLogin;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "frmReg";
            this.Text = "Regester";
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmReg));
            this.label1 = new Label();
            this.txt_phone = new TextBox();
            this.label2 = new Label();
            this.txt_userName = new TextBox();
            this.label3 = new Label();
            this.txt_pwd1 = new TextBox();
            this.label4 = new Label();
            this.txt_pwd2 = new TextBox();
            this.label5 = new Label();
            this.txt_QQ = new TextBox();
            this.label6 = new Label();
            this.txt_WW = new TextBox();
            this.label7 = new Label();
            this.txt_tjr = new TextBox();
            this.button1 = new Button();
            this.label8 = new Label();
            this.txt_Msg = new TextBox();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label12 = new Label();
            this.label11 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.lab_phone = new Label();
            this.lab_userName = new Label();
            this.lab_pwd1 = new Label();
            this.lab_pwd2 = new Label();
            this.lab_QQ = new Label();
            this.lab_WW = new Label();
            this.lab_tjr = new Label();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名:";
            this.txt_phone.Location = new Point(71, 6);
            this.txt_phone.MaxLength = 11;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new Size(148, 21);
            this.txt_phone.TabIndex = 1;
            // ISSUE: method pointer

            // ISSUE: method pointer
            this.txt_phone.Leave += new EventHandler(txt_phone_Leave);
            // ISSUE: method pointer
            this.txt_phone.KeyPress += new KeyPressEventHandler(txt_phone_KeyPress);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "手机号码:";
            this.txt_userName.Location = new Point(71, 36);
            this.txt_userName.MaxLength = 20;
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new Size(148, 21);
            this.txt_userName.TabIndex = 2;
            // ISSUE: method pointer
            this.txt_userName.Leave += new EventHandler(txt_userName_Leave);
            // ISSUE: method pointer
            this.txt_userName.KeyPress += new KeyPressEventHandler(txt_userName_KeyPress);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密    码:";
            this.txt_pwd1.Location = new Point(71, 66);
            this.txt_pwd1.MaxLength = 15;
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.PasswordChar = '*';
            this.txt_pwd1.Size = new Size(148, 21);
            this.txt_pwd1.TabIndex = 3;
            // ISSUE: method pointer
            this.txt_pwd1.Leave += new EventHandler(txt_pwd1_Leave);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 129);
            this.label4.Name = "label4";
            this.label4.Size = new Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Q Q 号码:";
            this.txt_pwd2.Location = new Point(71, 96);
            this.txt_pwd2.MaxLength = 15;
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '*';
            this.txt_pwd2.Size = new Size(148, 21);
            this.txt_pwd2.TabIndex = 4;
            // ISSUE: method pointer
            this.txt_pwd2.Leave += new EventHandler(txt_pwd2_Leave);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(6, 159);
            this.label5.Name = "label5";
            this.label5.Size = new Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "店铺旺旺:";
            this.txt_QQ.Location = new Point(71, 126);
            this.txt_QQ.MaxLength = 15;
            this.txt_QQ.Name = "txt_QQ";
            this.txt_QQ.Size = new Size(148, 21);
            this.txt_QQ.TabIndex = 5;
            // ISSUE: method pointer
            this.txt_QQ.Leave += new EventHandler(txt_QQ_Leave);
            // ISSUE: method pointer
            this.txt_QQ.KeyPress += new KeyPressEventHandler(txt_QQ_KeyPress);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 189);
            this.label6.Name = "label6";
            this.label6.Size = new Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "推荐人QQ:";
            this.txt_WW.Location = new Point(71, 156);
            this.txt_WW.MaxLength = 30;
            this.txt_WW.Name = "txt_WW";
            this.txt_WW.Size = new Size(148, 21);
            this.txt_WW.TabIndex = 6;
            // ISSUE: method pointer
            this.txt_WW.Leave += new EventHandler(txt_WW_Leave);
            // ISSUE: method pointer
            this.txt_WW.KeyPress += new KeyPressEventHandler(txt_WW_KeyPress);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "确认密码:";
            this.txt_tjr.Location = new Point(71, 186);
            this.txt_tjr.MaxLength = 20;
            this.txt_tjr.Name = "txt_tjr";
            this.txt_tjr.Size = new Size(148, 21);
            this.txt_tjr.TabIndex = 7;
            // ISSUE: method pointer
            this.txt_tjr.Leave += new EventHandler(txt_tjr_Leave);
            // ISSUE: method pointer
            this.txt_tjr.KeyPress += new KeyPressEventHandler(txt_tjr_KeyPress);
            this.button1.Location = new Point(121, 213);
            this.button1.Name = "button1";
            this.button1.Size = new Size(85, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "提交注册";
            this.button1.UseVisualStyleBackColor = true;
            // ISSUE: method pointer
            this.button1.Click += new EventHandler(button1_Click);
            this.label8.AutoSize = true;
            this.label8.ForeColor = Color.Red;
            this.label8.Location = new Point(221, 227);
            this.label8.Name = "label8";
            this.label8.Size = new Size(47, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "*为必填";
            this.txt_Msg.Location = new Point(8, 251);
            this.txt_Msg.Multiline = true;
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new Size(359, 69);
            this.txt_Msg.TabIndex = 10;
            // ISSUE: method pointer
            this.txt_Msg.KeyPress += new KeyPressEventHandler(txt_Msg_KeyPress);
            // ISSUE: method pointer
            this.txt_Msg.Enter += new EventHandler(txt_Msg_Enter);
            this.label9.AutoSize = true;
            this.label9.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label9.ForeColor = Color.Red;
            this.label9.Location = new Point(221, 9);
            this.label9.Name = "label9";
            this.label9.Size = new Size(11, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "*";
            this.label10.AutoSize = true;
            this.label10.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label10.ForeColor = Color.Red;
            this.label10.Location = new Point(221, 39);
            this.label10.Name = "label10";
            this.label10.Size = new Size(11, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "*";
            this.label12.AutoSize = true;
            this.label12.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label12.ForeColor = Color.Red;
            this.label12.Location = new Point(221, 69);
            this.label12.Name = "label12";
            this.label12.Size = new Size(11, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "*";
            this.label11.AutoSize = true;
            this.label11.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label11.ForeColor = Color.Red;
            this.label11.Location = new Point(221, 99);
            this.label11.Name = "label11";
            this.label11.Size = new Size(11, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "*";
            this.label13.AutoSize = true;
            this.label13.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label13.ForeColor = Color.Red;
            this.label13.Location = new Point(221, 129);
            this.label13.Name = "label13";
            this.label13.Size = new Size(11, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "*";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("新宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label14.ForeColor = Color.Red;
            this.label14.Location = new Point(221, 159);
            this.label14.Name = "label14";
            this.label14.Size = new Size(11, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "*";
            this.lab_phone.AutoSize = true;
            this.lab_phone.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_phone.Location = new Point(236, 9);
            this.lab_phone.Name = "lab_phone";
            this.lab_phone.Size = new Size(137, 12);
            this.lab_phone.TabIndex = 0;
            this.lab_phone.Text = "可以联系到您的手机号码";
            this.lab_userName.AutoSize = true;
            this.lab_userName.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_userName.Location = new Point(236, 39);
            this.lab_userName.Name = "lab_userName";
            this.lab_userName.Size = new Size(131, 12);
            this.lab_userName.TabIndex = 0;
            this.lab_userName.Text = "3位以上英文字母或数字";
            this.lab_pwd1.AutoSize = true;
            this.lab_pwd1.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_pwd1.Location = new Point(236, 69);
            this.lab_pwd1.Name = "lab_pwd1";
            this.lab_pwd1.Size = new Size(107, 12);
            this.lab_pwd1.TabIndex = 0;
            this.lab_pwd1.Text = "3-15位,区分大小写";
            this.lab_pwd2.AutoSize = true;
            this.lab_pwd2.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_pwd2.Location = new Point(236, 99);
            this.lab_pwd2.Name = "lab_pwd2";
            this.lab_pwd2.Size = new Size(77, 12);
            this.lab_pwd2.TabIndex = 0;
            this.lab_pwd2.Text = "再次输入密码";
            this.lab_QQ.AutoSize = true;
            this.lab_QQ.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_QQ.Location = new Point(236, 129);
            this.lab_QQ.Name = "lab_QQ";
            this.lab_QQ.Size = new Size(113, 12);
            this.lab_QQ.TabIndex = 0;
            this.lab_QQ.Text = "可以联系到您QQ号码";
            this.lab_WW.AutoSize = true;
            this.lab_WW.ForeColor = Color.FromArgb(64, 64, 64);
            this.lab_WW.Location = new Point(236, 159);
            this.lab_WW.Name = "lab_WW";
            this.lab_WW.Size = new Size(113, 12);
            this.lab_WW.TabIndex = 0;
            this.lab_WW.Text = "您的店铺的旺旺号码";
            this.lab_tjr.AutoSize = true;
            this.lab_tjr.ForeColor = Color.Red;
            this.lab_tjr.Location = new Point(224, 189);
            this.lab_tjr.Name = "lab_tjr";
            this.lab_tjr.Size = new Size(143, 12);
            this.lab_tjr.TabIndex = 0;
            this.lab_tjr.Text = "推荐人将可获得888流量币";
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(376, 324);
            this.Controls.Add((Control)this.label14);
            this.Controls.Add((Control)this.label13);
            this.Controls.Add((Control)this.label11);
            this.Controls.Add((Control)this.txt_Msg);
            this.Controls.Add((Control)this.label12);
            this.Controls.Add((Control)this.label10);
            this.Controls.Add((Control)this.label9);
            this.Controls.Add((Control)this.label8);
            this.Controls.Add((Control)this.button1);
            this.Controls.Add((Control)this.txt_tjr);
            this.Controls.Add((Control)this.label7);
            this.Controls.Add((Control)this.txt_WW);
            this.Controls.Add((Control)this.label6);
            this.Controls.Add((Control)this.txt_QQ);
            this.Controls.Add((Control)this.label5);
            this.Controls.Add((Control)this.txt_pwd2);
            this.Controls.Add((Control)this.label4);
            this.Controls.Add((Control)this.txt_pwd1);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.txt_userName);
            this.Controls.Add((Control)this.lab_tjr);
            this.Controls.Add((Control)this.lab_WW);
            this.Controls.Add((Control)this.lab_QQ);
            this.Controls.Add((Control)this.lab_pwd2);
            this.Controls.Add((Control)this.lab_pwd1);
            this.Controls.Add((Control)this.lab_userName);
            this.Controls.Add((Control)this.lab_phone);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.txt_phone);
            this.Controls.Add((Control)this.label1);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "frmReg";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "新用户注册";
            // ISSUE: method pointer
            this.Load += new EventHandler(frmReg_Load);
            this.ResumeLayout(false);
            InitializeComponent();
        }

     
        private Label label1;
        private TextBox txt_phone;
        private Label label2;
        private TextBox txt_userName;
        private Label label3;
        private TextBox txt_pwd1;
        private Label label4;
        private TextBox txt_pwd2;
        private Label label5;
        private TextBox txt_QQ;
        private Label label6;
        private TextBox txt_WW;
        private Label label7;
        private TextBox txt_tjr;
        private Button button1;
        private Label label8;
        private TextBox txt_Msg;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label11;
        private Label label13;
        private Label label14;
        private Label lab_phone;
        private Label lab_userName;
        private Label lab_pwd1;
        private Label lab_pwd2;
        private Label lab_QQ;
        private Label lab_WW;
        private Label lab_tjr;



        private void frmReg_Load(object sender, EventArgs e)
        {
            this.lab_tjr.Text = "推荐人将可获得" + sys.ConfigData.reg_tjr.ToString() + "流量币";
            this.txt_Msg.Text = "\t============注册说明=========\r\n1、注册成为会员后可获得" + sys.ConfigData.reg_u.ToString() + "流量币。\r\n2、每推荐1位朋友注册您将会获得" + sys.ConfigData.reg_tjr.ToString() + "流量币。\r\n3、被推荐人加入VIP后，您将再次获得" + (sys.ConfigData.reg_vip_tjr - sys.ConfigData.reg_tjr).ToString() + "流量币，50元销售提成!";
        }

        

        private void txt_phone_Leave(object sender, EventArgs e)
        {
            if (this.txt_phone.Text.Trim() == "")
            {
                this.lab_phone.Text = "可以联系到您的手机号码";
                this.lab_phone.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_phone.Text.Trim().Length == 11)
            {
                this.lab_phone.Text = "√";
                this.lab_phone.ForeColor = Color.Green;
            }
            else
            {
                this.lab_phone.Text = "手机号码只能为11位数字";
                this.lab_phone.ForeColor = Color.Red;
            }
        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                return;
            e.Handled = false;
        }

        private void txt_userName_Leave(object sender, EventArgs e)
        {
            if (this.txt_userName.Text.Trim() == "")
            {
                this.lab_userName.Text = "3位以上英文字母或数字";
                this.lab_userName.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_userName.Text.Trim().Length >= 3)
            {
                if (this.lab_phone.Text.Trim() != "√")
                {
                    int num1 = (int)MessageBox.Show("请先输入正确的手机号码!");
                }
                else
                {
                    this.lab_userName.Text = "检查中...";
                    this.lab_userName.ForeColor = Color.Red;
                    Application.DoEvents();
                    Thread.Sleep(200);
                    if (new usersClass().search(this.txt_userName.Text.Trim(), this.txt_phone.Text.Trim()).Rows.Count > 0)
                    {
                        int num2 = (int)MessageBox.Show("很抱歉,您的用户名己被抢注");
                        this.lab_userName.Text = "很抱歉,您的用户名己被抢注";
                    }
                    else
                    {
                        this.lab_userName.Text = "√";
                        this.lab_userName.ForeColor = Color.Green;
                    }
                 
                }
            }
            else
            {
                this.lab_userName.Text = "必须3位以上";
                this.lab_userName.ForeColor = Color.Red;
            }
        }

        private void txt_userName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txt_pwd1_Leave(object sender, EventArgs e)
        {
            if (this.txt_pwd1.Text.Trim() == "")
            {
                this.lab_pwd1.Text = "3-15位,区分大小写";
                this.lab_pwd1.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_pwd1.Text.Trim().Length < 3)
            {
                this.lab_pwd1.Text = "位数必须3位以上";
                this.lab_pwd1.ForeColor = Color.Red;
            }
            else
            {
                this.lab_pwd1.Text = "√";
                this.lab_pwd1.ForeColor = Color.Green;
                if (this.txt_pwd1.Text.Trim() == this.txt_pwd2.Text.Trim())
                {
                    this.lab_pwd2.Text = "√";
                    this.lab_pwd2.ForeColor = Color.Green;
                }
                else
                {
                    this.lab_pwd2.Text = "二次密码不一致";
                    this.lab_pwd2.ForeColor = Color.Red;
                }
            }
        }

        private void txt_pwd2_Leave(object sender, EventArgs e)
        {
            if (this.txt_pwd2.Text.Trim() == "")
            {
                this.lab_pwd2.Text = "3-15位,区分大小写";
                this.lab_pwd2.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_pwd2.Text.Trim().Length < 3)
            {
                this.lab_pwd2.Text = "位数必须3位以上";
                this.lab_pwd2.ForeColor = Color.Red;
            }
            else if (this.txt_pwd1.Text.Trim() == this.txt_pwd2.Text.Trim())
            {
                this.lab_pwd2.Text = "√";
                this.lab_pwd2.ForeColor = Color.Green;
            }
            else
            {
                this.lab_pwd2.Text = "二次密码不一致";
                this.lab_pwd2.ForeColor = Color.Red;
            }
        }

        private void txt_QQ_Leave(object sender, EventArgs e)
        {
            if (this.txt_QQ.Text.Trim() == "")
            {
                this.lab_QQ.Text = "可以联系到您的手机号码";
                this.lab_QQ.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_QQ.Text.Trim().Length >= 5)
            {
                if (new usersClass().search_QQ(this.txt_QQ.Text.Trim()).Rows.Count > 0)
                {
                    this.lab_QQ.Text = "该QQ号码己注册过";
                    this.lab_QQ.ForeColor = Color.Red;
                }
                else
                {
                    this.lab_QQ.Text = "√";
                    this.lab_QQ.ForeColor = Color.Green;
                }
            }
            else
            {
                this.lab_QQ.Text = "QQ号码不能少于5位";
                this.lab_QQ.ForeColor = Color.Red;
            }
        }

        private void txt_QQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                return;
            e.Handled = false;
        }

        private void txt_WW_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txt_WW_Leave(object sender, EventArgs e)
        {
            if (this.txt_WW.Text.Trim() == "")
            {
                this.lab_WW.Text = "您的店铺的旺旺号码";
                this.lab_WW.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_WW.Text.Trim().Length >= 3)
            {
                this.lab_WW.Text = "检查中...";
                this.lab_WW.ForeColor = Color.Red;
                Application.DoEvents();
                Thread.Sleep(200);
                if (new usersClass().search_WW_2(this.txt_WW.Text.Trim()))
                {
                    this.lab_WW.Text = "该店铺己被会员添加过";
                }
                else
                {
                    this.lab_WW.Text = "√";
                    this.lab_WW.ForeColor = Color.Green;
                }
            }
            else
            {
                this.lab_WW.Text = "旺旺号码不能少于3位";
                this.lab_WW.ForeColor = Color.Red;
            }
        }

        private void txt_tjr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar >= 65 && (int)e.KeyChar <= 90 || (int)e.KeyChar >= 97 && (int)e.KeyChar <= 122 || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_tjr_Leave(object sender, EventArgs e)
        {
            if (this.txt_tjr.Text.Trim() == "")
            {
                this.lab_tjr.Text = "推荐人将可获得888流量币";
                this.lab_tjr.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else if (this.txt_tjr.Text.Trim().Length >= 3)
            {
                this.lab_tjr.Text = "√";
                this.lab_tjr.ForeColor = Color.Green;
            }
            else
            {
                this.lab_tjr.Text = "必须3位以上";
                this.lab_tjr.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lab_phone.Text.Trim() != "√" || this.lab_userName.Text != "√" || (this.lab_pwd1.Text.Trim() != "√" || this.lab_pwd2.Text != "√") || this.lab_QQ.Text != "√" || this.lab_WW.Text != "√")
            {
                int num1 = (int)MessageBox.Show("请填写完所有必填资料后再提交");
            }
            else
            {
                UsersTBSturct Record = new UsersTBSturct();
                Record.phone = this.txt_phone.Text.Trim();
                Record.userName = this.txt_userName.Text.Trim();
                Record.pwd = this.txt_pwd1.Text.Trim();
                Record.QQ = this.txt_QQ.Text.Trim();
                Record.WW =  this.txt_WW.Text.Trim();
                Record.TJR = this.txt_tjr.Text.Trim();
                if (Record.TJR.Length < 3)
                    Record.TJR = "";
                Record.QT_name = "";
                Record.QT_Js = "";
               // Record.Price = (double)sys.ConfigData.reg_u;
                Record.Price =5000;
                // ISSUE: explicit reference operation
                // ISSUE: variable of a reference type
                UsersTBSturct local1 = Record;
                DateTime dateTime = DateTime.Now;
                string str1 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                // ISSUE: explicit reference operation
                (local1).regDate = str1;
                // ISSUE: explicit reference operation
                // ISSUE: variable of a reference type
                UsersTBSturct local2 = Record;
                dateTime = DateTime.Now;
                dateTime = dateTime.AddMonths(1);
                string str2 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                // ISSUE: explicit reference operation
                (local2).endDate = str2;
                Record.hyDj = 0;
                Record.xm = "";
                Record.ZFB = "";
                Record.url = "";
                Record.isEnable = 0;
                Record.lastAceive = "";
                Record.isAdin = 0;
                Record.chkId = 0;
                Record.purStr = "";
                if (Record.TJR == Record.QQ)
                {
                    int num2 = (int)MessageBox.Show("用户QQ与推荐人QQ不可相同!");
                }
                else
                {
                    if (sys.ConfigData.defIsDj == 1)
                    {
                        Record.isEnable = 1;
                        Record.msg = sys.ConfigData.djts;
                    }
                    usersClass usersClass = new usersClass();
                    int ReturnID = 0;
                    usersClass.InsertRecord(Record, ref ReturnID);
                    if (ReturnID > 0)
                    {
                        bool flag = false;
                        DataTable dataTable = usersClass.search_QQ(Record.TJR);
                        if (Record.TJR != "" && dataTable.Rows.Count > 0)
                        {
                            flag = true;
                            string strsql = string.Concat(new object[4]
              {
                (object) "update users set price=price+",
                (object) sys.ConfigData.reg_tjr,
                (object) " where id=",
                (object) dataTable.Rows[0]["ID"].ToString().Trim()
              });
                            usersClass.exec(strsql);
                        }
                        string str3 = "恭喜您，帐户已注册成功！\r\n";
                        string text;
                        if (sys.ConfigData.defIsDj == 1)
                        {
                            text = sys.ConfigData.djts;
                            if (text == "")
                                text = "";
                        }
                        else
                        {
                            text = string.Concat(new object[4]
              {
                (object) str3,
                (object) "1.默认我们已经给亲奖励",
                (object) sys.ConfigData.reg_u,
                (object) "流量币\r\n2.当亲加入VIP会员后，您还可以获得更多奖励哦"
              });
                            if (flag)
                            {
                                if (dataTable.Rows[0]["hydj"].ToString().Trim() == "0")
                                    text = text + (object)"\r\n3.您输入的推荐人“" + Record.TJR + "”将获得" + sys.ConfigData.reg_tjr + "个流量币奖励,当您加入VIP后,您的推荐人还可以再次获得奖励哦";
                                else
                                    text = text + (object)"\r\n3.您输入的推荐人“" + Record.TJR + "”将获得" + sys.ConfigData.reg_tjr + "个流量币奖励,当您加入VIP,您的推荐人还可以再次获得奖励哦";
                            }
                            else if (!(Record.TJR == ""))
                                text = text + "\r\n3.您输入的推荐人“" + Record.TJR + "”不存在,暂时无法获得奖励";
                        }
                        int num3 = (int)MessageBox.Show(text);
                        this.fLogin.txt_userName.Text = Record.userName;
                        this.fLogin.txt_pwd.Text = Record.pwd;
                        this.Close();
                        fLogin.Show();
                    }
                    else
                    {
                        int num4 = (int)MessageBox.Show("提交失败,请检查网络连接是否正常,或与管理员联系!");
                    }
                }
            }
        }

        private void txt_Msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_Msg_Enter(object sender, EventArgs e)
        {
            this.txt_phone.Focus();
        }

       

        private void frmReg_Load_1(object sender, EventArgs e)
        {
          
        }

        private void frmReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            fLogin.Show();
        }

      
    }
}
