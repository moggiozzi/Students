using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentsList
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    ObservableCollection<Student> StudentList;
    
    public MainWindow()
    {
      InitializeComponent();
      fillStudentList();
      dataGrid.ItemsSource = StudentList;
    }

    void fillStudentList()
    {
      StudentList = new ObservableCollection<Student>();
      StudentList.Add(new Student("Иван"));
      StudentList.Add(new Student("Света", Student.eGender.FEMALE));
      StudentList.Add(new Student("Кондориано", Student.eGender.MALE, 25));
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
      StudentList.Add(new Student());
    }
  }
}
