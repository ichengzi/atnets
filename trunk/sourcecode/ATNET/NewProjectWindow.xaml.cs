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
using System.Windows.Forms;
using System.IO;
using ATNET.Project;
using ATNET.Services.ProjectService;

namespace ATNET
{
    /// <summary>
    /// NewProjectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        public NewProjectWindow()
        {
            InitializeComponent();

            projPath.Text = AppDomain.CurrentDomain.BaseDirectory + "projects";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            if (btn.Content.ToString() == "浏览")
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                dialog.ShowDialog();
                projPath.Text = dialog.SelectedPath;
            }
            else if (btn.Content.ToString() == "确定")
            {
                if (string.IsNullOrEmpty(projName.Text))
                {
                    System.Windows.MessageBox.Show("请输入工程的名字!");
                    return;
                }
                else
                {
                    //验证工程的名字是否合适
                    //MessageBox.Show("请输入工程的名字!");
                    //return;
                }
                if (string.IsNullOrEmpty(projPath.Text))
                {
                    System.Windows.MessageBox.Show("请输入工程保存的路径!");
                    return;
                }
                else
                {
                    if (!Directory.Exists(projPath.Text))
                    {
                        System.Windows.MessageBox.Show("输入的路径不正确，请重新输入!");
                        return;
                    }
                }
                //建立新工程，进入主界面
                IProject project = CommonProject.NewProject(projPath.Text + "\\" + projName.Text);
                
                ProjectService.CurrentProject = project;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
