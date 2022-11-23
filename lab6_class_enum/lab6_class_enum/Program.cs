namespace lab6
{
    public enum DesignationEnum
    {
        FreshMens,
        Sophomores,
        Juniors,
        Seniors,
    }
    public class Student
    {
        public int Id { get; set; } = 0;
        public string FName { get; set; } = "";
        public string MName { get; set; } = "";
        public string LName { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Gender { get; set; } = "";
        public DesignationEnum Designation { get; set; } = DesignationEnum.FreshMens;

      
        public Student(int id, string fname, string mname, string lname, string gender, int age, DesignationEnum designation)
        {
            Id = id;
            FName = fname;
            MName = mname;
            LName = lname;
            Gender = gender;
            Age = age;
            Designation = designation;

        }
        public string getStudentInfo()
        {
            string studentDetail = "";
            studentDetail += $"id: {Id}{Environment.NewLine}";
            studentDetail += "Fullname: " + FName + " " + (MName.Trim().Length > 0 ? MName + " " : "") + " " + LName + Environment.NewLine;
            studentDetail += "Gender: " + Gender + Environment.NewLine;
            studentDetail += "Age: " + Age + Environment.NewLine;
            studentDetail += "Year: " + Designation + Environment.NewLine;
            return studentDetail;
        }
    }

    class Program
    {
        public static void Main()
        {
            List<Student> studentsList = new List<Student>()
            {
                new Student(1,"Rabindra","","Baisnab","Male",21,DesignationEnum.Sophomores),
                new Student(2,"Prasmu","","Neupane","Male",29,DesignationEnum.Seniors),
                new Student(3,"Aayush","R","Raute","Male",22,DesignationEnum.Juniors),
                new Student(4,"Ram","Kesari","Basnet","Female",21,DesignationEnum.FreshMens),
                new Student(5,"Sarika","","Neupane","Female",23,DesignationEnum.Sophomores)
            };

            var displayFemale = from student in studentsList where student.Gender == "Female" orderby student.Designation ascending select student;
            foreach (var res in displayFemale)
            {
                Console.WriteLine(res.getStudentInfo());
            }
        }
    }
}