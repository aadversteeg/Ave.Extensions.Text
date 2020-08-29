using Ave.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace UnitTests.Extensions.Text
{
    public class Luhn32Tests
    {
        [Theory(DisplayName = "L-001: GetCheckSum should return correct check sum.")]
        [InlineData("BW7L2X7R4RRAN", 'V')]
        [InlineData("SHALM2JMHCEYY", 'Q')]
        [InlineData("435PYOXWDDHW2", 'D')]
        [InlineData("6UVNHCZNET4GA", 'Z')]
        [InlineData("PVMAG27UJZUO4", 'P')]
        [InlineData("RR5FHL6XWRC4M", '3')]
        [InlineData("47A5UF2C65GLH", 'S')]
        [InlineData("J6MCDUFZHSZOA", 'F')]

        public void L001(string base32, char expectedCheck)
        {
            // act
            var check = Luhn32.GetCheckSum(base32);

            // assert
            check.Should().Be(expectedCheck);
        }

        [Theory(DisplayName = "L-002: IsValid should return true when valid, otherwise false.")]
        [InlineData("BW7L2X7R4RRANV", true)]
        [InlineData("SHALM2JMHCEYYQ", true)]
        [InlineData("435PYOXWDDHW2D", true)]
        [InlineData("6UVNHCZNET4GAZ", true)]
        [InlineData("PVMAG27UJZUO4J", false)]
        [InlineData("RR5FHL6XWRC4MD3", false)]
        [InlineData("47A5UF2C65GLHA", false)]
        [InlineData("J6MCDUFZHSZOAC", false)]

        public void L002(string base32, bool expectedValid)
        {
            // act
            var isValid = Luhn32.IsValid(base32);

            // assert
            isValid.Should().Be(expectedValid);
        }
    }
}
