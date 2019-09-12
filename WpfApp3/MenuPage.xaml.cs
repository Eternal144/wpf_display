using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class MenuPage : Page
    {
        //string s;
        public MenuPage()
        {

        }
        public MenuPage(StoreData obj,int index) 
        {
            //s = a;
            InitializeComponent();
            MessageBox.Show(obj.year + obj.major + obj.classes[index]);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IndexPage index = new IndexPage();
            this.NavigationService.Navigate(index);
        }
    }
}
