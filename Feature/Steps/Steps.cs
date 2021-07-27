using NUnit.Framework;
using TechTalk.SpecFlow;

namespace M11_Dzianis_Dukhnou.Feature.Steps
{
    [Binding]
    public class Steps : BaseSteps
    {

        #region Given methods

        [Given(@"I create a draft letter")]
        public void CreateDraftLetter()
        {
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();
        }

        [Given(@"The '(.*)' of letters created")]
        public void GivenTheOfLettersCreated(int number)
        {
            _homePage.CreateNumberOfDraftLetters(number, letter);
        }

        #endregion

        #region When methods

        [When(@"I click login button")]
        public void ClickLoginButton()
        {
            _loginPage = _startPage.ClickLogin();
        }

        [When(@"I login with credentials")]
        public void LoginWithCredentials()
        {
            _homePage = _loginPage.Login(user);
        }

        [When(@"I create new letter")]
        public void CreateNewLetter()
        {
            _letterPage = _homePage.CreateNewLetter();
        }

        [When(@"I populate TO, subject, and body")]
        public void PopulateTOSubjectAndBody()
        {
            _letterPage.PopulateEmail(letter);
        }

        [When(@"I close the letter")]
        public void CloseTheLetter()
        {
            _letterPage.CloseLetter();
        }

        [When(@"I open draft emails folder")]
        public void OpenDraftEmailsFolder()
        {
            _draftPage = _homePage.OpenDraftLetters();
        }

        [When(@"I open created draft email")]
        public void OpenCreatedDraftEmail()
        {
            _letterPage = _draftPage.OpenLetterByOrder(1);
        }

        [When(@"I click 'Send' button")]
        public void ClickSendButton()
        {
            _homePage = _letterPage.ClickSend();
        }

        [When(@"I open sent emails folder")]
        public void OpenSentEmailsFolder()
        {
            _sentPage = _homePage.OpenSentLetters();
        }

        [When(@"I perform right click on the letter")]
        public void RightClickOnTheLetterDraftFolder()
        {
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(1);
        }

        [When(@"I perform right click on the letter in '(.*)'")]
        public void RightClickOnTheLetterInSequence(int sequence)
        {
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(sequence);
        }

        [When(@"I move the letter to the Inbox folder")]
        public void MoveTheLetterToTheInboxFolder()
        {
            _rightClickMenuPage.MoveToInboxFolder();
        }

        [When(@"I open the Inbox folder")]
        public void OpenTheInboxFolder()
        {
            _inboxPage = _draftPage.BackToTheInboxFolder();
        }

        [When(@"I delete the letter")]
        public void DeleteTheLetter()
        {
            _draftPage = _rightClickMenuPage.Delete();
        }

        [When(@"I perform Scroll by '(.*)'")]
        public void PerformScrollByPixels(int pixels)
        {
            _draftPage.Scroll(pixels);
        }

        #endregion

        #region Then methods

        [Then(@"I see the MoveUp button")]
        public void VerifyTheMoveUpButton()
        {
            Assert.IsTrue(_draftPage.FindMoveUpButton(), "The MoveUp button doesn't appear");
        }

        [Then(@"I see the '(.*)' of emails has descresed by one")]
        public void VerifyTheNumberOfEmailsHasDescresedByOne(int number)
        {
            Assert.AreEqual(number - 1, _draftPage.CountDraftLetters(),
                "The count of draft letters was not decreased after deleting one letter");
        }

        [Then(@"I see the letter in the Inbox folder")]
        public void VerifyTheLetterInTheInboxFolder()
        {
            Assert.IsTrue(_inboxPage.FindLetterBySubject(letter._subject), "The Letter is not in the inbox folder");
        }

        [Then(@"I see the letter in the sent folder")]
        public void VerifyTheLetterInTheSentFolder()
        {
            Assert.IsTrue
                (
                _sentPage.FindLetterBySubject(letter._subject),
                "The letter is not in the Sent Folder"
                );
        }

        [Then(@"I don't see the letter in the draft folder")]
        public void VerifyTheLetterInTheDraftFolder()
        {
            Assert.IsFalse
                (
                _draftPage.FindLetterBySubject(letter._subject),
                "The letter is still in the draft folder"
                );
        }

        [Then(@"I see appropriate TO, subject, and body of the letter")]
        public void VerifyTOSubjectAndBodyOfTheLetter()
        {
            Assert.AreEqual(letter._emailTo, _letterPage.GetToField(), $"The Field TO doesn't have <{letter._emailTo}>");
            Assert.AreEqual(letter._subject, _letterPage.GetSubjectField(), $"The Field Subject doesn't have <{letter._subject}>");
            Assert.AreEqual(letter._message, _letterPage.GetMessageField(), $"The Field Message doesn't have <{letter._message}>");
        }

        [Then(@"I see the email in the draft folder")]
        public void VerifyTheEmailInTheDraftFolder()
        {
            Assert.IsTrue
                (
                _draftPage.FindLetterBySubject(letter._subject),
                "The letter is not in the draft folder"
                );
        }

        [Then(@"The Home page for the User Account should be opened")]
        public void VerifyUserAccountShouldBeOpened()
        {
            Assert.IsTrue(_homePage.FindAccountIconByAccountName(),
               "The login is not successful. Account Name has not been found!");
        }

        #endregion

    }
}