using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace XamCalc.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void BasicSum()
        {
            //Wait for application start
            app.WaitForElement(c => c.Marked("Display"));

            //Enter a number
            app.Tap(c => c.Marked("1"));
            app.Tap(c => c.Marked("9"));

            //Enter operation
            app.Tap(c => c.Marked("+"));

            //Enter a second number
            app.Tap(c => c.Marked("5"));
            app.Tap(c => c.Marked("4"));

            //Get result
            app.Tap(c=>c.Marked("="));

            var result = app.Query(c => c.Marked("Display")).FirstOrDefault();
            if (result == null)
            {
                Assert.Fail("No display was found");return;
            }
            var display = result.Text;
            Assert.AreEqual("73",display,message:"Result was not as expected.");
        }

        [Test]
        public void Multiply()
        {
            app.Tap(x => x.Marked("5"));
            app.Tap(x => x.Marked("0"));
            app.Tap(x => x.Marked("1"));
            app.Screenshot("First");
            app.Tap(x => x.Marked("X"));
            app.Screenshot("Operation");
            app.Tap(x => x.Marked("2"));
            app.Tap(x => x.Marked("5"));
            app.Screenshot("Second");
            app.Tap(x => x.Marked("="));
            var displayText = app.WaitForElement(x => x.Marked("Display")).First().Text;
            app.Screenshot("Waited for view with class: FormsTextView with text: 12525 with marked: Display");
            Assert.AreEqual("12525",displayText);
        }
    }
}