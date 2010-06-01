using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SoftArt.WPF.Graph
{
    // Implements ItemsControl for ToolboxItems    
    public class Toolbox : ItemsControl
    {
        // Defines the ItemHeight and ItemWidth properties of
        // the WrapPanel used for this Toolbox
        public Size ItemSize
        {
            get { return itemSize; }
            set { itemSize = value; }
        }
        private Size itemSize = new Size(50, 50);

        // Creates or identifies the element that is used to display the given item.        
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ToolboxItem();
        }

        // Determines if the specified item is (or is eligible to be) its own container.        
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ToolboxItem);
        }

        private Style tbkStyle = null;
        private Style imageStyle = null;
        private Style gridStyle = null;

        public Toolbox()
        {
            this.Loaded += new RoutedEventHandler(Toolbox_Loaded);
        }

        private void Toolbox_Loaded(object sender, RoutedEventArgs e)
        {
          
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppResources");
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                AddItem(files[i]);
            }
 
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            tbkStyle = (Style)this.TryFindResource("tbTextStyle");
            imageStyle = (Style)this.TryFindResource("imageStyle");
            gridStyle = (Style)this.TryFindResource("gridStyle");
        }

        private void AddItem(string imgPath)
        {
            Grid grid = new Grid();
            grid.Style = gridStyle;
            RowDefinition row1 = new RowDefinition();
            row1.Height = GridLength.Auto;
            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            Image img = new Image();
            img.Style = imageStyle;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imgPath);
            bitmap.EndInit();
            img.Source = bitmap;
            string imageName = Path.GetFileName(imgPath).Substring(0, Path.GetFileName(imgPath).IndexOf("."));
            img.ToolTip = imageName;

            TextBlock tbk = new TextBlock();
            tbk.Style = tbkStyle;
            tbk.Text = imageName;

            grid.Children.Add(img);
            grid.Children.Add(tbk);
            Grid.SetColumn(img, 0);
            Grid.SetColumn(tbk, 0);
            Grid.SetRow(img, 0);
            Grid.SetRow(tbk, 1);

            this.Items.Add(grid);
        }
    }
}
