
namespace FileSearcher
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelSearchDirectory = new System.Windows.Forms.Label();
            this.LabelSearchPattern = new System.Windows.Forms.Label();
            this.searchDirectory = new System.Windows.Forms.TextBox();
            this.searchPattern = new System.Windows.Forms.TextBox();
            this.fileTree = new System.Windows.Forms.TreeView();
            this.buttonStopSearch = new System.Windows.Forms.Button();
            this.buttonPauseSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelSearchDirectory
            // 
            this.LabelSearchDirectory.AutoSize = true;
            this.LabelSearchDirectory.Location = new System.Drawing.Point(13, 16);
            this.LabelSearchDirectory.Name = "LabelSearchDirectory";
            this.LabelSearchDirectory.Size = new System.Drawing.Size(116, 20);
            this.LabelSearchDirectory.TabIndex = 0;
            this.LabelSearchDirectory.Text = "Search directory";
            // 
            // LabelSearchPattern
            // 
            this.LabelSearchPattern.AutoSize = true;
            this.LabelSearchPattern.Location = new System.Drawing.Point(13, 55);
            this.LabelSearchPattern.Name = "LabelSearchPattern";
            this.LabelSearchPattern.Size = new System.Drawing.Size(105, 20);
            this.LabelSearchPattern.TabIndex = 1;
            this.LabelSearchPattern.Text = "Search pattern";
            // 
            // searchDirectory
            // 
            this.searchDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDirectory.Location = new System.Drawing.Point(135, 12);
            this.searchDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchDirectory.Name = "searchDirectory";
            this.searchDirectory.Size = new System.Drawing.Size(415, 27);
            this.searchDirectory.TabIndex = 2;
            // 
            // searchPattern
            // 
            this.searchPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPattern.Location = new System.Drawing.Point(135, 51);
            this.searchPattern.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchPattern.Name = "searchPattern";
            this.searchPattern.Size = new System.Drawing.Size(415, 27);
            this.searchPattern.TabIndex = 3;
            // 
            // fileTree
            // 
            this.fileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTree.Location = new System.Drawing.Point(16, 102);
            this.fileTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(534, 490);
            this.fileTree.TabIndex = 4;
            this.fileTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTree_BeforeExpand);
            this.fileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileTree_AfterSelect);
            // 
            // buttonStopSearch
            // 
            this.buttonStopSearch.Location = new System.Drawing.Point(16, 599);
            this.buttonStopSearch.Name = "buttonStopSearch";
            this.buttonStopSearch.Size = new System.Drawing.Size(94, 29);
            this.buttonStopSearch.TabIndex = 5;
            this.buttonStopSearch.Text = "Stop search";
            this.buttonStopSearch.UseVisualStyleBackColor = true;
            this.buttonStopSearch.Click += new System.EventHandler(this.buttonStopSearch_Click);
            // 
            // buttonPauseSearch
            // 
            this.buttonPauseSearch.Location = new System.Drawing.Point(126, 599);
            this.buttonPauseSearch.Name = "buttonPauseSearch";
            this.buttonPauseSearch.Size = new System.Drawing.Size(104, 29);
            this.buttonPauseSearch.TabIndex = 6;
            this.buttonPauseSearch.Text = "Pause search";
            this.buttonPauseSearch.UseVisualStyleBackColor = true;
            this.buttonPauseSearch.Click += new System.EventHandler(this.buttonPauseSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 640);
            this.Controls.Add(this.buttonPauseSearch);
            this.Controls.Add(this.buttonStopSearch);
            this.Controls.Add(this.fileTree);
            this.Controls.Add(this.searchPattern);
            this.Controls.Add(this.searchDirectory);
            this.Controls.Add(this.LabelSearchPattern);
            this.Controls.Add(this.LabelSearchDirectory);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "File searcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelSearchDirectory;
        private System.Windows.Forms.Label LabelSearchPattern;
        private System.Windows.Forms.TextBox searchDirectory;
        private System.Windows.Forms.TextBox searchPattern;
        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.Button buttonStopSearch;
        private System.Windows.Forms.Button buttonPauseSearch;
    }
}

