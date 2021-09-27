using System;

namespace lab2_csharp
{
    enum Education { Specialist, Bachelor, SecondEducation }
    class Exam
    {
        string name;
        int grade;
        DateTime dateOfExam;

        public Exam(string nameValue, int gradeValue, DateTime dateOfExamValue)
        {
            name = nameValue;
            grade = gradeValue;
            dateOfExam = dateOfExamValue;
        }
        public Exam() : this("Petya", 5, new DateTime(2000, 1, 1))
        {
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }
        public DateTime DateOfExam
        {
            get
            {
                return dateOfExam;
            }
            set
            {
                dateOfExam = value;
            }
        }
        public override string ToString()
        {
            return Name + " " + Grade + " " + DateOfExam;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Exam return false.
            Exam p = obj as Exam;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (name == p.name) && (grade == p.grade) && (dateOfExam == p.dateOfExam);
        }

        public static bool operator ==(Exam e1, Exam e2)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(e1, e2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)e1 == null) || ((object)e2 == null))
            {
                return false;
            }

            // Return true if the fields match:
            return e1.Equals(e2);
        }

        public static bool operator !=(Exam e1, Exam e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + grade.GetHashCode() + dateOfExam.GetHashCode();
        }

    }
}
