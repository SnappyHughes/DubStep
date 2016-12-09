using System.Text.RegularExpressions;
using NUnit.Framework;

namespace DubStep
{
    public class StringHelper
    {
        public static string SingleSpace = " ";
        public static string DoubleSpace = "  ";
    }

    public abstract class DJ
    {
        public string RemixValue;
        public string RemixReplacement;

        public abstract string SongDecoder(string lyric);
    }

    public class DubStepDJ : DJ
    {
        public DubStepDJ(string remixValue, string remixReplacement)
        {
            RemixValue = remixValue;
            RemixReplacement = remixReplacement;
        }

        public override string SongDecoder(string lyric)
        {
            return Regex.Replace(lyric, "(WUB)+", " ").Trim();
        }
    }

    [TestFixture]
    public class DubStepSongDecoderTests
    {
        [Test]
        public void ItShouldReturnABC()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("ABC", dubstepDj.SongDecoder("WUBWUBABCWUB"));
        }

        [Test]
        public void ItShouldReturnR_L()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("R L", dubstepDj.SongDecoder("RWUBWUBWUBLWUB"));
        }

        [Test]
        public void ItShouldRemoveWubAtTheStartOfTheLyric()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("YourSpace", dubstepDj.SongDecoder("WUBYourSpace"));
        }
        
        [Test]
        public void ItShouldRemoveWubAtTheEndtOfTheLyric()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("Lyric", dubstepDj.SongDecoder("LyricWUB"));
        }
        
        [Test]
        public void ItShouldReplaceWubInTheMiddleOfTheLyricWithSpace()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("Hello World", dubstepDj.SongDecoder("HelloWUBWorld"));
        }
        
        [Test]
        public void ItShouldReplaceWubWubInTheMiddleOfTheLyricWithASingleSpace()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("Hello World", dubstepDj.SongDecoder("HelloWUBWUBWorld"));
        }
        
        [Test]
        public void ItShouldReplaceMultipleWubsInTheMiddleOfTheLyricWithASingleSpace()
        {
            var dubstepDj = new DubStepDJ("WUB", " ");

            Assert.AreEqual("Hello World", dubstepDj.SongDecoder("HelloWUBWUBWUBWorld"));
        }
    }
}
