using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestDeleteProduct
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();

        [Test, Order(1)]
        [TestCase("https://localhost:44366/")]
        public void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1500);
            Assert.Pass();
        }

        //TEST LUỒNG EDIT SẢN PHẨM
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
        [TestCase("UserEmail", "UserPassword", "ngockhanh@gmail.com", "123")]
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
        public void TestClickManagerProduct()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/ul[1]/li[4]/a[1]/span[2]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(6)]
        public void ScrollToDeleteTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1800);");
            Thread.Sleep(1000);
        }

        [Test, Order(7)]
        public void TestClickDeleteProduct()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/div[1]/table[1]/tbody[1]/tr[25]/td[5]/h6[2]/a[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(8)]
        public void TestClickDelete()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/div[1]/form[1]/div[1]/input[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(9)]
        public void SignOutAdmin()
        {
            IWebElement btnSignOut = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/div[1]/form[1]/div[1]/input[1]"));
            btnSignOut.Click();
        }

        [Test, Order(10)]
        [TestCase("UserEmail", "UserPassword", "khanh@gmail.com", "123456")]
        public void LoginCustomer(string txtName, string txtPass, string content, string contentP)
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

        [Test,Order(11)]
        public void ClickBtnXiaomi()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[2]/div[1]/div[1]/ul[1]/li[4]/a[1]/img[1]"));
            btn.Click();
        }

        [Test,Order(12)]
        public void Scroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 960);");
            Thread.Sleep(1000);
        }
    }
}
