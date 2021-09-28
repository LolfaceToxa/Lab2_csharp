using System;

namespace lab2_csharp
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime birthday;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }
        public Person() : this("Obama", "Ivanovich", new DateTime(2000, 1, 1))
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
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public int Year
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }

        public DateTime Date { get; set; }

        public override bool Equals(object obj) // аргумент какого-то типа
        {
            if (obj == null)
                return false;
            Person m = obj as Person; // возвращает null если объект нельзя привести к типу Person
            if (m as Person == null)
                return false;

            return (m.Name == this.Name) && (m.Surname == this.Surname) && (m.Year==this.Year);
        }
        public override int GetHashCode()
        {
            return surname.GetHashCode() + name.GetHashCode() + birthday.GetHashCode();
        }


        public static bool operator ==(Person p1, Person p2)
        {
            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(p1, p2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)p1 == null) || ((object)p2 == null))
            {
                return false;
            }

            // Return true if the fields match:
            return p1.name == p2.name && p1.surname == p2.surname && p1.birthday == p2.birthday;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public virtual object DeepCopy()
        {
            return new Person(this.Name, this.Surname, this.Birthday);
        }


        public override string ToString()
        {
            return Name + " " + Surname + " " + Birthday.ToShortDateString();
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
    }
}