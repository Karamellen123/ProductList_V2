// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

//using System.Text.RegularExpressions;

List<string> ProductLists = new List<string>();

MainMenu();

void printList()
{
    Console.WriteLine("Printing list");
    for (int i = 0; i < ProductLists.Count; i++)
        Console.WriteLine(i + ") " + ProductLists[i]);
}

string CorrectFormat()
{
    string letter_1;
    string letter_2;
    string hyphen = "-";
    string correctFormat;
    int number_1;
    int number_2;
    int number_3;
    
    Regex exitRegex = new Regex(@"\b(exit|quit|end)\b", RegexOptions.IgnoreCase);

    Console.WriteLine("Format CE-400 \n400 is between 200-500");
    string answer = Console.ReadLine();

    // Check if the input matches the pattern
    if (exitRegex.IsMatch(answer))
    {
        return "exit";
    }    

    //Checks the length of the entered data
    if(answer.Length != 6)
    {
        if (answer.Length == 5 && !answer.Contains(hyphen))
        {
            //If user forgot to add Hyphen " - "
            Console.WriteLine("Missing Hyphen");
            letter_1 = answer[0].ToString();
            letter_1 = letter_1.ToUpper();

            letter_2 = answer[1].ToString();
            letter_2 = letter_2.ToUpper();
            
            number_1 = int.Parse(answer[2].ToString());
            number_2 = int.Parse(answer[3].ToString());
            number_3 = int.Parse(answer[4].ToString());
            answer = letter_1 + letter_2 + hyphen + number_1 + number_2 + number_3;
        }
        else 
        {
            Console.WriteLine("Something went wrong please try agian.");
            CorrectFormat();
        }
    }

    if(answer != null)
    {
        letter_1 = answer[0].ToString();    
        letter_1 = letter_1.ToUpper();

        letter_2 = answer[1].ToString();
        letter_2 = letter_2.ToUpper();

        number_1 = int.Parse(answer[3].ToString());
        number_2 = int.Parse(answer[4].ToString());
        number_3 = int.Parse(answer[5].ToString());

        char temp1 = Convert.ToChar(letter_1);
        char temp2 = Convert.ToChar(letter_2);

        //Checks if number is within index
        if (number_1 >= 2 && number_1 <= 5 && char.IsLetter(temp1) && char.IsLetter(temp2))
        {
            correctFormat = letter_1 + letter_2 + hyphen + number_1 + number_2 + number_3;
            Console.WriteLine("Correct Format: " + correctFormat);
            return correctFormat;
        }
        else if(char.IsLetter(temp1) && char.IsLetter(temp2))
        {
            Console.WriteLine("Number is out of index");
            CorrectFormat();
        }
        else if((number_1 >= 2 && number_1 <= 5))
        {
            Console.WriteLine("Please check the 2 first letters again");
            CorrectFormat();
        }
        else
        {
            Console.WriteLine("Something went wrong. Have you enterd the product correctly? According to CE-400");
            CorrectFormat();
        }
    }
    return hyphen;

}

void AddProduct()
{
    Console.WriteLine("What product would you like to add? ");
    string temp = CorrectFormat();                                                
    //string temp = Console.ReadLine();

    //if (temp.Contains("exit"))
    Regex exitRegex = new Regex(@"\b(exit|quit|end)\b", RegexOptions.IgnoreCase);

    // Check if the input matches the pattern
    if (exitRegex.IsMatch(temp))
    {
        ProductLists.Sort();
        printList();

    }
    else
    {
        ProductLists.Add(temp);
        Console.WriteLine("You have added: " + temp + " to your product list");
        MainMenu();
    }
}

void MainMenu()
{
    AddProduct();
}