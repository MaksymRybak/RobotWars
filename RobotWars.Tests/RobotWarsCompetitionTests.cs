using LightInject;
using Moq;
using NUnit.Framework;
using RobotWars.Core.System;
using RobotWars.DTO;

namespace RobotWars.Tests
{
    [TestFixture]
    public class RobotWarsCompetitionTests
    {
        private ServiceContainer _serviceContainer;
        private Mock<IConsoleWrapper> _consoleWrapperMock;
        private Mock<ICompetitionBootstrap> _competitionBootstrapMock;

        [SetUp]
        public void SetUp()
        {
            _serviceContainer = new ServiceContainer();

            _competitionBootstrapMock = new Mock<ICompetitionBootstrap>();
            _consoleWrapperMock = new Mock<IConsoleWrapper>();
            _serviceContainer.Register(m => _competitionBootstrapMock.Object);
            _serviceContainer.Register(m => _consoleWrapperMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _serviceContainer.Dispose();
        }

        [Test]
        public void Should_bootstrap_competition()
        {
            _consoleWrapperMock.Setup(m => m.ReadArenaUpperRightCoords()).Returns("5 5");
            _consoleWrapperMock.Setup(m => m.ReadRobotLocationAndHeadingDirection()).Returns("1 2 N");
            _consoleWrapperMock.Setup(m => m.ReadRobotBattleMoves()).Returns("LMLMLMLMM");

            RobotWarsCompetition.serviceContainer = _serviceContainer;
            RobotWarsCompetition.Main(new []{ "" });

            _competitionBootstrapMock.Verify(m => m.Start(It.IsAny<InputCompetitionDataDTO>()), Times.Exactly(1));
        }

        [Test]
        public void Should_not_bootstrap_competition_if_arena_upper_right_coordinates_are_wrong()
        {
            _consoleWrapperMock.Setup(m => m.ReadArenaUpperRightCoords()).Returns("5");

            RobotWarsCompetition.serviceContainer = _serviceContainer;
            RobotWarsCompetition.Main(new[] { "" });

            _competitionBootstrapMock.Verify(m => m.Start(It.IsAny<InputCompetitionDataDTO>()), Times.Exactly(0));
        }

        [TestCase("1 2", "wrong heading")]
        [TestCase("wrongposition", "N")]
        public void Should_not_bootstrap_competition_if_robot_position_or_heading_are_wrong(string robotPosition, string robotHeading)
        {
            _consoleWrapperMock.Setup(m => m.ReadArenaUpperRightCoords()).Returns("5 5");
            _consoleWrapperMock.Setup(m => m.ReadRobotLocationAndHeadingDirection()).Returns(string.Format("{0} {1}", robotPosition, robotHeading));

            RobotWarsCompetition.serviceContainer = _serviceContainer;
            RobotWarsCompetition.Main(new[] { "" });

            _competitionBootstrapMock.Verify(m => m.Start(It.IsAny<InputCompetitionDataDTO>()), Times.Exactly(0));
        }
    }
}
