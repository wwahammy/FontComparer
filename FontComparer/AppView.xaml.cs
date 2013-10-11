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

namespace FontComparer
{
    /// <summary>
    /// Interaction logic for AppView.xaml
    /// </summary>
    public partial class AppView : UserControl
    {
        public AppView()
        {
            InitializeComponent();
        }

      
   
   
            public Visual GetDescendantByType(Visual element, Type type)
            {
                if (element == null) return null;
                if (element.GetType() == type) return element;
                Visual foundElement = null;
                if (element is FrameworkElement)
                {
                    (element as FrameworkElement).ApplyTemplate();
                }
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
                {
                    Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                    foundElement = GetDescendantByType(visual, type);
                    if (foundElement != null)
                        break;
                }
                return foundElement;
            }
            private void lbx1_ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                ScrollViewer _listboxScrollViewer1 = GetDescendantByType(SourceBorder, typeof(ScrollViewer)) as ScrollViewer;
                ScrollViewer _listboxScrollViewer2 = GetDescendantByType(TestBorder, typeof(ScrollViewer)) as ScrollViewer;
                _listboxScrollViewer2.ScrollToVerticalOffset(_listboxScrollViewer1.VerticalOffset);
            }
        
    }
}
