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
            initializeLanguages();
        }


        private void initializeLanguages()
        {
            if (MainFrm.selectedLang==1)
            {
                AboutHungary();
            }
            if (MainFrm.selectedLang ==0)
            {
                AboutEnglish();
            }
        }
        private void AboutHungary()
        {
            this.Text = "DIT - Fájlnév olvasó - About";
            this.label1.Text = "DIT - Fájlnév olvasó";
            this.label2.Text = "Verzió:";
            this.label4.Text = "Készítette: Lábodi Dávid - DIT Services";
        }
        private void AboutEnglish()
        {
            this.Text = "DIT - Filename Reader - About";
            this.label1.Text = "DIT - Filename Reader";
            this.label2.Text = "Version:";
            this.label4.Text = "Created by: Lábodi Dávid - DIT Services";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dit-services.tk");
        }
    }
}
