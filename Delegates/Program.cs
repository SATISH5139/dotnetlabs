using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Oops;

class program
{
    

    // Created a new datatype
    public delegate void PM(string requirement);
    static void Main()
    {
        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Hand Movement animation :: y-co-ordinate = {i}");
            }
        });
        t1.Name = "Hand animation";

        Thread t2 = new Thread(() =>
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Ball Movement animation :: y-co-ordinate = {i}");
            }
        });
        t2.Name = "Ball animation";

        //start the threads
        t1.Start();
        t2.Start();
        Thread.Sleep(3000);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("********* The game has completed!!!*********");
    }

    private static void LinqLambdaL2()
    {
        //Collection of Rectangles
        List<Rectangle> rectangles = new List<Rectangle>();
        rectangles.Add(new Rectangle(10, 5));
        rectangles.Add(new Rectangle(10, 3));
        rectangles.Add(new Rectangle(20, 7));
        rectangles.Add(new Rectangle(25, 5));

        //Query: Get all rectangles whose length = 10


        rectangles
            .Where((r) => { return r.lenght == 10; })
            .ToList()
            .ForEach((r) =>
            {
                Console.WriteLine($"Length: {r.lenght} | Breadth: {r.breadth}");
            });



        //Using LINQ ~ SQL in .net

        var searchedRectangles = from r in rectangles
                                 where r.lenght == 10
                                 select r;
        //Display
        searchedRectangles
            .ToList()
            .ForEach((r) =>
            {
                Console.WriteLine($"Output from LINQ recatngles Length x Breadth : {r.lenght} x {r.breadth}");
            });


        //Query: Get all rectangles whose breadth = 3

        rectangles
            .Where((r1) => { return r1.breadth == 3; })
            .ToList()
            .ForEach((r1) =>
            {
                Console.WriteLine($"Length: {r1.lenght} | Breadth: {r1.breadth}");
            });

        //display

        searchedRectangles
            .ToList()

            .ForEach((r1) =>
            {
                Console.WriteLine($"Output from LINQ recatngles whose  Length x Breadth : " +
                    $"{r1.lenght} x {r1.breadth}");
            });
        //Query: Get all rectangles whose length = 10 and breadth = 5
        //Query: Get all rectnagles whose area > 50
    }

    private static void simpleLinq()
    {
        List<string> names = new List<string>();
        names.Add("Meena");
        names.Add("Teena");
        names.Add("Reena");
        names.Add("Reena Chakarvarthy");
        names.Add("Thy");


        names.ForEach((str) =>
        {
            Console.WriteLine(str);
        });


        List<string> result = names.Where((str) =>
        {
            return str.StartsWith("Re") && str.EndsWith("thy");
            //return str.StartsWith("Re") || str.EndsWith("thy");


        }).ToList();
        Console.WriteLine("Search for 'Reena'");
        result.ForEach((str) =>
        {
            Console.WriteLine($"Found match for: {str}");
        });

        //LINQ => language Integerated Query == SQL in .Net


        Console.WriteLine("----Using LINQ----");
        var queryOutput = (from str in names
                           where str == "Reena" && str.Contains("Chakravarthy")
                           select str)
                          .ToList();
        queryOutput.ForEach((str) =>
        {
            Console.WriteLine(str);
        });
    }

    private static void CallDelegates()
    {
        // Object or INSTANTIATION OF DELEGATE
        PM Vimal = new PM((requirement) => { Console.WriteLine("I, Satish have attended Tax Training"); });
        Vimal += (requirement) => { Console.WriteLine("I, Anush have attended Tax Training"); };
        Vimal += (requirement) => { Console.WriteLine("I, Izhan have attended Tax Training"); };

        //Calling Vimal
        //INVOKING DELEGATE
        Vimal("Tax training for team");
    }

    private static void Izhan(string requirement)
    {
        Console.WriteLine("I, Izhan have attended Tax Training");
    }

    private static void Anush(string requirement)
    {
        Console.WriteLine("I, Anush have attended Tax Training");
    }

    private static void Satish(string requirement)
    {
        Console.WriteLine("I, Satish have attended Tax Training");
    }
}