using System.Runtime.CompilerServices;

namespace LibraryManagement;

public class Notification
{
    string admin_num;
    public Notification(string mob_num)
    {
        admin_num = mob_num;
    }
    public void SendNotification(String msg)
    {
        SendSMS(admin_num, msg);
    }
    public void SendSMS(string num, string msg)
    {
        Console.WriteLine($"Sending Msg to {num} as {msg}");
    }
}