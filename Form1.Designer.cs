namespace ModJar_Builder
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label lblOutputName;
        private System.Windows.Forms.TextBox txtOutputName;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSourceFolder = new Label();
            txtSourceFolder = new TextBox();
            btnBrowseSource = new Button();
            lblOutputName = new Label();
            txtOutputName = new TextBox();
            lblOutputFolder = new Label();
            txtOutputFolder = new TextBox();
            btnBrowseOutput = new Button();
            btnBuild = new Button();
            lblLog = new Label();
            txtLog = new TextBox();
            SuspendLayout();
            // 
            // lblSourceFolder
            // 
            lblSourceFolder.AutoSize = true;
            lblSourceFolder.Location = new Point(20, 20);
            lblSourceFolder.Name = "lblSourceFolder";
            lblSourceFolder.Size = new Size(103, 20);
            lblSourceFolder.TabIndex = 0;
            lblSourceFolder.Text = "Source Folder:";
            // 
            // txtSourceFolder
            // 
            txtSourceFolder.Location = new Point(20, 40);
            txtSourceFolder.Name = "txtSourceFolder";
            txtSourceFolder.Size = new Size(540, 27);
            txtSourceFolder.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(570, 40);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(90, 23);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Browse...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // lblOutputName
            // 
            lblOutputName.AutoSize = true;
            lblOutputName.Location = new Point(20, 80);
            lblOutputName.Name = "lblOutputName";
            lblOutputName.Size = new Size(102, 20);
            lblOutputName.TabIndex = 3;
            lblOutputName.Text = "Output Name:";
            // 
            // txtOutputName
            // 
            txtOutputName.Location = new Point(20, 100);
            txtOutputName.Name = "txtOutputName";
            txtOutputName.Size = new Size(260, 27);
            txtOutputName.TabIndex = 4;
            // 
            // lblOutputFolder
            // 
            lblOutputFolder.AutoSize = true;
            lblOutputFolder.Location = new Point(20, 140);
            lblOutputFolder.Name = "lblOutputFolder";
            lblOutputFolder.Size = new Size(104, 20);
            lblOutputFolder.TabIndex = 5;
            lblOutputFolder.Text = "Output Folder:";
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(20, 160);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(540, 27);
            txtOutputFolder.TabIndex = 6;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(570, 160);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(90, 23);
            btnBrowseOutput.TabIndex = 7;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // btnBuild
            // 
            btnBuild.Location = new Point(20, 200);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new Size(120, 30);
            btnBuild.TabIndex = 8;
            btnBuild.Text = "Build Mod";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Click += btnBuild_Click;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(20, 240);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(37, 20);
            lblLog.TabIndex = 9;
            lblLog.Text = "Log:";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(20, 260);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(640, 160);
            txtLog.TabIndex = 10;
            // 
            // Form1
            // 
            ClientSize = new Size(679, 447);
            Controls.Add(lblSourceFolder);
            Controls.Add(txtSourceFolder);
            Controls.Add(btnBrowseSource);
            Controls.Add(lblOutputName);
            Controls.Add(txtOutputName);
            Controls.Add(lblOutputFolder);
            Controls.Add(txtOutputFolder);
            Controls.Add(btnBrowseOutput);
            Controls.Add(btnBuild);
            Controls.Add(lblLog);
            Controls.Add(txtLog);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModJar Builder";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
