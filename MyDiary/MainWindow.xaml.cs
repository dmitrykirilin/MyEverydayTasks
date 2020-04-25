using MyDiary.Model;
using MyDiary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace MyDiary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\diaryData.json";
        public BindingList<Diary> diaryData;
        private FileIOService fileIOService;
        MyDbContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new MyDbContext();
            db.Notes.Load();
            diaryData = db.Notes.Local.ToBindingList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            

            // Десериализация из JSON
            //try
            //{
            //    diaryData = fileIOService.LoadData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Close();
            //}
            
            //{
            //    new Diary(){Task = "jkhgkljg"},
            //    new Diary(){Task = "jkhgkl3453 p9038",
            //                IsDone = true}
            //};

            MyDataGrid.ItemsSource = diaryData;
            diaryData.ListChanged += DiaryData_ListChanged;
        }

        private void DiaryData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                db.Notes.Add(new Diary() {
                    Task = "sadfkgja ljaslfj",
                    IsDone = true
                });
                db.SaveChanges();
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                var product = db.Notes.Find(e.NewIndex + 1) as Diary;
                db.Notes.Remove(product);
                db.SaveChanges();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var product = db.Notes.Find(e.OldIndex) as Diary;
                product = diaryData[e.NewIndex];
                db.SaveChanges();
            }
               
                // Cериализация в JSON
                //try
                //{
                //    fileIOService.SaveData(sender as BindingList<Diary>);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    Close();
                //}
            
            
        }
    }
}
