using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Microsoft.VisualBasic;

namespace FolderHandling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // METHODS FOR TREEVIEW

        private void FillFolderNodes()
        {
            TreeNode FolderNode = new TreeNode(textBox1.Text);
            FillDirNode(FolderNode, textBox1.Text);
            FillFileNode(FolderNode, textBox1.Text);
            treeView1.Nodes.Add(FolderNode);
        }

        private void FillDirNode(TreeNode FolderNode, string Path)
        {
            string[] Dirs = Directory.GetDirectories(Path);

            foreach (string Dir in Dirs)
            {
                TreeNode DirNode = new TreeNode();
                DirNode.Text = Dir.Remove(0, Dir.LastIndexOf("\\") + 1);
                FolderNode.Nodes.Add(DirNode);
            }
        }

        private void FillFileNode(TreeNode FolderNode, string Path)
        {
            string[] Files = Directory.GetFiles(Path);

            foreach(string File in Files)
            {
                TreeNode FileNode = new TreeNode();
                FileNode.Text = File.Remove(0, File.LastIndexOf("\\") + 1);
                FolderNode.Nodes.Add(FileNode);
            }
        }

        private void CleanAllNodes()
        {
            treeView1.Nodes.Clear();
        }

        // MAIN METHODS

        private string ChoosePath(string PathToFile)
        {
            if(PathToFile == "")
            {
                return textBox1.Text;
            }

            return PathToFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select folder
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // show dir
            CleanAllNodes();
            FillFolderNodes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // create dir
            string Path = Interaction.InputBox("What the directory you want to create?", "Enter path", "");
            Path = ChoosePath(Path);

            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                MessageBox.Show($"The folder {Path} is created.", "Done");

                CleanAllNodes();
                FillFolderNodes();
            }
            else
            {
                MessageBox.Show($"The folder {Path} is exists.", "Warning");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // delete dir
            string Path = Interaction.InputBox("What the directory you want to delete?", "Enter path", "");
            Path = ChoosePath(Path);

            if(Directory.Exists(Path))
            {
                Directory.Delete(Path);
                MessageBox.Show($"The folder {Path} is deleted.", "Done");

                CleanAllNodes();
                FillFolderNodes();
            }
            else
            {
                MessageBox.Show($"The folder {Path} is not exists.", "Warning");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // create file
            string Path = Interaction.InputBox("What the file you want to create?", "Enter path", "");
            Path = ChoosePath(Path);

            if(!File.Exists(Path))
            {
                File.Create(Path).Close();
                MessageBox.Show($"The file {Path} is created.", "Done");

                CleanAllNodes();
                FillFolderNodes();
            }
            else
            {
                MessageBox.Show($"The file {Path} is exists.", "Warning");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // delete file
            string Path = Interaction.InputBox("What the file you want to delete?", "Enter path", "");
            Path = ChoosePath(Path);

            if(File.Exists(Path))
            {
                File.Delete(Path);
                MessageBox.Show($"The file {Path} is deleted.", "Done");

                CleanAllNodes();
                FillFolderNodes();
            }
            else
            {
                MessageBox.Show($"The file {Path} is not exists.", "Warning");
            }
        }
    }
}
