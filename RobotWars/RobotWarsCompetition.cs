using System;
using log4net;
using log4net.Config;
using LightInject;
using RobotWars.Core.Factories;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;
using RobotWars.Core.System.Logging;
using RobotWars.DTO;

namespace RobotWars
{
    public class RobotWarsCompetition
    {
        public static ServiceContainer serviceContainer;

        static RobotWarsCompetition()
        {
            //XmlConfigurator.Configure(new MemoryStream(Encoding.UTF8.GetBytes(configHelper.GetLog4NetConfig())));
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            GlobalContext.Properties["log4japp"] = "RobotWars";
            GlobalContext.Properties["UserName"] = Environment.UserName;

            serviceContainer = new ServiceContainer();
            serviceContainer.Register(s => serviceContainer);
            serviceContainer.Register<IConsoleWrapper, ConsoleWrapper>();
            serviceContainer.Register<ICompetitionBootstrap, CompetitionBootstrap>();
            
            // System
            serviceContainer.Register<ILogWriter, LogWriter>();

            // Factories
            serviceContainer.Register<IFactory, Factory>();
            serviceContainer.Register<IRobotFactory, RobotFactory>();
            serviceContainer.Register<IArenaFactory, ArenaFactory>();

            // Models (aka BOs)
            serviceContainer.Register<IBattleArena, BattleArena>();            
            serviceContainer.Register<INavigationSystem, NavigationSystem>();
            serviceContainer.Register<IRobot, Robot>();
            serviceContainer.Register<IRobotPosition, RobotPosition>();
            serviceContainer.Register<IArenaCoordinates, ArenaCoordinates>();
            serviceContainer.Register<ICompass, Compass>();
        }

        public static void Main(string[] args)
        {
            var logWriter = serviceContainer.GetInstance<ILogWriter>();
            var console = serviceContainer.GetInstance<IConsoleWrapper>();

            InputCompetitionDataDTO competitionData = null;
            try
            {
                competitionData = ReadInputCompetitionData();
            }
            catch (Exception e)
            {
                console.WriteLine("Error in input data: {0}", e.Message);
                logWriter.LogError("Error reading input data", e);
                return;
            }

            var competitionBootstrap = serviceContainer.GetInstance<ICompetitionBootstrap>();
            competitionBootstrap.Start(competitionData);

            console.WriteLine("The End: press Enter to exit");
            console.ReadLine();
        }

        private static InputCompetitionDataDTO ReadInputCompetitionData()
        {
            var console = serviceContainer.GetInstance<IConsoleWrapper>();
            var inputData = new InputCompetitionDataDTO();

            var defaultArenaBottomLeftCoords = "0 0";
            inputData.ArenaBottomLeftCoords.TryParseInputCoords(defaultArenaBottomLeftCoords);

            console.Write(">>> Enter upper-right coordinates of the arena in the format [X Y] (e.g: 5 5): ");
            inputData.ArenaUpperRightCoords.TryParseInputCoords(console.ReadArenaUpperRightCoords());

            int robotIx = 1;
            bool enterNextRobotToDeploy = true;
            while (enterNextRobotToDeploy)
            {
                var robotToDeploy = new InputRobotDTO { Id = robotIx };

                console.WriteLine(">>> Enter robot # {0} configuration", robotIx);
                console.Write(">>> robot's position and orientation in the format [X Y Orientation:[N,S,E,W]] (e.g: 1 2 N): ");
                robotToDeploy.TryParseInputLocationAndHeadingDirection(console.ReadRobotLocationAndHeadingDirection());

                console.Write(">>> robot's battle moves in the format [M1M2...Mn, where Mn:[L,R,M]] (e.g: LMLMLM): ");
                robotToDeploy.TryParseInputBattleMoves(console.ReadRobotBattleMoves());

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
