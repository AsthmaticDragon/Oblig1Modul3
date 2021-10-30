using NUnit.Framework;
using Oblig1Modul3;


namespace PersonTestx
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() {Id = 23, FirstName = "Per"},
                Mother = new Person() {Id = 29, FirstName = "Lise"},
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Kasper",
                LastName = "Hjalp",
                DeathYear = 2057,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Kasper Hjalp (Id=1) Død: 2057";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}