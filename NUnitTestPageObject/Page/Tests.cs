using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Case
{
    public class TestClass
    {
        private IWebDriver driver;
                
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Verify_the_presence()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();
            RuPage RU = home.goToRuPage();
            Assert.IsTrue(RU.Panes.Text.Contains("рыба"));
            Assert.Pass();
        }
        [Test]
        public void Fail_if_avg_less_3()
        {
            int[] paragraph = new int[10];
            for (int i = 0; i < 10; i = i + 1)
            {
                HomePage home = new HomePage(driver);
                ResultPage result = new ResultPage(driver);
                home.goToPage();
                home.clickOnGenerate();
                IList<IWebElement> all = result.Lipsum_contains_Lorem;
                var list_of_paragraphs = all.Count;
                Console.WriteLine(list_of_paragraphs);
                paragraph[i] = list_of_paragraphs;
            }
            int sum = paragraph.Sum();
            Console.WriteLine("Sum:" + sum);
            var avg = sum / 10;
            Console.WriteLine("Average:" + avg);
            Assert.IsTrue(avg >= 3);
            
        }
        [Test]
        public void Verify_result_has_paragraphs()
        {
            HomePage home = new HomePage(driver);
            ResultPage result = new ResultPage(driver);
            home.goToPage();
            home.clearAmount();
            home.Amount.SendKeys("10");
            home.clickOnGenerate();
            IList<IWebElement> list = result.List_of_paragraphs; 
            int sum = list.Count;
            Assert.IsTrue(sum == 10);
            //Repeat
            int[] number_of_paragraphs = { -1, 0, 5, 20 };
            for (int i = 0; i < number_of_paragraphs.Length; i = i + 1)
            {
                home.goToPage();
                home.clearAmount();
                var string_number_of_paragraphs = number_of_paragraphs[i].ToString();
                home.Amount.SendKeys(string_number_of_paragraphs);
                home.clickOnGenerate();
                {
                    IList<IWebElement> list1 = result.List_of_paragraphs;
                    int sum_of_paragraphs = list1.Count;
                    if (number_of_paragraphs[i] <= 0)
                    {
                        number_of_paragraphs[i] = 5;
                    }
                    Assert.AreEqual(sum_of_paragraphs, number_of_paragraphs[i]);
                    Console.WriteLine(sum_of_paragraphs + "with" + number_of_paragraphs[i]);
                }
            }
        }
        [Test]
        public void Verify_result_has_characters()
        {
            HomePage home = new HomePage(driver);
            ResultPage result = new ResultPage(driver);
            home.goToPage();
            home.clickOnBytes();
            home.clearAmount();
            home.Amount.SendKeys("100");
            home.clickOnGenerate();
            Assert.IsTrue(result.Generated.Text.Contains("100 bytes"));
            //Repeat
            int[] number_of_characters = { -1, 0, 140, 141 };
            for (int i = 0; i < 4; i = i + 1)
            {
                home.goToPage();
                home.clearAmount();
                home.clickOnBytes();
                var string_number_of_characters = number_of_characters[i].ToString();
                home.Amount.SendKeys(string_number_of_characters);
                home.clickOnGenerate();
                var generated = result.Lipsum.Text.Length;
                if (number_of_characters[i] <= 0)
                {
                    number_of_characters[i] = 27;
                }
                Assert.AreEqual(generated, number_of_characters[i]);
                Console.WriteLine(generated + " with " + number_of_characters[i]);
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }
}

