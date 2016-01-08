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
    public partial class Chongzhijilu : Form
    {
        public Chongzhijilu()
        {
            InitializeComponent();
        }

        private void Chongzhijilu_Load(object sender, EventArgs e)
        {
            hydjClass hydjClass = new hydjClass();
            this.gridview_chongzhijilu.DataSource = (object)hydjClass.getChongzhijilu(sys.LoginUser.ID.ToString());

        }
    }
}
