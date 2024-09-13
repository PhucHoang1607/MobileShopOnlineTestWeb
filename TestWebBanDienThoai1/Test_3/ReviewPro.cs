using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestReviewProK
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();

        [Test, Order(1)]
        [TestCase("https://localhost:44366/")]
        public void TestOpenUrl(string url)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1500);
            Assert.Pass();
        }

        [Test, Order(2)]
        public void TestOpenAdmin()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div[3]/a/i"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(3)]
        [TestCase("UserEmail", "UserPassword", "danghuy123@gmail.com", "123456")]
        public void TestInputLogin(string txtName, string txtPass, string content, string contentP)
        {
            IWebElement txt = driver.FindElement(By.Name("UserEmail"));
            IWebElement txtP = driver.FindElement(By.Name("UserPassword"));
            if (txt != null)
            {
                txt.SendKeys(content);
                txtP.SendKeys(contentP);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(txt);
        }

        [Test, Order(4)]
        public void TestLogin()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[2]/form[1]/input[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(5)]
        public void TestClickPro()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/div[9]/div[1]/a[1]/div[1]/div[1]/h5[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(6)]
        public void TestClick()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[4]/div[1]/div[2]/form[1]/div[1]/span[1]/i[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(7)]
        public void ClearSDT()
        {
            driver.FindElement(By.Name("CommentContent")).SendKeys("Điện thoại xịn <3");
            Thread.Sleep(3500);

        }

        [Test, Order(8)]
        public void TestClickSend()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[4]/div[1]/div[2]/form[1]/button[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(3500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(9)]
        public void TestClick1()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[4]/div[1]/div[2]/form[1]/div[1]/span[1]/i[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }
    }
}