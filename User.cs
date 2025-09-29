namespace Apps;

// Class used for user creation containing their username, email, userID and password.
// Email won't really be used and is just added for exta flair to make the program seem more legit.
// ID is mostly used to see new or old a user is by making the the first users ID 1 and the most 
// recent user the lowest availalbe number. 
// (if there's 49 existing users and a new user is made they will be assigned the ID of "50")
public class User
{
    public string Name;
    public string Email;
    public int ID;
    public string Pwd;

    // Method for when creating new user
    public User(string name, string email, int id, string pwd)
    {
        Name = name;
        Email = email;
        ID = id;
        Pwd = pwd;
        Console.WriteLine("New User Added");
    }

    // Method to easily print out the info of a certain user, in the program users will only be able to write out their own info since it contains a users password.
    // Admins will be able to print our the info of all users
    public void UserInfo()
    {
        Console.WriteLine($"User: {Name}, Email: {Email}, UserID: {ID}, Password: {Pwd}");
    }
}