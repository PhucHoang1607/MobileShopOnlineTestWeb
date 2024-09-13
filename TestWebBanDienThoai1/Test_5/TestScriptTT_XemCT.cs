using DocumentFormat.OpenXml.Wordprocessing;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebBanDienThoai1.ThuongHoangPhuc
{
    internal class TestScriptTT_XemCT
    {
        public IWebDriver dWebBanDienThoai;
        public IWebElement eSignIn, eUserName, ePassword, eBtnSignIn, eCategories, ePhone, eBtnAddToCart,
            eMinus, ePlus, eBtnBuy, eConBuy, eInputAddress, ePhone1, ePay, eSignOut, eCheckOrder, ePersonal;

        //Thanh toan don hang
        [Test]
        public void GioHang()
        {

            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(1000);

            dWebBanDienThoai.Manage().Window.Maximize();

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(1000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(1000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(1000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(1000);

            eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]"));
            eCategories.Click();
            Thread.Sleep(1000);


            IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
            js.ExecuteScript("window.scrollTo(0, 820);");
            Thread.Sleep(1000);

            ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[15]/a[1]/div[1]/img[1]"));
            ePhone.Click();
            Thread.Sleep(1000);

            js.ExecuteScript("window.scrollTo(0, 320);");

            ePlus = dWebBanDienThoai.FindElement(By.Id("counter-plus"));
            for (int i = 0; i < 3; i++)
            {
                ePlus.Click();
                Thread.Sleep(1000);
            }


            eMinus = dWebBanDienThoai.FindElement(By.Id("counter-minus"));
            eMinus.Click();
            Thread.Sleep(1000);

            js.ExecuteScript("window.scrollTo(0, 320);");

            eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
            eBtnAddToCart.Click();
            Thread.Sleep(1000);

            //
            eConBuy = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[2]/a[1]"));
            eConBuy.Click();
            Thread.Sleep(1000);

            eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]"));
            eCategories.Click();
            Thread.Sleep(1000);

            js.ExecuteScript("window.scrollTo(0, 740);");

            ePhone1 = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[9]/a[1]/div[1]/img[1]"));
            ePhone1.Click();
            Thread.Sleep(1000);

            eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
            eBtnAddToCart.Click();
            Thread.Sleep(1000);

            eBtnBuy = dWebBanDienThoai.FindElement(By.ClassName("order-button"));
            eBtnBuy.Click();
            Thread.Sleep(1000);

            js.ExecuteScript("window.scrollTo(0, 320);");

            eInputAddress = dWebBanDienThoai.FindElement(By.ClassName("order-address-input"));
            eInputAddress.SendKeys("123 Địa chỉ số 1, tp Hồ Chí Minh");
            Thread.Sleep(5000);

            ePay = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/form[1]/div[1]/div[2]/div[1]/button[1]"));
            ePay.Click();
            Thread.Sleep(1000);

            ePersonal = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[3]"));
            ePersonal.Click();
            Thread.Sleep(1000);

            eSignOut = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/a[4]/i[1]"));
            eSignOut.Click();

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("ngockhanh@gmail.com");
            Thread.Sleep(1000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123");
            Thread.Sleep(1000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(5000);

            eCheckOrder = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/ul[1]/li[5]/a[1]"));
            eCheckOrder.Click();
            Thread.Sleep(1000);



            //dWebBanDienThoai.Quit();


            Assert.Pass();
        }

        IWebElement eSearch, eBtnSearch;
        //[Test]
        public void TraCuuSPXemChiTiet()
        {
            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(1000);

            dWebBanDienThoai.Manage().Window.Maximize();

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(1000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(1000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(1000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(1000);

            eSearch = dWebBanDienThoai.FindElement(By.Name("searchString"));
            eSearch.SendKeys("OP");
            Thread.Sleep(1000);

            eBtnSearch = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/form[1]/button[1]/i[1]"));
            eBtnSearch.Click();
            Thread.Sleep(1000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
            js.ExecuteScript("window.scrollTo(0, 900);");
            Thread.Sleep(1000);

            ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/div[2]/div[5]/a[1]/div[1]/img[1]"));
            ePhone.Click();



        }
    }
}
