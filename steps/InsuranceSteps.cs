using System;
using TechTalk.SpecFlow;
using UnitTestProject1.steps.sberSteps;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [Binding]
    public class InsuranceSteps
    {
        IWebDriver driver;
        PersonSteps person;
        RequestSteps request;
        DrawUpSteps drawup;

        [Before]
        public void before()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            person = new PersonSteps(driver);
            request = new RequestSteps(driver);
            drawup = new DrawUpSteps(driver);
        }


        [When(@"выбран пункт меню ""(.*)""")]
        public void ЕслиВыбранПунктМеню(string item)
        {
            person.SelectMenuItem(item);
        }
        
        [When(@"выбран подпункт ""(.*)""")]
        public void ЕслиВыбранПодпункт(string item)
        {
            person.SelectSubMenuItem(item);
        }
        
        [When(@"выбрана ""(.*)"" сумма страховой защиты")]
        public void ЕслиВыбранаСуммаСтраховойЗащиты(string lvl)
        {
            drawup.SelectLlv(lvl);
        }
        
        [When(@"введены ""(.*)"", ""(.*)"", ""(.*)"" застрахованных")]
        public void ЕслиВведеныЗастрахованных(string surname, string name, string date)
        {
            drawup.FillInsuredData(surname, name, date);
        }
        
        [When(@"введены ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" страхователя")]
        public void ЕслиВведеныСтрахователя(string surname, string name, string middlename, string date, string gender)
        {
            drawup.FillInsurantData(surname, name, middlename, date, gender);
        }
        
        [When(@"введены ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ЕслиВведены(string series, string number, string date, string issuer)
        {
            drawup.FillPassData(series, number, date, issuer);
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"заголовок страницы содержит - ""(.*)""")]
        public void ТоЗаголовокСтраницыСодержит(string expected)
        {
            request.CheckPageTitle(expected);
        }
        
        [Then(@"нажать Оформить онлайн")]
        public void ТоНажатьОформитьОнлайн()
        {
            request.DrawUpButtonClick();
        }
        
        [Then(@"нажать Оформить")]
        public void ТоНажатьОформить()
        {
            drawup.DrawUp();
        }
        
        [Then(@"нажать Продолжить")]
        public void ТоНажатьПродолжить()
        {
            drawup.Submit();
        }
        
        [Then(@"появилось сообщение ""(.*)""")]
        public void ТоПоявилосьСообщение(string p0)
        {
            drawup.CheckAlert();
        }
    }
}
