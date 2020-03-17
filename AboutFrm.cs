using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIT_FileNameReader
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            InitializeComponent();
            this.VersionLabel.Text = version;
            this.Text = "DIT - Filename Reader - About";
        }

        private void AboutFrm_Load(object sender, EventArgs e)
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
