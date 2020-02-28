using System;
using OpenQA.Selenium;
using UnitTestProject1.pages.sberPages;
using NUnit.Allure.Steps;
using NUnit.Framework;

namespace UnitTestProject1.steps.sberSteps
{
    class RequestSteps
    {
        private RequestPage request;
        public RequestSteps(IWebDriver driver)
        {
            request = new RequestPage(driver);
        }

        [AllureStep("Нажата кнопка \"Оформить онлайн\"")]
        public void DrawUpButtonClick()
        {
            request.DrawUpButtonClick();
        }

        [AllureStep("Проверка заголовка на соответствие \"{0}\"")]
        public void CheckPageTitle(string expected)
        {
            Assert.IsTrue(request.GetTitle().Contains(expected));
        }
    }
}
