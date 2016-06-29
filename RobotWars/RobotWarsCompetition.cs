using System;
using LightInject;
using RobotWars.Core.Factories;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;
using RobotWars.DTO;
using RobotWars.System;

namespace RobotWars
{
    public class RobotWarsCompetition
    {
        public static ServiceContainer serviceContainer;

        static RobotWarsCompetition()
        {
            serviceContainer = new ServiceContainer();
            serviceContainer.Register<IConsoleWrapper, ConsoleWrapper>();
            serviceContainer.Register<ICompetitionBootstrap, CompetitionBootstrap>();
            
            // Factories
            serviceContainer.Register<IRobotFactory, RobotFactory>();
            serviceContainer.Register<IArenaFactory, ArenaFactory>();

            // Models (aka BOs)
            serviceContainer.Register<IBattleArena, BattleArena>();
            serviceContainer.Register<IRobot, Robot>();
            serviceContainer.Register<INavigationSystem, NavigationSystem>();
        }

        public static void Main(string[] args)
        {
            var console = serviceContainer.GetInstance<IConsoleWrapper>();

            InputCompetitionDataDTO competitionData = null;
            try
            {
                competitionData = ReadInputCompetitionData();
            }
            catch (Exception e)
            {
                console.WriteLine("Error in input data: {0}", e.Message);
                return;
            }

            var competitionBootstrap = serviceContainer.GetInstance<ICompetitionBootstrap>();
            competitionBootstrap.Start(competitionData);

            console.WriteLine("The End - press any key");
            console.ReadLine();
        }

        private static InputCompetitionDataDTO ReadInputCompetitionData()
        {
            var console = serviceContainer.GetInstance<IConsoleWrapper>();
            var inputData = new InputCompetitionDataDTO();

            var defaultArenaBottomLeftCoords = "0 0";
            if (!inputData.ArenaBottomLeftCoords.TryParseInputCoords(defaultArenaBottomLeftCoords))
                throw new Exception("Error reading bottom-left coordinates. Please try again.");

            console.Write(">>> Enter upper-right coordinates of the arena in the format [X Y] (e.g: 5 5): ");
            if (!inputData.ArenaUpperRightCoords.TryParseInputCoords(console.ReadArenaUpperRightCoords()))
                throw new Exception("Error reading upper-right coordinates. Please try again.");

            int robotIx = 1;
            bool enterNextRobotToDeploy = true;
            while (enterNextRobotToDeploy)
            {
                var robotToDeploy = new InputRobotDTO { Id = robotIx };

                console.WriteLine(">>> Enter robot # {0} configuration", robotIx);
                console.Write(">>> robot's position and orientation in the format [X Y Orientation:[N,S,E,W]] (e.g: 1 2 N): ");
                if (!robotToDeploy.TryParseInputLocationAndHeadingDirection(console.ReadRobotLocationAndHeadingDirection()))
                    throw new Exception("Error reading robot's position and orientation. Please try again.");

                console.Write(">>> robot's battle moves in the format [M1M2...Mn, where Mn:[L,R,M]] (e.g: LMLMLM): ");
                if (!robotToDeploy.TryParseInputBattleMoves(console.ReadRobotBattleMoves()))
                    throw new Exception("Error reading robot's battle moves. Please try again.");

                console.Write("Enter next robot to deploy [Y/N]?: ");
                var proceed = console.ReadLine();
                enterNextRobotToDeploy = proceed != null && proceed.Equals("Y", StringComparison.InvariantCultureIgnoreCase);

                inputData.RobotsToDeploy.Add(robotToDeploy);
                robotIx++;
            }

            return inputData;
        }
    }
}
