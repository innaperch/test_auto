using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace POMExample.PageObjects
{
    class ResultPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='generated']")]
        public IWebElement Generated { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        public IList<IWebElement> List_of_paragraphs { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        public IWebElement Lipsum { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p[contains(text(), 'orem')]")]
        public IList<IWebElement> Lipsum_contains_Lorem { get; set; }
    }

}