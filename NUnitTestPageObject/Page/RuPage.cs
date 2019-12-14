using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace POMExample.PageObjects
{
    class RuPage
    {
        private IWebDriver driver;

        public RuPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Panes']/div[1]/p")]
        public IWebElement Panes { get; set; }
                     
    }
}