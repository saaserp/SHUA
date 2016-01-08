using CommonLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace x86
{
    public partial class frmMain : Form
    {
        private bool _isClose;
        private bool Urlflag;
        private bool isLoad;
        private DateTime lastCheckClick;
        private string strResultUrl;
        private int _temJsq;
        private int __temJsq;
        private string _price;
        private string _cur_home_url;
        private string _clickedUrl;
        private Color[] c;
        private string _cur_click_bbname;
        private TaskTBSturct _curTask;
        public delegate void Clickdelegate(WebBrowser web);
        public delegate void Showdelegate(string str);
        public delegate void ToUrldelegate(WebBrowser web, string url);
        Clickdelegate clickdelegateClick_home;
        Clickdelegate clickdelegateClick_bb;
        Clickdelegate clickdelegateClick_Scro;
        Clickdelegate clickdelegateClick_jd;
        Clickdelegate clickdelegateClick_lm;
        Showdelegate showdelegate;
        ToUrldelegate toUrldelegate;
        public delegate void Movedelegate();
        Movedelegate movedelegate;
        public delegate void DelegateUpdateAllData();
        public DelegateUpdateAllData delegateUpdateAllDate;
        public delegate void DelegateInitView();
        public delegate void DelegateShowOnlineStu(string s1, int flag);
        DelegateShowOnlineStu delegateShowOnlineStu;
        DelegateInitView delegateInitView;
        public delegate void DelegateCloseMe();
        DelegateCloseMe delegateCloseMe;
        private Thread MainThread2;
        private Thread MainThread3;
        private Thread MainThread;
        private Thread ThreadFukuan;
        private DataTable hydjTB;
        private bool isOpenMsg;
        Form loginForm;
        private int msgRow;
        public enum ShowCommands
        {
            SW_HIDE = 0,
            SW_NORMAL = 1,
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_MAXIMIZE = 3,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11,
        }
        [DllImport("shell32.dll")]
        private static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, frmMain.ShowCommands nShowCmd);
        public frmMain(Form loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.lastCheckClick = DateTime.Now;
            this._curTask = new TaskTBSturct();
            this._curTask.Stu = "";
            _isClose = false;
            //_curTask.keyword = "星际争霸2代练";

            //_curTask.userId = 5630;

            //_curTask.ID = 6532611;
            //_curTask.ww = "包包大人就是大象";
            //_curTask.comeType = "按综合";
            //_curTask.pageNum = 3;
            //_curTask.downNum1 = 1;
            //_curTask.downNum2 = 2;
            //_curTask.ipSpace = 24;
            //_curTask.jdTime1 = 120;
            //_curTask.jdTime2 = 180;
            //_curTask.dnTime1 = 90;
            //_curTask.dnTime2 = 120;
            //_curTask.sl = 1;
            //_curTask.price = 14.30;
            //_curTask.Stu = "搜索宝贝";


            this._temJsq = 0;
            this.isLoad = false;
            this._cur_home_url = "";
            this._clickedUrl = "";
            this._cur_click_bbname = "";
            msgRow = 0;
            clickdelegateClick_home = click_home;
            clickdelegateClick_bb = click_bb;
            clickdelegateClick_Scro = click_Scro;
            clickdelegateClick_jd = click_jd;
            clickdelegateClick_lm = click_lm;

            delegateCloseMe = closeMe;
            movedelegate = move1;
            showdelegate = ShowMessage;
            toUrldelegate = openUrl;
            delegateInitView = initView;
            delegateUpdateAllDate = updateAllData;
            delegateShowOnlineStu = showOnlineStu;
            __temJsq = 0;
            // ConnStr.connStr = "Data Source=127.0.0.1;Initial Catalog=mytao;User ID=lwc;Password=123456";



        }



        void check()
        {

            
            while (true)
            {
                task();
                try
                {
                    functionSwitch();//开启某些功能
                    this.BeginInvoke(delegateShowOnlineStu, "", 3);
                    showTixianleiji();//累计提现金额
                    sys.LoginUser = new usersClass().getUserInfo(sys.LoginUser.ID.ToString());

                    //this.Invoke(delegateUpdateLable, this.lab_mymsg, sys.LoginUser.msg);
                    this.BeginInvoke(delegateInitView);
                }
                catch (Exception )
                {

                }
               

                Thread.Sleep(10000);
            }
        }
        private void task()
        {
            try
            {

                TimeSpan timeSpan = DateTime.Now.Subtract(this.lastCheckClick);
                if (timeSpan.TotalSeconds > 40.0 && this._curTask.Stu != "")
                {
                    this.postTask(0);
                    this._curTask.Stu = "";
                    this.lastCheckClick = DateTime.Now.AddSeconds(50.0);
                }
                else if (this._curTask.Stu == "")
                {
                    this._temJsq = 0;
                    if (timeSpan.TotalSeconds > 0.0)
                        this.downTask();
                }
                else if (this._curTask.Stu == "浏览进店页")
                {
                    if (timeSpan.TotalSeconds > 0.0)
                    {
                        if (this._curTask.sl > this._curTask.jd)
                        {
                            if (this._curTask.homeTime1 > 0)
                            {
                                this._curTask.Stu = "浏览主页";
                                // ISSUE: method pointer
                                this.BeginInvoke(clickdelegateClick_home, this.webBrowser1);
                            }
                            else
                            {
                                this._curTask.Stu = "浏览宝贝";
                                // ISSUE: method pointer
                                this.BeginInvoke(clickdelegateClick_bb, this.webBrowser1);
                            }
                        }
                        else
                        {
                            this.strLog = string.Format("{0} 正在提交任务.", DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, this.strLog);
                            int num = 0;
                            while (num < 3)
                            {
                                if (this.postTask(2))
                                {
                                    num = 10;
                                }
                                else
                                {
                                    ++num;
                                    Thread.Sleep(20000);
                                }
                            }
                            this.strLog = string.Format("{0} 您将在20秒后再次获取任务.", (object)DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this._curTask.Stu = "";
                            this.lastCheckClick = DateTime.Now.AddSeconds(5.0);
                        }
                    }
                    else
                    {
                        try
                        {
                            // ISSUE: method pointer
                            this.BeginInvoke(clickdelegateClick_Scro, this.webBrowser1);
                        }
                        catch (Exception)
                        { 
                        }
                       
                    }
                }
                else if (this._curTask.Stu == "浏览主页" || this._curTask.Stu == "浏览宝贝")
                {
                    if (timeSpan.TotalSeconds > 0.0)
                    {
                        if (this._curTask.sl > this._curTask.jd)
                        {
                            this._curTask.Stu = "浏览宝贝";
                            // ISSUE: method pointer
                            this.BeginInvoke(clickdelegateClick_bb, this.webBrowser1);
                        }
                        else
                        {
                            this.strLog = string.Format("{0} 正在提交任务.", DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, this.strLog);
                            int num = 0;
                            while (num < 3)
                            {
                                if (this.postTask(2))
                                {
                                    num = 10;
                                }
                                else
                                {
                                    ++num;
                                    Thread.Sleep(20000);
                                }
                            }
                            this.strLog = string.Format("{0} 您将在20秒后再次获取任务.", (object)DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this._curTask.Stu = "";
                            this.lastCheckClick = DateTime.Now.AddSeconds(5.0);
                        }
                    }
                    else
                    {
                     
                        // ISSUE: method pointer
                        this.BeginInvoke(clickdelegateClick_Scro, (object)this.webBrowser1);
                    }
                }
                else if (this._curTask.Stu == "搜索宝贝")
                {
                    if (timeSpan.TotalSeconds > 0.0)
                    {
                        // ISSUE: method pointer
                        this.BeginInvoke(clickdelegateClick_jd, this.webBrowser1);
                    }
                    else
                    {
                        // ISSUE: method pointer
                        this.BeginInvoke(clickdelegateClick_Scro, this.webBrowser1);
                    }
                }
                else if (this._curTask.Stu == "按类目搜索宝贝" && timeSpan.TotalSeconds > 0.0)
                {
                    // ISSUE: method pointer
                    this.BeginInvoke(clickdelegateClick_lm,  this.webBrowser1);
                }
            }
            catch
            {
            }
        }
        private void click_home(WebBrowser web)
        {
            try
            {
                HtmlDocument document = web.Document;
                Encoding encoding = Encoding.GetEncoding("gb2312");
                string documentText = web.DocumentText;
                if (documentText != null && documentText.Trim() != "")
                {
                    byte[] numArray = new byte[web.DocumentStream.Length];
                    web.DocumentStream.Read(numArray, 0, (int)web.DocumentStream.Length);
                    char[] chars = new char[encoding.GetCharCount(numArray, 0, numArray.Length)];
                    encoding.GetChars(numArray, 0, numArray.Length, chars, 0);
                    string str1 = new string(chars);
                    web.Document.GetElementsByTagName("a");
                    for (int index = 0; index < document.Links.Count; ++index)
                    {
                        string outerHtml = document.Links[index].OuterHtml;
                        string innerText = document.Links[index].InnerText;
                        if (innerText != null && innerText.IndexOf("进入店铺") != -1)
                        {
                            document.Links[index].SetAttribute("target", "_self");
                            document.Links[index].InvokeMember("Click");
                            this._curTask.Stu = "浏览主页";
                            string format = "{0} 正在浏览主页.";
                            DateTime now = DateTime.Now;
                            string str2 = now.ToString();
                            this.strLog = string.Format(format, (object)str2);
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this._curTask.jd = this._curTask.jd + 1;
                            // ISSUE: explicit reference operation
                            // ISSUE: variable of a reference type
                            TaskTBSturct local = this._curTask;
                            now = DateTime.Now;
                            string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                            // ISSUE: explicit reference operation
                            (local).startTime = str3;
                            if (this._curTask.homeTime1 == this._curTask.homeTime2)
                            {
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.homeTime1);
                                this._curTask.jdTime1 = this._curTask.homeTime1;
                                break;
                            }
                            Random random = new Random();
                            Thread.Sleep(1000);
                            this._curTask.jdTime1 = random.Next(this._curTask.homeTime1, this._curTask.homeTime2);
                            now = DateTime.Now;
                            this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                            break;
                        }
                    }
                }
            }
            catch
            {
                this._curTask.Stu = "";
                this._curTask.optStu = 0;
            }
        }


        private string strLog;
        private bool postTask(int stu)
        {
            try
            {
                TasksClass tasksClass = new TasksClass();
                int num1 = tasksClass.PostTask(this._curTask.ID, stu);
                int num2 = 0;
                while (num1 < 0 && num2 < 5)
                {
                    num1 = tasksClass.PostTask(this._curTask.ID, stu);
                    if (num1 >= 0)
                        num2 = 100;
                    else
                        Thread.Sleep(1000);
                }
                if (num1 < 0)
                {
                    this.strLog = string.Format("{0} 提交失败,20秒后重试.", (object)DateTime.Now.ToString());
                    this.BeginInvoke(showdelegate, (object)this.strLog);
                    return false;
                }
                TaskLogTBSturct data = new TaskLogTBSturct();
                data.taskId = this._curTask.ID;
                data.ww = this._curTask.ww;
                data.ip = this.lab_IP.Text.Trim().Split(' ')[0].Trim();
                data.uId = sys.LoginUser.ID;
                if (stu == 2)
                {
                    double p = this._curTask.price * this.getMyHydj(1) / 100.0;
                    usersClass usersClass = new usersClass();
                    double syPrice = 0.0;
                    bool flag = usersClass.changePrice_2(sys.LoginUser.ID, p, ref syPrice);
                    UsersTBSturct loginUser = sys.LoginUser;
                    loginUser.Price = syPrice;
                    sys.LoginUser = loginUser;
                    data.price = p;
                    data.stu = 2;
                    data.optTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (!flag)
                        return false;
                    this.strLog = string.Format("{0} 恭喜完成任务:{1} 获得流量币:{2} 余额:{3}.", (object)DateTime.Now.ToString(), (object)this._curTask.ID, (object)p.ToString("f2"), (object)sys.LoginUser.Price.ToString("f2"));
                    this.BeginInvoke(showdelegate, (object)this.strLog);
                    //this.addPostLog(data);
                    return true;
                }
                if (stu != 1)
                    return true;
                double p1 = this._curTask.price / 2.0 * this.getMyHydj(1) / 100.0;
                usersClass usersClass1 = new usersClass();
                double syPrice1 = 0.0;
                bool flag1 = usersClass1.changePrice_2(sys.LoginUser.ID, p1, ref syPrice1);
                UsersTBSturct loginUser1 = sys.LoginUser;
                loginUser1.Price = syPrice1;
                sys.LoginUser = loginUser1;
                if (!flag1)
                    return false;
                usersClass1.changePrice_2(this._curTask.userId, this._curTask.price / 2.0, ref syPrice1);
                this.strLog = string.Format("{0} 恭喜完成任务:{1} 获得流量币:{2} 余额:{3}.", (object)DateTime.Now.ToString(), (object)this._curTask.ID, (object)p1.ToString("f2"), (object)sys.LoginUser.Price.ToString("f2"));
                this.BeginInvoke(showdelegate, (object)this.strLog);
                data.price = p1;
                data.stu = 1;
                data.optTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
              //  this.addPostLog(data);
                return true;
            }
            catch
            {
                return false;
            }

        }
        //private bool postTask(int stu)
        //{
            //try
            //{
            //    TasksClass tasksClass = new TasksClass();
            //    int num1 = tasksClass.PostTask(this._curTask.ID, stu);
            //    int num2 = 0;
            //    while (num1 < 0 && num2 < 5)
            //    {
            //        num1 = tasksClass.PostTask(this._curTask.ID, stu);
            //        if (num1 >= 0)
            //            num2 = 100;
            //        else
            //            Thread.Sleep(1000);
            //    }
            //    if (num1 < 0)
            //    {
            //        this.strLog = string.Format("{0} 提交失败,20秒后重试.", (object)DateTime.Now.ToString());
            //        // ISSUE: method pointer
            //        this.BeginInvoke(showdelegate, (object)this.strLog);
            //        return false;
            //    }
            //    TaskLogTBSturct data = new TaskLogTBSturct();
            //    data.taskId = this._curTask.ID;
            //    data.ww = this._curTask.ww;
            //    data.ip = this.lab_IP.Text.Trim().Split(' ')[0].Trim();
            //    data.ip = "";
            //    data.uId = sys.LoginUser.ID;
            //    if (stu == 2)
            //    {
            //        double p = this._curTask.price * this.getMyHydj(1) / 100.0;
            //        usersClass usersClass = new usersClass();
            //        double syPrice = 0.0;
            //        bool flag = usersClass.changePrice_2(sys.LoginUser.ID, p, ref syPrice);

            //        UsersTBSturct loginUser = sys.LoginUser;
            //        loginUser.Price = syPrice;
            //        sys.LoginUser = loginUser;
            //        data.price = 0;
            //        data.stu = 2;
            //        data.optTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //        if (!flag)
            //            return false;
            //        this.strLog = string.Format("{0} 恭喜完成任务:{1} 获得流量币:{2} 余额:{3}.", (object)DateTime.Now.ToString(), (object)this._curTask.ID, (object)p.ToString("f2"), (object)sys.LoginUser.Price.ToString("f2"));
            //        // ISSUE: method pointer
            //        this.BeginInvoke(showdelegate, (object)this.strLog);
            //        //this.addPostLog(data);
            //        return true;
            //    }
            //    if (stu != 1)
            //        return true;
            //    double p1 = this._curTask.price / 2.0 * this.getMyHydj(1) / 100.0;
            //    usersClass usersClass1 = new usersClass();
            //    double syPrice1 = 0.0;
            //    bool flag1 = usersClass1.changePrice_2(sys.LoginUser.ID, p1, ref syPrice1);

            //    UsersTBSturct loginUser1 = sys.LoginUser;
            //    loginUser1.Price = syPrice1;
            //    sys.LoginUser = loginUser1;
            //    if (!flag1)
            //        return false;
            //    usersClass1.changePrice_2(this._curTask.userId, this._curTask.price / 2.0, ref syPrice1);
            //    this.strLog = string.Format("{0} 恭喜完成任务:{1} 获得流量币:{2} 余额:{3}.", (object)DateTime.Now.ToString(), (object)this._curTask.ID, (object)p1.ToString("f2"), (object)sys.LoginUser.Price.ToString("f2"));
            //    // ISSUE: method pointer
            //    this.BeginInvoke(showdelegate, (object)this.strLog);
            //    data.price = 0;
            //    data.stu = 1;
            //    data.optTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    //this.addPostLog(data);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        //}




        private void click_bb(WebBrowser web)
        {
            try
            {
                HtmlDocument document = web.Document;
                Encoding encoding = Encoding.GetEncoding("gb2312");
                string documentText = web.DocumentText;
                if (documentText != null && documentText.Trim() != "")
                {
                    byte[] numArray = new byte[web.DocumentStream.Length];
                    web.DocumentStream.Read(numArray, 0, (int)web.DocumentStream.Length);
                    char[] chars = new char[encoding.GetCharCount(numArray, 0, numArray.Length)];
                    encoding.GetChars(numArray, 0, numArray.Length, chars, 0);
                    string str1 = new string(chars);
                    web.Document.GetElementsByTagName("a");
                    Random random1 = new Random();
                    Thread.Sleep(500);
                    int num1 = random1.Next(1, 10);
                    int num2 = 0;
                    web.Url.ToString().Trim().Replace("&", "&amp;");
                    for (int index1 = 0; index1 < document.Links.Count; ++index1)
                    {
                        string outerHtml = document.Links[index1].OuterHtml;
                        if (outerHtml != null && (outerHtml.IndexOf("http://item.taobao.com/item.htm") != -1 || outerHtml.IndexOf("http://detail.tmall.com/item.htm") != -1) && outerHtml.IndexOf("catid=0") == -1)
                        {
                            if (this._clickedUrl.Trim() != "")
                            {
                                string[] strArray = sys.rValue(outerHtml, "id=", "&");
                                if (strArray.Length == 0)
                                    strArray = sys.rValue(outerHtml, "id=", "\"");
                                string str2 = "";
                                if (strArray.Length > 0)
                                {
                                    for (int index2 = 0; index2 < strArray[index2].Length; ++index2)
                                    {
                                        if (strArray[index2].Length > 5)
                                        {
                                            str2 = strArray[index2].Trim();
                                            break;
                                        }
                                    }
                                }
                                if (this._clickedUrl.IndexOf(str2) != -1)
                                    continue;
                            }
                            ++num2;
                            int index3 = index1;
                            if (num2 == num1)
                            {
                                document.Links[index1].SetAttribute("target", "_self");
                                document.Links[index1].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                            if (index1 >= document.Links.Count - 3 && index3 >= 0)
                            {
                                document.Links[index3].SetAttribute("target", "_self");
                                document.Links[index3].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate,this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                        if (outerHtml != null && outerHtml.IndexOf("http://item.jd.com") != -1 && outerHtml.IndexOf("catid=0") == -1)
                        {
                            if (this._clickedUrl.Trim() != "")
                            {
                                string[] strArray = sys.rValue(outerHtml, "com/", ".html");
                                if (strArray.Length == 0)
                                    strArray = sys.rValue(outerHtml, "/", "\"");
                                string str2 = "";
                                if (strArray.Length > 0)
                                {
                                    for (int index2 = 0; index2 < strArray[index2].Length; ++index2)
                                    {
                                        if (strArray[index2].Length > 5)
                                        {
                                            str2 = strArray[index2].Trim();
                                            break;
                                        }
                                    }
                                }
                                if (this._clickedUrl.IndexOf(str2) != -1)
                                    continue;
                            }
                            ++num2;
                            int index3 = index1;
                            if (num2 == num1)
                            {
                                document.Links[index1].SetAttribute("target", "_self");
                                document.Links[index1].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                            if (index1 >= document.Links.Count - 3 && index3 >= 0)
                            {
                                document.Links[index3].SetAttribute("target", "_self");
                                document.Links[index3].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                        if (outerHtml != null && outerHtml.IndexOf("http://detail.1688.com") != -1 && outerHtml.IndexOf("catid=0") == -1)
                        {
                            if (this._clickedUrl.Trim() != "")
                            {
                                string[] strArray = sys.rValue(outerHtml, "offer/", ".html");
                                if (strArray.Length == 0)
                                    strArray = sys.rValue(outerHtml, "/", "\"");
                                string str2 = "";
                                if (strArray.Length > 0)
                                {
                                    for (int index2 = 0; index2 < strArray[index2].Length; ++index2)
                                    {
                                        if (strArray[index2].Length > 5)
                                        {
                                            str2 = strArray[index2].Trim();
                                            break;
                                        }
                                    }
                                }
                                if (this._clickedUrl.IndexOf(str2) != -1)
                                    continue;
                            }
                            ++num2;
                            int index3 = index1;
                            if (num2 == num1)
                            {
                                document.Links[index1].SetAttribute("target", "_self");
                                document.Links[index1].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                            if (index1 >= document.Links.Count - 3 && index3 >= 0)
                            {
                                document.Links[index3].SetAttribute("target", "_self");
                                document.Links[index3].InvokeMember("Click");
                                this._curTask.Stu = "浏览宝贝";
                                string format = "{0} 正在浏览店内宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = this._curTask.jd + 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.dnTime1 == this._curTask.dnTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.dnTime2);
                                    this._curTask.jdTime1 = this._curTask.dnTime2;
                                    return;
                                }
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                this._curTask.jdTime1 = random2.Next(this._curTask.dnTime1, this._curTask.dnTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                    }
                    this._curTask.Stu = "浏览主页";
                    this._curTask.homeTime1 = 80;
                    this._curTask.homeTime2 = 120;
                    // ISSUE: method pointer
                    this.BeginInvoke(clickdelegateClick_home, (object)this.webBrowser1);
                }
            }
            catch
            {
                this._curTask.Stu = "";
                this._curTask.optStu = 0;
            }
        }
        private void add(int flag)
        {
            TaskTBSturct Record = new TaskTBSturct();
            Record.userId = sys.LoginUser.ID;
            Record.keyword = this.rw_txt_key.Text.Trim();
            Record.ww = this.rw_com_ww.Text.Trim();
            Record.comeType = this.rw_com_jd.Text.Trim();
            Record.pageNum = (int)Convert.ToInt16(this.rw_com_page.Text.Trim());
            Record.dq = this.rw_txt_dq.Text.Trim();
            if (this.Urlflag)
                Record.urltaobao = this.strResultUrl;
            if (!this.Urlflag)
                Record.urltaobao = (string)null;
            Record.xinpin = !this.checkBox2.Checked ? "" : "新品";
            Record.baoyou = !this.checkBox6.Checked ? "" : "包邮";
            Record.zsyfx = !this.checkBox9.Checked ? "" : "赠送退货运费险";
            Record.hdfk = !this.checkBox13.Checked ? "" : "货到付款";
            Record.hwsp = !this.checkBox12.Checked ? "" : "海外商品";
            Record.tianmao = !this.checkBox15.Checked ? "" : "天猫";
            Record.zpbz = !this.checkBox8.Checked ? "" : "正品保障";
            Record.xiaoshi24 = !this.checkBox3.Checked ? "" : "24小时内发货";
            Record.tian7 = !this.checkBox7.Checked ? "" : "7+天内退货";
            Record.wwzx = !this.checkBox4.Checked ? "" : "旺旺在线";
            Record.xykzf = !this.checkBox5.Checked ? "" : "信用卡支付";
            Record.zhekou = !this.checkBox11.Checked ? "" : "折扣促销";
            Record.mfhx = !this.checkBox10.Checked ? "" : "免费换新";
            Record.pzcn = !this.checkBox14.Checked ? "" : "品质承诺";
            Record.downNum1 = !(this.rw_txt_cjsl1.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_cjsl1.Text.Trim()) : 1;
            Record.downNum2 = !(this.rw_txt_cjsl2.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_cjsl2.Text.Trim()) : 2;
            Record.price1 = !(this.rw_txt_price1.Text.Trim() != "") ? -1 : Convert.ToInt32(this.rw_txt_price1.Text.Trim());
            Record.price2 = !(this.rw_txt_price2.Text.Trim() != "") ? -1 : Convert.ToInt32(this.rw_txt_price2.Text.Trim());
            if (Record.downNum1 < 0)
                Record.downNum1 = 1;
            if (Record.downNum2 < 0)
                Record.downNum2 = 1;
            if (Record.downNum2 < Record.downNum1)
                Record.downNum2 = Record.downNum1;
            Record.ipSpace = (int)Convert.ToInt16(this.rw_com_ip.Text.Replace("小时", "").Trim());
            if (this.rw_jd_sj1.Text.Trim() == "")
            {
                Record.jdTime1 = 120;
                this.rw_jd_sj1.Text = "120";
            }
            else
                Record.jdTime1 = (int)Convert.ToInt16(this.rw_jd_sj1.Text.Trim());
            if (this.rw_jd_sj2.Text.Trim() == "")
            {
                Record.jdTime2 = 180;
                this.rw_jd_sj2.Text = "180";
            }
            else
                Record.jdTime2 = (int)Convert.ToInt16(this.rw_jd_sj2.Text.Trim());
            if (Record.jdTime1 < 120)
                Record.jdTime1 = 120;
            if (Record.jdTime1 > 180)
                Record.jdTime1 = 180;
            if (Record.jdTime2 > 300)
                Record.jdTime2 = 300;
            if (Record.jdTime2 < Record.jdTime1)
                Record.jdTime2 = Record.jdTime1;
            if (this.rw_dn_sj1.Text.Trim() == "")
            {
                Record.dnTime1 = 60;
                this.rw_dn_sj1.Text = "60";
            }
            else
                Record.dnTime1 = (int)Convert.ToInt16(this.rw_dn_sj1.Text.Trim());
            if (this.rw_dn_sj2.Text.Trim() == "")
            {
                Record.dnTime2 = 120;
                this.rw_dn_sj2.Text = "120";
            }
            else
                Record.dnTime2 = (int)Convert.ToInt16(this.rw_dn_sj2.Text.Trim());
            if (Record.dnTime1 < 30)
                Record.dnTime1 = 30;
            if (Record.dnTime1 > 120)
                Record.dnTime1 = 120;
            if (Record.dnTime2 > 180)
                Record.dnTime2 = 180;
            if (Record.dnTime2 < Record.dnTime1)
                Record.dnTime2 = Record.dnTime1;
            Record.sl = !(this.rw_txt_snedNum1.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_snedNum1.Text.Trim()) : 10;
            if (Record.sl <= 0)
                Record.sl = 1;
            if (this.rw_chk_home.Checked)
            {
                if (this.rw_howe_time1.Text.Trim() == "")
                {
                    Record.homeTime1 = 60;
                    this.rw_howe_time1.Text = "60";
                }
                else
                    Record.homeTime1 = (int)Convert.ToInt16(this.rw_howe_time1.Text.Trim());
                if (this.rw_howe_time2.Text.Trim() == "")
                {
                    Record.homeTime2 = 120;
                    this.rw_howe_time2.Text = "120";
                }
                else
                    Record.homeTime2 = (int)Convert.ToInt16(this.rw_howe_time2.Text.Trim());
                if (Record.homeTime1 < 30)
                    Record.homeTime1 = 30;
                if (Record.homeTime1 > 120)
                    Record.homeTime1 = 120;
                if (Record.homeTime2 > 180)
                    Record.homeTime2 = 180;
                if (Record.homeTime2 < Record.homeTime1)
                    Record.homeTime2 = Record.homeTime1;
            }
            else
                Record.homeTime1 = Record.homeTime2 = 0;
            Record.price = (double)(Record.jdTime2 + Record.dnTime2 * Record.downNum2 + Record.pageNum * 30);
            if (Record.homeTime2 > 0)
                Record.price += (double)Record.homeTime2;
            Record.price = Record.price / 100.0;
            Record.price += 8.0;
            double num1 = Record.price;
            int num2 = 0;
            double num3 = 0.0;
            num3 = (Record.price + (double)num2) * (double)Record.sl;
            double price = sys.LoginUser.hyDj != 0 ? Record.price * (double)Record.sl * this.getMyHydj(2) / 100.0 : (Record.price + (double)num2) * (double)Record.sl;
            Record.allPrice = !this.rw_rao_ms1.Checked ? (sys.LoginUser.hyDj != 0 ? Record.price + (double)num2 : Record.price + (double)num2) : (Record.price + (double)num2) * (double)Record.sl;
            Record.jsPrice = !this.rw_rao_ms1.Checked ? (sys.LoginUser.hyDj != 0 ? (Record.price + (double)num2) * this.getMyHydj(2) / 100.0 : (Record.price + (double)num2) * (double)Record.sl) : (sys.LoginUser.hyDj != 0 ? (Record.price + (double)num2) * (double)Record.sl * this.getMyHydj(2) / 100.0 : (Record.price + (double)num2) * (double)Record.sl);
            this.rw_lab_price1.Text = (Record.price * (double)Record.sl).ToString("f1").Replace(".0", "");
            this.rw_lab_price2.Text = price.ToString("f1").Replace(".0", "");
            this.rw_lab_price4.Text = (Record.price * (double)Record.sl * 0.6).ToString("f1").Replace(".0", "");
            this.rw_lab_price3.Text = (Record.price * (double)Record.sl * 0.95).ToString("f1").Replace(".0", "");
            if (flag == 0)
                return;
            if (this.txt_spid.Text.Trim() == "")
            {
                int num4 = (int)MessageBox.Show("请输入商品ID，商品ID只能是商品链接上“id=”后面的数字");
                this.txt_spid.Focus();
                this.txt_spid.BackColor = Color.PeachPuff;
            }
            else
            {
                this.txt_spid.Focus();
                this.txt_spid.BackColor = Color.White;
                if (this.txt_spid.Text.Trim().Length <= 13)
                {
                    this.DialogResult = DialogResult.OK;
                    Record.spid = this.txt_spid.Text.Trim();
                    if (this.rw_com_jd.Text == "直通车" && this.rw_txt_title.Text.Trim() == "")
                    {
                        int num4 = (int)MessageBox.Show("请复制直通车创意标题到标题框内。若复制的是宝贝标题时，踩出来的是综合搜索，不是直通车");
                        this.rw_txt_title.Focus();
                        this.rw_txt_title.BackColor = Color.PeachPuff;
                    }
                    else
                    {
                        this.rw_txt_title.Focus();
                        this.rw_txt_title.BackColor = Color.White;
                        if (this.rw_com_jd.Text == "按京东" && this.rw_txt_title.Text.Trim() == "")
                        {
                            int num4 = (int)MessageBox.Show("请复制商品标题(45字以内)到标题框内，必须一字不差");
                            this.rw_txt_title.Focus();
                            this.rw_txt_title.BackColor = Color.PeachPuff;
                        }
                        else
                        {
                            this.rw_txt_title.Focus();
                            this.rw_txt_title.BackColor = Color.White;
                            if (this.rw_com_jd.Text == "直通车")
                            {
                                Record.title = this.rw_txt_title.Text.Trim();
                                Record.lm1 = "";
                                Record.lm2 = "";
                            }
                            else if (this.rw_com_jd.Text == "按京东")
                            {
                                if (this.rw_txt_title.Text.Trim().Length <= 36)
                                {
                                    Record.title = this.rw_txt_title.Text.Trim();
                                    Record.lm1 = "";
                                    Record.lm2 = "";
                                }
                                else
                                {
                                    Record.title = this.rw_txt_title.Text.Trim().Substring(0, 36);
                                    Record.lm1 = "";
                                    Record.lm2 = "";
                                }
                            }
                            else
                            {
                                Record.lm1 = "";
                                Record.lm2 = "";
                                Record.title = "";
                            }
                            string text = sys.LoginUser.userName + ",您好！发布任务后请保持挂机，否则您的任务将暂停执行，若软件重启，请点击刷新任务\r\n1.本次任务共需 " + this.rw_lab_price2.Text + " 个流量币,提高VIP等级后更实惠\r\n2.VIP9只需要 " + (Record.price * (double)Record.sl * 0.5).ToString("f1").Replace(".0", "") + " 个流量币\r\n3.挂爱流量，赚流量币，每完成6个任务算1个贡献值或者直接购买高级别VIP\r\n4.确定现在发布任务吗?";
                            if (sys.LoginUser.hyDj == 0)
                                text = sys.LoginUser.userName + ",您好！发布任务后请保持挂机，否则您的任务将暂停执行，若软件重启，请点击刷新任务\r\n1.您不是VIP会员,加入VIP后可享受更多的特权及优惠\r\n2.发布本次任务共需 " + this.rw_lab_price1.Text + " 个流量币\r\n3.购买VIP8后只需 " + (Record.price * (double)Record.sl * 0.6).ToString("f1").Replace(".0", "") + " 个流量币\r\n4.确定现在发布任务吗?否则，请点击顶部“升级VIP”";
                            if (this.rw_rao_ms2.Checked)
                            {
                                text = sys.LoginUser.userName + ",您好！发布任务后请保持挂机，否则您的任务将暂停执行，若软件重启，请点击刷新任务\r\n1.本次任务共需 " + this.rw_lab_price2.Text + " 个流量币,提高VIP等级后更实惠\r\n2.VIP9只需要 " + (Record.price * (double)Record.sl * 0.5).ToString("f1").Replace(".0", "") + " 个流量币\r\n3.挂爱流量，赚流量币，每完成6个任务算1个贡献值或者直接购买高级别VIP\r\n4.确定现在发布任务吗?";
                                if (sys.LoginUser.hyDj == 0)
                                    text = sys.LoginUser.userName + ",您好！发布任务后请保持挂机，否则您的任务将暂停执行，若软件重启，请点击刷新任务\r\n1.您不是VIP会员,加入VIP后可享受更多的特权及优惠\r\n2.发布本次任务共需 " + this.rw_lab_price1.Text + " 个流量币\r\n3.购买VIP8后只需 " + (Record.price * (double)Record.sl * 0.6).ToString("f1").Replace(".0", "") + " 个流量币\r\n4.确定现在发布任务吗?否则请点击顶部“升级VIP”";
                            }
                            if (MessageBox.Show(text, "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                return;
                            if (sys.LoginUser.hyDj == 0)
                                Record.jsPrice = Record.allPrice;

                            Record.sendTime = this.rw_send_time.BeginDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                            if (Convert.ToDateTime(Record.sendTime) < DateTime.Now)
                                Record.sendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            Record.startTime = "";
                            Record.Stu = "等待中";
                            Record.jd = 0;
                            Record.optStu = 0;
                            Record.noFind = 0;
                            UsersTBSturct loginUser;
                            if (this.rw_rao_ms1.Checked)
                            {
                                double syPrice = 0.0;
                                if (!new usersClass().changePrice(sys.LoginUser.ID, Record.allPrice, ref syPrice))
                                {
                                    int num4 = (int)MessageBox.Show("对不起，您帐户流量币不够支付本次任务所需流量币!");
                                    return;
                                }
                                loginUser = sys.LoginUser;
                                loginUser.Price = syPrice;
                                sys.LoginUser = loginUser;
                                new TasksClass().InsertRecord(Record);
                                this.SearchTask();
                            }
                            if (this.rw_rao_ms2.Checked)
                            {
                                double syPrice = 0.0;
                                if (!new usersClass().changePrice(sys.LoginUser.ID, price, ref syPrice))
                                {
                                    int num4 = (int)MessageBox.Show("对不起，您帐户流量币不够支付本次任务所需流量币!");
                                }
                                else
                                {
                                    loginUser = sys.LoginUser;
                                    loginUser.Price = syPrice;
                                    sys.LoginUser = loginUser;
                                    if (this.rw_txt_space1.Text.Trim() == "" || this.rw_txt_space1.Text.Trim() == "0")
                                        this.rw_txt_space1.Text = "5";
                                    if (this.rw_txt_space2.Text.Trim() == "" || this.rw_txt_space2.Text.Trim() == "0")
                                        this.rw_txt_space2.Text = "10";
                                    int num5 = (int)Convert.ToInt16(this.rw_txt_space1.Text.Trim());
                                    int num6 = (int)Convert.ToInt16(this.rw_txt_space2.Text.Trim());
                                    if (num5 <= 0)
                                        num5 = 5;
                                    if (num6 <= 0)
                                        num6 = 10;
                                    if (num6 < num5)
                                        num6 = num5;
                                    int num7 = (int)Convert.ToInt16((this.rw_txt_snedNum1.Text.Trim()));
                                    DateTime dateTime = this.rw_send_time.BeginDateTime();
                                    for (int index = 0; index < num7; ++index)
                                    {
                                        int num8;
                                        if (num5 == num6)
                                        {
                                            num8 = num5;
                                        }
                                        else
                                        {
                                            Application.DoEvents();
                                            Thread.Sleep(500);
                                            num8 = new Random().Next(num5 * 60, num6 * 60);
                                        }
                                        dateTime = dateTime.AddSeconds((double)num8);
                                        Record.sendTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                        Record.sl = 1;
                                        new TasksClass().InsertRecord(Record);
                                        Application.DoEvents();
                                        Thread.Sleep(200);
                                    }
                                    this.SearchTask();
                                }
                            }
                        }
                    }
                }
                else
                {
                    int num4 = (int)MessageBox.Show("商品ID只能是商品链接上“id=”后面的数字，不是旺旺，也不是链接");
                    this.txt_spid.Focus();
                }
            }
        }

        public void ShowMessage(string str)
        {
            try
            {
                if (this.home_txtMsg.Text.Length > 3000)
                    this.home_txtMsg.Clear();
                this.home_txtMsg.AppendText(str + "\r\n");
                this.home_txtMsg.ScrollToCaret();
                Application.DoEvents();
                Thread.Sleep(200);
            }
            catch
            {
            }
        }

        void initView()
        {

            comboBox1.SelectedItem = 0;
            label26.Text = sys.LoginUser.QQ;
            lab_IP.Text = sys.getIP();
            label27.Text = sys.LoginUser.phone;

            label22.Text = sys.LoginUser.userName;
            label23.Text = "Vip" + sys.LoginUser.hyDj;
            label24.Text = sys.LoginUser.QT_Js;
            label25.Text = sys.LoginUser.hyDj==0?sys.LoginUser.endDate:"无限制";
            label28.Text = sys.LoginUser.WW;
            label29.Text = sys.LoginUser.regDate;
            comboBox1.SelectedIndex = 0;
            rw_search_stu.SelectedIndex = 0;
            rw_com_jd.SelectedIndex = 0;
            Urlflag = false;
            this.isOpenMsg = false;
        }
        void refreashUserInfo(string userName)
        {
            usersClass u = new usersClass();

            _price = u.getUserMoney(userName);
            lab_me_price.Text = _price;
           
          
        }
        Thread ThreadSetState;
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            //ConnStr.connStr = "data source=sjk.taoliu.com.cn;Database=sq_taoliu2;uid=sq_taoliu2;pwd=taoliu123";



            // UsersTBSturct  user=  new UsersTBSturct();
            //user.ID = 9600;
            //  sys.LoginUser = user;

            AppConfig.SetValue("Ver", "8.4");
            try
            {
                frmMain frmMain = this;
                string str = frmMain.Text + "V" + AppConfig.getValue("Ver").Trim();
                frmMain.Text = str;
            }
            catch
            {
            }

            string encryptedString = AppConfig.getValue("s4").Trim();
            if (encryptedString != "")
            {
                try
                {
                    ConnStr.connStr = Encrypt.md5Decrypt(encryptedString, "tbll20131224");
                }
                catch
                {
                }
            }
            Process[] processesByName = Process.GetProcessesByName(Application.ProductName);



            if (processesByName.Length > 1)
            {
                int num = (int)MessageBox.Show("已启动过了,不能重复启动！\r\n可以先关闭己启动的软件或在任务管理器中找到相应进程结束,然后再次启动.");
                this.Close();
            }




            init();
            this.MainThread = new Thread(new ThreadStart(updateAllData));
            this.MainThread.IsBackground = true;
            this.MainThread.Start();

            this.MainThread3 = new Thread(new ThreadStart(move));
            this.MainThread3.IsBackground = true;
            this.MainThread3.Start();

            ThreadSetState = new Thread(new ThreadStart(setState));

            ThreadSetState.Start();

          

            this.getht();
            this.getMsg();

            strLog = sys.LoginUser.userName + "登录成功";
            this.BeginInvoke(showdelegate, (object)this.strLog);

            radioButton1.PerformClick();
            updateLable();

            ////刷新提现记录
            RefeashMyTixianApplyFun();

            ////刷新我推荐的人
            FillTixianGridFun();
            showTixianleiji();//累计提现金额
            this.MainThread2 = new Thread(new ThreadStart(check));
            this.MainThread2.IsBackground = true;

            this.MainThread2.Start();
        

        }

        private static void setState()
        {
            TasksClass tasksClass = new TasksClass();
            string strsql1 = "update tasks8 set stu='等待中' where stu='暂停' and userid=" + (object)sys.LoginUser.ID;
            tasksClass.exec(strsql1);
            usersClass usersClass = new usersClass();
            string strsql2 = "update tasks8 set Stu='等待中' where  Stu='正在进行' and startTime<'" + tasksClass.getSysTime().AddMinutes(-30.0).ToString("yyyy-MM-dd HH:mm:ss") + "' and jd<sl";
            usersClass.exec(strsql2);
            string strsql3 = "update tasks8 set Stu='操作完成',jd=sl where  jd>=sl or nofind>=sl ";
            usersClass.exec(strsql3);
        }

        private void FillTixianGridFun()
        {
            delegateFillTixianGrid = FillTixianGrid;
            ThreadFillTixianGrid = new Thread(refreshTixian);
            ThreadFillTixianGrid.Start();
        }

        private void getMsg()
        {
            try
            {
                messagesClass messagesClass = new messagesClass();
                DataTable dataTable1 = messagesClass.search("公告");
                this.txtMsg.Clear();
                if (dataTable1.Rows.Count > 0)
                {
                    for (int index1 = 0; index1 < dataTable1.Rows.Count; ++index1)
                    {
                        int index2 = index1 % 2;
                        if (index1 > 0)
                            this.txtMsg.AppendText("\r\n");
                        this.txtMsg.SelectionColor = this.c[index2];
                        this.txtMsg.AppendText("    " + dataTable1.Rows[index1]["content"].ToString().Trim());
                        int strLen = sys.getStrLen("    " + dataTable1.Rows[index1]["content"].ToString().Trim());
                        this.msgRow += strLen % 36 == 0 ? strLen / 36 : strLen / 36 + 1;
                    }
                    this.txtMsg.Height = 21 * this.msgRow;
                    this.txtMsg.Top = 30;
                }
                DataTable dataTable2 = messagesClass.search("顶部滚动");
                if (dataTable2.Rows.Count <= 0)
                    return;
                this.lab_top_msg.Text = dataTable2.Rows[0]["content"].ToString().Trim();

            }
            catch
            {
            }
        }
        private void move()
        {
            while (true)
            {
                try
                {
                    // ISSUE: method pointer
                    this.BeginInvoke(movedelegate);
                    Thread.Sleep(100);
                }
                catch
                {
                }
            }
        }

        private void click_Scro(WebBrowser web)
        {
            try
            {
                ++this.__temJsq;
                if (this.__temJsq > 1000)
                    this.__temJsq = 0;
                DateTime dateTime = Convert.ToDateTime(this._curTask.startTime);
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now.Subtract(dateTime);
                if ((this._curTask.Stu == "浏览主页" || this._curTask.Stu == "浏览宝贝" || this._curTask.Stu == "浏览进店页") && this.__temJsq % 4 == 0)
                {
                    string format = "{0} 第 {1} / {2} 宝贝已踩 {3} / {4} 秒.";
                    object[] objArray1 = new object[5];
                    object[] objArray2 = objArray1;
                    int index = 0;
                    now = DateTime.Now;
                    string str = now.ToString();
                    objArray2[index] = str;
                    objArray1[1] = this._curTask.jd;
                    objArray1[2] = this._curTask.sl;
                    if ((int)timeSpan.TotalSeconds > this._curTask.jdTime1)
                    {

                        this._curTask.startTime = now.ToString();
                        dateTime = Convert.ToDateTime(this._curTask.startTime);
                        timeSpan = now.Subtract(dateTime);
                    }
                    objArray1[3] = (int)timeSpan.TotalSeconds+1;
                    objArray1[4] =this._curTask.jdTime1;
                   
                    object[] objArray3 = objArray1;
                    this.strLog = string.Format(format, objArray3);
                    // ISSUE: method pointer
                    this.BeginInvoke(showdelegate, (object)this.strLog);
                }
                try
                {
                    if (this._curTask.Stu == "搜索宝贝")
                    {
                        int num1 = web.Document.Window.Size.Height;
                        if (num1 < 3000)
                            num1 = 3000;
                        int num2 = num1 / 30;
                        web.Document.Window.ScrollTo(0, ((int)timeSpan.TotalSeconds+1 )* num2);
                    }
                    else
                    {
                        int num = web.Document.Window.Size.Height / this._curTask.jdTime1;
                        web.Document.Window.ScrollTo(0, (int)timeSpan.TotalSeconds * num);
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        public void functionSwitch()
        {
            sysConfigClass s = new sysConfigClass();
            DataTable dataTable = s.getFunction();

            string[] funNames = new string[dataTable.Rows.Count];
           for(int i=0;i<dataTable.Rows.Count;i++)
           {
               funNames[i]=dataTable.Rows[i]["function"].ToString().Trim();
               if (funNames[i] == "返现功能" )
               {
                   string isOpen = dataTable.Rows[i]["isOpen"].ToString().Trim();
                   if (isOpen != "True")
                   {
                       this.Invoke(delegatesetVisble, this.groupBox17, false);
                       this.Invoke(delegatesetVisble, this.groupBox18, false);
                       this.Invoke(delegatesetVisble, this.groupBox20, false);
                       this.Invoke(delegatesetVisble, this.groupBox21, false);



                   }
                   else
                   {

                       this.Invoke(delegatesetVisble, this.groupBox17, true);
                       this.Invoke(delegatesetVisble, this.groupBox18, true);
                       this.Invoke(delegatesetVisble, this.groupBox20, true);
                       this.Invoke(delegatesetVisble, this.groupBox21, true);

                   }
               }
           }
            
        }
        public delegate void DelegatesetVisble(Control o, bool v);
        DelegatesetVisble delegatesetVisble;
        public void setVisble(Control o, bool v)
        {
            o.Visible = v;
        }
        private void click_jd(WebBrowser web)
        {
            try
            {
                this.lastCheckClick = DateTime.Now.AddSeconds(60.0);
                HtmlDocument document = web.Document;
                Encoding encoding = Encoding.GetEncoding("gb2312");
                string documentText = this.webBrowser1.DocumentText;
                if (documentText != null && documentText.Trim() != "")
                {
                    byte[] numArray = new byte[web.DocumentStream.Length];
                    web.DocumentStream.Read(numArray, 0, (int)web.DocumentStream.Length);
                    char[] chars = new char[encoding.GetCharCount(numArray, 0, numArray.Length)];
                    encoding.GetChars(numArray, 0, numArray.Length, chars, 0);
                    string str1 = new string(chars);
                    HtmlElementCollection elementsByTagName1;
                    string outerHtml1;
                    string innerText1;
                    if (this._curTask.comeType == "直通车")
                    {
                        elementsByTagName1 = web.Document.GetElementsByTagName("a");
                        for (int index = 0; index < document.Links.Count; ++index)
                        {
                            outerHtml1 = document.Links[index].OuterHtml;
                            string innerText2 = document.Links[index].InnerText;
                            if (innerText2 != null && innerText2.IndexOf(this._curTask.title.Trim()) != -1)
                            {
                                this.isLoad = false;
                                document.Links[index].SetAttribute("target", "_self");
                                document.Links[index].InvokeMember("Click");
                                this._curTask.Stu = "浏览进店页";
                                string format = "{0} 找到“" + this._curTask.keyword + "”宝贝,执行浏览宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.jdTime1 == this._curTask.jdTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                    return;
                                }
                                this._curTask.jdTime1 = new Random().Next(this._curTask.jdTime1, this._curTask.jdTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                    }
                    else if (this._curTask.comeType == "按类目")
                    {
                        elementsByTagName1 = web.Document.GetElementsByTagName("a");
                        for (int index = 0; index < document.Links.Count; ++index)
                        {
                            string str2 = this._curTask.spid;
                            string outerHtml2 = document.Links[index].OuterHtml;
                            innerText1 = document.Links[index].InnerText;
                            if (outerHtml2 != null && outerHtml2.IndexOf(str2) > 0)
                            {
                                this.isLoad = false;
                                document.Links[index].Focus();
                                Thread.Sleep(1000);
                                document.Links[index].SetAttribute("target", "_self");
                                document.Links[index].InvokeMember("Click");
                                this._curTask.Stu = "浏览进店页";
                                this.strLog = string.Format("{0} 找到“" + this._curTask.keyword + "”宝贝,执行浏览宝贝.", (object)DateTime.Now.ToString());
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = 1;
                                this._curTask.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                if (this._curTask.jdTime1 == this._curTask.jdTime2)
                                {
                                    this.lastCheckClick = DateTime.Now.AddSeconds((double)this._curTask.jdTime1);
                                    return;
                                }
                                this._curTask.jdTime1 = new Random().Next(this._curTask.jdTime1, this._curTask.jdTime2);
                                this.lastCheckClick = DateTime.Now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                    }
                    else if (this._curTask.comeType == "按京东")
                    {
                        elementsByTagName1 = web.Document.GetElementsByTagName("a");
                        for (int index = 0; index < document.Links.Count; ++index)
                        {
                            outerHtml1 = document.Links[index].OuterHtml;
                            string innerText2 = document.Links[index].InnerText;
                            if (innerText2 != null && innerText2.IndexOf(this._curTask.title.Trim()) != -1)
                            {
                                this.isLoad = false;
                                document.Links[index].SetAttribute("target", "_self");
                                document.Links[index].InvokeMember("Click");
                                this._curTask.Stu = "浏览进店页";
                                string format = "{0} 找到“" + this._curTask.keyword + "”宝贝,执行浏览宝贝.";
                                DateTime now = DateTime.Now;
                                string str2 = now.ToString();
                                this.strLog = string.Format(format, (object)str2);
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = 1;
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str3;
                                if (this._curTask.jdTime1 == this._curTask.jdTime2)
                                {
                                    now = DateTime.Now;
                                    this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                    return;
                                }
                                this._curTask.jdTime1 = new Random().Next(this._curTask.jdTime1, this._curTask.jdTime2);
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                    }
                    else
                    {
                        elementsByTagName1 = web.Document.GetElementsByTagName("a");
                        for (int index = 0; index < document.Links.Count; ++index)
                        {
                            string str2 = this._curTask.spid;
                            string outerHtml2 = document.Links[index].OuterHtml;
                            innerText1 = document.Links[index].InnerText;
                            if (outerHtml2 != null && outerHtml2.IndexOf(str2) > 0)
                            {
                                this.isLoad = false;
                                document.Links[index].Focus();
                                Thread.Sleep(1000);
                                document.Links[index].SetAttribute("target", "_self");
                                document.Links[index].InvokeMember("Click");
                                this._curTask.Stu = "浏览进店页";
                                this.strLog = string.Format("{0} 找到“" + this._curTask.keyword + "”宝贝,执行浏览宝贝.", (object)DateTime.Now.ToString());
                                // ISSUE: method pointer
                                this.BeginInvoke(showdelegate, (object)this.strLog);
                                this._curTask.jd = 1;
                                this._curTask.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                if (this._curTask.jdTime1 == this._curTask.jdTime2)
                                {
                                    this.lastCheckClick = DateTime.Now.AddSeconds((double)this._curTask.jdTime1);
                                    return;
                                }
                                this._curTask.jdTime1 = new Random().Next(this._curTask.jdTime1, this._curTask.jdTime2);
                                this.lastCheckClick = DateTime.Now.AddSeconds((double)this._curTask.jdTime1);
                                return;
                            }
                        }
                    }
                    this._curTask.noFind = this._curTask.noFind + 1;
                    if (this._curTask.noFind < this._curTask.pageNum)
                    {
                        HtmlElementCollection elementsByTagName2;
                        try
                        {
                            elementsByTagName2 = this.webBrowser1.Document.GetElementById("list-page").Document.GetElementsByTagName("a");
                        }
                        catch
                        {
                            elementsByTagName2 = this.webBrowser1.Document.GetElementsByTagName("a");
                        }
                        for (int index = 0; index < elementsByTagName2.Count; ++index)
                        {
                            outerHtml1 = elementsByTagName2[index].OuterHtml;
                            string innerText2 = elementsByTagName2[index].InnerText;
                            if (innerText2 != null && innerText2.Trim() == (this._curTask.noFind + 1).ToString())
                            {
                                this.isLoad = false;
                                elementsByTagName2[index].InvokeMember("Click");
                                break;
                            }
                        }
                        this.strLog = string.Format("{0} 第" + (object)this._curTask.noFind + "页展现完成,准备找第" + (string)(object)(this._curTask.noFind + 1) + "页.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        this.lastCheckClick = DateTime.Now.AddSeconds(20.0);
                    }
                    else
                    {
                        this.strLog = string.Format("{0} 展现任务完成,正在提交任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        this.lastCheckClick.AddMinutes(2.0);
                        int num = 0;
                        while (num < 3)
                        {
                            if (this.postTask(1))
                            {
                                num = 10;
                            }
                            else
                            {
                                ++num;
                                Thread.Sleep(20000);
                            }
                        }
                        this._curTask.Stu = "";
                        this.lastCheckClick = DateTime.Now.AddSeconds(5.0);
                        this._curTask.optStu = 0;
                        this.strLog = string.Format("{0} 20秒后重新获取任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                    }
                }
            }
            catch
            {
                try
                {
                    this.postTask(0);
                    this._curTask.Stu = "";
                    this._curTask.optStu = 0;
                    this.lastCheckClick = DateTime.Now.AddSeconds(50.0);
                }
                catch
                {
                }
            }
        }
        private void click_lm(WebBrowser web)
        {
        }

        private void downTask()
        {
            try
            {
                this._cur_home_url = "";
                this._clickedUrl = "";
                this._cur_click_bbname = "";
                if (this.lab_IP.Text.Trim().Split(' ')[0].Trim() == "")
                {
                    this.lastCheckClick = DateTime.Now.AddSeconds(10.0);
                }
                else
                {
                    Random random1 = new Random();
                    this.strLog = string.Format("{0} 正在请求任务.", (object)DateTime.Now.ToString());
                    // ISSUE: method pointer
                    this.BeginInvoke(showdelegate, (object)this.strLog);
                    string[] strArray1 = new string[5];
                    string[] strArray2 = strArray1;
                    int index1 = 0;
                    int num1 = sys.LoginUser.ID;
                    string str1 = num1.ToString();
                    strArray2[index1] = str1;
                    strArray1[1] = "_";
                    strArray1[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    strArray1[3] = "_";
                    string[] strArray3 = strArray1;
                    int index2 = 4;
                    num1 = random1.Next(0, 1000);
                    string str2 = num1.ToString();
                    strArray3[index2] = str2;
                    DataTable dataTable = new TasksClass().downTask(this.lab_IP.Text.Trim().Split(' ')[0].Trim(), string.Concat(strArray1), sys.LoginUser.ID);
                    // TasksClass c = new TasksClass();
                    //string downStr1 = this.lab_IP.Text.Trim().Split(' ')[0].Trim();
                    //    string downStr2= string.Concat(strArray1);
                    //    int downStr3 = 5630;
                    // DataTable dataTable = c.downTask(downStr1, downStr2, downStr3);
                    if (dataTable == null)
                    {
                        this._curTask.Stu = "";
                        this.strLog = string.Format("{0} 没有找到适合的任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        this.lastCheckClick = DateTime.Now.AddSeconds(20.0);
                        this._curTask.optStu = 0;
                        this.strLog = string.Format("{0} 20秒后重新获取任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                    }
                    else if (dataTable.Rows.Count == 0)
                    {
                        this._curTask.Stu = "";
                        this.strLog = string.Format("{0} 没有找到适合的任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        this.lastCheckClick = DateTime.Now.AddSeconds(20.0);
                        this._curTask.optStu = 0;
                        this.strLog = string.Format("{0} 20秒后重新获取任务.", (object)DateTime.Now.ToString());
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                    }
                    else if (dataTable.Rows.Count >= 0)
                    {
                        TaskTBSturct taskTbSturct = new TaskTBSturct();
                        taskTbSturct.ID = Convert.ToInt32(dataTable.Rows[0]["ID"].ToString().Trim());
                        taskTbSturct.userId = Convert.ToInt32(dataTable.Rows[0]["userId"].ToString().Trim());
                        taskTbSturct.keyword = dataTable.Rows[0]["keyword"].ToString().Trim();
                        taskTbSturct.xinpin = dataTable.Rows[0]["xinpin"].ToString().Trim();
                        taskTbSturct.baoyou = dataTable.Rows[0]["baoyou"].ToString().Trim();
                        taskTbSturct.tianmao = dataTable.Rows[0]["tianmao"].ToString().Trim();
                        taskTbSturct.xiaoshi24 = dataTable.Rows[0]["xiaoshi24"].ToString().Trim();
                        taskTbSturct.tian7 = dataTable.Rows[0]["tian7"].ToString().Trim();
                        taskTbSturct.zhekou = dataTable.Rows[0]["zhekou"].ToString().Trim();
                        taskTbSturct.zsyfx = dataTable.Rows[0]["zsyfx"].ToString().Trim();
                        taskTbSturct.hdfk = dataTable.Rows[0]["hdfk"].ToString().Trim();
                        taskTbSturct.wwzx = dataTable.Rows[0]["wwzx"].ToString().Trim();
                        taskTbSturct.xykzf = dataTable.Rows[0]["xykzf"].ToString().Trim();
                        taskTbSturct.hwsp = dataTable.Rows[0]["hwsp"].ToString().Trim();
                        taskTbSturct.zpbz = dataTable.Rows[0]["zpbz"].ToString().Trim();
                        taskTbSturct.mfhx = dataTable.Rows[0]["mfhx"].ToString().Trim();
                        taskTbSturct.pzcn = dataTable.Rows[0]["pzcn"].ToString().Trim();
                        taskTbSturct.urltaobao = dataTable.Rows[0]["urltaobao"].ToString().Trim();
                        taskTbSturct.ww = dataTable.Rows[0]["ww"].ToString().Trim();
                        taskTbSturct.comeType = dataTable.Rows[0]["comeType"].ToString().Trim();
                        taskTbSturct.pageNum = (int)Convert.ToInt16(dataTable.Rows[0]["pageNum"].ToString().Trim());
                        if (taskTbSturct.pageNum > sys.ConfigData.maxPage)
                            taskTbSturct.pageNum = sys.ConfigData.maxPage;
                        taskTbSturct.dq = dataTable.Rows[0]["dq"].ToString().Trim();
                        taskTbSturct.downNum1 = (int)Convert.ToInt16(dataTable.Rows[0]["downNum1"].ToString().Trim());
                        taskTbSturct.downNum2 = (int)Convert.ToInt16(dataTable.Rows[0]["downNum2"].ToString().Trim());
                        taskTbSturct.ipSpace = (int)Convert.ToInt16(dataTable.Rows[0]["ipSpace"].ToString().Trim());
                        taskTbSturct.jdTime1 = (int)Convert.ToInt16(dataTable.Rows[0]["jdTime1"].ToString().Trim());
                        taskTbSturct.jdTime2 = (int)Convert.ToInt16(dataTable.Rows[0]["jdTime2"].ToString().Trim());
                        taskTbSturct.dnTime1 = (int)Convert.ToInt16(dataTable.Rows[0]["dnTime1"].ToString().Trim());
                        taskTbSturct.dnTime2 = (int)Convert.ToInt16(dataTable.Rows[0]["dnTime2"].ToString().Trim());
                        taskTbSturct.spid = dataTable.Rows[0]["spid"].ToString().Trim();
                        try
                        {
                            taskTbSturct.price1 = (int)Convert.ToInt16(dataTable.Rows[0]["price1"].ToString().Trim());
                            taskTbSturct.price2 = (int)Convert.ToInt16(dataTable.Rows[0]["price2"].ToString().Trim());
                        }
                        catch
                        {
                            taskTbSturct.price1 = taskTbSturct.price2 = -1;
                        }
                        taskTbSturct.price = Convert.ToDouble(dataTable.Rows[0]["price"].ToString().Trim());
                        taskTbSturct.homeTime1 = (int)Convert.ToInt16(dataTable.Rows[0]["homeTime1"].ToString().Trim());
                        taskTbSturct.homeTime2 = (int)Convert.ToInt16(dataTable.Rows[0]["homeTime2"].ToString().Trim());
                        taskTbSturct.title = dataTable.Rows[0]["title"].ToString().Trim();
                        taskTbSturct.lm1 = dataTable.Rows[0]["lm1"].ToString().Trim();
                        taskTbSturct.lm2 = dataTable.Rows[0]["lm2"].ToString().Trim();
                        taskTbSturct.sl = 0;
                        taskTbSturct.optStu = 1;
                        taskTbSturct.jd = 0;
                        TaskLogClass taskLogClass = new TaskLogClass();
                        if (taskTbSturct.downNum2 > 0)
                        {
                            if (taskTbSturct.downNum2 != taskTbSturct.downNum1)
                            {
                                Random random2 = new Random();
                                Thread.Sleep(1000);
                                taskTbSturct.sl = random2.Next(taskTbSturct.downNum1, taskTbSturct.downNum2);
                            }
                            else
                                taskTbSturct.sl = taskTbSturct.downNum1;
                        }
                        taskTbSturct.sl = taskTbSturct.sl + 1;
                        if (taskTbSturct.homeTime1 > 0)
                            taskTbSturct.sl = taskTbSturct.sl + 1;
                        if (taskTbSturct.sl > 4)
                            taskTbSturct.sl = 4;
                        this._curTask = taskTbSturct;
                        this.strLog = string.Format("{0} 接到任务编号:{1},完成可获的流量币:{2},帐户余额:{3}.", (object)DateTime.Now.ToString(), (object)this._curTask.ID, (object)(this._curTask.price * this.getMyHydj(1) / 100.0), (object)sys.LoginUser.Price);
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        if (this.mchk_clear1.Checked || !this.chk_clear2.Checked)
                        {
                            this.strLog = string.Format("{0} 调用系统函数清理IE.", (object)DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this.CleanCookie(1);
                        }
                        if (this.mchk_clear2.Checked)
                        {
                            this.strLog = string.Format("{0} 调用CCleaner清理IE.", (object)DateTime.Now.ToString());
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this.CleanCookie(2);
                            Thread.Sleep(10000);
                        }

                        string format1 = "{0} 清理完成,开始检测宝贝";

                        DateTime now = DateTime.Now;
                        string str3 = now.ToString();
                        this.strLog = string.Format(format1, (object)str3);
                        // ISSUE: method pointer
                        this.BeginInvoke(showdelegate, (object)this.strLog);
                        string str4 = "http://s.taobao.com/search?tab=all&q=" + taskTbSturct.keyword;
                        this._curTask.Stu = "搜索宝贝";
                        now = DateTime.Now;
                        this.lastCheckClick = now.AddSeconds(20.0);
                        string str5 = str4 + "&style=grid";
                        if (taskTbSturct.price1 >= 0 && taskTbSturct.price2 >= 0)
                            str5 = str5 + (object)"&filter=reserve_price%5B" + (string)(object)taskTbSturct.price1 + "%2C" + (string)(object)taskTbSturct.price2 + "%5D";
                        else if (taskTbSturct.price1 >= 0)
                            str5 = string.Concat(new object[4]
              {
                (object) str5,
                (object) "&reserve_price%5B",
                (object) taskTbSturct.price1,
                (object) "%2C%5D"
              });
                        else if (taskTbSturct.price2 >= 0)
                            str5 = string.Concat(new object[4]
              {
                (object) str5,
                (object) "&filter=reserve_price%5B%2C",
                (object) taskTbSturct.price2,
                (object) "%5D"
              });
                        if (taskTbSturct.comeType.IndexOf("人气") > -1)
                            str5 += "&sort=renqi-desc";
                        else if (taskTbSturct.comeType.IndexOf("销量") > -1)
                            str5 += "&sort=sale-desc";
                        else if (taskTbSturct.comeType.IndexOf("信用") > -1)
                            str5 += "&sort=credit-desc";
                        else if (taskTbSturct.comeType.IndexOf("最新") > -1)
                            str5 += "&auction_tag%5B0%5D=1154";
                        else if (taskTbSturct.comeType.IndexOf("价格") > -1)
                            str5 += "&sort=price-asc";
                        else if (taskTbSturct.comeType.IndexOf("天猫") > -1)
                            str5 += "&tab=mall";
                        else if (taskTbSturct.comeType.IndexOf("京东") > -1)
                            str5 = "http://search.jd.com/Search?keyword=" + HttpUtility.UrlEncode(taskTbSturct.keyword, Encoding.GetEncoding("UTF-8")) + "&enc=utf-8";
                        else if (taskTbSturct.comeType.IndexOf("阿里") > -1)
                            str5 = "http://s.1688.com/selloffer/offer_search.htm?keywords=" + sys.ulEncode(taskTbSturct.keyword) + "&from=marketSearch&mergeSameDesign=false&n=y&filt=y";
                        if (taskTbSturct.urltaobao != null && taskTbSturct.urltaobao != "")
                            str5 = taskTbSturct.urltaobao;
                        if (taskTbSturct.dq != "")
                            str5 = str5 + "&loc=" + taskTbSturct.dq;
                        if (taskTbSturct.xinpin == "新品")
                            str5 += "&auction_tag%5B0%5D=1154";
                        if (taskTbSturct.baoyou == "包邮")
                            str5 += "&baoyou=1";
                        if (taskTbSturct.tianmao == "天猫")
                            str5 += "&seller_type=tmall";
                        if (taskTbSturct.xiaoshi24 == "24小时内发货")
                            str5 += "&consign_date=1";
                        if (taskTbSturct.tian7 == "7+天内退货")
                            str5 += "&auction_tag%5B0%5D=4806";
                        if (taskTbSturct.zhekou == "折扣促销")
                            str5 += "&discount=1";
                        if (taskTbSturct.zsyfx == "赠送退货运费险")
                            str5 += "&auction_tag%5B0%5D=385";
                        if (taskTbSturct.hdfk == "货到付款")
                            str5 += "&support_cod=1";
                        if (taskTbSturct.wwzx == "旺旺在线")
                            str5 += "&olu=yes";
                        if (taskTbSturct.xykzf == "信用卡支付")
                            str5 += "&support_xcard=1";
                        if (taskTbSturct.hwsp == "海外商品")
                            str5 += "&globalbuy=1";
                        if (taskTbSturct.zpbz == "正品保障")
                            str5 += "&user_type=1";
                        if (taskTbSturct.mfhx == "免费换新")
                            str5 += "&mfhx=1";
                        if (taskTbSturct.pzcn == "品质承诺")
                            str5 += "&auction_tag%5B0%5D=4742";
                        this._curTask.sendTime = str5;
                        this._curTask.noFind = 0;
                        if (this._curTask.spid.Trim() == "")
                        {
                            string format2 = "{0} 商品ID为空,正在提交任务.";
                            now = DateTime.Now;
                            string str6 = now.ToString();
                            this.strLog = string.Format(format2, (object)str6);
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                            this.lastCheckClick.AddMinutes(2.0);
                            int num2 = 0;
                            while (num2 < 3)
                            {
                                if (this.postTask(1))
                                {
                                    num2 = 10;
                                }
                                else
                                {
                                    ++num2;
                                    Thread.Sleep(20000);
                                }
                            }
                            this._curTask.Stu = "";
                            now = DateTime.Now;
                            this.lastCheckClick = now.AddSeconds(5.0);
                            this._curTask.optStu = 0;
                            string format3 = "{0} 20秒后重新获取任务.";
                            now = DateTime.Now;
                            string str7 = now.ToString();
                            this.strLog = string.Format(format3, (object)str7);
                            // ISSUE: method pointer
                            this.BeginInvoke(showdelegate, (object)this.strLog);
                        }
                        else
                        {
                            try
                            {
                                // ISSUE: method pointer
                                this.BeginInvoke(toUrldelegate, this.webBrowser1, str5);
                            }
                            catch (Exception)
                            { 
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void getht()
        {
            hydjClass hydjClass = new hydjClass();
            this.grid_Price.DataSource = (object)hydjClass.getPrice();
            this.hydjTB = hydjClass.getHydj_2();
            this.grid_hydj.DataSource = (object)this.hydjTB;
            this.grid_Price.Height = 110;
            this.grid_hydj.Top = this.grid_Price.Top + this.grid_Price.Height + 2;
            this.grid_hydj.Height = 250;
        }
        private double getMyHydj(int flag)
        {

            //for (int index = 0; index < this.hydjTB.Rows.Count; ++index)
            //{
            //    this.hydjTB.Rows[index]["id"].ToString().Trim();
            //    if (this.hydjTB.Rows[index]["id"].ToString().Trim() == (sys.LoginUser.hyDj + 1).ToString())
            //    {
            //        if (flag == 1)
            //            return Convert.ToDouble(this.hydjTB.Rows[index]["jp1"].ToString().Replace("%", "").Trim());
            //        return Convert.ToDouble(this.hydjTB.Rows[index]["jp2"].ToString().Replace("%", "").Trim());
            //    }
            //}
            switch (flag)
            {
                case 0: return 100;
                    
                case 1:
                    return 100;  
                case 2:
                    return 95;  
                case 8:
                    return 60;
                case 9:
                    return 50;
                
            }
            return 100.0;
        }
        private void openUrl(WebBrowser web, string url)
        {
            try
            {
                web.Navigate(url);
            }
            catch (Exception)
            {
 
            }
        }
        private static void RunCmd(string cmd)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
            }
            catch
            {
            }
        }
        public bool CleanCookie(int flag)
        {
            try
            {
                if (flag == 1)
                {
                    frmMain.ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 255", "", frmMain.ShowCommands.SW_HIDE);
                    frmMain.ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 2", "", frmMain.ShowCommands.SW_HIDE);
                    frmMain.ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 1", "", frmMain.ShowCommands.SW_HIDE);
                }
                else
                    frmMain.RunCmd("CCleaner.exe /auto");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.MainThread2 = new Thread(new ThreadStart(check));
            this.MainThread2.IsBackground = true;
            this.MainThread2.Start();
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    Application.DoEvents();
                else if (e.Url.ToString() != this.webBrowser1.Url.ToString())
                {
                    Application.DoEvents();
                }
                else
                {
                    string str1 = this.webBrowser1.Url.ToString();
                    if (str1.IndexOf("&catid=0") > 0 || str1.IndexOf("fktz.php") != -1)
                    {
                        if (this._cur_home_url.Trim() != "")
                        {
                            this.webBrowser1.Navigate(this._cur_home_url);
                            this.lastCheckClick = DateTime.Now.AddSeconds(30.0);
                            return;
                        }
                    }
                    else
                        this.postTask(0);
                    this._clickedUrl += this.webBrowser1.Url.ToString();
                    this.isLoad = true;
                    if (this._curTask.Stu == "搜索宝贝")
                    {
                        if (this._curTask.comeType == "按京东")
                        {
                            this.lastCheckClick = DateTime.Now.AddSeconds(17.0);
                            this._curTask.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else if (this._curTask.comeType == "阿里巴巴")
                        {
                            this.lastCheckClick = DateTime.Now.AddSeconds(35.0);
                            this._curTask.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            this.lastCheckClick = DateTime.Now.AddSeconds(15.0);
                            this._curTask.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                    else if (this._curTask.Stu == "按类目搜索宝贝")
                    {
                        this.lastCheckClick = DateTime.Now.AddSeconds(10.0);
                        // ISSUE: explicit reference operation
                        // ISSUE: variable of a reference type
                        TaskTBSturct local1 = this._curTask;
                        DateTime now = DateTime.Now;
                        string str2 = now.ToString("yyyy-MM-dd HH:mm:ss");
                        // ISSUE: explicit reference operation
                        (local1).startTime = str2;
                        string innerHtml = this.webBrowser1.Document.GetElementById("J_CatBd").InnerHtml;
                        HtmlElementCollection elementsByTagName = this.webBrowser1.Document.GetElementById("J_CatBd").Document.GetElementsByTagName("LI");
                        for (int index = 0; index < elementsByTagName.Count; ++index)
                        {
                            string outerHtml = elementsByTagName[index].OuterHtml;
                            if (outerHtml != null && outerHtml.IndexOf(this._curTask.lm1.Trim()) > 0)
                            {
                                elementsByTagName[index].InvokeMember("Click");
                                this._curTask.Stu = "搜索宝贝";
                                now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds(50.0);
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local2 = this._curTask;
                                now = DateTime.Now;
                                string str3 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local2).startTime = str3;
                                break;
                            }
                        }
                    }
                    else if (this._curTask.Stu == "搜索类目宝贝")
                    {
                        HtmlElementCollection elementsByTagName1 = this.webBrowser1.Document.GetElementsByTagName("INPUT");
                        for (int index = 0; index < elementsByTagName1.Count; ++index)
                        {
                            string outerHtml = elementsByTagName1[index].OuterHtml;
                            if (outerHtml != null && outerHtml.IndexOf("search-keyword") > 0)
                            {
                                elementsByTagName1[index].SetAttribute("value", this._curTask.keyword);
                                break;
                            }
                        }
                        HtmlElementCollection elementsByTagName2 = this.webBrowser1.Document.GetElementsByTagName("A");
                        for (int index = 0; index < elementsByTagName2.Count; ++index)
                        {
                            string outerHtml = elementsByTagName2[index].OuterHtml;
                            if (outerHtml != null && outerHtml.IndexOf("搜全站") > 0)
                            {
                                elementsByTagName2[index - 1].InvokeMember("Click");
                                this._curTask.Stu = "搜索宝贝";
                                DateTime now = DateTime.Now;
                                this.lastCheckClick = now.AddSeconds(50.0);
                                // ISSUE: explicit reference operation
                                // ISSUE: variable of a reference type
                                TaskTBSturct local = this._curTask;
                                now = DateTime.Now;
                                string str2 = now.ToString("yyyy-MM-dd HH:mm:ss");
                                // ISSUE: explicit reference operation
                                (local).startTime = str2;
                                break;
                            }
                        }
                    }
                    else if (this._curTask.Stu == "浏览进店页" && this._cur_home_url.Trim() == "")
                    {
                        HtmlDocument document = this.webBrowser1.Document;
                        this.webBrowser1.Document.GetElementsByTagName("a");
                        for (int index = 0; index < document.Links.Count; ++index)
                        {
                            string outerHtml = document.Links[index].OuterHtml;
                            string innerText = document.Links[index].InnerText;
                            if (innerText != null && innerText.IndexOf("进入店铺") != -1)
                            {
                                string[] strArray = sys.rValue(outerHtml, "href=\"", "\"");
                                if (strArray.Length > 0)
                                {
                                    this._cur_home_url = strArray[0].Trim();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.SearchTask();
        }
        private void SearchTask()
        {
            TasksClass tasksClass1 = new TasksClass();
            int num = (int)Convert.ToInt16(this.comboBox1.Text.Replace("天内", ""));
            DataGridView dataGridView = this.grid_myTask;
            TasksClass tasksClass2 = tasksClass1;
            int userId = sys.LoginUser.ID;
            string stu = this.rw_search_stu.Text.Replace("查询所有", "");
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddDays((double)-num);
            string rq = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable myTask = tasksClass2.getMyTask(userId, stu, rq);
            dataGridView.DataSource = (object)myTask;
        }


        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ((this.rw_com_jd.Text == "按类目" || this.rw_com_jd.Text == "按京东" || this.rw_com_jd.Text == "阿里巴巴") && sys.LoginUser.hyDj <= 7)
            {
                int num1 = (int)MessageBox.Show("亲,类目流量、京东流量以及阿里巴巴只能由VIP8以上会员通过自定义搜索路径发布");
            }
            else if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num2 = (int)MessageBox.Show("关键字不能为空!");
            }
            else
                this.add(1);
        }

        private void rw_com_lm2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string[] strArray = this.rw_com_lm1.SelectedValue.ToString().Trim().Split('|');
            //this.rw_com_lm1.Items.Clear();
            //for (int index = 0; index < strArray.Length; ++index)
            //    this.rw_com_lm1.Items.Add((object)strArray[index].Trim());
            //this.rw_com_lm1.SelectedIndex = 0;
        }


        private void getMeMsg()
        {
            infosClass infosClass = new infosClass();
            DataTable noRead = infosClass.getNoRead(sys.LoginUser.ID);
            if (noRead != null && noRead.Rows.Count > 0)
            {
                this._meMesg = "";
                for (int index = 0; index < noRead.Rows.Count && index <= 9; ++index)
                {
                    if (this._meMesg.Trim() != "")
                        this._meMesg += "\r\n";
                    frmMain frmMain = this;
                    string str = frmMain._meMesg + noRead.Rows[index]["content"].ToString().Trim() + "   " + noRead.Rows[index]["rq"].ToString().Replace("02013", "2013");
                    frmMain._meMesg = str;
                }
                infosClass.updateStu(Convert.ToInt32(noRead.Rows[0][0].ToString().Trim()));
            }
            else
            {
                DataTable noRead2 = infosClass.getNoRead_2(sys.LoginUser.ID);
                if (noRead2 != null && noRead2.Rows.Count > 0)
                    this._meMesg = noRead2.Rows[0]["content"].ToString().Trim();
            }
        }

        private void updateAllData()
        {
            while (true)
            {
                if (!this._isClose)
                {
                    // this.Invoke(delegateRefreashgridview_chongzhijilu);



                    this.getOnlineNum();
                    this._ip = sys.getIP();
                    this.getMeMsg();
                    if (!this.isOpenMsg)
                    {
                        this.isOpenMsg = true;
                        try
                        {

                            DataTable dataTable = new messagesClass().search("弹出提示");
                            if (dataTable.Rows.Count > 0)
                            {
                                for (int index = 0; index < dataTable.Rows.Count; ++index)
                                {
                                    int num = (int)MessageBox.Show(dataTable.Rows[index]["content"].ToString().Trim());
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    Thread.Sleep(120000);
                }
                else
                    break;
            }
        }
        private void getOnlineNum()
        {
            try
            {
                usersClass usersClass = new usersClass();

                usersClass.SelectRecordByID(sys.LoginUser.ID);
                string stu = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (usersClass.updateLoginUserStu(stu, sys.LoginUser.ID))
                {
                    UsersTBSturct loginUser = sys.LoginUser;
                    loginUser.lastAceive = stu;
                    sys.LoginUser = loginUser;
                }
                this._onlieNum = sys.ConfigData.reg_vip_u + usersClass.getOnlienSum();

                if (this._onlieNum < 0)
                    ++this._connectServerFailNum;
                else
                    this._connectServerFailNum = 0;
                // ISSUE: method pointer
                object[] arr = { (object)_onlieNum.ToString(), (object)1 };
                // sys.LoginUser = usersClass.getUserInfo(sys.LoginUser.ID.ToString());
                //this.BeginInvoke(delegateShowOnlineStu, arr);
                this.BeginInvoke(delegateShowOnlineStu, _onlieNum.ToString(), 3);
                if (!sys.chk(ConnStr.connStr))
                    return;
                this._curTask.Stu = "";
                this._isClose = true;
                // ISSUE: method pointer
                this.BeginInvoke(delegateCloseMe);
            }
            catch
            {
            }
        }
        private void closeMe()
        {
            this.Close();
        }
        private void showOnlineStu(string sl, int flag)
        {
            try
            {
                usersClass u = new usersClass();


                sys.LoginUser = u.getUserInfo(sys.LoginUser.ID.ToString());
                if (flag == 1)
                    this.lab_onlie_num.Text = sl+2000;
                else if (flag == 2)
                {
                    this.lab_me_price.Text = sl;

                }
                else
                {
                    this.lab_me_price.Text = sys.LoginUser.Price.ToString("f2");
                    this.lab_onlie_num.Text = (int.Parse(this._onlieNum.ToString())+2000).ToString();
                    this.lab_IP.Text = this._ip;
                    this.lab_meMessage.Text = this._meMesg;
                    lab_onliNumber.Text = this.lab_onlie_num.Text;
                    this.lab_money.Text = this.lab_me_price.Text;

                }
            }
            catch
            {
            }


        }
        private void frmMain_Close()
        {
            if (this._isClose)
            {
                try
                {
                    this.MainThread.Abort();
                }
                catch
                {
                }
                try
                {
                    this.MainThread2.Abort();
                }
                catch
                {
                }
                try
                {
                    this.MainThread3.Abort();
                }
                catch
                {
                }
                if (this._curTask.Stu != "" && this.rw_chk_Addtp.Checked)
                    this.postTask(0);

            }
            else if (MessageBox.Show("确定要退出爱流量吗？退出后您的任务将暂停执行", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TasksClass tasksClass = new TasksClass();
                if (sys.LoginUser.hyDj <= 8)
                {
                    string strsql = "update tasks8 set stu='暂停' where stu='等待中' and userid=" + (object)sys.LoginUser.ID;
                    tasksClass.exec(strsql);
                }
                try
                {
                    this.MainThread.Abort();
                }
                catch
                {
                }
                if (this._curTask.Stu != "" && this.rw_chk_Addtp.Checked)
                    this.postTask(0);
                loginForm.Close();
            }
            else
            {
                new usersClass().updateLoginUserStu(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), sys.LoginUser.ID);

            }
          
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this._isClose)
            {
                try
                {
                    this.MainThread.Abort();
                }
                catch
                {
                }
                try
                {
                    this.MainThread2.Abort();
                }
                catch
                {
                }
                try
                {
                    this.MainThread3.Abort();
                }
                catch
                {
                }
                if (this._curTask.Stu != "" && this.rw_chk_Addtp.Checked)
                    this.postTask(0);
                loginForm.Close();
                e.Cancel = false;

            }
            else if (MessageBox.Show("确定要退出爱流量吗？退出后您的任务将暂停执行", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TasksClass tasksClass = new TasksClass();
                if (sys.LoginUser.hyDj <= 8)
                {
                    string strsql = "update tasks8 set stu='暂停' where stu='等待中' and userid=" + (object)sys.LoginUser.ID;
                    tasksClass.exec(strsql);
                }
                try
                {
                    this.MainThread.Abort();
                }
                catch
                {
                }
                if (this._curTask.Stu != "" && this.rw_chk_Addtp.Checked)
                    this.postTask(0);
                loginForm.Close();
                e.Cancel = false;
            }
            else
            {
                new usersClass().updateLoginUserStu(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), sys.LoginUser.ID);
                e.Cancel = true;

            }
        }

        private void move1()
        {
            //try
            //{
            //    if (this.txtMsg.Height + this.txtMsg.Top - 63 > 0)
            //        this.txtMsg.Top = this.txtMsg.Top - 1;
            //    else
            //        this.txtMsg.Top = 30;
            //    if (this.lab_top_msg.Left < -this.lab_top_msg.Width)
            //        this.lab_top_msg.Left = this.panel_top.Width;
            //    else
            //        this.lab_top_msg.Left = this.lab_top_msg.Left - 2;
            //}
            //catch
            //{
            //}
        }

        public string _ip { get; set; }

        public int _onlieNum { get; set; }

        public int _connectServerFailNum { get; set; }

        public string _meMesg { get; set; }

        private void rw_chk_Addtp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rw_chk_Addtp.Checked)
            {
                this._curTask.optStu = 0;
                this._curTask.Stu = "";
                this.lastCheckClick = DateTime.Now;
                this.strLog = string.Format("{0} 开启赚流量币.", (object)DateTime.Now.ToString());
                // ISSUE: method pointer
                this.BeginInvoke(showdelegate, this.strLog);
            }
            else
            {
                this.strLog = string.Format("{0} 停止赚流量币.", (object)DateTime.Now.ToString());
                // ISSUE: method pointer
                this.BeginInvoke(showdelegate, this.strLog);
                if (this._curTask.Stu != "")
                    this.postTask(0);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "按类目";
                taobaofrm taobaofrm = new taobaofrm();
                string str = HttpUtility.UrlEncode(this.rw_txt_key.Text, Encoding.GetEncoding("UTF-8"));
                taobaofrm.Url = "http://list.taobao.com/itemlist/default.htm?&q=" + str;
                taobaofrm.Url += "&same_info=1&isnew=2&tid=0&_input_charset=utf-8";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;

                this.WindowState = FormWindowState.Normal;

                this.notifyIcon1.Visible = true;
            }
        }
        private void show_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            }

        }
        private void close_MouseDown(object sender, MouseEventArgs e)
        {
            this.frmMain_Close();
        }
        private void min_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            idForm idForm = new idForm();
            if (idForm.ShowDialog() != DialogResult.OK)
                return;
            this.txt_spid.Text = idForm.Url;
        }



        private void init()
        {
           


                freashWW();
          
            for (int index = 3; index <= sys.ConfigData.maxPage; ++index)
                this.rw_com_page.Items.Add((object)index.ToString());
            this.rw_com_page.SelectedIndex = 5;
            this.rw_com_jd.SelectedIndex = 0;
            for (int i = 1; i <= 300; i++)
            {
                rw_txt_cjsl1.Items.Add(i);
                rw_txt_cjsl2.Items.Add(i);
                rw_jd_sj1.Items.Add(i);
                rw_jd_sj2.Items.Add(i);
                rw_dn_sj1.Items.Add(i);
                rw_dn_sj2.Items.Add(i);
                rw_howe_time1.Items.Add(i);
                rw_howe_time2.Items.Add(i);
                rw_txt_snedNum1.Items.Add(i);
                rw_txt_space1.Items.Add(i);
                rw_txt_space2.Items.Add(i);
            }

            rw_txt_snedNum1.SelectedIndex = 5;
            rw_txt_space1.SelectedIndex = 2;
            rw_txt_space2.SelectedIndex = 5;
            this.rw_txt_cjsl1.SelectedIndex = 1;
            this.rw_txt_cjsl2.SelectedIndex = 3;
            this.rw_jd_sj1.SelectedIndex = 120;
            this.rw_jd_sj2.SelectedIndex = 120;
            this.rw_dn_sj1.SelectedIndex = 90;
            this.rw_dn_sj2.SelectedIndex = 120;
            this.rw_howe_time1.SelectedIndex = 90;
            this.rw_howe_time2.SelectedIndex = 120;
            delegatesetVisble = setVisble;


            // this.rw_com_ip.Text = "24小时";
            //this.rw_search_day.SelectedIndex = this.rw_search_stu.SelectedIndex = 0;
            // this.rw_com_lm1.DataSource = (object)new lmClass().getAllLm();
            //this.rw_com_lm1.DisplayMember = "clsName";
            //this.rw_com_lm1.ValueMember = "content";
            //this.rw_com_lm1.SelectedIndex = 0;
            //string[] strArray1 = this.rw_com_lm1.SelectedValue.ToString().Trim().Split('|');
            // this.rw_com_lm2.Items.Clear();
            //for (int index = 0; index < strArray1.Length; ++index)
            //    this.rw_com_lm2.Items.Add((object)strArray1[index].Trim());
            // this.rw_com_lm2.SelectedIndex = 0;
            //this.wt_com_type.SelectedIndex = 0;
        }
        void freashWW()
        {
            this.rw_com_ww.Items.Clear();
            string[] strArray = sys.LoginUser.WW.Split('|');
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (strArray[index].Trim() != "")
                    this.rw_com_ww.Items.Add((object)strArray[index].Trim());
               

            }
            try
            {
                this.rw_com_ww.SelectedIndex = 0;
            }
            catch (Exception )
            {
                this.rw_com_ww.SelectedIndex = -1;
            }
            if ((sys.LoginUser.hyDj <= 8 && this.rw_com_ww.Items.Count >= 3) || this.rw_com_ww.Items.Count >= 20 || sys.LoginUser.hyDj == 0)
                this.but_add_ww.Enabled = false;
            else
              
                this.but_add_ww.Enabled = true;
            if (this.rw_com_ww.Items.Count == 0)
            {
                this.but_add_ww.Enabled = true;
            }
            if (rw_com_ww.Items.Count == 1)
            {
                this.but_add_del.Enabled = false;
            }
            else
            {
                this.but_add_del.Enabled = true;
 
            }

          

            label28.Text="";
            for (int i = 0; i < rw_com_ww.Items.Count; i++)
            {
                label28.Text +=  rw_com_ww.Items[i].ToString() + "|";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frm_ww frmWw = new frm_ww();
            int num = (int)frmWw.ShowDialog();
            if (frmWw.DialogResult != DialogResult.OK)
                return;
                ;
            
            
            freashWW();





        }

        private void rw_com_jd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rw_com_jd.Text == "直通车")
            {

                this.rw_panel_title.Visible = true;
                this.rw_panel_title.Enabled = true;
                this.rw_panel_lm.Visible = false;
            }
            else if (this.rw_com_jd.Text == "按京东")
            {

                this.rw_panel_title.Visible = true;
                this.rw_panel_title.Enabled = true;
                this.rw_panel_lm.Visible = false;
            }
            else
            {
                this.rw_panel_title.Enabled = false;
                this.rw_panel_lm.Enabled = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sys.myWordsId = -1;
            frm_myWords frmMyWords = new frm_myWords();
            int num = (int)frmMyWords.ShowDialog();
            if (frmMyWords.DialogResult != DialogResult.OK || sys.myWordsId == -1)
                return;
            DataRow dataRow = new MyWordsClass().SelectRecordByID(sys.myWordsId).Rows[0];
            this.rw_txt_key.Text = dataRow["keyword"].ToString().Trim();
            this.rw_com_ww.Text = dataRow["ww"].ToString().Trim();
            this.rw_txt_title.Text = dataRow["title"].ToString().Trim();
            this.rw_txt_price1.Text = dataRow["price1"].ToString().Trim().Replace("-1", "");
            this.rw_txt_price2.Text = dataRow["price2"].ToString().Trim().Replace("-1", "");
            this.rw_txt_dq.Text = dataRow["dq"].ToString().Trim();
            this.rw_com_jd.Text = dataRow["comeType"].ToString().Trim();
            this.rw_com_page.Text = dataRow["pageNum"].ToString().Trim();
            this.rw_howe_time1.Text = dataRow["homeTime1"].ToString().Trim();
            this.rw_howe_time2.Text = dataRow["homeTime2"].ToString().Trim();
            this.rw_txt_cjsl1.Text = dataRow["downNum1"].ToString().Trim();
            this.rw_txt_cjsl2.Text = dataRow["downNum2"].ToString().Trim();
            this.rw_jd_sj1.Text = dataRow["jdTime1"].ToString().Trim();
            this.rw_jd_sj2.Text = dataRow["jdTime2"].ToString().Trim();
            this.rw_dn_sj1.Text = dataRow["dnTime1"].ToString().Trim();
            this.rw_dn_sj2.Text = dataRow["dnTime2"].ToString().Trim();
            this.rw_com_lm1.Text = dataRow["lm1"].ToString().Trim();
            this.rw_com_lm2.Text = dataRow["lm2"].ToString().Trim();
            this.txt_spid.Text = dataRow["spid"].ToString().Trim();
            if (dataRow["spid"].ToString().Trim() == "展现")
            {
                this.rw_rao_zx1.Checked = true;
            }
            else
            {
                this.txt_spid.Visible = true;
                //this.label44.Visible = true;
                this.linkLabel4.Visible = true;
                this.rw_rao_zx1.Checked = false;
                this.txt_spid.Text = dataRow["spid"].ToString().Trim();
            }
            if (dataRow["urltaobao"].ToString().Trim() != null && dataRow["urltaobao"].ToString().Trim() != "")
            {
                //this.button7.Visible = false;
                //this.button8.Visible = true;
                //this.button3.Visible = true;
                //this.button4.Visible = true;
                //this.button5.Visible = true;
                //this.button6.Visible = true;
                //this.button9.Visible = true;
                //this.button10.Visible = true;
                this.Urlflag = true;
                this.strResultUrl = dataRow["urltaobao"].ToString().Trim();
            }
            else
            {
                //this.button7.Visible = true;
                //this.button8.Visible = false;
                //this.button3.Visible = false;
                //this.button4.Visible = false;
                //this.button5.Visible = false;
                //this.button6.Visible = false;
                //this.button9.Visible = false;
                //this.button10.Visible = false;
                this.Urlflag = false;
                this.strResultUrl = dataRow["urltaobao"].ToString().Trim();
            }
            if (dataRow["xinpin"].ToString().Trim() == "新品")
                this.checkBox2.Checked = true;
            if (dataRow["baoyou"].ToString().Trim() == "包邮")
                this.checkBox6.Checked = true;
            if (dataRow["zsyfx"].ToString().Trim() == "赠送退货运费险")
                this.checkBox9.Checked = true;
            if (dataRow["hdfk"].ToString().Trim() == "货到付款")
                this.checkBox13.Checked = true;
            if (dataRow["hwsp"].ToString().Trim() == "海外商品")
                this.checkBox12.Checked = true;
            if (dataRow["tianmao"].ToString().Trim() == "天猫")
                this.checkBox15.Checked = true;
            if (dataRow["zpbz"].ToString().Trim() == "正品保障")
                this.checkBox8.Checked = true;
            if (dataRow["xiaoshi24"].ToString().Trim() == "24小时内发货")
                this.checkBox3.Checked = true;
            if (dataRow["tian7"].ToString().Trim() == "7+天内退货")
                this.checkBox7.Checked = true;
            if (dataRow["wwzx"].ToString().Trim() == "旺旺在线")
                this.checkBox4.Checked = true;
            if (dataRow["xykzf"].ToString().Trim() == "信用卡支付")
                this.checkBox5.Checked = true;
            if (dataRow["zhekou"].ToString().Trim() == "折扣促销")
                this.checkBox11.Checked = true;
            if (dataRow["mfhx"].ToString().Trim() == "免费换新")
                this.checkBox10.Checked = true;
            if (dataRow["pzcn"].ToString().Trim() == "品质承诺")
                this.checkBox14.Checked = true;
            if (this.rw_howe_time2.Text.Trim() != "" && this.rw_howe_time2.Text.Trim() != "0")
                this.rw_chk_home.Checked = true;
            sys.myWordsId = -1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.rw_txt_key.Text.Trim() == "")
            {
                int num1 = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                MyWordsTBSturct Record = new MyWordsTBSturct();
                Record.userId = sys.LoginUser.ID;
                Record.keyword = this.rw_txt_key.Text.Trim();
                Record.ww = this.rw_com_ww.Text.Trim();
                Record.comeType = this.rw_com_jd.Text.Trim();
                Record.pageNum = (int)Convert.ToInt16(this.rw_com_page.Text.Trim());
                Record.dq = this.rw_txt_dq.Text.Trim();
                Record.spid = this.txt_spid.Text.Trim();
                if (this.txt_spid.Text.Trim() == "")
                {
                    int num2 = (int)MessageBox.Show("请输入商品ID，商品ID只能是商品链接上“id=”后面的数字");
                    this.txt_spid.Focus();
                    this.txt_spid.BackColor = Color.PeachPuff;
                }
                else
                {
                    this.txt_spid.Focus();
                    this.txt_spid.BackColor = Color.White;
                    if (this.txt_spid.Text.Trim().Length <= 13)
                    {
                        this.DialogResult = DialogResult.OK;
                        Record.urltaobao = !this.Urlflag ? (string)null : this.strResultUrl;
                        Record.xinpin = !this.checkBox2.Checked ? "" : "新品";
                        Record.baoyou = !this.checkBox6.Checked ? "" : "包邮";
                        Record.zsyfx = !this.checkBox9.Checked ? "" : "赠送退货运费险";
                        Record.hdfk = !this.checkBox13.Checked ? "" : "货到付款";
                        Record.hwsp = !this.checkBox12.Checked ? "" : "海外商品";
                        Record.tianmao = !this.checkBox15.Checked ? "" : "天猫";
                        Record.zpbz = !this.checkBox8.Checked ? "" : "正品保障";
                        Record.xiaoshi24 = !this.checkBox3.Checked ? "" : "24小时内发货";
                        Record.tian7 = !this.checkBox7.Checked ? "" : "7+天内退货";
                        Record.wwzx = !this.checkBox4.Checked ? "" : "旺旺在线";
                        Record.xykzf = !this.checkBox5.Checked ? "" : "信用卡支付";
                        Record.zhekou = !this.checkBox11.Checked ? "" : "折扣促销";
                        Record.mfhx = !this.checkBox10.Checked ? "" : "免费换新";
                        Record.pzcn = !this.checkBox14.Checked ? "" : "品质承诺";
                        Record.downNum1 = !(this.rw_txt_cjsl1.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_cjsl1.Text.Trim()) : 1;
                        Record.downNum2 = !(this.rw_txt_cjsl2.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_cjsl2.Text.Trim()) : 2;
                        Record.price1 = !(this.rw_txt_price1.Text.Trim() != "") ? -1 : Convert.ToInt32(this.rw_txt_price1.Text.Trim());
                        Record.price2 = !(this.rw_txt_price2.Text.Trim() != "") ? -1 : Convert.ToInt32(this.rw_txt_price2.Text.Trim());
                        if (Record.downNum1 < 0)
                            Record.downNum1 = 1;
                        if (Record.downNum2 < 0)
                            Record.downNum2 = 1;
                        if (Record.downNum2 < Record.downNum1)
                            Record.downNum2 = Record.downNum1;
                        Record.ipSpace = (int)Convert.ToInt16(this.rw_com_ip.Text.Replace("小时", "").Trim());
                        if (this.rw_jd_sj1.Text.Trim() == "")
                        {
                            Record.jdTime1 = 180;
                            this.rw_jd_sj1.Text = "180";
                        }
                        else
                            Record.jdTime1 = (int)Convert.ToInt16(this.rw_jd_sj1.Text.Trim());
                        if (this.rw_jd_sj2.Text.Trim() == "")
                        {
                            Record.jdTime2 = 300;
                            this.rw_jd_sj2.Text = "300";
                        }
                        else
                            Record.jdTime2 = (int)Convert.ToInt16(this.rw_jd_sj2.Text.Trim());
                        if (Record.jdTime1 < 120)
                            Record.jdTime1 = 120;
                        if (Record.jdTime1 > 180)
                            Record.jdTime1 = 180;
                        if (Record.jdTime2 > 300)
                            Record.jdTime2 = 300;
                        if (Record.jdTime2 < Record.jdTime1)
                            Record.jdTime2 = Record.jdTime1;
                        if (this.rw_dn_sj1.Text.Trim() == "")
                        {
                            Record.dnTime1 = 60;
                            this.rw_dn_sj1.Text = "60";
                        }
                        else
                            Record.dnTime1 = (int)Convert.ToInt16(this.rw_dn_sj1.Text.Trim());
                        if (this.rw_dn_sj2.Text.Trim() == "")
                        {
                            Record.dnTime2 = 120;
                            this.rw_dn_sj2.Text = "120";
                        }
                        else
                            Record.dnTime2 = (int)Convert.ToInt16(this.rw_dn_sj2.Text.Trim());
                        if (Record.dnTime1 < 30)
                            Record.dnTime1 = 30;
                        if (Record.dnTime1 > 120)
                            Record.dnTime1 = 120;
                        if (Record.dnTime2 > 180)
                            Record.dnTime2 = 180;
                        if (Record.dnTime2 < Record.dnTime1)
                            Record.dnTime2 = Record.dnTime1;
                        Record.sl = !(this.rw_txt_snedNum1.Text.Trim() == "") ? (int)Convert.ToInt16(this.rw_txt_snedNum1.Text.Trim()) : 10;
                        if (Record.sl <= 0)
                            Record.sl = 1;
                        if (this.rw_chk_home.Checked)
                        {
                            if (this.rw_howe_time1.Text.Trim() == "")
                            {
                                Record.homeTime1 = 60;
                                this.rw_howe_time1.Text = "60";
                            }
                            else
                                Record.homeTime1 = (int)Convert.ToInt16(this.rw_howe_time1.Text.Trim());
                            if (this.rw_howe_time2.Text.Trim() == "")
                            {
                                Record.homeTime2 = 90;
                                this.rw_howe_time2.Text = "90";
                            }
                            else
                                Record.homeTime2 = (int)Convert.ToInt16(this.rw_howe_time2.Text.Trim());
                            if (Record.homeTime1 < 30)
                                Record.homeTime1 = 30;
                            if (Record.homeTime1 > 120)
                                Record.homeTime1 = 120;
                            if (Record.homeTime2 > 180)
                                Record.homeTime2 = 180;
                            if (Record.homeTime2 < Record.homeTime1)
                                Record.homeTime2 = Record.homeTime1;
                        }
                        else
                            Record.homeTime1 = Record.homeTime2 = 0;
                        Record.price = (double)(Record.jdTime2 + Record.dnTime2 * Record.downNum2 + Record.pageNum * 30);
                        if (Record.homeTime2 > 0)
                            Record.price += (double)Record.homeTime2;
                        Record.price = Record.price / 100.0;
                        Record.price = 15.0;
                        if (sys.LoginUser.hyDj > 0)
                            Record.price = 14.0;
                        double num2 = Record.price;
                        Record.allPrice = 0.0;
                        if (this.rw_com_jd.Text == "直通车" && this.rw_txt_title.Text.Trim() == "")
                        {
                            int num3 = (int)MessageBox.Show("请复制直通车创意标题到标题框内。若复制的是宝贝标题，踩出来的是综合搜索，不是直通车");
                            this.rw_txt_title.Focus();
                            this.rw_txt_title.BackColor = Color.PeachPuff;
                        }
                        else
                        {
                            this.rw_txt_title.Focus();
                            this.rw_txt_title.BackColor = Color.White;
                            if (this.rw_com_jd.Text == "按京东" && this.rw_txt_title.Text.Trim() == "")
                            {
                                int num3 = (int)MessageBox.Show("请复制商品标题(45字以内)到标题框内，必须一字不差");
                                this.rw_txt_title.Focus();
                                this.rw_txt_title.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                this.rw_txt_title.Focus();
                                this.rw_txt_title.BackColor = Color.White;
                                if (this.rw_com_jd.Text == "直通车")
                                {
                                    Record.title = this.rw_txt_title.Text.Trim();
                                    Record.lm1 = "";
                                    Record.lm2 = "";
                                }
                                else if (this.rw_com_jd.Text == "按京东")
                                {
                                    if (this.rw_txt_title.Text.Trim().Length <= 36)
                                    {
                                        Record.title = this.rw_txt_title.Text.Trim();
                                        Record.lm1 = "";
                                        Record.lm2 = "";
                                    }
                                    else
                                    {
                                        Record.title = this.rw_txt_title.Text.Trim().Substring(0, 36);
                                        Record.lm1 = "";
                                        Record.lm2 = "";
                                    }
                                }
                                else
                                {
                                    Record.lm1 = "";
                                    Record.lm2 = "";
                                    Record.title = "";
                                }
                                if (this.txt_spid.Text.Trim() == "")
                                {
                                    int num3 = (int)MessageBox.Show("请输入商品ID.");
                                }
                                else
                                {
                                    Record.jsPrice = Record.allPrice;
                                    Record.sendTime = this.rw_send_time.BeginDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                                    new MyWordsClass().InsertRecord(Record);
                                    int num4 = (int)MessageBox.Show("词库添加成功!");
                                }
                            }
                        }
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("商品ID只能是商品链接上“id=”后面的数字，不是旺旺，也不是链接");
                        this.txt_spid.Focus();
                    }
                }
            }
        }

        private void but_add_del_Click(object sender, EventArgs e)
        {
            if (this.rw_com_ww.Text.Trim() == "" || MessageBox.Show("确定要删除当前选中旺旺吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (this.rw_com_ww.Items.Count == 0)
            {
                MessageBox.Show("至少要关联一个旺旺号", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            usersClass usersClass = new usersClass();
            string allww = sys.LoginUser.WW.ToString();
            if (usersClass.delete_ww(this.rw_com_ww.Text.Trim(), sys.LoginUser.ID, ref allww) > 0)
            {
                try
                {
                    UsersTBSturct loginUser = sys.LoginUser;
                    loginUser.WW = allww;
                    sys.LoginUser = loginUser;
                    freashWW();
                }
                catch
                {
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "按综合";
                taobaofrm taobaofrm = new taobaofrm();
                string str = sys.ulEncode(this.rw_txt_key.Text);
                taobaofrm.Url = "http://s.taobao.com/search?tab=all&q=" + str;
                taobaofrm.Url += "&style=grid";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "天猫搜索";
                taobaofrm taobaofrm = new taobaofrm();
                string str = sys.ulEncode(this.rw_txt_key.Text);
                taobaofrm.Url = "http://s.taobao.com/search?tab=all&q=" + str;
                taobaofrm.Url += "&tab=mall";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "直通车";
                taobaofrm taobaofrm = new taobaofrm();
                string str = sys.ulEncode(this.rw_txt_key.Text);
                taobaofrm.Url = "http://s.taobao.com/search?tab=all&q=" + str;
                taobaofrm.Url += "&style=grid";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "按京东";
                taobaofrm taobaofrm = new taobaofrm();
                string str = HttpUtility.UrlEncode(this.rw_txt_key.Text, Encoding.GetEncoding("UTF-8"));
                taobaofrm.Url = "http://search.jd.com/Search?keyword=" + str;
                taobaofrm.Url += "&enc=utf-8";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.rw_txt_key.Text.Trim() == "" || this.rw_txt_key.Text.Trim() == "宝贝关键词")
            {
                int num = (int)MessageBox.Show("关键字不能为空!");
            }
            else
            {
                this.rw_com_jd.Text = "阿里巴巴";
                taobaofrm taobaofrm = new taobaofrm();
                taobaofrm.Url = "http://s.1688.com/selloffer/offer_search.htm?keywords=" + sys.ulEncode(this.rw_txt_key.Text);
                taobaofrm.Url += "&from=marketSearch&mergeSameDesign=false&n=y&filt=y";
                if (taobaofrm.ShowDialog() == DialogResult.OK)
                    this.strResultUrl = taobaofrm.Url;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Urlflag = false;
            this.button1.Visible = false;

            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button11.Visible = false;
            this.button7.Visible = false;
            this.rw_com_jd.Visible = true;
            this.label51.Visible = true;
        }

        private void label51_Click(object sender, EventArgs e)
        {
            if (sys.LoginUser.hyDj < 8)
                return;
            this.Urlflag = true;
            this.button1.Visible = true;

            this.button8.Visible = true;
            this.button9.Visible = true;
            this.button10.Visible = true;
            this.button11.Visible = true;
            this.button7.Visible = true;
            this.rw_com_jd.Visible = true;
            this.label51.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.add(0);
        }

        private void refreashPrice(object sender, EventArgs e)
        {
            try
            {
                add(0);
            }
            catch (Exception )
            {
            }
        }

        private void refreashPrice(object sender, KeyPressEventArgs e)
        {
            try
            {
                add(0);
            }
            catch (Exception )
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            rw_txt_price1.Text = "";
            rw_txt_price2.Text = "";
            rw_txt_dq.SelectedIndex = -1;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }



        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("确定要升级到VIP" + (sys.LoginUser.hyDj + 1) + "吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                MessageBox.Show("没有升级");
            }
            else
            {
                //usersClass us = new usersClass();
                //if (us.updateHhdj(sys.LoginUser.ID.ToString(), sys.LoginUser.hyDj + 1))

                //    MessageBox.Show("恭喜您升级成功！");
                //else
                //{
                //    MessageBox.Show("升级失败，当前升级的人数过多，稍后再试！");
                //}
            }

        }



        private void selectVipCard(object sender, EventArgs e)
        {
            foreach (Control c in this.groupBox14.Controls)
            {

                if (c is RadioButton)
                {
                    if (((RadioButton)c).Checked == true)
                    {
                        switch (((RadioButton)c).TabIndex)
                        {
                            case 0:
                                pictureBox1.Image = global::x86.Properties.Resources.car51;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    richTextBox2.Text = "你的购买价格： 300 元/张 内含：100000流量币";
                                    label57.Text = "300";
                                }
                                else
                                {
                                    richTextBox2.Text = "超值特惠卡500元,内含：100000流量币";
                                    label57.Text = "500";
                                }
                                break;
                            case 1:
                                pictureBox1.Image = global::x86.Properties.Resources.car41;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    richTextBox2.Text = "你的购买价格： 160 元/张 内含：50000流量币";
                                    label57.Text = "160";
                                }
                                else
                                {
                                    richTextBox2.Text = "超值特惠卡250元,内含：50000流量币";
                                    label57.Text = "250";
                                }
                                break;
                            case 2:
                                pictureBox1.Image = global::x86.Properties.Resources.car31;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    label57.Text = "68";
                                    richTextBox2.Text = "你的购买价格： 68 元/张 内含：20000流量币";
                                }
                                else
                                {
                                    label57.Text = "100";
                                    richTextBox2.Text = "超值特惠卡100元,内含：20000流量币";
                                }
                                break;
                            case 3:
                                pictureBox1.Image = global::x86.Properties.Resources.car21;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    label57.Text = "35";
                                    richTextBox2.Text = "你的购买价格： 35 元/张 内含：10000流量币";
                                }
                                else
                                {
                                    label57.Text = "50";
                                    richTextBox2.Text = "超值特惠卡50元,内含：10000流量币";
                                }
                                break;
                            case 4:
                                pictureBox1.Image = global::x86.Properties.Resources.car11;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    label57.Text = "18";
                                    richTextBox2.Text = "你的购买价格： 18 元/张 内含：5000流量币";
                                }
                                else
                                {
                                    label57.Text = "25";
                                    richTextBox2.Text = "超值特惠卡25元,内含：5000流量币";
                                }
                                break;
                            case 5:
                                pictureBox1.Image = global::x86.Properties.Resources.car01;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    label57.Text = "8";
                                    richTextBox2.Text = "你的购买价格： 8 元/张 内含：2000流量币";
                                }
                                else
                                {
                                    label57.Text = "10";
                                    richTextBox2.Text = "超值特惠卡10元,内含：2000流量币";
                                }
                                break;
                        }

                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }
        Thread submitMoneyThread;
        void submitMoney(string liushuihao, double money, string what)
        {

            if (new usersClass().search_liushuihao(liushuihao))
            {
                MessageBox.Show("您已经提交过了，请点击'充值记录'查看");
                return;
            }

            if (liushuihao == "")
            {
                MessageBox.Show("支付宝订单流水号填写有误");
                //textBox4.Focus();
                return;
            }



            usersClass user = new usersClass();

            if (user.addMoney(liushuihao, money, sys.LoginUser.ID, what) == 1)
                MessageBox.Show("充值成功，3分钟内到账。", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                MessageBox.Show("服务器繁忙，请稍后提交!");
        }
        private void button14_Click(object sender, EventArgs e)
        {


            string liushuihao = textBox4.Text.Trim();
            double money = double.Parse(label57.Text.Trim());


            submitMoneyThread = new Thread(() =>
            {
                submitMoney(liushuihao, money, "购买流量币");
            });
            submitMoneyThread.Start();


        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chongzhijilu chongzhi = new Chongzhijilu();
            chongzhi.Show();
        }
        public void sleep()
        {
            Thread.Sleep(1000);
            MessageBox.Show("已复制本系统支付宝账号,可在“对方支付宝账号”直接粘贴");
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (label57.Text == "0")
            {
                MessageBox.Show("请选择要购买的卡");
                return;
            }
            Clipboard.SetData(DataFormats.Text, "986044519@qq.com");


            System.Diagnostics.Process.Start("https://shenghuo.alipay.com/transfer/ac/acFill.htm");
            ThreadFukuan = new Thread(new ThreadStart(sleep));
            ThreadFukuan.Start();

        }

        private void grid_myTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {

            string liushuihao = textBox1.Text.Trim();
            double money = double.Parse(label52.Text.Trim());


            submitMoneyThread = new Thread(() =>
            {
                submitMoney(liushuihao, money, "购买VIP");
            });
            submitMoneyThread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label52.Text == "0")
            {
                MessageBox.Show("请选择要购买的卡");
                return;
            }
            Clipboard.SetData(DataFormats.Text, "986044519@qq.com");


            System.Diagnostics.Process.Start("https://shenghuo.alipay.com/transfer/ac/acFill.htm");
            ThreadFukuan = new Thread(new ThreadStart(sleep));
            ThreadFukuan.Start();
        }

        private void selectVIPCard2(object sender, EventArgs e)
        {
            foreach (Control c in this.groupBox11.Controls)
            {

                if (c is RadioButton)
                {
                    if (((RadioButton)c).Checked == true)
                    {
                        switch (((RadioButton)c).TabIndex)
                        {
                            case 0:
                                pictureBox2.Image = global::x86.Properties.Resources.vipcar0;
                                {
                                    richTextBox1.Text = "VIP1会员每月要求介绍3个新会员，少介绍一个扣1000流量币；最多可绑定旺旺账号3个，可以同时为3个店铺放流量；介绍新会员升级IP后可得到5%的利润.购买价格：100元/张 内含：20000流量币 升级为：VIP1";
                                    label52.Text = "100";
                                }

                                break;
                            case 1:
                                pictureBox2.Image = global::x86.Properties.Resources.vipcar1;
                                if (sys.LoginUser.hyDj > 0)
                                {
                                    richTextBox1.Text = "VIP2:购买价格：200元  内含：40000流量币，可以同时为3个店铺放流量；介绍新会员升级IP后可得到50元的利润";
                                    label52.Text = "200";
                                }

                                break;
                            case 2:
                                pictureBox2.Image = global::x86.Properties.Resources.vipcar2;
                                label52.Text = "400";
                                richTextBox1.Text = "VIP8:购买价格：400元  内含：80000流量币，可以同时为3个店铺放流量；同时可以出售自己的流量币给其他会员。介绍新会员升级IP后可得到50元的利润";
                                break;
                            case 3:
                                pictureBox2.Image = global::x86.Properties.Resources.vip9;
                                {
                                    label52.Text = "2000";
                                    richTextBox1.Text = "VIP9:购买价格：2000元  内含：6000000流量币，不限制添加旺旺数量，可以同时为20个店铺放流量，适合有卖家资源的用户购买,介绍新会员升级IP后可得到50元的利润";
                                }

                                break;

                        }

                    }
                }
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Chongzhijilu().Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
        private delegate void DelegateFillTixianGrid(DataTable t);
        DelegateFillTixianGrid delegateFillTixianGrid;

        private void FillTixianGrid(DataTable t)
        {
            this.dataGridView1.DataSource = t;
        }
        Thread ThreadFillTixianGrid;

        public void refreshTixian()
        {
            usersClass userClass = new usersClass();
            DataTable dt = userClass.getWotuijiande(sys.LoginUser.QQ);
            this.Invoke(delegateFillTixianGrid, dt);

        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //new Wotuijiande().Show();
            //usersClass userClass = new usersClass();

            //dataGridView1.DataSource = userClass.getWotuijiande(sys.LoginUser.QQ);
            FillTixianGridFun();
            label65.Text = "0";
        }
        Thread ThreadWoKeYiTixiande;
        public delegate void DelegaterefreashWoKeyiFanLable(Label l, string v);
        DelegaterefreashWoKeyiFanLable delegateUpdateLable;
        public void updateLable(Label lable, string value)
        {
            lable.Text = value;
        }
        public void showWoKeyifa()
        {
            usersClass u = new usersClass();
            double m = u.getWoKeyifan(sys.LoginUser.QQ);
            this.Invoke(delegateUpdateLable, label60, m + "");
        }
        public void showTixianleiji()
        {
            usersClass u = new usersClass();
            double m = u.getLeijiTixian(sys.LoginUser.ID);
            this.Invoke(delegateUpdateLable, linkLabel12, m + "");
 
        }
        public void showTuijianrenshu()
        {
            usersClass u = new usersClass();
            int m = u.getCountTuijian(sys.LoginUser.QQ);
            this.Invoke(delegateUpdateLable, label62, m + "");
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            delegateUpdateLable = updateLable;
            ThreadWoKeYiTixiande = new Thread(new ThreadStart(showWoKeyifa));
            ThreadWoKeYiTixiande.Start();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            delegateUpdateLable = updateLable;
            ThreadWoKeYiTixiande = new Thread(new ThreadStart(showTuijianrenshu));
            ThreadWoKeYiTixiande.Start();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            updateLable();
        }

        private void updateLable()
        {
            delegateUpdateLable = updateLable;
            ThreadWoKeYiTixiande = new Thread(new ThreadStart(showTuijianrenshu));
            ThreadWoKeYiTixiande.Start();
            delegateUpdateLable = updateLable;
            ThreadWoKeYiTixiande = new Thread(new ThreadStart(showWoKeyifa));
            ThreadWoKeYiTixiande.Start();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;

            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;


            if (view.Columns[e.ColumnIndex].DataPropertyName == "状态")
            {
                //e.Value = ((string)originalValue == "可以提现") ? "提现" : "不可提现";
                if ((string)originalValue != "可以提现50元")
                {


                    dataGridView1.Columns[e.ColumnIndex + 1].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "False";



                }
                else
                {
                    dataGridView1.Columns[e.ColumnIndex + 1].ReadOnly = false;
                }

            }
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {

        }

   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ThreadCaculateMoney = new Thread(new ParameterizedThreadStart(caculateMoney));
            ThreadCaculateMoney.Start(this.dataGridView1);
            
        }
        Thread ThreadCaculateMoney;
        private void caculateMoney(object o)
        {
            DataGridView dag = (DataGridView)o;
            int selectCount=0;
            for (int i = 0; i < dag.Rows.Count; i++)
            {
                if (dag.Rows[i].Cells[4].EditedFormattedValue.ToString() == "True")
                {
                    selectCount++;
                }
            }
            this.Invoke(delegateUpdateLable, this.label65, selectCount * 50 + "");
          
        }
        public delegate void DelegatesetGridViewTixianApply(DataTable t);
        DelegatesetGridViewTixianApply delegatesetGridViewTixianApply;

        public void setGridViewTixianApply(DataTable t)
        {
            this.dataGridView2.DataSource = t;
        }
        Thread RefeashMyTixianApply;
        public void RefreashMyTixianApply()
        {
            usersClass us = new usersClass();
            DataTable dt = us.getTixianApply(sys.LoginUser.ID);
            this.Invoke(delegatesetGridViewTixianApply, dt);

        }
        Thread threadbackMoney;
        private void updatebackMoney(object o)
        {
            Hashtable ha = (Hashtable)o;

            string apployerName = (string)ha["g_userName"];
            string g_payway = (string)ha["g_payway"];
            string g_textPayaccount = (string)ha["g_textPayaccount"];
            string g_realName = (string)ha["g_realName"];
            usersClass u = new usersClass();

             u.applyForTixian(50, sys.LoginUser.ID, apployerName, g_payway, g_textPayaccount,g_realName);
        }
        public bool isAdded(string g_userName)
        {
            //如果已经申请提现，返回true
            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                if (dataGridView2.Rows[j].Cells[2].EditedFormattedValue.ToString() == g_userName)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void button15_Click_1(object sender, EventArgs e)
        {

         
            this.button15.Enabled = false;
          
            ThreadCaculateMoney = new Thread(new ParameterizedThreadStart(caculateMoney));
            ThreadCaculateMoney.Start(this.dataGridView1);
           


            if (label65.Text == "0")
            {
                MessageBox.Show("请在上面的表格中勾选金额", "提示");
                this.button15.Enabled = true;
                return;
            }
            if (textPayaccount.Text == "")
            {
                MessageBox.Show("支付宝或财付通账号不为空");
                textPayaccount.Focus();
                this.button15.Enabled = true;
                return;
            }
            if (textRealName.Text == "")
            {
                MessageBox.Show("请输入真实的用户名");
                textRealName.Focus();
                this.button15.Enabled = true;
                return;
            }


            submitApply();
            RefeashMyTixianApplyFun();
           FillTixianGridFun();
        
            this.button15.Enabled = true;
        }

        private void submitApply()
        {
            string g_payway = "支付宝";
            string g_textPayaccount = "";
            string g_realName = "";
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            textPayaccount.Enabled = false;
            textRealName.Enabled = false;

            if (radioButton11.Checked == true)
            {
                g_payway = "支付宝";
            }
            else
            {
                g_payway = "财付通";

            }


            g_textPayaccount = textPayaccount.Text;
            g_realName = textRealName.Text;
            Hashtable hs = new Hashtable();
            hs.Add("g_payway", g_payway);
            hs.Add("g_textPayaccount", g_textPayaccount);
            hs.Add("g_realName", g_realName);
            hs.Add("grid",dataGridView1);
            delegateProgress = progress;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
         

          

            ThreadSubmitSubFun = new Thread(new ParameterizedThreadStart(submitSubFun));
            ThreadSubmitSubFun.Start(hs);
          


            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            textPayaccount.Enabled = true;
            textRealName.Enabled = true;
           
        }
        public delegate void DelegateProgress(ProgressBar p,int v,int arg);
        DelegateProgress delegateProgress;
        public void progress(ProgressBar p,int v,int arg)
        {
            if (arg == 0)
            {
                p.Visible = false;
                MessageBox.Show("您的" + this.label65.Text + "元提现申请成功，10分钟内到账，请耐心等候。", "温馨提示");
                this.label65.Text = "0";
                updateLable();
                FillTixianGridFun();
            }
            else
            {
                p.Visible = true;
            }
            try
            {
                p.Value = v;
            }
            catch (Exception )
            {
                p.Visible = false;
            }
           



        }
        Thread ThreadSubmitSubFun;
        private void submitSubFun(object o)
        {
            Hashtable hs = (Hashtable)o;
            DataGridView dg1 = (DataGridView)hs["grid"];
            int sumCount=0;
            for (int i = 0; i < dg1.Rows.Count; i++)
            {
                if (dg1.Rows[i].Cells[4].EditedFormattedValue.ToString() == "True")
                {
                    sumCount++;
                }

 
            }
            int count = 0;
            string g_payway = (string)hs["g_payway"];
            string g_textPayaccount = (string)hs["g_textPayaccount"];
            string g_realName = (string)hs["g_realName"];
            delegateSetProgressMaxValue = SetProgressMaxValue;
            this.Invoke(delegateSetProgressMaxValue,progressBar1, sumCount);
            for (int i = 0; i < dg1.Rows.Count; i++)
            {
                if (dg1.Rows[i].Cells[4].EditedFormattedValue.ToString() == "True")
                {

                    string g_userName = dg1.Rows[i].Cells[1].EditedFormattedValue.ToString();

                    Hashtable ht = new Hashtable();
                

                    ht.Add("g_userName", g_userName);
                    ht.Add("g_payway", g_payway);
                    ht.Add("g_textPayaccount", g_textPayaccount);
                    ht.Add("g_realName", g_realName);
                    
                 
                    if (isAdded(g_userName))
                    {
                        continue;
                    }
                    threadbackMoney = new Thread(new ParameterizedThreadStart(updatebackMoney));
                    threadbackMoney.Start(ht);
                   this.Invoke(delegateProgress,progressBar1, count++,1);
                }
             
            }
           this.Invoke(delegateProgress, progressBar1, 0,0);
        }
        public delegate void  DelegateSetProgressMaxValue(ProgressBar p,int max);
        DelegateSetProgressMaxValue delegateSetProgressMaxValue;
       void  SetProgressMaxValue(ProgressBar p,int max)
        {
            p.Maximum = max;
        }
        private void linkLabel8_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefeashMyTixianApplyFun();
        }

        private void RefeashMyTixianApplyFun()
        {
            delegatesetGridViewTixianApply = setGridViewTixianApply;
            RefeashMyTixianApply = new Thread(new ThreadStart(RefreashMyTixianApply));
            RefeashMyTixianApply.Start();
        }

        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateLable();
            ThreadCaculateMoney = new Thread(new ParameterizedThreadStart(caculateMoney));
            ThreadCaculateMoney.Start(this.dataGridView1);
            showTixianleiji();//累计提现金额
        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellMouseEventArgs e)
        {
            ThreadCaculateMoney = new Thread(new ParameterizedThreadStart(caculateMoney));
            ThreadCaculateMoney.Start(this.dataGridView1);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Wotuijiande().Show();
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showTixianleiji();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1_DocumentCompleted_1(sender, e);

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.notifyIcon1.BalloonTipText = "正在为您刷店铺流量，点击我，弹出窗口";
                this.notifyIcon1.BalloonTipTitle = "爱流量";
                this.notifyIcon1.ShowBalloonTip(100);
                
                this.Hide();
            }
        }

        private void 升级VIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string url = "http://wpa.qq.com/msgrd?v=3&uin=407205052&site=qq&menu=yes";
            System.Diagnostics.Process.Start(url);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            string url = "http://wpa.qq.com/msgrd?v=3&uin=3292816140&site=qq&menu=yes";
            System.Diagnostics.Process.Start(url);
        }
    }
}
