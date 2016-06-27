namespace RobotWars
{
    public interface ICompetitionBootstrap
    {
        void Start(string[] args);
    }

    public class CompetitionBootstrap : ICompetitionBootstrap
    {
        private readonly GameConsole _gameConsole;

        public CompetitionBootstrap()
        {
            _gameConsole = new GameConsole();    
        }

        public void Start(string[] args)
        {
            // TODO: pars args
            _gameConsole.StartCompetition();
            _gameConsole.EndCompetition();
            _gameConsole.VisualizeCompetitionResults();
        }
    }
}
