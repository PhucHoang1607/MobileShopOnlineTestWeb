using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Edge;
using DocumentFormat.OpenXml.Bibliography;
using ClosedXML.Excel;

namespace TestWebBanDienThoai1
{
    public class Tests
    {
        public IWebDriver dWebBanDienThoai;
        public IWebElement eSignIn,eUserName, ePassword, eBtnSignIn, eCategories, ePhone, eBtnAddToCart, 
            eMinus, ePlus, eBtnBuy, eConBuy,eInputAddress, ePhone1, ePay, eSignOut, eCheckOrder;

        //Thanh toan don hang
        //[Test]
        //public void ThanhToanDonHang()
        //{
           
        //    dWebBanDienThoai = new ChromeDriver();
        //    dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
        //    Thread.Sleep(2000);

        //    dWebBanDienThoai.Manage().Window.Maximize();

        //    eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
        //    eSignIn.Click();
        //    Thread.Sleep(2000);

        //    eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
        //    eUserName.SendKeys("khanh@gmail.com");
        //    Thread.Sleep(2000);

        //    ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
        //    ePassword.SendKeys("123456");
        //    Thread.Sleep(2000);

        //    eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
        //    eBtnSignIn.Click();
        //    Thread.Sleep(2000);

        //    eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]"));
        //    eCategories.Click();
        //    Thread.Sleep(2000);


        //    IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
        //    js.ExecuteScript("window.scrollTo(0, 620);");
        //    Thread.Sleep(1000);

        //    ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[1]/a[1]/div[1]/img[1]"));
        //    ePhone.Click();
        //    Thread.Sleep(1000);

        //    js.ExecuteScript("window.scrollTo(0, 320);");

        //    ePlus = dWebBanDienThoai.FindElement(By.Id("counter-plus"));
        //    for(int i = 0; i < 3; i++)
        //    {
        //        ePlus.Click();
        //        Thread.Sleep(1000);
        //    }


        //    eMinus = dWebBanDienThoai.FindElement(By.Id("counter-minus"));
        //    eMinus.Click();
        //    Thread.Sleep(2000);

        //    js.ExecuteScript("window.scrollTo(0, 320);");

        //    eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
        //    eBtnAddToCart.Click();
        //    Thread.Sleep(1000);

        //    //
        //    eConBuy = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[2]/a[1]"));
        //    eConBuy.Click();
        //    Thread.Sleep(1000);

        //    eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]"));
        //    eCategories.Click();
        //    Thread.Sleep(2000);

        //    js.ExecuteScript("window.scrollTo(0, 740);");

        //    ePhone1 = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[9]/a[1]/div[1]/img[1]"));
        //    ePhone1.Click();
        //    Thread.Sleep(2000);

        //    eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
        //    eBtnAddToCart.Click();
        //    Thread.Sleep(2000);

        //    eBtnBuy = dWebBanDienThoai.FindElement(By.ClassName("order-button"));
        //    eBtnBuy.Click();
        //    Thread.Sleep(2000);

        //    js.ExecuteScript("window.scrollTo(0, 320);");

        //    eInputAddress = dWebBanDienThoai.FindElement(By.ClassName("order-address-input"));
        //    eInputAddress.SendKeys("123 Địa chỉ số 1, tp Hồ Chí Minh");
        //    Thread.Sleep(5000);

        //    ePay = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/form[1]/div[1]/div[2]/div[1]/button[1]"));
        //    ePay.Click();
        //    Thread.Sleep(1000);

        //    ePersonal = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[3]"));
        //    ePersonal.Click();
        //    Thread.Sleep(2000);

        //    eSignOut = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/a[4]/i[1]"));
        //    eSignOut.Click();

        //    eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
        //    eUserName.SendKeys("ngockhanh@gmail.com");
        //    Thread.Sleep(2000);

        //    ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
        //    ePassword.SendKeys("123");
        //    Thread.Sleep(2000);

        //    eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
        //    eBtnSignIn.Click();
        //    Thread.Sleep(2000);

        //    eCheckOrder = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/ul[1]/li[5]/a[1]"));
        //    eCheckOrder.Click();
        //    Thread.Sleep(2000);



