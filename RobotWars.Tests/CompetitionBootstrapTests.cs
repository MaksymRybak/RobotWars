using Moq;
using NUnit.Framework;
using RobotWars.Core.System.Logging;

namespace RobotWars.Tests
{
    [TestFixture]
    public class CompetitionBootstrapTests
    {
        private Mock<ILogWriter> logWriterMock;

        private CompetitionBootstrap competitionBootstrap;

        [SetUp]
        public void SetUp()
        {
            logWriterMock = new Mock<ILogWriter>();

            competitionBootstrap = new CompetitionBootstrap(null, null, null, null, null, logWriterMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            competitionBootstrap = null;
        }

        [Test]
        public void Should_bootstrap_competition()
        {
            // TODO: test passing not null value
            competitionBootstrap.Start(null);
        }
    }
}
