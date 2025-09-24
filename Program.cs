using System;
using System.Threading;

class RainSimulation
{
    static void Main()
    {
        // Rain frames
        string[] rainFrames = new string[]
        {
            @"
|     |  | |   |     | |  |
  | |     |    | | |     |
|   |  |     |   |    |   |
  |   | | |    |    |  |
|     |    |  |   | |   | |
  | |   |    |  |    |
|   |   | |   |   |    |  ",

            @"
  | |     |    | | |     |
|   |  |     |   |    |   |
  |   | | |    |    |  |
|     |    |  |   | |   | |
  | |   |    |  |    |
|   |   | |   |   |    |  
|     |  | |   |     | |  |",

            @"
|   |  |     |   |    |   |
  |   | | |    |    |  |
|     |    |  |   | |   | |
  | |   |    |  |    |
|   |   | |   |   |    |  
|     |  | |   |     | |  |
  | |     |    | | |     |"
        };

        // Simple car design
        string[] car = new string[]
        {
            "     ______",
            " ___/[] [] \\___",
            "|_           _|",
            "  (o)----- (o)"
        };

        int windowWidth = Console.WindowWidth;
        int carX = -20; // Start car off-screen
        Console.CursorVisible = false;

        for (int frameIndex = 0; frameIndex < 200; frameIndex++)
        {
            Console.Clear();

            // Draw rain
            string rain = rainFrames[frameIndex % rainFrames.Length];
            Console.SetCursorPosition(0, 0);
            Console.Write(rain);

            // Draw car
            DrawCar(car, carX);

            // Move car
            carX++;
            if (carX > windowWidth)
            {
                carX = -car[0].Length; // reset off-screen
            }

            Thread.Sleep(120);
        }

        Console.CursorVisible = true;
    }

    static void DrawCar(string[] carArt, int x)
    {
        int y = 8; // Car appears below the rain
        for (int i = 0; i < carArt.Length; i++)
        {
            int lineX = x;
            string line = carArt[i];

            if (lineX < 0)
            {
                // Clip left part if car is partially off-screen
                int skip = -lineX;
                if (skip >= line.Length) continue;
                line = line.Substring(skip);
                lineX = 0;
            }

            if (lineX + line.Length > Console.WindowWidth)
            {
                // Clip right part if car is partially off-screen
                line = line.Substring(0, Console.WindowWidth - lineX);
            }

            Console.SetCursorPosition(lineX, y + i);
            Console.Write(line);
        }
    }
}
