using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class MainForm : Form
    {
        private List<AutoResetEvent> _waitHandlers = new List<AutoResetEvent>();
        private List<CancellationTokenSource> _tokens = new List<CancellationTokenSource>();
        private bool _onPause = false;

        public MainForm()
        {
            InitializeComponent();
            FillDriveNodes();
        }

        private void LoadSettings()
        {
            searchDirectory.Text = Properties.Settings.Default.SearchDirectory;
            searchPattern.Text = Properties.Settings.Default.SearchPattern;
        }

        private void SetCurrentDirectory()
        {
            string currentDirectory = searchDirectory.Text;
            if (string.IsNullOrWhiteSpace(currentDirectory) || ! Directory.Exists(currentDirectory))
                return;
            currentDirectory = currentDirectory.Replace(@":\", @"\");
            string[] nodes = currentDirectory.Split(new char[] { '\\' });

            TreeNode currentNode = null;
            foreach (string node in nodes)
            {
                if (currentNode == null)
                {
                    currentNode = fileTree.Nodes.Find(String.Concat(node, @":\"), false).FirstOrDefault() as TreeNode;
                    if (currentNode == null)
                        break;
                    currentNode.Expand();
                }
                else
                { 
                    currentNode = currentNode.Nodes.Find(node, false).FirstOrDefault() as TreeNode;
                    if (currentNode == null)
                        break;
                    currentNode.Expand();                    
                }                    
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
            this.SetCurrentDirectory();
        }

        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name, Name = drive.Name };
                    FillDirectoriesNodes(driveNode, drive.Name);
                    fileTree.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex) { }
        }

        private void FillDirectoriesNodes(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    dirNode.Name = dirNode.Text;                    
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception ex) { }            
        }        

        private void fileTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            dirNode.Name = dirNode.Text;
                            FillDirectoriesNodes(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    FillFilesNodes(e.Node, e.Node.FullPath);
                }
            }
            catch (Exception ex) { }
        }

        private async void FillFilesNodes(TreeNode directoryNode, string path)
        {
            try
            {
                AutoResetEvent waitHandler = new AutoResetEvent(true);
                _waitHandlers.Add(waitHandler);
                CancellationTokenSource token = new CancellationTokenSource();
                _tokens.Add(token);
                
                await foreach (var file in RegexFileSearcher.FindFilesAsync(waitHandler, token.Token, path, searchPattern.Text))
                {
                    TreeNode fileNode = new TreeNode();
                    fileNode.Text = file.Remove(0, file.LastIndexOf("\\") + 1);
                    directoryNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex) { }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.SearchDirectory = searchDirectory.Text;
            Properties.Settings.Default.SearchPattern = searchPattern.Text;
            Properties.Settings.Default.Save();
        }

        private void fileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            searchDirectory.Text = e.Node.FullPath.Replace(@"\\", @"\");     
        }

        private void buttonStopSearch_Click(object sender, EventArgs e)
            => _tokens.ForEach(t => t.Cancel());

        private void buttonPauseSearch_Click(object sender, EventArgs e)
        {
            if (_onPause)
                _waitHandlers.ForEach(h => h.Set());
            else
                _waitHandlers.ForEach(h => h.Reset());

            _onPause = !_onPause;
        }        
    }
}
