using System.Diagnostics.Contracts;

namespace LibraryManagement;

public class Library
{
    public string Title_inLib { get; set; }
    public string ID_inLib { get; set; }
    public string author_inlib { get; set; }
    public string Issue_date_lib { get; set; }
    public string End_Date_lib{ get; set; }
    public Library(string t, string i, string a)
    {
        Title_inLib = t;
        ID_inLib = i;
        author_inlib = a;
        
    }
    public void Lib_Details()
    {
        Console.WriteLine($"Title:{Title_inLib}\tAuthor:{author_inlib}\tID:{ID_inLib}");

    }
}