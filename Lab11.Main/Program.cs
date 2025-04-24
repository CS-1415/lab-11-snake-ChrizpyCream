using Lab11;

Board biggest = new Board(54, 215);
Snake test = new Snake("me", 3, 2, biggest);

Console.WriteLine("Make the terminal full screen. Press any button to continue...");
Console.ReadKey();

Console.Clear();
AbstractGraphic2D.Display(biggest.Display);
AbstractGraphic2D.Display(test.Body);

bool playing = true;

while (playing)
{
    // Game loop
    while (test.IsAlive && !Console.KeyAvailable)
    {
        test.MoveForward();

        Console.Clear();
        AbstractGraphic2D.Display(biggest.Display);
        AbstractGraphic2D.Display(test.Body);
        Thread.Sleep(125);
    }

    // If snake dies
    if (!test.IsAlive)
    {
        Console.WriteLine("\nPress R to restart or Q to quit...");
        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.R && key != ConsoleKey.Q);

        if (key == ConsoleKey.R)
        {
            // Reset board and snake
            biggest = new Board(54, 215);
            test = new Snake("me", 3, 2, biggest);
            Console.Clear();
            AbstractGraphic2D.Display(biggest.Display);
            AbstractGraphic2D.Display(test.Body);
        }
        else if (key == ConsoleKey.Q)
        {
            playing = false;
        }
    }

    // Check input for movement
    if (Console.KeyAvailable)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D:
                test.TurnEast();
                break;
            case ConsoleKey.W:
                test.TurnNorth();
                break;
            case ConsoleKey.A:
                test.TurnWest();
                break;
            case ConsoleKey.S:
                test.TurnSouth();
                break;
        }
    }
}
