using LightInject;

namespace RobotWars
{
    public class RobotWarsCompetition
    {
        public static ServiceContainer serviceContainer;

        static RobotWarsCompetition()
        {
            serviceContainer = new ServiceContainer();
            serviceContainer.Register<ICompetitionBootstrap, CompetitionBootstrap>();
        }

        public static void Main(string[] args)
        {
            var competitionBootstrap = serviceContainer.GetInstance<ICompetitionBootstrap>();
            competitionBootstrap.Start(args);
        }
    }
}
