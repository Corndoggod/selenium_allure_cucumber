using System;
using OpenQA.Selenium;
using UnitTestProject1.pages.sberPages;
using NUnit.Allure.Steps;

namespace UnitTestProject1.steps.sberSteps
{
    class PersonSteps
    {
        private PersonPage person;

        public PersonSteps(IWebDriver driver)
        {
            person = new PersonPage(driver);
        }

        [AllureStep ("Выбран пункт меню {0}")]
        public void SelectMenuItem(string item)
        {
            person.SelectMenuItem(item);
        }

        [AllureStep ("Выбран подпункт меню {0}")]
        public void SelectSubMenuItem(string subitem)
        {
            person.SelectSubMenuItem(subitem);
        }
    }
}
