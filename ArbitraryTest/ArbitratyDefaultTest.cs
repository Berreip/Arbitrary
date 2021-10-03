using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ArbitraryLib;
using ArbitraryLib.Processors;
using NUnit.Framework;

namespace ArbitraryTest
{
    [TestFixture]
    internal sealed class ArbitratyDefaultTest
    {
        private IArbitraryGeneratorBag _sut;

        [SetUp]
        public void TestInitialize()
        {
            // mock:

            // software under test:
            _sut = ArbitratyPredefined.GetDefault();
        }

        [Test]
        public void ReplaceGenerator()
        {
            //Arrange

            //Act
            _sut.RegisterGenerator(ArbitraryGeneratorPredefined.IntGenerator);

            //Assert
            Assert.Pass();
        }

        
        /// <summary>
        /// should not very few colision for 1000 requested int 
        /// </summary>
        [Test]
        [Repeat(1000)]
        public void Int_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<int>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<int>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }
        
        [Test]
        [Repeat(100)]
        public void Int_GetRange_Tests()
        {
            //Arrange

            //Act
            var range = _sut.GetNewRange<int>(1_000);
            
            //Assert
            Assert.AreEqual(1_000, range.Length);
            Assert.Greater(range.ToHashSet().Count, 990);
        }
        
          
        [Test]
        [Repeat(100)]
        public void Int_GetRange_DirectAccess_Tests()
        {
            //Arrange

            //Act
            var range = Arbitrary.GetNewRange<int>(1_000);
            
            //Assert
            Assert.AreEqual(1_000, range.Length);
        }
        
        [Test]
        [Repeat(100)]
        public void Int_GetNew_DirectAccess_Tests()
        {
            //Arrange

            //Act
            var _ = Arbitrary.GetNew<int>();
            
            //Assert
            Assert.Pass();
        }
        
        [Test]
        [Repeat(1000)]
        public void Uint_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<uint>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<uint>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }

        [Test]
        [Repeat(1000)]
        public void float_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<float>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<float>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }
        
        [Test]
        [Repeat(1000)]
        public void long_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<long>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<long>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }  
        
        [Test]
        [Repeat(1000)]
        public void double_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<double>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<double>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }
          
        [Test]
        public void char_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<char>();

            //Act
            for (var i = 0; i < 1_000_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<char>());
            }

            //Assert
            Assert.AreEqual(73, hashDuplicates.Count);
        }
           
        [Test]
        [Repeat(1000)]
        public void string_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<string>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<string>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }
        
        [Test]
        [Repeat(1000)]
        public void byte_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<byte>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<byte>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 150);
        }
        
        [Test]
        [Repeat(1000)]
        public void bool_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<bool>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<bool>());
            }

            //Assert
            Assert.AreEqual(2, hashDuplicates.Count);
        }
         
        [Test]
        [Repeat(1000)]
        public void DateTime_Tests()
        {
            //Arrange
            var minDate = DateTime.Now.AddYears(-21);
            var maxDate = DateTime.Now.AddYears(21);

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                var date = _sut.GetNew<DateTime>();
                
                //Assert
                Assert.Greater(date, minDate);
                Assert.Less(date, maxDate);
            }
        }
        
        [Test]
        [Repeat(1000)]
        public void Timespan_Tests()
        {
            //Arrange 
            var hashDuplicates = new HashSet<TimeSpan>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<TimeSpan>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }
         
        [Test]
        [Repeat(1000)]
        public void Guid_Tests()
        {
            //Arrange
            var hashDuplicates = new HashSet<Guid>();

            //Act
            for (var i = 0; i < 1000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<Guid>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 990);
        }  
        
        [Test]
        [Repeat(1000)]
        public void Enum_KnownColor_Tests()
        {
            //Arrange 
            var hashDuplicates = new HashSet<KnownColor>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<KnownColor>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 100);
        }
        
        
        [Test]
        [Repeat(1000)]
        public void Enum_ConsoleKey_Tests()
        {
            //Arrange 
            var hashDuplicates = new HashSet<ConsoleKey>();

            //Act
            for (var i = 0; i < 1_000; i++)
            {
                hashDuplicates.Add(_sut.GetNew<ConsoleKey>());
            }

            //Assert
            Assert.Greater(hashDuplicates.Count, 100);
        }
    }
}