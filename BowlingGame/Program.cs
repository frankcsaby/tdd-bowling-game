
using System;
using BowlingGame;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowling Game Score Calculator");
            Console.WriteLine("-----------------------------");

            Game game = new Game();
            bool gameOver = false;

            int frame = 1;
            int roll = 1;
            int previousPins = 0;
            int maxPinsAvailable = 10;

            try
            {
                while (!gameOver && frame <= 10)
                {
                    if (roll == 2 && frame < 10)
                    {
                        maxPinsAvailable = 10 - previousPins;
                    }
                    else
                    {
                        maxPinsAvailable = 10;
                    }

                    Console.WriteLine($"Frame {frame}, Roll {roll}");
                    Console.Write($"Enter pins knocked down (0-{maxPinsAvailable}): ");

                    if (int.TryParse(Console.ReadLine(), out int pins) && pins >= 0 && pins <= maxPinsAvailable)
                    {
                        game.Roll(pins);

                        if (pins == 10 && roll == 1 && frame < 10)
                        {
                            Console.WriteLine("Strike!");
                            frame++;
                            roll = 1;
                            previousPins = 0;
                        }
                        else if (roll == 2)
                        {
                            if (pins + previousPins == 10 && frame < 10)
                            {
                                Console.WriteLine("Spare!");
                            }

                            if (frame == 10)
                            {
                                if (pins + previousPins == 10 || previousPins == 10)
                                {
                                    roll++;
                                }
                                else
                                {
                                    gameOver = true;
                                }
                            }
                            else
                            {
                                frame++;
                                roll = 1;
                                previousPins = 0;
                            }
                        }
                        else if (roll == 3)
                        {
                            gameOver = true;
                        }
                        else
                        {
                            roll++;
                            previousPins = pins;
                        }

                        Console.WriteLine($"Current score: {game.Score()}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {maxPinsAvailable}.");
                    }
                }

                Console.WriteLine($"Game Over! Final score: {game.Score()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}