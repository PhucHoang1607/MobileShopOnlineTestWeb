using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAddProduct
{
    [TestFixture]
    public class TestAddProduct
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
        [TestCase("MediaTek Helio G96")]
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
        [TestCase("8 GB")]
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
        [TestCase("128 GB")]
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
        [TestCase("6.67 inches")]
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
        [TestCase("Android 11, MIUI 12.5")]
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
        [TestCase("Camera góc rộng: 108 MP, f/1.9, PDAF")]
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
        [TestCase("5000mAh (typ)")]
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
        [TestCase("1080 x 2400 pixels (FullHD+)")]
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
        [TestCase("Xiaomi Redmi Note 11 Pro 5G 128GB")]
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
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }


        [Test, Order(18)]
        public void TestClickDiscount()
        {
            IWebElement btn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/form[1]/div[2]/div[1]/div[1]/input[4]"));
            if (btn != null)
            {
                btn.Click();
                Thread.Sleep(2500);
                Assert.IsNotNull(btn);
            }

        }

        [Test, Order(19)]
        [TestCase("100000")]
        public void TestInputDiscount(string content)
        {
            IWebElement element = driver.FindElement(By.Name("IntialPrice"));
            if (element != null)
            {
                element.SendKeys(content);
                Thread.Sleep(2500);
            }
            Assert.IsNotNull(element);
        }

        [Test, Order(20)]
        [TestCase("Hiệu năng ổn định cho mọi tác vụ - Snapdragon® 695 mạnh mẽ đi kèm 8GB RAM Sống động từng khung hình - Màn hình AMOLED 6.67\", FHD+ đem lại trải nghiệm hình ảnh hoàn hảo Chụp ảnh chuyên nghiệp - Cụm 3 camera sau lên đến 108MP đi kèm nhiều chế độ chụp tiện ích Thoải mái sử dụng không lắng lo - Viên pin lớn 5000mAh, sạc nhanh 67W")]
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

        [Test, Order(21)]
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
    }
}