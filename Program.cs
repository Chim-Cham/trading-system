using Apps;

// ------------------------------------------------------------------------------------------------------------------------------------------------
// Lists that hold the information that will be used for different parts of the program.
// User holds all info for each user such as Name, Email, ID, and Password.
// Item holds all info for each item stored such as Name, Description and OwnerID.
// ------------------------------------------------------------------------------------------------------------------------------------------------
List<User> users = new List<User>();
List<Item> items = new List<Item>();
// ------------------------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------------------------------------------------
// The below code snippet is used to import all user info from a txt file. ReadALLLines goes through the textfile and stores each lines read in a 
// string array that later on gets converted to list items stored in List<User>.
// ------------------------------------------------------------------------------------------------------------------------------------------------
string[] importUsers = File.ReadAllLines("users.txt");
// ------------------------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------------------------------------------------
// The below loop goes through the importedUsers array and uses .Split to make the string into an array that then is used to take out the necessary 
// info to import the users into List<User>. It does this by "splitting" of the string into a new seperate string that is stored in values after 
// every " : " that appears in the txt file.
// ------------------------------------------------------------------------------------------------------------------------------------------------
// The different index in values translates to the following:
// values[0] = user.Name
// values[1] = user.Email
// values[2] = user.ID
// values[3] = user.Pwd
// ------------------------------------------------------------------------------------------------------------------------------------------------
// User info is stored in the following format "Name : Email : ID : Password".
// ------------------------------------------------------------------------------------------------------------------------------------------------
for (int i = 0; i < importUsers.Length; i++)
{
    if (importUsers[i] == null)
    {
        break;
    }
    else
    {
        string[] values = importUsers[i].Split(" : ");
        users.Add(new User(values[0], values[1], values[2], values[3]));
    }
}
// ------------------------------------------------------------------------------------------------------------------------------------------------

foreach (User user in users)
{
    System.Console.WriteLine($"User: {user.Name}, Email: {user.Email}, ID: {user.ID}, Password: {user.Pwd}");
}




