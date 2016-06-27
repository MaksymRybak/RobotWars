using LightInject;
using Moq;
using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class RobotWarsCompetitionTests
    {
        private ServiceContainer _serviceContainer;
        private Mock<ICompetitionBootstrap> _competitionBootstrapMock;

        [SetUp]
        public void SetUp()
        {
            _serviceContainer = new ServiceContainer();

            _competitionBootstrapMock = new Mock<ICompetitionBootstrap>();
            _serviceContainer.Register(m => _competitionBootstrapMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _serviceContainer.Dispose();
        }

        [Test]
        public void Should_bootstrap_competition()
        {
            RobotWarsCompetition.serviceContainer = _serviceContainer;
            RobotWarsCompetition.Main(new []{ "" });

            _competitionBootstrapMock.Verify(m => m.Start(It.IsAny<string[]>()), Times.Exactly(1));
        }
    }
}
