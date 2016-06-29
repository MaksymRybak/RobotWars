using NUnit.Framework;

namespace RobotWars.Tests
{
    [TestFixture]
    public class CompetitionBootstrapTests
    {
        private CompetitionBootstrap competitionBootstrap;

        [SetUp]
        public void SetUp()
        {
            competitionBootstrap = new CompetitionBootstrap(null, null, null, null, null);
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
