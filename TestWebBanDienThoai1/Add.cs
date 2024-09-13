using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAddProduct
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();

        [Test, Order(1)]
        [TestCase("https://localhost:44366/")]
        public void TestOpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1500);
            Assert.Pass();
        }


        //TEST LUỒNG ADD SẢN PHẨM
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
        public void TestClickAddProduct()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/p[1]/a[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(7)]
        [TestCase("Go Dau, Tan Quy, Tan Phu, Ho Chi Minh")]
        public void TestInputChipset(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Chipset"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(8)]
        [TestCase("dfgdfgdfg")]
        public void TestInputRam(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Ram"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(9)]
        [TestCase("asdasddgdfg")]
        public void TestInputRom(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Memory"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(10)]
        [TestCase("dfhdfhd")]
        public void TestInputSize(string content)
        {
            IWebElement element = driver.FindElement(By.Name("ScreenSize"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(11)]
        [TestCase("asdasdasd")]
        public void TestInputSystem(string content)
        {
            IWebElement element = driver.FindElement(By.Name("OS"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(12)]
        [TestCase("asdasd")]
        public void TestInputCamera(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Camera"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(13)]
        [TestCase("asdasd")]
        public void TestInputPin(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Pin"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(14)]
        [TestCase("adasd")]
        public void TestInputPixel(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Resolution"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(15)]
        [TestCase("asdas")]
        public void TestInputNameProduct(string content)
        {
            IWebElement element = driver.FindElement(By.Name("ProductName"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(16)]
        public void TestClickUp()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/input[2]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(17)]
        [TestCase("2500000")]
        public void TestInputPrice(string content)
        {
            IWebElement element = driver.FindElement(By.Name("Price"));
            if ( element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(18)]
        [TestCase("sdgadfgfdgsdfgsdfgs")]
        public void TestInputIntro(string content)
        {
            IWebElement element = driver.FindElement(By.Name("ProductIntroduction"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(19)]
        public void TestClickAdd()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/button[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }


        [Test, Order(20)]
        public void TestCheckProductAdd()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1200);");
            Thread.Sleep(1000);
        }
    }
}