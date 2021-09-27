
namespace lab2_csharp
{
    class Test
    {
        string subject;
        bool pass;

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public bool Pass
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }

        public Test(string subjectValue, bool passValue)
        {
            subject = subjectValue;
            pass = passValue;
        }
        public Test() : this("PE", true)
        {
        }

        public override string ToString()
        {
            string t;
            if (Pass){
                t = " - Сдан";
            }
            else
            {
                t = " - Не сдан";
            }
            return subject + t;
        }
    }
}
