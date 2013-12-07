using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsList
{
  [Serializable]
  class Student
  {
    public enum eGender { MALE, FEMALE };
    
    public String Name { get; set; }
    public eGender Gender { get; set; }
    public int Age { get; set; }

    public Student(String name = "", eGender g = eGender.MALE, int age = 18)
    {
      Name = name;
      Gender = g;
      Age = age;
    }
  }
}
