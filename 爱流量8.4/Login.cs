using CommonLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading;

using System.Windows.Forms;
using WindowsFormsApplication7;

namespace Login
{
    public partial class LoginForm : Form
    {
        frmReg fRegester;
        LoginForm fLogin;
        public LoginForm()
        {
            InitializeComponent();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!(this.txt_userName.Text.Trim() == ""))
                return;
            this.txt_userName.Text = "用户名/手机号码/QQ";
            this.txt_userName.ForeColor = System.Drawing.Color.Tan;
        }

        private void txt_userName_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txt_userName_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txt_userName_Enter(object sender, EventArgs e)
        {
            if (!(this.txt_userName.Text.Trim() == "用户名/手机号码/QQ"))
                return;
            this.txt_userName.Text = "";
            this.txt_userName.ForeColor = System.Drawing.Color.Black;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            doLogin();
        }

        private void doLogin()
        {


            if (this.txt_userName.Text.Replace("用户名/手机号码/QQ", "").Trim() == "")
            {
                int num2 = (int)MessageBox.Show("请输入用户名.");
            }
            else if (this.txt_pwd.Text.Trim() == "")
            {
                int num3 = (int)MessageBox.Show("请输入密码.");
            }
            else
            {
                this.Hide();
                usersClass usersClass = new usersClass();
                string stu = DateTime.Now.ToString("yyyy-MM-hh HH:mm:ss");
                DataTable dataTable = usersClass.login(this.txt_userName.Text.Trim(), this.txt_pwd.Text.Trim(), stu);
                if (dataTable.Rows.Count > 0)
                {
                    if (this.checkBox1.Checked)
                    {
                        AppConfig.SetValue("s1", "1");
                        string str1 = this.txt_userName.Text.Trim();
                        string str2 = "$";
                        DateTime dateTime = DateTime.Now;
                        dateTime = dateTime.AddDays(512.0);
                        string str3 = Encrypt.md5Encrypt(dateTime.ToString("yyyy-MM-dd HH:mm:ss") + this.txt_pwd.Text.Trim(), "ll13715**tb!");
                        AppConfig.SetValue("s2", str1 + str2 + str3);
                    }
                    else
                    {
                        AppConfig.SetValue("s1", "0");
                        AppConfig.SetValue("s2", "");
                    }
                    UsersTBSturct usersTbSturct = new UsersTBSturct();
                    usersTbSturct.lastAceive = stu;
                    usersTbSturct.ID = Convert.ToInt32(dataTable.Rows[0]["ID"].ToString().Trim());
                    usersTbSturct.userName = dataTable.Rows[0]["userName"].ToString();
                    usersTbSturct.phone = dataTable.Rows[0]["phone"].ToString().Trim();
                    usersTbSturct.pwd = this.txt_pwd.Text.Trim();
                    usersTbSturct.QQ = dataTable.Rows[0]["QQ"].ToString().Trim();
                    usersTbSturct.WW = dataTable.Rows[0]["WW"].ToString().Trim();
                    usersTbSturct.QT_name = dataTable.Rows[0]["QT_name"].ToString().Trim();
                    usersTbSturct.QT_Js = dataTable.Rows[0]["QT_Js"].ToString().Trim();
                    usersTbSturct.Price = Convert.ToDouble(dataTable.Rows[0]["price"].ToString().Trim());
                    if ((int)Convert.ToInt16(dataTable.Rows[0]["hydj"].ToString().Trim()) == 0)
                    {
                        usersTbSturct.endDate = dataTable.Rows[0]["endDate"].ToString().Trim();
                    }
                    else
                    {
                        usersTbSturct.endDate = "无限制";
                    }
                    usersTbSturct.regDate = dataTable.Rows[0]["regDate"].ToString().Trim();
                    usersTbSturct.hyDj = (int)Convert.ToInt16(dataTable.Rows[0]["hydj"].ToString().Trim());
                    usersTbSturct.TJR = dataTable.Rows[0]["tjr"].ToString().Trim();
                    usersTbSturct.xm = dataTable.Rows[0]["xm"].ToString().Trim();
                    usersTbSturct.ZFB = dataTable.Rows[0]["zfb"].ToString().Trim();
                    usersTbSturct.url = dataTable.Rows[0]["url"].ToString().Trim();
                    usersTbSturct.isEnable = (int)Convert.ToInt16(dataTable.Rows[0]["isEnable"].ToString().Trim());
                    usersTbSturct.isAdin = (int)Convert.ToInt16(dataTable.Rows[0]["isAdin"].ToString().Trim());
                    usersTbSturct.purStr = "|" + dataTable.Rows[0]["purStr"].ToString().Trim() + "|";
                    usersTbSturct.msg = dataTable.Rows[0]["msg"].ToString().Trim();
                    if (usersTbSturct.isEnable == 2)
                    {
                        string text = "对不起,您的帐号己被冻结,请与管理员联系!";
                        if (dataTable.Rows[0]["msg"].ToString().Trim() != "")
                            text = dataTable.Rows[0]["msg"].ToString().Trim();
                        this.Show();
                        int num4 = (int)MessageBox.Show(text);
                    }
                    else if (usersTbSturct.isEnable == 1)
                    {
                        string text = usersTbSturct.msg.Trim();
                        if (text == "")
                            text = "帐号审核中,请稍候再试!";
                        this.Show();
                        int num4 = (int)MessageBox.Show(text);

                    }
                    else if (usersTbSturct.hyDj == 0 && Convert.ToDateTime(usersTbSturct.endDate) < DateTime.Now)
                    {
                       
                        if (MessageBox.Show("对不起,您的有效期己过,加入VIP后可以继续使用!请点击确定了解") != DialogResult.OK)
                            
                        this.Show();
                
                        System.Diagnostics.Process.Start("http://115.159.3.89/");
                        return;
                    }
                    else
                    {

                        sys.LoginUser = usersTbSturct;
                        
                        this.DialogResult = DialogResult.OK;
                        button1.Enabled = false;

                        frmMain frmMain = new frmMain(this);
                        frmMain.Show();
                        //frmMain.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("登录失败");
                    button1.Enabled = true;
                    this.Show();
                }
            }
        }
        Thread autoLoginAction;
        public delegate void DelegateDoLogin();
        DelegateDoLogin delegateDologin;
        public void ThreadDoLogin()
        {
            Thread.Sleep(1000);
            if (this.txt_userName.Text == "" || this.txt_pwd.Text == "")
            {
                checkBox1.Checked = false;
                return;
            }
            this.Invoke(delegateDologin);

        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
           //ConnStr.connStr = "Data Source=127.0.0.1;Initial Catalog=mytao;User ID=lwc;Password=123456";
           ConnStr.connStr = "Data Source=115.159.3.89;Initial Catalog=mytao;User ID=lwc;Password=liuwencai123jjF";
            //ConnStr.connStr = "Data Source=aliuliang.net;Initial Catalog=mytao;User ID=lwc;Password=Jj2460776";
             delegateDologin = doLogin;
             this.TopMost = true;

            
            if (AppConfig.getValue("s1").Trim() == "1")
            {
                try
                {
                    string[] strArray = AppConfig.getValue("s2").Trim().Split('$');
                    if (strArray.Length == 2)
                    {
                        this.txt_userName.Text = strArray[0];
                        string str = Encrypt.md5Decrypt(strArray[1], "ll13715**tb!");
                        this.txt_pwd.Text = str.Substring(19, str.Length - 19);
                        this.checkBox1.Checked = true;
                    }
                }
                catch
                {

                }

            }
            if (AppConfig.getValue("s3").Trim() == "1")
                this.checkBox2.Checked = true;
            // ISSUE: method pointer
            if (checkBox2.CheckState == CheckState.Checked)
            {
                autoLoginAction = new Thread(new ThreadStart(ThreadDoLogin));
                autoLoginAction.Start();
            }
        }
      
       
        int _onlineNum=0;
        public bool isConn=false;
        private Thread ConnThread;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string AppValue = "0";
            if (this.checkBox1.Checked)
                AppValue = "1";
            AppConfig.SetValue("s1", AppValue);
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object obj = registryKey.GetValue("爱流量");
            if (obj != null && obj.ToString().Trim() == Application.ExecutablePath.ToString().Trim())
                return;
            registryKey.SetValue("爱流量", (object)Application.ExecutablePath.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fRegester = new frmReg(this);
            this.Hide();
            fRegester.Show();
        }

        private void txt_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://115.159.3.89/");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string AppValue = "0";
            if (this.checkBox2.Checked)
                AppValue = "1";
            AppConfig.SetValue("s3", AppValue);
        }
    }

}
