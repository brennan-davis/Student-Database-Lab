string[] students = { "Kyle", "Nancy", "Grace", "Jen", "Ron", "Morgan", "Megan", "Jaron" };
string[] hometown = { "Knoxville", "Chattanooga", "Nashville", "Morristown", "Ocoee", "Jefferson City", "Crossville", "Memphis" };
string[] favFood = { "Steak", "Hamburgers", "Mac & Cheese", "Beans", "Smoked Salmon", "Pizza", "Pickles", "Cookies" };
string[] categories = { "Hometown", "Favorite Food" };

bool continueLoop = true;

while (continueLoop)
{
    Console.Clear();

    Console.WriteLine("Hello! Welcome to Bridgeton High's Student Management System Demo. We have 8 students in our database for this demo.\n\nPlease provide a number in the range of 1 through 8 to see student details:");

    bool studentIdIsInt = int.TryParse(Console.ReadLine(), out int studentId);

    while (!studentIdIsInt || studentId <= 0 || studentId > students.Count())
    {
        if (!studentIdIsInt)
            Console.WriteLine("\nSorry, that is not a valid Student ID Number.");
        else
            Console.WriteLine("\nSorry, that Student ID Number is out of range.");
        
        Console.WriteLine($"\nPlease input a whole number in the range of 1 - {students.Count()}:");
        
        studentIdIsInt = int.TryParse(Console.ReadLine(), out studentId);
    }

    Console.WriteLine($"\nStudent Found: {students[studentId - 1]}\n");
    Console.WriteLine("What information would you like to know?\n\nCategories:\n1. Hometown\n2. Favorite Food\n\nPlease enter a number for the corresponding category or type the category's name:");

    string input = Console.ReadLine();
    bool inputIsInt = int.TryParse(input, out int catNum);
    if (inputIsInt)
    {
        while (catNum <= 0 && catNum > categories.Count())
        {
            Console.WriteLine($"Sorry, your category number did not match our system.\nPlease type the category number in the range of 1-{students.Count()}:");
            inputIsInt = int.TryParse(Console.ReadLine(), out catNum);
        }
    }
    else
    {
        while (input.ToLower() != categories[0].ToLower() && input.ToLower() != categories[1].ToLower())
        {
            Console.WriteLine($"Sorry, your category name did not match our system.\nPlease type the category name as exactly '{categories[0]}' or '{categories[1]}':");
            input = Console.ReadLine();
        }
    }

    Console.WriteLine();


    if (catNum == 1 || input.ToLower() == categories[0].ToLower())
        Console.WriteLine($"{students[studentId - 1]}'s hometown is {hometown[studentId - 1]}.\n");
    else
        Console.WriteLine($"{students[studentId - 1]}'s favorite food is {favFood[studentId - 1]}.\n");

    Console.WriteLine($"\nPress ENTER to look up a different student. Press any other key to exit the program...");
    ConsoleKeyInfo key = Console.ReadKey();

    if (key.KeyChar != 13)
        continueLoop = false;
}

Console.WriteLine("\nThank you for trying our Demo! We look forward to hearing your feedback.");