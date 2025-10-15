// See https://aka.ms/new-console-template for more information
using Technika_dotnet;

Console.WriteLine("Witamy w Programie xyz do oceny Pracowników");
Console.WriteLine("===========================================");
Console.WriteLine();

var employee = new Employee();

while (true)
{
    Console.WriteLine("Podaj kolejną liczbę, lub \'q\', aby zakończyć program");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    else
    {
        employee.AddGrade(input);
    }
}

var statistics = employee.GetStatistics();
Console.WriteLine($"Imię: {employee.Name}, Nazwisko: {employee.Surname}, Letter: {statistics.Letter}, Średnia: {statistics.Average:N2}, Max: {statistics.Max}, Min: {statistics.Min}");