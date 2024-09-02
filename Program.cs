using System;
using SplashKitSDK;

namespace RobotDodge
{
    public class Program
    {
        private static Window gameWindow;
        private static  RobotDodgeGame game; 
        public static void Main()
        {

            Console.WriteLine("Game Is Loading");
            gameWindow = new Window("RobotDodge Game", 600, 600);
            game = new RobotDodgeGame(gameWindow);

            while (game.Quit != true)
            {
                game.HandleInput();
                game.Update();
                game.Draw();
            }

        }
    }
}
