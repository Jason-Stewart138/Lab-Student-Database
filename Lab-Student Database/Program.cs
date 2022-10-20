using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Welcome to the AS5000 Student Database System");
Console.WriteLine();
Console.WriteLine("Press any key to continue");
Console.ReadKey();
Console.Clear();
MainMenu();
ExitApplication();

void MainMenu()
{
    bool lookUpStudentRequired = true;

    do
    {
        Console.WriteLine("┌───────────┐");
        Console.WriteLine("│ MAIN MENU │");
        Console.WriteLine("└───────────┘");
        Console.WriteLine();

        LoadStudentData(out string[] studentName, out int totalEntries, out string[] studentHomeTown, out string[] studentFavoriteFood);

        Console.WriteLine($"Currently there are {totalEntries} students in the system");
        Console.WriteLine();

        int userStudentSelection = GetUserStudentSelection(totalEntries, studentName, lookUpStudentRequired);

        if ((userStudentSelection - 1) >= 0)
        {
            string currentStudentSelection = studentName[userStudentSelection - 1].Substring(3);
            Console.Clear();
            DisplayUserInformation(userStudentSelection, currentStudentSelection, studentHomeTown, studentFavoriteFood);
            lookUpStudentRequired = LookUpAnotherStudent("look up another student");
            Console.Clear();
        }

    } while (lookUpStudentRequired);
}

void LoadStudentData(out string[] studentName, out int totalEntries, out string[] studentHomeTown, out string[] studentFavoriteFood)
{
    studentName = new string[]
    {
        "1. Jason Stewart",
        "2. Bobby Smith",
        "3. Amy Wise",
        "4. Hugh Mann",
        "5. Peter Pan",
        "6. Josh Potter",
        "7. Kim Arnold",
        "8. Zach Rice",
        "9. Vlad Kurtickson",
        "10. Apple Jones"
    };
    totalEntries = studentName.Length;

    studentHomeTown = new string[]
    {
        "Otsego, MI",
        "Kalamazoo, MI",
        "Grand Rapids, MI",
        "Grand Rapids, MI",
        "Ann Arbor, MI",
        "Chicago, IL",
        "Farmington Hills, MI",
        "South Bend, IN",
        "Grand Rapids, MI",
        "Jackson, MI"
    };

    studentFavoriteFood = new string[]
    {
        "Burritos",
        "Pizza",
        "Pizza",
        "Tacos",
        "Cheese Burgers",
        "Pad Thai",
        "Pizza",
        "Tacos",
        "Tacos",
        "Cheese Burgers"
    };
};

int GetUserStudentSelection(int totalEntries, string[] studentName, bool lookUpStudentRequiredIn)
{
    bool isValid;
    int userStudentSelectionReturn;

    do
    {
        Console.WriteLine($"Please enter a number between 1 and {totalEntries} to access student information or type ALL to view the class roster");

        string userResponse = Console.ReadLine().ToLower();
        if (userResponse == "all")
        {
            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine(studentName[i]);
            }
            isValid = true;
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            return userStudentSelectionReturn = 0;
            Console.WriteLine();
            MainMenu();
        }
        else
        {
            isValid = int.TryParse(userResponse, out userStudentSelectionReturn) && (userStudentSelectionReturn >= 1 && userStudentSelectionReturn <= totalEntries);
            if (!isValid)
            {
                Console.WriteLine("Please try that again, remember you must enter a whole number without decimals.");

            }
        }
    } while (!isValid);
    return userStudentSelectionReturn;
}

void DisplayUserInformation(int userStudentSelection, string currentStudentSelection, string[] studentHomeTown, string[] studentFavoriteFood)
{
    Console.WriteLine($"You selected student number {userStudentSelection}");
    Console.WriteLine();
    Console.WriteLine($"Student {userStudentSelection} is:");
    Console.WriteLine(currentStudentSelection);
    Console.WriteLine();
    Console.WriteLine($"What else would you like to know about {currentStudentSelection}?");
    string[] userOptions = new string[] { "1. Hometown", "2. Favorite Food" };
    for (int i = 0; i < userOptions.Length; i++)
    {
        Console.WriteLine(userOptions[i]);
    }
    bool isValid = false;
    do
    {
        string currentStudentExtendedDetailsSelection = Console.ReadLine().ToLower();
        GetStudentExtendedInformation(currentStudentExtendedDetailsSelection, currentStudentSelection, studentHomeTown, studentFavoriteFood, userStudentSelection, isValid, out isValid);

    } while (!isValid);
    Console.ReadKey();
    Console.Clear();
};

void GetStudentExtendedInformation(string currentStudentExtendedDetailsSelection, string currentStudentSelection, string[] studentHomeTown, string[] studentFavoriteFood, int userStudentSelection, bool isValidIn, out bool isValid)
{
    if (new[] { "1", "2", "home", "hometown", "town", "food", "favorite", "favorite food", "f", "h" }.Contains(currentStudentExtendedDetailsSelection))
    {
        isValid = true;
        if (new[] { "1", "home", "hometown", "town", "h" }.Contains(currentStudentExtendedDetailsSelection))
        {
            Console.WriteLine($"{currentStudentSelection}'s hometown is: {studentHomeTown[userStudentSelection - 1]}");
        }
        else
        {
            Console.WriteLine($"{currentStudentSelection}'s favorite food is: {studentFavoriteFood[userStudentSelection - 1]}");
        }
    }
    else
    {
        isValid = false;
        Console.WriteLine("You have entered an invalid option, please try again.");
    }
}

bool LookUpAnotherStudent(string typeOfRepeat)
{
    Console.WriteLine($"Would you like to {typeOfRepeat} (y/n)?");
    string input = Console.ReadLine();
    bool goAgain = input.ToLower() == "y";
    return goAgain;
}

void ExitApplication()
{
    Console.WriteLine("Thank you for using the AS5000");
    Console.WriteLine("Press Any Key To Exit");
    Console.ReadKey();

    Console.Clear();
    Console.WriteLine("Good Bye");
    Environment.Exit(0);
}