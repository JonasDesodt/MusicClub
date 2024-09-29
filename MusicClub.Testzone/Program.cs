using MusicClub.Testzone.Models;

namespace MusicClub.Testzone;

partial class Program
{
    static void Main(string[] args)
    {
        HelloFrom("Generated Code");

        var test = new AddressResult
        {
            AdditionalProperty = "test",
            PersonId = 1,
            PersonResult = new PersonResult()
        };




        Console.WriteLine(test.AdditionalProperty);

    }

    static partial void HelloFrom(string name);
}