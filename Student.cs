using System;
using System.Collections;

namespace lab2_csharp
{
    class Student : Person, IDateAndCopy
    {
        Education educat;
        int groupNumber;
        ArrayList exams = null;
        ArrayList tests = null;

        public Student(Person persValue, Education educatValue, int groupNumberValue)
        {
            this.Name = persValue.Name;
            this.Surname = persValue.Surname;
            this.Birthday = persValue.Birthday;
            this.Educat = educatValue;
            this.GroupNumber = groupNumberValue;
            exams = new ArrayList();
            tests = new ArrayList();
        }
        public Student()
        {
            Name = "Alex";
            Surname = "Ometov";
            Birthday = new DateTime(2000, 1, 1);
            Educat = Education.Specialist;
            GroupNumber = 111;
            exams = new ArrayList();
            tests = new ArrayList();
        }
        public Person pers
        {
            get
            {
                return new Person(this.Name, this.Surname, this.Birthday);
            }
            set
            {
                this.Name = value.Name; 
                this.Surname = value.Surname; 
                this.Birthday = value.Birthday;
            }
        }
        public bool this[Education e]
        {
            get
            {
                return educat == e;
            }
        }
        public Education Educat
        {
            get
            {
                return educat;
            }
            set
            {
                educat = value;
            }
        }
        public int GroupNumber
        {
            get
            {
                return groupNumber;
            }
            set
            {
                bool t = false;
                while (t != true){
                    if ((value > 100) && (value <= 599))
                    {
                        groupNumber = value;
                        t = true;
                    }
                    else
                        throw new ArgumentOutOfRangeException("Значение должно быть от 101 до 599");
                }
            }
        }
        public ArrayList Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams = value;
            }
        }
        public ArrayList Tests
        {
            get
            {
                return tests;
            }
            set
            {
                tests = value;
            }
        }
        public double Average
        {
            get
            {
                if (Exams == null)
                {
                    return 0;
                }
                int sum = 0;
                foreach (Exam value in Exams)
                {
                    sum += value.Grade;
                }
                return sum / Exams.Count;
            }
        }
        public override string ToString()
        {
            string lineOne = Name + " " + Surname + " " + Birthday + " " + Educat + " " + GroupNumber;
            for (int i = 0; i < Exams.Count; i++)
            {
                lineOne += "\n" + Exams[i].ToString();
            }
            for (int i = 0; i < Tests.Count; i++)
            {
                lineOne += "\n" + Tests[i].ToString();
            }
            return lineOne;
        }
        public override string ToShortString()
        {
            return Name + " " + Surname + " " + Birthday + " " + Educat + " " + GroupNumber + " " + Average;
        }
        public void AddExams(params Exam[] newEx)
        {
            foreach (var item in newEx)
            {
                exams.Add(item);
            }
        }

        public void AddTests(params Test[] newTest)
        {
            foreach (var item in newTest)
            {
                tests.Add(item);
            }
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Student return false.
            Student p = obj as Student;
            if ((object)p == null)
            {
                return false;
            }

            if (!this.pers.Equals(p.pers))
            {
                return false;
            }
            if (!(this.educat == p.educat))
            {
                return false;
            }
            if (!(this.groupNumber == p.groupNumber))
            {
                return false;
            }


            if (!((this.exams.Count) == (p.exams.Count)))
            {
                return false;
            }

            if (!((this.tests.Count) == (p.tests.Count)))
            {
                return false;
            }

            Exam exam;
            foreach (var item in this.exams)
            {
                exam = (Exam)item;
                if (!p.exams.Contains(exam))
                {
                    return false;
                }
            }

            Test test;
            foreach (var item in this.tests)
            {
                test = (Test)item;
                if (!p.tests.Contains(test))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool operator ==(Student s1, Student s2)
        {
            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(s1, s2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)s1 == null) || ((object)s2== null))
            {
                return false;
            }
            return s1.Equals(s2);
        }


        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }


        public override int GetHashCode()
        {
            return pers.GetHashCode() + educat.GetHashCode() + groupNumber.GetHashCode();
        }

        public virtual Student DeepCopy()
        {
            Student obj = new Student(this.pers, this.educat, this.groupNumber);

            foreach (var item in this.exams)
            {
                obj.exams.Add(item);
            }


            foreach (var item in this.tests)
            {
                obj.tests.Add(item);
            }

            return obj;
        }

        //итераторы

        public IEnumerable TestAndExam()
        {
            foreach (var item in this.exams)
            {
                yield return item;
            }

            foreach (var item in this.tests)
            {
                yield return item;
            }
        } //итератор для последовательного перебора всех элементов из списков зачетов и экзаменов(объединение);

        public IEnumerable ExamGrade(int grade)
        {
            foreach (var item in this.exams)
            {
                if (((Exam)item).Grade > grade)
                    yield return item;
            }
        } //итератор c параметром для перебора экзаменов (объектов типа Exam) с оценкой больше заданного значения

        public IEnumerable ExamAndTestDone()
        {
            foreach (var item in this.exams)
            {
                if (((Exam)item).Grade > 2)
                    yield return item;
            }

            foreach (var item in this.tests)
            {
                if (((Test)item).Pass == true)
                    yield return item;
            }
        } //итератор для перебора сданных зачетов и экзаменов(>2)

        public IEnumerable TestWhereExamDone()
        {
            foreach (var test in this.tests)
            {
                if (((Test)test).Pass == true)
                    foreach (var exam in this.ExamGrade(2))
                    {
                        if (((Test)test).Subject == ((Exam)exam).Name)
                            yield return test;
                    }
            }
        } //итератор для перебора всех сданных зачетов, для которых сдан и экзамен

        public IEnumerator GetEnumerator() //
        {
            return new StudentEnumerator(exams, tests);
        }


    }
}
