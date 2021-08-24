﻿using OpenQA.Selenium;
using M11_Dzianis_Dukhnou.WebDriver;
using M11_Dzianis_Dukhnou.Entities;
using M11_Dzianis_Dukhnou.WebElements;
using log4net;

namespace M11_Dzianis_Dukhnou.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//a[@href = 'https://360.yandex.ru/?from=mail-header-360']");

        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HomePage() : base(StartPageLocator, "Home Page")
        {
            Log.Info($"The {_title} is open");
        }

        private readonly BaseElement _sentItemsButton = new BaseElement(By.XPath("//span[text() = 'Отправленные']"));
        private readonly BaseElement _draftsButton = new BaseElement(By.XPath("//span[text() = 'Черновики']"));
        private readonly BaseElement _inboxButton = new BaseElement(By.XPath("//span[text() = 'Входящие']"));
        private readonly BaseElement _refreshButton = new BaseElement(By.XPath("//span[@data-click-action='mailbox.check']"));
        private readonly BaseElement _userIcon = new BaseElement(By.XPath("//div[contains(@class, 'user-pic user-pic')]"));
        private readonly BaseElement _userName = new BaseElement(By.XPath($"//span[text() ='{Configuration.UserID}']"));

        private BaseElement _writeButton = new BaseElement(By.XPath("//a[contains(@class, 'mail-ComposeButton')]"));

        public bool FindAccountIconByAccountName()
        {
            return _userName.IsElementDisplayed();
        }

        public InboxPage OpenInboxLetters()
        {
            _inboxButton.Click();

            return new InboxPage();
        }

        public SentPage OpenSentLetters()
        {
            _sentItemsButton.Click();

            return new SentPage();
        }

        public DraftPage OpenDraftLetters()
        {
            _draftsButton.Click();

            return new DraftPage();
        }

        public void Refresh()
        {
            _refreshButton.Click();
        }

        public LetterPage CreateNewLetter()
        {
            _writeButton = new JsDecorator(_writeButton);
            _writeButton.Click();

            return new LetterPage();
        }

        public void CreateNumberOfDraftLetters(int number, Letter letter)
        {
            LetterPage letterPage;

            for (int i = 0; i < number; i++)
            {
                letterPage = CreateNewLetter();
                letterPage.PopulateEmail(letter);
                letterPage.CloseLetter();
            }
        }

        public UserMenuPage OpenUserMenu()
        {
            _userIcon.Click();

            return new UserMenuPage();
        }
    }
}