using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIT_FileNameReader
{
    public partial class ErrorFrm : Form
    {
        public ErrorFrm(string errormsg)
        {
            InitializeComponent();
            ErrorBox.Text = errormsg;
        }

        private void ErrorFrm_Load(object sender, EventArgs e)
        {
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);
        }
    }
}
