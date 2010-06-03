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
using System.Drawing.Printing;

namespace ATNET.Gui.Windows
{
    /// <summary>
    /// ChoseLabelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChoseLabelWindow : Window
    {
        public ChoseLabelWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ChoseLabelWindow_Loaded);
        }

        private void ChoseLabelWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IList<string> prints = GetPrintList();
            foreach (string print in prints)
            {
                cmbPrint.Items.Add(print);
            }
        }

        private IList<string> GetPrintList()
        {
            IList<string> printList = new List<string>();

            foreach (string name in PrinterSettings.InstalledPrinters)
            {
                printList.Add(name);
            }
            return printList;
        }
    }
}
