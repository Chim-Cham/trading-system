using System.Runtime.Intrinsics.Arm;
using Apps;

// Lists that hold the information that will be used for different parts of the program.
// User holds all info for each user such as Name, Email, ID, and Password.
// Item holds all info for each item stored such as Name, Description and OwnerID.
// ------------------------------------------------------------------------------------------------------------------------------------------------
List<User> users = new List<User>();
List<Item> items = new List<Item>();
// ------------------------------------------------------------------------------------------------------------------------------------------------

// The below code snippet is used to import all user info from a txt file. ReadALLLines goes through the textfile and stores each lines read in a 
// string array that later on gets converted to list items stored in List<User>.
// ------------------------------------------------------------------------------------------------------------------------------------------------
string[] importUsers = File.ReadAllLines("users.txt");
string[] importItems = File.ReadAllLines("items.txt");
// ------------------------------------------------------------------------------------------------------------------------------------------------

// The below loop goes through the importedUsers array and uses .Split to make the string into an array that then is used to take out the necessary 
// info to import the users into List<User>. It does this by "splitting" of the string into a new seperate string that is stored in values after 
// every " : " that appears in the txt file.
// ------------------------------------------------------------------------------------------------------------------------------------------------
// The different index in values translates to the following:
// values[0] = users.Name
// values[1] = users.Email
// values[2] = users.ID (values[2] gets converted to a int using TryParse)
// values[3] = users.Pwd
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
        int.TryParse(values[2], out int ID);
        users.Add(new User(values[0], values[1], ID, values[3]));
    }
}
// ------------------------------------------------------------------------------------------------------------------------------------------------

// Following loop does the same as above but for Items.
// ------------------------------------------------------------------------------------------------------------------------------------------------
// The different index in values translates to the following:
// values[0] = items.Name
// values[1] = items.Desc
// values[2] = items.ItemID (values[2] gets converted to a int using TryParse)
// values[3] = items.OwnerID (values[3] gets converted to a int using TryParse)
// ------------------------------------------------------------------------------------------------------------------------------------------------
// Item info is stored in the following format "Name : Description : ItemID : OwnerID".
// ------------------------------------------------------------------------------------------------------------------------------------------------
for(int i = 0; i < importItems.Length; i++)
{
    if (importItems[i] == null)
    {
        break;
    }
    else
    {
        string[] values = importItems[i].Split(" : ");
        int.TryParse(values[2], out int OID);
        items.Add(new Item(values[0], values[1], OID));
    }
}
// ------------------------------------------------------------------------------------------------------------------------------------------------

// Parameters used during majority of the program to determine what user is logged in via activeUser and to control when the program exits via 
// running that controls the while loop that encompasses the majority of the programs code.
// ------------------------------------------------------------------------------------------------------------------------------------------------
User? activeUser = null;
bool running = true;
// ------------------------------------------------------------------------------------------------------------------------------------------------

// The actual program the user will be interacting with. As long as the running variable is true the program will continue to loop through.
// ------------------------------------------------------------------------------------------------------------------------------------------------
while (running)
{
    // Clear keeps the terminal clean and avoid having it fill up with rows upon rows of text.
    Console.Clear();

    // Login part, program sees that a user is not logged in because activeUser is null and therefor prompts the user to input login credentials.
    if (activeUser == null)
    {   
        // User interface for logging in and registering as new user.
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine($" Welcome!");
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine("1. Register");
        System.Console.WriteLine("2. Login");
        System.Console.WriteLine("3. Exit");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                // Account registration logic, user inputs a username and password which then get added to users.txt and List<User> so a restart 
                // is not needed to make the registration take effect. The username is also converted to a hotmail adress that is automatically 
                // made upon registraion.
                System.Console.Write("Enter Username: ");
                string? userInput = System.Console.ReadLine();
                System.Console.Write("Enter Password: ");
                string? passInput = System.Console.ReadLine();
                string emailInput = $"{userInput}@hotmail.com";
                users.Add(new User(userInput, emailInput, users.Capacity+1, passInput));
                // string value that is appended to users.txt. "\n" is added to make sure that the user info is added onto it's own row. Also reason
                // for users.Count having a subract added onto it is because count gives the total number of entires in List<User> so it starts from 1 
                // and not 0 and since the admin login info has the userID of 0 it would skip a number. Could add logic here that goes through List<User>
                // and looks for the lowest available number and assigns a number that way instead. Will do if i remember and have time.
                string inputCompile = $"\n{userInput} : {emailInput} : {users.Count-1} : {passInput}";
                File.AppendAllText("users.txt", inputCompile);
                break;

            case "2":
                // foreach loop that goes through List<User> to try and find Username and Password combo that fits with the user input, if 
                // one is found the program sets activeUser to the first match found. If multiple users would have the same Username/Password 
                // combo only the user that shows up first in the list would be able to login. Some logic that is able to detect already 
                // exisitng usernames and prompt the user to pick a unique one while registering could be used here but since it was not 
                // listed in the assignment requirements i decided to skip it to save time.        
                System.Console.Write("Enter Username: ");
                userInput = System.Console.ReadLine();
                System.Console.Write("Enter Password: ");
                passInput = System.Console.ReadLine();
                foreach (User user in users)
                {
                    if (user.Login(userInput, passInput))
                    {
                        activeUser = user;
                        break;
                    }
                }
                break;

            case "3":
                // switch case sets running to false and therefor causes the encapsulating while loop to stop and the program as a whole.
                running = false;
                break;

            default:
                // If input doesn't fit any of the set cases it will print out "Invalid!".
                System.Console.WriteLine("Invalid!");
                break;
        }
        
        Console.Clear();
    }

    // Once logged in the remaining code is the actual interactive part that users will navigate to list items, trade and register articles they want to
    // use for said trading.
    else
    {
        // User interface that displays once logged in.
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine($" Welcome {activeUser.Name}");
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine("1. User Info");
        System.Console.WriteLine("2. Logout");
        System.Console.WriteLine("3. Exit");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                activeUser.UserInfo();
                Console.ReadLine();
                break;
            case "2":
                activeUser = null;
                break;
            case "3":
                running = false;
                break;
            default:
                System.Console.WriteLine("Invalid!");
                break;
        }
    }
}
// ------------------------------------------------------------------------------------------------------------------------------------------------