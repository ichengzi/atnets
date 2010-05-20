using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SoftArt.WPF.Graph;

namespace SoftArt.WPF.Styles
{
    /// <summary>
    /// 自定义的textbox类，用于在图形中显示文字
    /// </summary>
    public class GraphTextBox:TextBox
    {

        public GraphTextBox()
        {
            this.Loaded+=new System.Windows.RoutedEventHandler(GraphTextBox_Loaded);
            this.IsHitTestVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(GraphTextBox_IsHitTestVisibleChanged);
        }

        private void GraphTextBox_IsHitTestVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (this.IsHitTestVisible)
            {
                this.ToolTip = "按住Ctrl键，按回车换行";
            }
            else
            {
                this.ToolTip = this.Text;
            }
        }

        private void GraphTextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ToolTip = this.Text;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Enter && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                int index = this.CaretIndex;
                if (index >= 0)
                {
                    this.Text = this.Text.Insert(index, Environment.NewLine);
                }
            }
        }

    }
}
