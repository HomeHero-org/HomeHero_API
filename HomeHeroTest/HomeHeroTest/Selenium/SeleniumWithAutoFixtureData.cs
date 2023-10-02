using AutoFixture;
using AutoFixture.Xunit2;
using OpenQA.Selenium;
using System.Net.Mail;
using Xunit.Abstractions;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;
using AutoFixture.AutoMoq;

namespace HomeHeroTest.Selenium
{
    public class SeleniumWithAutoFixtureData : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithAutoFixtureData(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;

        }

        
        [Fact]

        public void TestRegisterUserWithType()
        {
            var driver = webDriverFixture.EdgeDriver;
             driver
                .Navigate()
                .GoToUrl("http://localhost:3000/");
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var model = fixture.Build<RequestCreateDto>()
                             
                              .Create();

            driver.FindElement(By.Id("titulo")).SendKeys(model.RequestTitle);
            driver.FindElement(By.Id("fecha")).SendKeys(model.PublicationReqDate.ToString());
            driver.FindElement(By.Id("numMb")).SendKeys(model.MembersNeeded.ToString());
            driver.FindElement(By.Id("descripcion")).SendKeys(model.RequestContent);
            driver.FindElement(By.Id("imagen")).SendKeys("C:\\Users\\juanm\\OneDrive\\Imágenes\\Wallpapers\\1313972.jpeg");
            testOutputHelper.WriteLine("Test Completed");
        }
       
    }
}
