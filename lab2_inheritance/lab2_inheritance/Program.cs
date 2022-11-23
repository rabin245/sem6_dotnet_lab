namespace Program
{
    class ProgramClass
    {
        public static void Main(string[] args)
        {
            List<Family> familyList = new List<Family>();
            familyList.Add(new FamilyMember(id: 1, firstName: "Ram", lastName: "Basnet", role: "Father"));
            familyList.Add(new FamilyMember(id: 2, firstName: "Sita", lastName: "Basnet", role: "Mother"));
            familyList.Add(new FamilyMember(id: 3, firstName: "Ekaterina", lastName: "Basnet", role: "Daughter"));

            foreach (FamilyMember member in familyList)
            {
                member.display();
            }
        }
    }



    public class Family
    {
        public int Id { get; set; }
        public string LastName { get; set; }
     

        public Family(int id, string lastName)
        {
            Id = id;
            LastName = lastName;
        }

        public void display()
        {
            Console.WriteLine("\nThis is from parent class.");
            Console.WriteLine($"id = {Id}\tlast name = {LastName}\n");
        }
    }
    public class FamilyMember : Family
    {
        public string FirstName { get; set; }
        public string Role { get; set; }
        public FamilyMember(int id, string lastName, string firstName, string role) : base(id, lastName)
        {
            FirstName = firstName;
            Role = role;
        }
        
        public new void display()
        {
            base.display();
            Console.WriteLine("This is from child class.");
            Console.WriteLine($"first name = {FirstName}\trole = {Role}\n");

        }

    }
}