string selection;
do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("8. Count Smiling Faces");
    Console.WriteLine("9. Highest In Geometric Sequence");
    Console.WriteLine("Q to Quit");
    System.Console.Write("Your input: ");
    selection = Console.ReadLine()!;

    if (selection != "q")
    {
        Console.Clear();
        switch (selection)
        {
            case "0": RunCalculateCircleArea(); break;
            case "1": RunRandomInRange(); break;
            case "2": RunToFizzBuzz(); break;
            case "3": RunFibonacciByIndex(); break;
            case "4": RunAskForNumberInRange(); break;
            case "5": RunIsPalindrome(); break;
            case "6": RunIsPalindromeAdvanced(); break;
            case "7": RunChartBar(); break;
            case "8": RunCountSmilingFaces(); break;
            case "9": RunHighestInGeometricSequence(); break;
            default: break;
        }

        Console.Write("Press any key to continue... ");
        Console.ReadKey();
    }
}
while (selection != "q");

#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius: ");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius)
{
    return radius * radius * Math.PI;
}
#endregion

#region Random in Range
void RunRandomInRange()
{
    int numberZeroCount = 0;
    int numberOneCount = 0;
    int numberTwoCount = 0;
    for (int i = 0; i < 1_000_000; i++)
    {
        int random = RandomInRange(0, 2);
        if (random == 0) { numberZeroCount++; }
        else if (random == 1) { numberOneCount++; }
        else { numberTwoCount++; }
    }
    System.Console.WriteLine($"The number 0: {numberZeroCount}");
    System.Console.WriteLine($"The number 1: {numberOneCount}");
    System.Console.WriteLine($"The number 2: {numberTwoCount}");
}

int RandomInRange(int min, int max)
{
    return Random.Shared.Next(min, max + 1);
}
#endregion

#region To Fizz Buzz
void RunToFizzBuzz()
{
    System.Console.Write("Enter your number: ");
    int number = int.Parse(Console.ReadLine()!);
    System.Console.WriteLine(ToFizzBuzz(number));
}
string ToFizzBuzz(int value)
{
    if (value % 15 == 0) { return "FizzBuzz"; }
    else if (value % 5 == 0) { return "Buzz"; }
    else if (value % 3 == 0) { return "Fizz"; }
    return value.ToString();
}
#endregion

#region Fibonacci by Index
void RunFibonacciByIndex()
{
    System.Console.Write("Enter your number for the fibonacci Sequence: ");
    int number = int.Parse(Console.ReadLine()!);
    System.Console.WriteLine($"The number is: {FibonacciByIndex(number)}");
}
ulong FibonacciByIndex(int value)
{
    ulong firstNumber = 0;
    ulong secondNumber = 1;
    ulong nextNumber = 0;
    int count = 0;
    if (value == 0) { return firstNumber; }
    else if (value == 1) { return secondNumber; }
    else
    {
        while (count != value - 1)
        {
            nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
            count++;
        }
    }
    return nextNumber;
}
#endregion

#region Ask for Number in Range
void RunAskForNumberInRange()
{
    AskForNumberInRange(5, 10);
}
int AskForNumberInRange(int min, int max)
{
    bool IsValid;
    int input;
    System.Console.WriteLine($"Please enter a value between {min} and {max}");
    do
    {
        input = int.Parse(Console.ReadLine()!);
        IsValid = input <= max && input >= min;
        if (!IsValid)
        {
            if (input > max)
            {
                System.Console.WriteLine($"Wrong number. Your input is too high. The maximum is {max}. Try again!");
            }
            else
            {
                System.Console.WriteLine($"Wrong number. Your input is too low. The minimum is {min}. Try again!");
            }
        }
    }
    while (!IsValid);
    System.Console.WriteLine("Thank you, your input is valid.");
    return input;
}
#endregion

#region Is a Palindrome
void RunIsPalindrome()
{
    System.Console.Write("Enter a Random string: ");
    string input = Console.ReadLine()!;
    System.Console.WriteLine($"Is it a Palindrome? {IsPalindrome(input)}");
}
bool IsPalindrome(string input)
{
    string reversInput = "";
    for (int i = input.Length; i > 0; i--)
    {
        reversInput += input[i - 1];
    }
    if (reversInput == input) { return true; }
    return false;
}
#endregion

#region  Is a Palindrome Advanced 
void RunIsPalindromeAdvanced()
{
    System.Console.Write("Enter a Random string: ");
    string input = Console.ReadLine()!.ToLower();
    System.Console.WriteLine($"Is it a Palindrome? {IsPalindromeAdvanced(input)}");
}
bool IsPalindromeAdvanced(string input)
{
    string reversInput = "";
    string chars = " ,-";
    for (int j = 0; j < input.Length; j++)
    {
        for (int k = 0; k < chars.Length; k++)
        {
            if (input[j] == chars[k])
            {
                input = input.Remove(j, 1);
                j--;
            }
        }
    }

    for (int i = input.Length; i > 0; i--)
    {
        reversInput += input[i - 1];
    }
    if (reversInput == input) { return true; }
    return false;
}
#endregion

#region Chart Bar
void RunChartBar()
{
    System.Console.Write("Enter your number for the char Bar: ");
    double input = double.Parse(Console.ReadLine()!);
    System.Console.WriteLine($"Your Chart bar is: {ChartBar(input)}");
}

string ChartBar(double value)
{
    string chartBar = "";
    value = Math.Floor(value * 10);
    System.Console.WriteLine(value);
    for (int i = 0; i < value; i++)
    {
        chartBar += "o";
    }
    while (chartBar.Length < 10)
    {
        chartBar += ".";
    }

    return chartBar;
}
#endregion

#region Count Smiling Faces
void RunCountSmilingFaces()
{
    System.Console.Write("Enter your String for the Smiling Faces: ");
    string input = Console.ReadLine()!;
    System.Console.WriteLine($"There were {CountSmilingFaces(input)} Smileys in your string!");
}
int CountSmilingFaces(string input)
{
    int count = 0;
    for (int i = 0; i < input.Length - 2; i++)
    {
        if (input.Substring(i, 3) == ":-)") { count++; }
    }
    return count;
}
#endregion

#region Highest In Geometric Sequence
void RunHighestInGeometricSequence()
{
    System.Console.Write("Enter double a: ");
    double a = double.Parse(Console.ReadLine()!);
    System.Console.Write("Enter double r: ");
    double r = double.Parse(Console.ReadLine()!);
    System.Console.Write("Enter the maximum: ");
    double max = double.Parse(Console.ReadLine()!);
    System.Console.WriteLine($"The highest Number is: {HighestInGeometricSequence(a, r, max)}");
}
double HighestInGeometricSequence(double a, double r, double max)
{
    int k = 0;
    double highestPossibleNumber = 0;
    if (r >= 1)
    {
        while (a * Math.Pow(r, k) <= max)
        {
            highestPossibleNumber = a * Math.Pow(r, k);
            k++;
        }
    }
    else
    {
        while (a * Math.Pow(r, k) >= max)
        {
            k++;
            highestPossibleNumber = a * Math.Pow(r, k);
        }  
    }
    return highestPossibleNumber;
}
#endregion
