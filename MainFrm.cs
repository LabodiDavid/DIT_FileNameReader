using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DIT_FileNameReader
{
    public partial class MainFrm : Form
    {
        public bool listExtension;
        public bool isSelectedFolder;
        public bool isExtensionFiltered;
        public static string extension;
        public static string path;
        public string[] files;
        public string[] withoutextfiles;
        public int fileindex;
        public int lengthindex;
        string defPath = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
        public MainFrm()
        {
            InitializeComponent();
            
        }

        public string[] GetFileNames(string path, string filter="")
        {
            if (filter=="" || String.IsNullOrEmpty(filter))
            {
                filter = "*";
            }
            files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "DIT - Filename Reader";
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);

        }

        public void doPreview()
        {
            if (isSelectedFolder && (!IsdefaultPath()))
            {
                Preview();
            }
            else
            {
                if (IsdefaultPath())
                {
                    ErrorFrm err = new ErrorFrm("Nem adtál meg könyvtárat a listázásához!");
                    err.Show();
                }
                if (isExtensionFiltered==true && !(extension.StartsWith("*")))
                {
                    ErrorFrm err = new ErrorFrm("Helytelen formában adtad meg a kiterjesztést! \n Helyes példa: *.png");
                    err.Show();
                }
            }
        }
        public void ChooseFolder()
        {

            try
            {
                if (DirectoryDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryBox.Text = DirectoryDialog.SelectedPath;
                    isSelectedFolder = true;
                    path = DirectoryBox.Text;
                }
            }
            catch (Exception exc)
            {
                ErrorFrm errfrm = new ErrorFrm(exc.Message);
                errfrm.Show();

            }
            
        }
        public void FileProcess()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Fajlnevek.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter sw = new StreamWriter(save.OpenFile());

                for (int i = 0; i < FilenamesBox.Lines.Count(); i++)

                {

                    sw.WriteLine(FilenamesBox.Lines[i].ToString());

                }
                sw.Dispose();
                sw.Close();

            }
        }
        public void Preview()
        {
            try
            {
                
                if (listExtension==false)
                {
                    lengthindex = GetFileNames(path, extension).Length;
                    withoutextfiles = new string[lengthindex];
                    for (int i = 0; i < lengthindex; i++)
                    {
                        
                        int n = GetFileNames(path, extension)[i].LastIndexOf(".");
                        if (n > 0)
                        {
                            withoutextfiles[i] = files[i].Remove(n);
                        }
                        
                    }
                    FilenamesBox.Lines = withoutextfiles;
                }
                if (listExtension==true)
                {
                    FilenamesBox.Lines = GetFileNames(path, extension);
                }
                
            }
            catch (Exception exc)
            {
                ErrorFrm errfrm = new ErrorFrm(exc.Message);
                errfrm.Show();

            }
        }

        private void FilenamesBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        public bool IsdefaultPath()
        {
            if (DirectoryBox.Text== "Pl.: D:/Zenek")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                extension = "*";
                CriteriumBox.Visible = true;
                doPreview();
            }
            if (checkBox2.Checked==false)
            {
                extension = "*";
                CriteriumBox.Visible = false;
                doPreview();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void CriteriumBox_Enter(object sender, EventArgs e)
        {
            if (CriteriumBox.Text=="*")
            {
                CriteriumBox.Text = "";
            }
            else
            {
                CriteriumBox.Text = extension;
            }
        }

        private void CriteriumBox_Leave(object sender, EventArgs e)
        {
            if (!(CriteriumBox.Text=="*" || String.IsNullOrWhiteSpace(CriteriumBox.Text)))
            {
                extension = CriteriumBox.Text;
                CriteriumBox.Text = extension;
                isExtensionFiltered = true;
                doPreview();
            }
            else
            {
                extension = "*";
                CriteriumBox.Text = extension;
                isExtensionFiltered = false;
                doPreview();
            }
            
        }

        private void DirectoryBox_Enter(object sender, EventArgs e)
        {
            if (isSelectedFolder==false && IsdefaultPath())
            {
                DirectoryBox.Text = defPath;
            }
            else
            {
                path = DirectoryBox.Text;
                
            }
            
        }

        private void DirectoryBox_Leave(object sender, EventArgs e)
        {
                if (IsdefaultPath())
                {
                    DirectoryBox.Text = defPath;
                }
                else
                {
                    path = DirectoryBox.Text;
                    DirectoryBox.Text = path;
                    isSelectedFolder = true;
                    doPreview();
            }
                

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                extension = "*";
                listExtension = true;
                doPreview();
                
            }
            if (checkBox1.Checked == false)
            {
                listExtension = false;
                extension = "*";
                doPreview();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                FileProcess();
            }
            catch (Exception exc)
            {
                ErrorFrm errfrm = new ErrorFrm(exc.Message);
                errfrm.Show();
                
            }
            

        }

        private void CriteriumBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutFrm about = new AboutFrm();
            about.Show();
        }
    }
}
