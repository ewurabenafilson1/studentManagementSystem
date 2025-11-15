class Student
{
    public string? IndexNumber{ get; set; }
    public string?  Name { get; set; }

    public int? Age { get; set; }
    
    public string? Email { get; set; }
    
    public string? Course { get; set; }

    public Student() { }
    //for serialization and deserialization

    public Student(string indexNumber, string name, int age, string email, string course)
    {
        IndexNumber = indexNumber;
        Name = name;
        Age = age;
        Email = email;
        Course = course;
    }

    public override string ToString()
    {
        return $"Index Number: {IndexNumber}| Name: {Name} | Age: {Age} | Email: {Email} | Course: {Course} ";
    }
}