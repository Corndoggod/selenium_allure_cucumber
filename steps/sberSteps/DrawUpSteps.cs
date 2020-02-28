using System;
using OpenQA.Selenium;
using UnitTestProject1.pages.sberPages;
using NUnit.Allure.Steps;

namespace UnitTestProject1.steps.sberSteps
{
    class DrawUpSteps
    {
        private DrawUpPage drawup;

        public DrawUpSteps(IWebDriver driver)
        {
            drawup = new DrawUpPage(driver);
        }

        [AllureStep("Выбрана {0} сумма затрат")]
        public void SelectLlv(string lvl)
        {
            drawup.SelectLvl(lvl);
        }

        [AllureStep("Нажата кнопка \"Оформить\"")]
        public void DrawUp()
        {
            drawup.DrawUp();
        }
        

        [AllureStep("Введены данные застрахованных: {0}, {1}, {2}")]
        public void FillInsuredData(String surname, String name, String birthday)
        {
            drawup.FillInsuredData(surname, name, birthday);
        }

        [AllureStep("Введены данные страхователя: {0}, {1}, {2}, {4}")]
        public void FillInsurantData(String surname, String name, String middlename, String birthday, String gender)
        {
            drawup.FillInsurantData(surname, name, middlename, birthday, gender);
        }

        [AllureStep("Введены паспортные данные: {0}, {1}, {2}")]
        public void FillPassData(String series, String number, String date, String issuer)
        {
            drawup.FillPassData(series, number, date, issuer);
        }

        [AllureStep("Нажата кнопка \"Продолжить\"")]
        public void Submit()
        {
            drawup.Submit();
        }

        [AllureStep("Проверка наличия предупреждающего сообщения")]
        public void CheckAlert()
        {
            drawup.CheckAlert();
        }
    }
}
