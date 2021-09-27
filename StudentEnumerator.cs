using System;
using System.Collections;

namespace lab2_csharp
{
    class StudentEnumerator : IEnumerator  //интерфейс System.Collections.IEnumerable
    {
        ArrayList exams;
        ArrayList tests;
        public StudentEnumerator(ArrayList examsValue, ArrayList testsValue)
        {
            this.exams = examsValue;
            this.tests = testsValue;
        }

        int index = -1;
        public object Current
        {
            get
            {
                if (index != -1){
                    return exams[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index равен -1, а должен быть хотя бы 0");
                }
            }
        }

        public bool MoveNext() //название от IEnumerator
        {
            for (int i = index + 1; i < exams.Count; i++)
            {
                foreach (var test in tests)
                {
                    if (((Test)tests).Subject == ((Exam)exams[i]).Name)
                    {
                        index = i;
                        return true;
                    }
                }
            }
            return false;
        }

        public void Reset() //название от IEnumerator
        {
            if (exams.Count > 0) 
                {index = 0; }
            else 
                {index = -1; }

        }
    }
}