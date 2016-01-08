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
    public partial class Wotuijiande : Form
    {
        public Wotuijiande()
        {
            InitializeComponent();
        }

        private void Wotuijiande_Load(object sender, EventArgs e)
        {
         usersClass userClass=new usersClass();

         usersClass us = new usersClass();
         DataTable dt = us.getTixianApply(sys.LoginUser.ID);
         this.dataGridView2.DataSource = dt;

        }
    }
}
