using System;
using ArbitraryLib;
using ArbitraryLib.Processors;
using NUnit.Framework;

namespace ArbitraryTest
{
    [TestFixture]
    internal sealed  class GetEmptyTests
    {
        private IArbitraryGeneratorBag _sut;

        [SetUp]
        public void TestInitialize()
        {
            // mock:

            // software under test:
            _sut = ArbitratyPredefined.GetEmpty();
        }

        [Test]
        public void Empty_Throws_InvalidOperationException()
        {
            //Arrange

            //Act
            Assert.Throws<InvalidOperationException>(() => _sut.GetNew<int>());

            //Assert
        }
    }
}