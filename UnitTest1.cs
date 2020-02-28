using System;
using OpenQA.Selenium;
using UnitTestProject1.steps.sberSteps;
using UnitTestProject1.pages.yaPages;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace UnitTestProject1
{
    [TestFixture]
    [AllureNUnit]
    public class UnitTest1
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Before()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void After()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        [AllureTag("SberTest")]
        public void SberTest()
        {
            driver.Url = ("https://www.sberbank.ru/ru/person");

            PersonSteps person = new PersonSteps(driver);
            RequestSteps request = new RequestSteps(driver);
            DrawUpSteps drawup = new DrawUpSteps(driver);

            person.SelectMenuItem("Страхование");
            person.SelectSubMenuItem("Страхование путешественников");

            request.CheckPageTitle("Страхование путешественников");
            request.DrawUpButtonClick();

            drawup.SelectLlv("Минимальная");
            drawup.DrawUp();

            drawup.FillInsuredData("sur", "name", "12121999");
            drawup.FillInsurantData("стра", "хова", "тель", "10101999", "Женский");
            drawup.FillPassData("1234", "567890", "11122020", "оуфмс");
            drawup.Submit();
            drawup.CheckAlert();
            /*            PersonPage person = new PersonPage(driver);

                        person.SelectMenuItem("Страхование");
                        person.SelectSubMenuItem("путешественников");

                        RequestPage request = new RequestPage(driver);
                        Assert.IsTrue(request.GetTitle().Contains("Страхование путешественников"));
                        request.DrawUpButtonClick();

                        DrawUpPage drawup = new DrawUpPage(driver);
                        drawup.SelectLvl("Минимальная");
                        drawup.DrawUp();

                        drawup.FillInsuredData("sur", "name", "12121999");
                        drawup.FillInsurantData("стра", "хова", "тель", "10101999", "Женский");
                        drawup.FillPassData("1234", "567890", "11122020", "оуфмс");
                        drawup.Submit();
                        Assert.IsTrue(drawup.IsElemExist(By.XPath(".//span[contains(@class,'invalid-validate')]")));*/
        }

        [Test]
        [AllureTag("YaTVtest")]
        public void YandexTvTest()
        {
            driver.Url = ("https://yandex.ru");
            MainPage main = new MainPage(driver);
            main.SelectMenuItem("Маркет");

            MarketPage market = new MarketPage(driver);
            market.SelectMenuItem("Электроника");

            CategoryPage category = new CategoryPage(driver);
            category.SelectMenuItem("Телевизоры");

            SubCategoryPage tvPage = new SubCategoryPage(driver);
            tvPage.ToAdvancedFilter();

            FilterPage filter = new FilterPage(driver);
            filter.FillPriceBound(FilterPage.Sides.LEFT, "20000");
            filter.FilterByProducer("LG");
            filter.FilterByProducer("Samsung");
            filter.Apply();

            tvPage = new SubCategoryPage(driver);
            tvPage.ChangeVisibleAmount();
            String firstElem = tvPage.GetFirstElement().Text;
            tvPage.SearchProduct(firstElem);

            SubCategoryPage searchedTvPage = new SubCategoryPage(driver);
            Assert.IsTrue(firstElem.Equals(searchedTvPage.GetFirstElement().Text));
        }
        
        [Test]
        [AllureTag("YaHphTest")]
        public void YandexHphonesTest()
        {
            driver.Url = ("https://yandex.ru");
            MainPage main = new MainPage(driver);
            main.SelectMenuItem("Маркет");

            MarketPage market = new MarketPage(driver);
            market.SelectMenuItem("Электроника");

            CategoryPage category = new CategoryPage(driver);
            category.SelectMenuItem("Наушники");

            SubCategoryPage headphonesPage = new SubCategoryPage(driver);
            headphonesPage.ToAdvancedFilter();

            FilterPage filter = new FilterPage(driver);
            filter.FillPriceBound(FilterPage.Sides.LEFT, "5000");
            filter.FilterByProducer("Beats");
            filter.Apply();

            headphonesPage = new SubCategoryPage(driver);
            headphonesPage.ChangeVisibleAmount();
            String firstElem = headphonesPage.GetFirstElement().Text;
            headphonesPage.SearchProduct(firstElem);

            SubCategoryPage searchedHphonesPage = new SubCategoryPage(driver);
            Assert.IsTrue(firstElem.Equals(searchedHphonesPage.GetFirstElement().Text));
        }
    }
}
