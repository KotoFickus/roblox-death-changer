namespace Roblox_death_sound_replacer
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            ofd.Filter = "OGG audio files|*.ogg";
        }

        private string FindRobloxPath() {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string robloxPath = Path.Combine(userPath, @"Roblox\Versions\");
            var directories = new DirectoryInfo(robloxPath).GetDirectories().OrderByDescending(o => o.CreationTime);
            string directory = "";
            foreach(DirectoryInfo dir in directories)
            {
                foreach (FileInfo fileInfo in dir.GetFiles()) {
                    if (fileInfo.Name == "RobloxPlayerBeta.exe" || fileInfo.Name == "RobloxPlayerLauncher.exe") {
                        directory = dir.FullName;
                        break;
                    }
                }
                if (directory != "") break;
            }
            return directory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK) {
                label2.Text = ofd.SafeFileName;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Copy(ofd.FileName, Path.Combine(FindRobloxPath(), @"content\sounds\ouch.ogg"), true);
            MessageBox.Show("Replaced succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Path.Combine(FindRobloxPath(), @"content\sounds\ouch.ogg"), Properties.Resources.ouch);
            MessageBox.Show("Replaced succesfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Path.Combine(FindRobloxPath(), @"content\sounds\ouch.ogg"), Properties.Resources.oof);
            MessageBox.Show("Replaced succesfully");
        }
    }
}