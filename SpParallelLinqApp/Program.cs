using System.Threading.Channels;

List<int> numbers = new();

for(int i = 0; i < 20; i++)
    numbers.Add(i + 1);

/*
var squares = from n in numbers.AsParallel()
              select n * n;

foreach(var s in squares)
    Console.Write($"{s} ");
*/

// linq operators
var sq1 = from n in numbers
                    .AsParallel()
                    .AsOrdered()
          select n * n;

foreach(int s in sq1)
    Console.Write($"{s} ");

Console.WriteLine();

// methods
var sq2 = numbers.AsParallel()
       .AsOrdered()
       .Select(n => n * n)
       .AsUnordered();

foreach (int s in sq2)
    Console.Write($"{s} ");
