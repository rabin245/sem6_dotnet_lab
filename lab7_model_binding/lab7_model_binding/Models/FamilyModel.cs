namespace lab7_model_binding.Models
{
    public class FamilyModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Relation Relation { get; set; }
        public FamilyModel()
        {
            Id = 0; FullName = ""; Gender = ""; Age = 0; Relation = Relation.None;
        }
        public FamilyModel(int iId, string sFullName, string sGender, int iAge, Relation eRelation)
        {
            Id = iId; FullName = sFullName; Gender = sGender; Age = iAge; Relation = eRelation;
        }
        public override string ToString()
        {
            return $"ID : {Id}, Full Name : {FullName}, Gender : {Gender}, Age : {Age}, Relation : {Relation}";
        }
    }
    public enum Relation { Father, Mother, Brother, Sister, None }
}
