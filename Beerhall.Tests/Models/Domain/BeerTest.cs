using System;
using Beerhall.Models.Domain;
using NUnit.Framework;
using Xunit;

namespace Beerhall.Tests.Models.Domain
{
    public class BeerTest
    {
        [Xunit.Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        public void NewBeer_WrongName_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Beer(name));
        }

        [Fact]
        public void AlcoholKnown_AlcoholByVolumeNotSet_ReturnsFalse()
        {
            var beer = new Beer("New beer");
            Assert.False(beer.AlcoholKnown);
        }

        [Fact]
        public void AlcoholKnown_AlcoholByVolumeSet_ReturnsTrue()
        {
            var beer = new Beer("New beer") {AlcoholByVolume = 8.5D};
            Assert.True(beer.AlcoholKnown);
        }
    }
}