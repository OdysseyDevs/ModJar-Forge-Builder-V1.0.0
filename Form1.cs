using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace ModJar_Builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyDarkTheme();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

            foreach (Control c in this.Controls)
            {
                ApplyDarkThemeToControl(c);
            }
        }

        private void ApplyDarkThemeToControl(Control c)
        {
            if (c is TextBox tb)
            {
                tb.BackColor = Color.FromArgb(45, 45, 45);
                tb.ForeColor = Color.White;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (c is Button btn)
            {
                btn.BackColor = Color.FromArgb(58, 58, 58);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            }
            else if (c is Label lbl)
            {
                lbl.ForeColor = Color.White;
            }
            else if (c is Panel pnl)
            {
                pnl.BackColor = Color.FromArgb(37, 37, 37);
                foreach (Control child in pnl.Controls)
                    ApplyDarkThemeToControl(child);
            }

            foreach (Control child in c.Controls)
                ApplyDarkThemeToControl(child);
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the Forge mod project folder (with gradlew)";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = dlg.SelectedPath;
                    if (string.IsNullOrWhiteSpace(txtOutputName.Text))
                        txtOutputName.Text = new DirectoryInfo(dlg.SelectedPath).Name;
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the folder where the .jar should be placed";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolder.Text = dlg.SelectedPath;
                }
            }
        }

        private async void btnBuild_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            string sourceFolder = txtSourceFolder.Text.Trim();
            string outputName = txtOutputName.Text.Trim();
            string outputFolder = txtOutputFolder.Text.Trim();

            if (string.IsNullOrWhiteSpace(sourceFolder) || !Directory.Exists(sourceFolder))
            {
                MessageBox.Show("Please select a valid source folder.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(outputName))
            {
                MessageBox.Show("Please enter an output name.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show("Please select an output folder.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gradlew = Path.Combine(sourceFolder, "gradlew.bat");
            if (!File.Exists(gradlew))
            {
                MessageBox.Show("gradlew.bat not found in the source folder.\n" +
                                "Make sure this is a Forge Gradle project.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnBuild.Enabled = false;
            btnBuild.Text = "Building...";

            try
            {
                AppendLog("Running Gradle build...");

                var psi = new ProcessStartInfo
                {
                    FileName = gradlew,
                    Arguments = "build",
                    WorkingDirectory = sourceFolder,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                var process = new Process { StartInfo = psi, EnableRaisingEvents = true };

                process.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        AppendLog(ev.Data);
                };

                process.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        AppendLog("[ERR] " + ev.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await System.Threading.Tasks.Task.Run(() => process.WaitForExit());

                AppendLog($"Gradle exited with code {process.ExitCode}");

                if (process.ExitCode != 0)
                {
                    MessageBox.Show("Build failed. Check the log for details.",
                        "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string libsPath = Path.Combine(sourceFolder, "build", "libs");
                if (!Directory.Exists(libsPath))
                {
                    MessageBox.Show("build/libs folder not found. Build may have failed.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jar = Directory.GetFiles(libsPath, "*.jar").FirstOrDefault();
                if (jar == null)
                {
                    MessageBox.Show("No .jar file found in build/libs.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Directory.CreateDirectory(outputFolder);

                string destPath = Path.Combine(outputFolder, outputName + ".jar");
                File.Copy(jar, destPath, true);

                AppendLog($"Copied jar to: {destPath}");
                MessageBox.Show("Build complete!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AppendLog("Exception: " + ex.Message);
                MessageBox.Show("An error occurred. Check the log for details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuild.Enabled = true;
                btnBuild.Text = "Build Mod";
            }
        }

        private void AppendLog(string text)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(AppendLog), text);
                return;
            }

            txtLog.AppendText(text + Environment.NewLine);
        }
    }
}