        //    //dWebBanDienThoai.Quit();


        //    Assert.Pass();
        //}

        IWebElement eSearch, eBtnSearch;
        //[Test]
        public void TraCuuSPXemChiTiet()
        {
            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(2000);

            dWebBanDienThoai.Manage().Window.Maximize();

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(2000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(2000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(2000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(2000);

            eSearch = dWebBanDienThoai.FindElement(By.Name("searchString"));
            eSearch.SendKeys("OP");
            Thread.Sleep(2000);

            eBtnSearch = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/form[1]/button[1]/i[1]"));
            eBtnSearch.Click();
            Thread.Sleep(2000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
            js.ExecuteScript("window.scrollTo(0, 900);");
            Thread.Sleep(1000);

            ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/div[2]/div[5]/a[1]/div[1]/img[1]"));
            ePhone.Click();



        }

        

        public IWebElement eDeleteProduct, eBack1;

        //Xoa San Pham Khoi gio hang
        //[Test]
        public void XoaSanPhamKhoiGioHang()
        {
            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(2000);

            dWebBanDienThoai.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(2000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(2000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(2000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(2000);

            eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/ul[1]/li[1]/a[1]"));
            eCategories.Click();
            Thread.Sleep(2000);


            IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
            js.ExecuteScript("window.scrollTo(0, 620);");
            Thread.Sleep(1000);

            ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[1]/a[1]/div[1]/img[1]"));
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
            Thread.Sleep(2000);

            js.ExecuteScript("window.scrollTo(0, 320);");

            eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
            eBtnAddToCart.Click();
            Thread.Sleep(1000);

            eDeleteProduct = dWebBanDienThoai.FindElement(By.ClassName("delete-product-cart"));
            eDeleteProduct.Click();
            Thread.Sleep(2000);

            eBack1 = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/a[1]"));
            eBack1.Click();
            Thread.Sleep(2000);

            dWebBanDienThoai.Quit();

        }


        public IWebElement eQuantity3;
        //Them so luong san pham trong gio hang
        //[Test]
        public void ThemSoLuongSP()
        {
            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(2000);

            dWebBanDienThoai.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(2000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(2000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(2000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(2000);

            eCategories = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[2]/div[1]/div[1]/ul[1]/li[1]/a[1]/img[1]"));
            eCategories.Click();
            Thread.Sleep(2000);


            IJavaScriptExecutor js = (IJavaScriptExecutor)dWebBanDienThoai;
            js.ExecuteScript("window.scrollTo(0, 720);");
            Thread.Sleep(1000);

            ePhone = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[3]/div[2]/div[3]/a[1]/div[1]/img[1]"));
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
            Thread.Sleep(2000);

            js.ExecuteScript("window.scrollTo(0, 320);");

            eBtnAddToCart = dWebBanDienThoai.FindElement(By.ClassName("add-to-cart-btn"));
            eBtnAddToCart.Click();
            Thread.Sleep(1000);

            eQuantity3 = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[3]/div[1]/input[2]"));
            eQuantity3.Click();
            eQuantity3.Clear();
            Thread.Sleep(1000);
            eQuantity3.SendKeys("7");
            Thread.Sleep(2000);
        }


        public IWebElement ePersonal, eYourPay;
        //[Test]
        public void DonHangCaNhan()
        {
            dWebBanDienThoai = new ChromeDriver();
            dWebBanDienThoai.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(2000);

            dWebBanDienThoai.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            eSignIn = dWebBanDienThoai.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(2000);

            eUserName = dWebBanDienThoai.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("khanh@gmail.com");
            Thread.Sleep(2000);

            ePassword = dWebBanDienThoai.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123456");
            Thread.Sleep(2000);

            eBtnSignIn = dWebBanDienThoai.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(2000);

            ePersonal = dWebBanDienThoai.FindElement(By.ClassName("user-avatar"));
            ePersonal.Click();
            Thread.Sleep(2000);

            eYourPay = dWebBanDienThoai.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/a[2]"));
            eYourPay.Click();

        }




        public IWebDriver tWebAdmin;
        public IWebElement eNaviProduct, eAddProduct, eImage, eChipSet, eRam, eMemmory, eSize, eOS, eCam, eBattery, eDR,
            eProductName, eQuantity, ePrice, eCategoryId, eCategoryClick, eDescription;


     
        //[Test]
        public void TestAdmin()
        {
            tWebAdmin = new ChromeDriver();
            tWebAdmin.Navigate().GoToUrl("https://localhost:44366/");
            Thread.Sleep(2000);
            tWebAdmin.Manage().Window.Size = new System.Drawing.Size(1552, 832);

            eSignIn = tWebAdmin.FindElement(By.Id("login"));
            eSignIn.Click();
            Thread.Sleep(2000);

            eUserName = tWebAdmin.FindElement(By.Name("UserEmail"));
            eUserName.SendKeys("ngockhanh@gmail.com");
            Thread.Sleep(2000);

            ePassword = tWebAdmin.FindElement(By.Name("UserPassword"));
            ePassword.SendKeys("123");
            Thread.Sleep(2000);

            eBtnSignIn = tWebAdmin.FindElement(By.ClassName("btn"));
            eBtnSignIn.Click();
            Thread.Sleep(2000);

            eNaviProduct = tWebAdmin.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[2]/ul[1]/li[4]/a[1]"));
            eNaviProduct.Click();
            Thread.Sleep(2000);

            eAddProduct = tWebAdmin.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[2]/p[1]/a[1]"));
            eAddProduct.Click();
            Thread.Sleep(2000);



            //eImage = tWebAdmin.FindElement(By.ClassName("box-img-admin"));
            //eImage.Click();
            //Thread.Sleep(2000);

            eChipSet = tWebAdmin.FindElement(By.Id("Chipset"));
            eChipSet.SendKeys("MediaTek Helio G35");
            Thread.Sleep(2000);

            eRam = tWebAdmin.FindElement(By.Id("Ram"));
            eRam.SendKeys("4 GB");
            Thread.Sleep(2000);

            eMemmory = tWebAdmin.FindElement(By.Id("Memory"));
            eMemmory.SendKeys("128 GB");
            Thread.Sleep(2000);

            eSize = tWebAdmin.FindElement(By.Id("ScreenSize"));
            eSize.SendKeys("6.56 inches");
            Thread.Sleep(2000);

            eOS = tWebAdmin.FindElement(By.Id("OS"));
            eOS.SendKeys("Android 12");
            Thread.Sleep(2000);

            eCam = tWebAdmin.FindElement(By.Id("Camera"));
            eCam.SendKeys("Before: Chính 13 MP & Phụ 2 MP, After:8 MP");
            Thread.Sleep(2000);

            eBattery = tWebAdmin.FindElement(By.Id("Pin"));
            eBattery.SendKeys("5000 mAh33 W");
            Thread.Sleep(1000);

            eDR = tWebAdmin.FindElement(By.Id("Resolution"));
            eDR.SendKeys("Chính 13 MP & Phụ 2 MP");
            Thread.Sleep(1000);

            eProductName = tWebAdmin.FindElement(By.Name("ProductName"));
            eProductName.SendKeys("OPPO A57");
            Thread.Sleep(1000);

            eQuantity = tWebAdmin.FindElement(By.Name("amount"));
            eQuantity.Clear();
            eQuantity.SendKeys("20");
            Thread.Sleep(2000);

            ePrice = tWebAdmin.FindElement(By.Name("Price"));
            ePrice.SendKeys("3.890.000");
            Thread.Sleep(2000);

            eCategories = tWebAdmin.FindElement(By.XPath("//select[@id='CategoryID']"));
            eCategories.SendKeys("OPPO");
            Thread.Sleep(1000);

            eDescription = tWebAdmin.FindElement(By.Name("ProductIntroduction"));
            eDescription.SendKeys("OPPO đã bổ sung thêm vào dòng sản phẩm OPPO A giá rẻ một thiết bị mới có tên OPPO A57 128GB. Khác với mẫu A57 5G đã" +
                " được ra mắt trước đó, điện thoại dòng A mới có màn hình HD+, camera chính 13 MP và pin 5000 mAh.");
            Thread.Sleep(2000);
            

            tWebAdmin.Quit();


            Assert.Pass();
        }


       

    }
}