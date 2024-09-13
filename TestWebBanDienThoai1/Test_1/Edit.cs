using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.Intrinsics.Arm;

namespace TestEditProduct
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();

        [Test, Order(1)]
        [TestCase("https://localhost:44366/")]
        public void OpenUrl(string url)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
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
        public void TestClickEditProduct()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[5]/h6[1]/a[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }

        [Test, Order(7)]
        public void dasd()
        {
            driver.FindElement(By.Id("Chipset")).Clear();
            driver.FindElement(By.Id("Chipset")).SendKeys("Snapdragon 8+ Gen 1 (4 nm)");
            driver.FindElement(By.Id("Ram")).Clear();
            driver.FindElement(By.Id("Ram")).SendKeys("16G");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/input[2]")).Clear();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/input[2]")).SendKeys("Samsung Galaxy A10");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/textarea[1]")).Clear();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/textarea[1]")).SendKeys("Camera mắt thần bóng đêm Nightography - Bắt trọn mọi khoảng khắc\r\nMãn nhãn từng chi tiết - Màn hình 6.6\"\", Dynamic AMOLED 2X, 120Hz\r\nHiệu năng mạnh mẽ, xử lí thông minh - Snapdragon 8 Gen 1 (4 nm)\r\nThỏa sức trải nghiệm chỉ với một lần sạc - Viên pin 3700 mAh, sạc nhanh 45W, sạc không dây"); 
        }

        [Test, Order(8)]
        public void TestClickEditSave()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/button[1]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }
        }
    }
}