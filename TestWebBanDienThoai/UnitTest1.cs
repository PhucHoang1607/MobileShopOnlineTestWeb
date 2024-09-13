using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestWebBanDienThoai
{
   
    public class Tests
    {
        IWebDriver d1;
        IWebElement e1;
        [Test]
        public void KichBan1()
        {
            

            d1 = new ChromeDriver();
            d1.Navigate().GoToUrl("https://www.google.com.vn/?hl=vi");

        }
    }
}