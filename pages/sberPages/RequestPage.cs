using System;
using OpenQA.Selenium;
using NLog;

namespace UnitTestProject1.pages.sberPages
{
    class RequestPage : BasePage
    {
        private IWebDriver driver;
        private Logger logger = LogManager.GetCurrentClassLogger();
        private By drawUpLocator = By.XPath(".//div[contains(@class,'product-teaser-full-width__button')]");

        public RequestPage(IWebDriver driver) : base(driver)
        {   
            logger.Info("Открыта страница страхования путешественников");
            try
            {
                this.driver = driver;
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }
        public void DrawUpButtonClick()
        {
            logger.Info("Нажата кнопка \"оформить онлайн\"");
            try
            {
                driver.FindElement(drawUpLocator).Click();
            }
            catch (Exception e)
            {
                logger.Info("Ошибка: " + e);
            }
        }
    }
}
