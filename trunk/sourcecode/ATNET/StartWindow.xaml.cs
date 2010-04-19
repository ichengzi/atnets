using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ATNET {
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window 
    {
        public StartWindow() 
        {
            InitializeComponent();

            InitRecentProjectFiles();
        }

        public static string OpenProjectFile {
            get;
            set;
        }

        private bool InitRecentProjectFiles() {

            List<string> files = new List<string>();
            files.Add("c:\\Windows\\1.atnprj");
            files.Add("d:\\winodws\\2.atnprj");
            foreach (string file in files) {

                recentProjectLv.Items.Add(file);
            }
            return true;
        }

        private void button_Click(object sender, RoutedEventArgs e) 
        {
            var btn = sender as Button;
            if (btn.Name == "btnOK")
            {
                if ((bool)openRecentRadio.IsChecked) //Open Recent Project
                {
                    string fileName = recentProjectLv.SelectedItem as string;
                    if (!File.Exists(fileName)) {//project file not exist
                        MessageBox.Show("Project File is not existed!");
                        return;
                    }
                    OpenProjectFile = fileName;
                }
                else if ((bool)openOtherRadion.IsChecked) {//Open Other Project
                    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                    openFileDialog.InitialDirectory = "projects";
                    openFileDialog.DefaultExt = "atnprj";
                    openFileDialog.Filter = "Atnet Project files (*.atnprj)|*.atnprj";
                    openFileDialog.ShowDialog();
                    OpenProjectFile = openFileDialog.FileName;
                }
                else {//new project
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.InitialDirectory = "projects";
                    saveFileDialog.DefaultExt = "atnprj";
                    saveFileDialog.Filter = "Atnet Project files (*.atnprj)|*.atnprj";
                    saveFileDialog.ShowDialog();
                    ATNetProject.SaveProjectFile(saveFileDialog.FileName);
                    OpenProjectFile = saveFileDialog.FileName;
                }
                this.Close();
            }
            else if (btn.Name == "btnCancel") 
            {
                this.Close();
            }
            else 
            {
                //Help Document
            }
        }

    }

}
