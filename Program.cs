using System;

namespace lab2_csharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1-ый вариант, лаб. работа №2");
            Console.WriteLine("_________________________________________________________________");

            Person pers1 = new Person(); //1
            Person pers2 = new Person();

            if ((object)pers1 == (object)pers2)
                Console.WriteLine("Ссылки равны");
            else
                Console.WriteLine("Ссылки не равны");

            if (pers1 == pers2)
                Console.WriteLine("Объекты равны");
            else
                Console.WriteLine("Объекты не равны");

            Console.WriteLine("Хеш-код 1: " + pers1.GetHashCode().ToString());
            Console.WriteLine("Хеш-код 2: " + pers2.GetHashCode().ToString());

            Console.WriteLine("_________________________________________________________________");

            Student Studentik = new Student(); //2
            Studentik.AddExams(new Exam("Биология", 5, DateTime.Today), new Exam("История", 4, DateTime.Today));
            Studentik.AddTests(new Test("Биология", true), new Test("История", true));

            Console.WriteLine(Studentik.ToString());
            
            Console.WriteLine("_________________________________________________________________");


            Console.WriteLine(Studentik.ToString()); //3
            Console.WriteLine(Studentik.pers.ToString());

            Console.WriteLine("_________________________________________________________________");

            Student NewStudentCopy = Studentik.DeepCopy(); //4
            if (Studentik == NewStudentCopy)
                Console.WriteLine("Объекты равны");
            else
                Console.WriteLine("Объекты не равны");

            Console.WriteLine(Studentik.ToString());
            Console.WriteLine(NewStudentCopy.ToString());

            Studentik.AddExams(new Exam("Физика", 5, DateTime.Today));

            Console.WriteLine("После изменения исходного объекта:");
            
            Console.WriteLine(Studentik.ToString());
            Console.WriteLine(NewStudentCopy.ToString());
            
            if (Studentik == NewStudentCopy) 
                Console.WriteLine("Объекты равны");
            else
                Console.WriteLine("Объекты не равны");

            Console.WriteLine("_________________________________________________________________");

            try //5
            {
                Studentik.GroupNumber = 23; //должно быть от 101 до 599
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message + "\n");
            }
            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Список всех экзаменов и зачетов:"); //6
            foreach (var item in Studentik.TestAndExam())
            {
                Console.WriteLine(item.ToString() + "\n");
            }

            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Список всех экзаменов с оценкой выше указанной:"); //7
            foreach (var item in Studentik.ExamGrade(3))
            {
                Console.WriteLine(item.ToString() + "\n");
            }

            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Список всех сданных зачетов и сданных экзаменов:"); //8
            foreach (var item in Studentik.ExamAndTestDone())
            {
                Console.WriteLine(item.ToString() + "\n");
            }

            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Список сданных зачетов, для которых сдан и экзамен:"); //9
            foreach (var item in Studentik.TestWhereExamDone())
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            
            Console.WriteLine("_________________________________________________________________");


            Console.WriteLine("Список предметов, которые есть как в списке зачетов, так и в списке экзаменов:"); //10
            foreach (var exam in Studentik)
            {
                Console.WriteLine(((Exam)exam).Name);
            }


            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Нажмите любую кнопку, чтобы выйти");
            Console.ReadKey();
        }
    }
}
