using OpenQA.Selenium.Edge;

namespace HomeHeroTest.Selenium
{
    public class WebDriverFixture : IDisposable
    {
        public EdgeDriver EdgeDriver { get;private set; }
        public WebDriverFixture()
        {          
            EdgeDriver = new EdgeDriver();
        }
        public void Dispose()
        {
            EdgeDriver.Dispose();
            EdgeDriver.Quit();                    
        }
    }
}
