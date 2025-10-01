namespace Apps;

// Class used for user creation containing their username, email, userID and password.
// Email won't really be used and is just added for exta flair to make the program seem more legit.
// ID is mostly used to see new or old a user is by making the the first users ID 1 and the most 
// recent user the lowest availalbe number. 
// (if there's 49 existing users and a new user is made they will be assigned the ID of "50")
public class User
{
    // Username
    public string Name;
    // User Email
    public string Email;
    //UserID
    public string ID;
    //User Password
    public string Pwd;

    // Method for when creating new user
    public User(string name, string email, string id, string pwd)
    {
        Name = name;
        Email = email;
        ID = id;
        Pwd = pwd;
    }

    // Method for logging in, when used will check if the given inputs (username and password) is equal to the Name and Pwd. 
    // If it is the method will return true and allow the login if not it will return false.
    public bool Login(string username, string password)
    {
        return username == Name && password == Pwd;
    }

    // Method to easily print out the info of a certain user, in the program users will only be able to write out their own info since it contains a users password.
    // Admins will be able to print our the info of all users
    public void UserInfo()
    {
        Console.WriteLine($"User: {Name}, Email: {Email}, UserID: {ID}, Password: {Pwd}");
    }
}