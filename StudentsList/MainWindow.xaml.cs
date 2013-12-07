using Microsoft.Win32;
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
using System.Xml;

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
      StudentList = new ObservableCollection<Student>();
      dataGrid.ItemsSource = StudentList;
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
      StudentList.Add(new Student());
    }

    private void loadFromXmlButton_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Filter = "(.xml)|*.xml";
      if ((bool)dlg.ShowDialog())
        loadFromXml(dlg.FileName);
    }

    private void loadFromXml(String fileName)
    {
      StudentList.Clear();
      if (System.IO.File.Exists(fileName))
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(fileName);
        XmlNode rootNode = doc["students"];
        foreach (XmlNode s in rootNode.ChildNodes)
        {
          string name = s.Attributes["name"].Value;
          int age = 0;
          int.TryParse(s.Attributes["age"].Value, out age);
          Student.eGender gender = Student.eGender.MALE;
          if (s.Attributes["gender"].Value == "female")
            gender = Student.eGender.FEMALE;
          Student st = new Student(name, gender, age);
          StudentList.Add(st);
        }
      }
    }

    private void saveToXmlButton_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.Filter = "(.xml)|*.xml";
      if ((bool)dlg.ShowDialog())
        saveToXml(dlg.FileName);
    }

    private void saveToXml(String fileName)
    {
      XmlDocument doc = new XmlDocument();
      doc.InnerXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><students></students>";
      XmlElement rootNode = doc["students"];
      foreach (var s in StudentList)
      {
        XmlElement studentNode = doc.CreateElement("student");
        studentNode.SetAttribute("name", s.Name);
        studentNode.SetAttribute("age", s.Age.ToString());
        if (s.Gender == Student.eGender.MALE)
          studentNode.SetAttribute("gender", "male");
        else
          studentNode.SetAttribute("gender", "female");
        rootNode.AppendChild(studentNode);
      }
      doc.Save(fileName);
    }
  }
}
