namespace LibraryManagement;

public class Book : Library
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ID { get; set; }
    public string Issue_Date { get; set; }
    public string End_Date { get; set; }
    public Book(string t, string i,string a) : base(t, i,a)
    {

        Title = t;
        ID = i;

    }
    public void show()
    {
        Console.WriteLine($"Title:{Title} -- Author:{Author}");
    }
    
}