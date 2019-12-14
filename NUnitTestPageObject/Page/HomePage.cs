using OpenQA.Selenium;

using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;


namespace POMExample.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
                
        [FindsBy(How = How.XPath, Using = "//*[@id='Panes']/div[1]/p")]
        public IWebElement Panes_1 { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//*[@id='generate']")]
        private IWebElement Generate { get; set; }
        public void clickOnGenerate()
        { Generate.Click(); }

        [FindsBy(How = How.Name, Using = "amount")]
        public IWebElement Amount;
       
        public void clearAmount()
        {  Amount.Clear();  }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='bytes']")]
        private IWebElement Bytes;
        public void clickOnBytes()
        { Bytes.Click(); }

        [FindsBy(How = How.LinkText, Using = "Pyccкий")]
        private IWebElement Ru;
        public void clickOnRuLink()
        { Ru.Click(); }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://lipsum.com/");
        }
        
        public ResultPage goToResultPage()
        {
            Generate.Click();
            return new ResultPage(driver);
        }
        public RuPage goToRuPage()
        {
            Ru.Click();
            return new RuPage(driver);
        }
   
        }
    }
