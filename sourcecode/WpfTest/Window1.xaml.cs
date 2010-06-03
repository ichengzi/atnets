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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfTest.Gui.Components;

namespace WpfTest
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
  
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //CreateTree();
            //CreateCustomTree();
        }

        private void CreateTree()
        {
            TreeView treeView = new TreeView();
            TreeViewItem baseItem = new TreeViewItem();
            baseItem.Header = "Base";
            TreeViewItem item1 = new TreeViewItem();
            item1.Header = "1";
            baseItem.Items.Add(item1);
            treeView.Items.Add(baseItem);

            mainGrid.Children.Add(treeView);
        }

        private void CreateCustomTree()
        {
            Image icon = LoadImage();

            CustomTreeNode baseNode = new CustomTreeNode(icon, "工程");
            ExtTreeView treeView = new ExtTreeView(baseNode);
            for (int i = 0; i < 10; i++)
            {
                CustomTreeNode node = new CustomTreeNode(LoadImage(), "子项" + i);
                node.AddTo(treeView);
                CustomTreeNode node1 = new CustomTreeNode(LoadImage(), "子子项" + 2);
                node1.AddTo(node);
            }
            
            mainGrid.Children.Add(treeView);
        }

        private Image LoadImage()
        {
            Image icon = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("icons\\add.png", UriKind.Relative);
            bitmap.EndInit();
            icon.Source = bitmap;
            return icon;
        }
    }
}
