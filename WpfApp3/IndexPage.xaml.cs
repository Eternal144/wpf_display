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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class IndexPage : Page
    {
        List<StoreData> selectDataList = new List<StoreData>();
        IList<SelectYear> yearsList = new List<SelectYear>();
        IList<Selectmajor> majorsList = new List<Selectmajor>();
        IList<SelectClasses> classesList = new List<SelectClasses>();
        int[] indexReocrd;
        

        //int[] arrOfYears = new int[2] { 1999, 2000 };
        public IndexPage() //
        {
            InitializeComponent();
            selectDataList.Add(new StoreData() { year = 1999, major = "软工", classes = new int[4] { 1, 2, 3, 4 } });
            selectDataList.Add(new StoreData() { year = 1999, major = "计算机", classes = new int[3] { 1, 2, 3 } });
            selectDataList.Add(new StoreData() { year = 2000, major = "软工", classes = new int[5] { 1, 2, 3, 4, 5 } });
            selectDataList.Add(new StoreData() { year = 2000, major = "计算机", classes = new int[4] { 1, 2, 3, 4 } });
            indexReocrd = new int[3] { -1, -1, -1 }; //初始化为-1；
            LodData();
        }
        private StoreData findObj()
        {
            int y = yearsList[indexReocrd[0]].Year;
            string m = majorsList[indexReocrd[1]].Major;
            foreach (StoreData obj in selectDataList)
            {
                if (obj.year == y && obj.major == m) //班级可以渲染了。
                {
                    return obj;
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(indexReocrd[0] != -1 && indexReocrd[1] != -1 && indexReocrd[2] != -1) //可以携带信息进行跳转了。
            {
                StoreData obj = findObj();
                MenuPage page2 = new MenuPage(obj, indexReocrd[2]);
                this.NavigationService.Navigate(page2); //展示三个目录了
            }

        }

        private void LodData() // 先渲染届别和专业。
        {
            ISet<int> set1 = new HashSet<int>();
            ISet<string> set2 = new HashSet<string>();
           
            foreach (StoreData obj in selectDataList)
            {
               if(set1.Add(obj.year) == false) //添加啦
                {
                    yearsList.Add(new SelectYear() { Year = obj.year });
                }
                if (set2.Add(obj.major) == false) //添加啦
                {
                    majorsList.Add(new Selectmajor() { Major = obj.major });
                }
            }
            this.year.ItemsSource = yearsList;
            this.major.ItemsSource = majorsList;
            
        }

        //记录当前选中值
        private void classes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.classes.SelectedIndex != -1)
            {
                indexReocrd[2] = this.classes.SelectedIndex;
            }
        }
        private void renderClasses()
        {

            if (indexReocrd[0] != -1 && indexReocrd[1] != -1) //可以渲染班级了
            {
                this.classes.ItemsSource = null;
                int y = yearsList[indexReocrd[0]].Year;
                string m = majorsList[indexReocrd[1]].Major;
                StoreData obj = findObj();
                classesList.Clear();
                foreach (int i in obj.classes)
                {
                    classesList.Add(new SelectClasses() { SClass = i });
                            
                }
                this.classes.ItemsSource = classesList;
            }
        }
        //记录当前选中值
        private void major_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.major.SelectedIndex != -1)
            {
                indexReocrd[1] = this.major.SelectedIndex;
                renderClasses();
            }
            
        }
        //记录当前选中值。获取index
        private void year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedValue
            if(this.year.SelectedIndex != -1)
            {
                indexReocrd[0] = this.year.SelectedIndex;
                renderClasses();
            }
           
        }
    }
    public class SelectYear //一个对象？
    {
        public int Year { get; set; }
        
    }
    public class Selectmajor
    {
        public string Major { get; set; }
    }
    public class SelectClasses
    {
        public int SClass { get; set; }
    }

}
