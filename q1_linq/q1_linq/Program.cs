namespace StudentNamespace
{
    public class Student
    {
        public int RoleNo { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } 

        public Student()
        {
            RoleNo = 0;
            FullName = "";
            Class = "";
            Email = "";
            Address = "";
        }
        public Student(int roll, string fullName, string sclass, string email, string address)
        {
            RoleNo = roll;
            FullName = fullName;
            Class = sclass;
            Email = email;
            Address = address;

        }
        public string displayStudent()
        {
            string studentDetail = "";
            studentDetail += "Roll no: " + RoleNo + "\n";
            studentDetail += "Fullname: " + FullName + "\n";
            studentDetail += "Class: " + Class + "\n";
            studentDetail += "Email: " + Email + "\n";
            studentDetail += "Address: " + Address + "\n";
            return studentDetail;
        }
    }

    class Program
    {
        public static void Main()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(1, "Rabindra Baisnab", "Science", "drarabin@gmail.com", "Bhaktapur"),
                new Student(2, "Aayush Raute", "Medical", "ayusraute@gmail.com", "Bhaktapur"),
                new Student(3, "Pramsu Nepane", "Psychology", "prasmu@gmail.com", "Kathmandu"),
                new Student(4, "Test Name", "Sports", "test@gmail.com", "Bhaktapur"),
                new Student(5, "Hishan Shrestha", "Science", "hishnae@gmail.com", "Lalitpur")
            };
            //Console.WriteLine("Enter details of 5 students");
            //for(int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Enter roll number: ");
            //    int rollNo = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Enter full name: ");
            //    string fullName = Console.ReadLine();
            //    Console.WriteLine("Enter student class: ");
            //    string studClass = Console.ReadLine();
            //    Console.WriteLine("Enter email: ");
            //    string email = Console.ReadLine();
            //    Console.WriteLine("Enter address: ");
            //    string address = Console.ReadLine();

            //    studentList.Add(new Student(rollNo, fullName, studClass, email, address));
            //}

            var filteredStudents = from student in studentList where student.Address == "Bhaktapur" orderby student.Class descending select student;
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.displayStudent());
            }
        }
    }
}