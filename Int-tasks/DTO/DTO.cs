namespace Int_tasks.DTO;
public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }
}

public class Standard
{
    public int StandardID { get; set; }
    public string StandardName { get; set; }
}

public class Result
{

    public string PlayerName { get; set; }
    public string Type { get; set; }
}


public class Player
{
    public string PlayerName { get; set; }
    public int PlayerId { get; set; }
}
