using OpenQA.Selenium;

namespace TodoTesting
{
    public class Tests
    {
        private  IWebDriver driver;
        private string _projectUrl = "http://localhost:4200/login";


        private readonly By _registerLink = By.XPath("//h1[@id='register']");
        private readonly By _usernameRegisterInput = By.XPath("//input[@id='inputUsername']");
        private readonly By _passwordRegisterInput = By.XPath("//input[@id='inputPassword']");
        private readonly By _registerBtn = By.XPath("//button[@id='reg']");
      

        private readonly By _usernameInput = By.XPath("//input[@id='username']");
        private readonly By _passwordInput = By.XPath("//input[@id='password']");
        private readonly By _loginBtn = By.XPath("//button[@id='login']");
        private readonly By _taskTitleInput = By.XPath("//input[@id='name']");
        private readonly By _taskDescInput = By.XPath("//input[@id='description']");
        private readonly By _priority = By.XPath("//select[@id='priority']");
        private readonly By _option = By.XPath("//option[@value='High']");
        private readonly By _addBtn = By.XPath("//button[@id='addTask']");
        private readonly By _deleteBtn = By.XPath("//button[@id='delete']");
        private readonly By _editBtn = By.XPath("//button[@id='edit']");
        private readonly By _saveBtn = By.XPath("//button[@id='save']");

        private readonly By _actualRegResult = By.XPath("//*[@id='reg-text']");
        private readonly By _actualLoginResult = By.XPath("//*[@id='greet-text']");  
        private readonly By _actualEditResult = By.XPath("//h1[@id='editTitle']");

        private readonly string usernameRegText = "testusername";
        private readonly string passwordRegText = "testpassword";
        private readonly string usernameText = "front";
        private readonly string passwordText = "end";
        private readonly string titleText = "test Title";
        private readonly string descText = "test desc";
        private readonly string titleEditText = "test title after edit";
        private readonly string descEditText = "test desc after edit";

        private string _expectedRegResult = "Account Registration";
        private  string _expectedLoginResult = "Welcome to the To Do App";
        private string _expectedEditResult = "Edit Task";

        private string _errorMessage = "This element does not exist";

        [SetUp]
        public void Setup()
        {
            driver=new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_projectUrl);
            Waits.ShouldLocate(driver,_projectUrl);
        }

        [Test]

        public void RegisterTest() 
        {
            var register = driver.FindElement(_registerLink);
            register.Click();

            Waits.WaitSomeTime(10);
            var actualRegResult = driver.FindElement(_actualRegResult).Text;
            Assert.AreEqual(_expectedRegResult, actualRegResult, _errorMessage);

            Waits.WaitSomeTime(3);
            var regUsername = driver.FindElement(_usernameRegisterInput);
            regUsername.Click();
            regUsername.SendKeys(usernameRegText);

            Waits.WaitSomeTime(3);
            var regPassword =driver.FindElement(_passwordRegisterInput);
            regPassword.Click();
            regPassword.SendKeys(passwordRegText);

            Waits.WaitSomeTime(3);
            var regBtn = driver.FindElement(_registerBtn);
            regBtn.Click();


        }

        [Test]
        public void LoginTest()
        {
            var username = driver.FindElement(_usernameInput);
            username.Click();
            username.SendKeys(usernameText);

            Waits.WaitSomeTime(3);
            var password = driver.FindElement(_passwordInput);
            password.Click();
            password.SendKeys(passwordText);

            Waits.WaitSomeTime(3);
            var loginBtn=driver.FindElement(_loginBtn);
            loginBtn.Click();

            Waits.WaitForElement(driver, _actualLoginResult);
            var actualLoginResult = driver.FindElement(_actualLoginResult).Text;
            Assert.AreEqual(_expectedLoginResult, actualLoginResult, _errorMessage);

        }

        [Test]
        public void AddTaskTest()
        {
            LoginTest();
            Waits.WaitSomeTime(3);

            var title = driver.FindElement(_taskTitleInput);
            title.Click();
            title.SendKeys(titleText);
            Waits.WaitSomeTime(3);

            var desc =driver.FindElement(_taskDescInput);
            desc.Click();
            desc.SendKeys(descText);
            Waits.WaitSomeTime(3);

            var priority = driver.FindElement(_priority);
            priority.Click();

            var option =driver.FindElement(_option);
            option.Click();
            Waits.WaitSomeTime(3);

            var add = driver.FindElement(_addBtn);
            add.Click();
        }

        [Test]
        public void RemoveTaskTest()
        { 
            LoginTest();
            var delete = driver.FindElement(_deleteBtn);
            delete.Click();
            
        }

        [Test]
        public void UpdateTaskTest()
        {
            LoginTest();
            var edit=driver.FindElement(_editBtn);
            edit.Click();
            Waits.WaitForElement(driver, _actualEditResult);
            var actualEditResult=driver.FindElement(_actualEditResult).Text;
            
            Assert.That(actualEditResult, Is.EqualTo(_expectedEditResult), _errorMessage);

            var title = driver.FindElement(_taskTitleInput);
            title.Click();
           
            title.SendKeys(titleEditText);

            var desc = driver.FindElement(_taskDescInput);
            desc.Click();
          
            desc.SendKeys(descEditText);

            var priority = driver.FindElement(_priority);
            priority.Click();

            var option = driver.FindElement(_option);
            option.Click();

            var save = driver.FindElement(_saveBtn);
            save.Click();

        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}