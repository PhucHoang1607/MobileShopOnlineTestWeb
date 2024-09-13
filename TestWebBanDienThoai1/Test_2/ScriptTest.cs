using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.Office.Interop.Excel;
using System.Xml.Linq;
using OfficeOpenXml;
using System.IO;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal.Execution;
using System.IO.Packaging;
using NUnit.Framework.Internal;
using static NUnit.Framework.Constraints.Tolerance;
using System.Collections.ObjectModel;
using static TestProject1.Tests;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        string filePath;
        DateTime now;
        int countEmpty;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            filePath = "D:\\output_DangDucTai.xlsx";
            now = DateTime.Now;
            countEmpty = 0;
        }
        //Contructor
        public class DataTest
        {
            public string? userEmail { get; set; }
            public string? userPassword { get; set; }
            public string? productName { get; set; }
            public string? amount { get; set; }
            public string? giaban { get; set; }
            public string? giakhuyenmai { get; set; }
            public string? numCategory { get; set; }
            public string? gioiThieuSP { get; set; }
            public string? chip { get; set; }
            public string? ram { get; set; }
            public string? rom { get; set; }
            public string? size { get; set; }
            public string? os { get; set; }
            public string? camera { get; set; }
            public string? pin { get; set; }
            public string? resolution { get; set; }
            public string? userEmailCustomer { get; set; }
            public string? userPasswordCustomer { get; set; }
            public string? searchKey{ get; set; }
            public string? idSp { get; set; }
            public string? brand { get; set; }
        }
        public static IEnumerable<DataTest> GetDataTest()
        {
                    
            using (var excelPackage = new ExcelPackage(new System.IO.FileInfo(@"D:\output_DangDucTai.xlsx")))
            {
                var worksheet = excelPackage.Workbook.Worksheets[0];
                //var cellValue = worksheet.Cells[2, 21].Value?.ToString();
                // dataInput = cellValue;
                if (worksheet != null)
                {
                    //lấy số dòng
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 8; row <= 9; row++) // Bắt đầu từ hàng thứ 2 để bỏ qua tiêu đề
                    {                     
                        yield return new DataTest
                        {
                            userEmail = worksheet.Cells[row, 21].Value?.ToString() ?? "" ,
                            userPassword = worksheet.Cells[row, 22].Value?.ToString() ?? "",
                            productName = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                            amount = worksheet.Cells[row, 3].Value?.ToString() ?? "" ,
                            giaban = worksheet.Cells[row, 4].Value?.ToString() ?? "" ,
                            giakhuyenmai = worksheet.Cells[row, 5].Value?.ToString() ?? "" ,
                            numCategory = worksheet.Cells[row, 6].Value?.ToString() ?? "" ,
                            gioiThieuSP = worksheet.Cells[row, 7].Value?.ToString() ?? "",
                            chip = worksheet.Cells[row, 11].Value?.ToString() ?? "" ,
                            ram = worksheet.Cells[row, 12].Value?.ToString() ?? "" ,
                            rom = worksheet.Cells[row, 13].Value?.ToString() ?? "" ,
                            size = worksheet.Cells[row, 14].Value?.ToString() ?? "" ,
                            os = worksheet.Cells[row, 15].Value?.ToString() ?? "" ,
                            camera = worksheet.Cells[row, 16].Value?.ToString() ?? "",
                            pin = worksheet.Cells[row, 17].Value?.ToString() ?? "" ,
                            resolution = worksheet.Cells[row, 18].Value?.ToString() ?? "" ,
                            userEmailCustomer = worksheet.Cells[row, 23].Value?.ToString() ?? "" ,
                            userPasswordCustomer = worksheet.Cells[row, 24].Value?.ToString() ?? "",
                            idSp = worksheet.Cells[row, 19].Value?.ToString() ?? "",
                            brand = worksheet.Cells[row, 20].Value?.ToString() ?? ""

                        };
                    }
                }
            }

        }
        //[TestCaseSource(nameof(GetDataTest))]
        public void Shop_Them(DataTest dataTest)
        {
           
            // Nhập đúng toàn bộ thông tin.
            driver.Navigate().GoToUrl("https://localhost:44366/");
            driver.FindElement(By.CssSelector(".bi-person")).Click();
            //Chon tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys(dataTest.userEmail);          
            //Chon mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys(dataTest.userPassword);
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(4) span:nth-child(2)")).Click();
            driver.FindElement(By.LinkText("Thêm sản phẩm")).Click();
            //ten san pham  
            driver.FindElement(By.Name("ProductName")).Click();
            driver.FindElement(By.Name("ProductName")).SendKeys(dataTest.productName);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("ProductName")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //so luong         
            driver.FindElement(By.Name("amount")).Clear();
            driver.FindElement(By.Name("amount")).SendKeys(dataTest.amount);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("amount")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //check so luong
            string enteredAmount = driver.FindElement(By.Name("amount")).GetAttribute("value");
            // Kiểm tra giá trị vượt quá giới hạn
            int amountSP=int.Parse(enteredAmount);                           
                // Ghi dữ liệu vào tệp Excel
                if ( amountSP < 1 || amountSP > 100)
                {
                    using (ExcelPackage item = new ExcelPackage(filePath))
                    {
                        ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                        worksheet.Cells["H42"].Value = "PASSED" + "_" + now;
                        item.SaveAs(new FileInfo(filePath));
                        driver.Quit();
                    }
                }                  
            //gia ban
            driver.FindElement(By.Id("fname")).Click();
            driver.FindElement(By.Id("fname")).SendKeys(dataTest.giaban);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("fname")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //gia khuyen mai
            driver.FindElement(By.Id("myCheck")).Click();
            driver.FindElement(By.Id("text")).Click();
            driver.FindElement(By.Id("text")).SendKeys(dataTest.giakhuyenmai);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("text")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //danh muc
            driver.FindElement(By.Id("CategoryID")).Click();
            {
                SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("CategoryID")));           
                dropdown.SelectByIndex(int.Parse(dataTest.numCategory));
            }
            //gioi thieu
            driver.FindElement(By.Name("ProductIntroduction")).Click();          
            driver.FindElement(By.Name("ProductIntroduction")).SendKeys(dataTest.gioiThieuSP);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("ProductIntroduction")).GetAttribute("value")))
            {
                countEmpty++;                 
            }
            //load hinh anh          
            //1
            IWebElement fileInput = driver.FindElement(By.CssSelector("input[name='ImgProd1']"));         
            string imagePath = "D:\\ThuongHieu.png";
            //check
            fileInput.SendKeys(imagePath);
           
            //2
            IWebElement fileInput1 = driver.FindElement(By.CssSelector("input[name='ImgProd2']"));
            string imagePath1 = "D:\\ThuongHieu.png";
            fileInput1.SendKeys(imagePath1);
            //check
           
            //3
            IWebElement fileInput2 = driver.FindElement(By.CssSelector("input[name='ImgProd3']"));
            string imagePath2 = "D:\\ThuongHieu.png";
            fileInput2.SendKeys(imagePath2);

            //chip
            driver.FindElement(By.Id("Chipset")).Click();
            driver.FindElement(By.Id("Chipset")).SendKeys(dataTest.chip);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Chipset")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //ram
            driver.FindElement(By.Id("Ram")).Click();
            driver.FindElement(By.Id("Ram")).SendKeys(dataTest.ram);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Ram")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //rom
            driver.FindElement(By.Id("Memory")).Click();
            driver.FindElement(By.Id("Memory")).SendKeys(dataTest.rom);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Memory")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //size
            driver.FindElement(By.Id("ScreenSize")).Click();
            driver.FindElement(By.Id("ScreenSize")).SendKeys(dataTest.size);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("ScreenSize")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //os
            driver.FindElement(By.Id("OS")).Click();
            driver.FindElement(By.Id("OS")).SendKeys(dataTest.os);        
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("OS")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //camera
            driver.FindElement(By.Id("Camera")).Click();
            driver.FindElement(By.Id("Camera")).SendKeys(dataTest.camera);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Camera")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //pin
            driver.FindElement(By.Id("Pin")).Click();
            driver.FindElement(By.Id("Pin")).SendKeys(dataTest.pin);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Pin")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //DPG
            driver.FindElement(By.Id("Resolution")).Click();
            driver.FindElement(By.Id("Resolution")).SendKeys(dataTest.resolution);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Resolution")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //-------CheckAll------Empty
            if (countEmpty > 0)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H36"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    countEmpty = 0;
                    driver.Quit();
                }
            }
            driver.FindElement(By.CssSelector(".btn")).Click();
            //Nguoi dung
            driver.FindElement(By.LinkText("Đăng xuất")).Click();
            //tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys("vy@gmail.com");
            //mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys("abc");
            driver.FindElement(By.CssSelector(".btn")).Click();
            //tim kiem
            driver.FindElement(By.Name("searchString")).Click();
            driver.FindElement(By.Name("searchString")).SendKeys("phone new");
            driver.FindElement(By.CssSelector(".bi-search")).Click();
            // Tạo một tệp Excel mới
            IWebElement checkResults = driver.FindElement(By.XPath("//div[contains(@class, 'row product-list-items')]"));        
            // Kiểm tra xem tệp Excel đã được tạo và ghi dữ liệu thành công hay không
            FileInfo eFile = new FileInfo(filePath);

            using (ExcelPackage item = new ExcelPackage(filePath))
            {
                //ExcelWorksheet worksheet = item.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                // Ghi dữ liệu vào tệp Excel
                if (checkResults.Text.Contains("Không có sản phẩm nào"))
                {
                    worksheet.Cells["H31"].Value = "FAILED"+"_"+now;
                    //worksheet.Cells["T2"].Value = now; 
                }
                else 
                { 
                    worksheet.Cells["H31"].Value = "PASS"+"_"+now;
                   // worksheet.Cells["T2"].Value = now;
                }            
                // Lưu tệp Excel
                item.SaveAs(new FileInfo(filePath));
            }
            // Kiểm tra xem tệp Excel đã được tạo và ghi dữ liệu thành công hay không
            Assert.IsTrue(File.Exists(filePath));                      
        }
        //[TestCaseSource(nameof(GetDataTest))]
        public void Shop_Sua(DataTest dataTest)
        {
            // Nhập đúng toàn bộ thông tin.
            driver.Navigate().GoToUrl("https://localhost:44366/");
            driver.FindElement(By.CssSelector(".bi-person")).Click();
            //Chon tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys(dataTest.userEmail);
            //Chon mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys(dataTest.userPassword);
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(4) span:nth-child(2)")).Click();
            //truyen id san pham chinh sua
            driver.Navigate().GoToUrl("https://localhost:44366/Admin/AdminProducts/Edit/"+dataTest.idSp);

            //ten san pham  
            driver.FindElement(By.Name("ProductName")).Clear();
            driver.FindElement(By.Name("ProductName")).SendKeys(dataTest.productName);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("ProductName")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //so luong         
            driver.FindElement(By.Name("amount")).Clear();
            driver.FindElement(By.Name("amount")).SendKeys(dataTest.amount);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("amount")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //check so luong
            string enteredAmount = driver.FindElement(By.Name("amount")).GetAttribute("value");
            // Kiểm tra giá trị vượt quá giới hạn
            int amountSP = int.Parse(enteredAmount);
            // Ghi dữ liệu vào tệp Excel
            if (amountSP < 1 || amountSP > 100)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H23"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            //gia ban
            driver.FindElement(By.Id("fname")).Clear();
            driver.FindElement(By.Id("fname")).SendKeys(dataTest.giaban);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("fname")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //check gia ban          
            string enterPrice = driver.FindElement(By.Id("fname")).GetAttribute("value");
            // Kiểm tra giá trị vượt quá giới hạn
            int Price = int.Parse(enterPrice);
            // Ghi dữ liệu vào tệp Excel
            if (Price < 1 || Price > 100000000)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H12"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            //gia khuyen mai
            driver.FindElement(By.Id("myCheck")).Click();
            driver.FindElement(By.Id("text")).Clear();
            driver.FindElement(By.Id("text")).SendKeys(dataTest.giakhuyenmai);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("text")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //check gia ban khuyen mai         
            string enterPriceKM = driver.FindElement(By.Id("text")).GetAttribute("value");
            // Kiểm tra giá trị vượt quá giới hạn
            int PriceKM = int.Parse(enterPriceKM);
            // Ghi dữ liệu vào tệp Excel
            if (PriceKM < 1 || PriceKM > 100000000)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H12"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            //danh muc
            driver.FindElement(By.Id("CategoryID")).Click();
            {
                SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("CategoryID")));
                dropdown.SelectByIndex(int.Parse(dataTest.numCategory));
            }
            //gioi thieu
            driver.FindElement(By.Name("ProductIntroduction")).Clear();
            driver.FindElement(By.Name("ProductIntroduction")).SendKeys(dataTest.gioiThieuSP);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("ProductIntroduction")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //load hinh anh          
            //1
            IWebElement fileInput = driver.FindElement(By.CssSelector("input[name='ImgProd1']"));
            string imagePath = "D:\\PRODUCT.png";
            //check
            fileInput.SendKeys(imagePath);

            //2
            IWebElement fileInput1 = driver.FindElement(By.CssSelector("input[name='ImgProd2']"));
            string imagePath1 = "D:\\PRODUCT.png";
            fileInput1.SendKeys(imagePath1);
            //check

            //3
            IWebElement fileInput2 = driver.FindElement(By.CssSelector("input[name='ImgProd3']"));
            string imagePath2 = "D:\\PRODUCT.png";
            fileInput2.SendKeys(imagePath2);

            //chip
            driver.FindElement(By.Id("Chipset")).Clear();
            driver.FindElement(By.Id("Chipset")).SendKeys(dataTest.chip);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Chipset")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //ram
            driver.FindElement(By.Id("Ram")).Clear();
            driver.FindElement(By.Id("Ram")).SendKeys(dataTest.ram);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Ram")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //rom
            driver.FindElement(By.Id("Memory")).Clear();
            driver.FindElement(By.Id("Memory")).SendKeys(dataTest.rom);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Memory")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //size
            driver.FindElement(By.Id("ScreenSize")).Clear();
            driver.FindElement(By.Id("ScreenSize")).SendKeys(dataTest.size);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("ScreenSize")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //os
            driver.FindElement(By.Id("OS")).Clear();
            driver.FindElement(By.Id("OS")).SendKeys(dataTest.os);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("OS")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //camera
            driver.FindElement(By.Id("Camera")).Clear();
            driver.FindElement(By.Id("Camera")).SendKeys(dataTest.camera);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Camera")).GetAttribute("value")))
            {
                countEmpty++;
            }
            //pin
            driver.FindElement(By.Id("Pin")).Clear();
            driver.FindElement(By.Id("Pin")).SendKeys(dataTest.pin);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Pin")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //DPG
            driver.FindElement(By.Id("Resolution")).Clear();
            driver.FindElement(By.Id("Resolution")).SendKeys(dataTest.resolution);
            //check
            if (string.IsNullOrEmpty(driver.FindElement(By.Id("Resolution")).GetAttribute("value")))
            {
                countEmpty++;
            }

            //-------CheckAll------Empty
            if (countEmpty > 0)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H18"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    countEmpty = 0;
                    driver.Quit();
                }
            }
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            //Nguoi dung
            driver.FindElement(By.LinkText("Đăng xuất")).Click();
            //tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys("vy@gmail.com");
            //mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys("abc");
            driver.FindElement(By.CssSelector(".btn")).Click();
            //tim kiem
            driver.FindElement(By.Name("searchString")).Click();
            driver.FindElement(By.Name("searchString")).SendKeys("phone new");
            driver.FindElement(By.CssSelector(".bi-search")).Click();
            // Tạo một tệp Excel mới
            IWebElement checkResults = driver.FindElement(By.XPath("//div[contains(@class, 'row product-list-items')]"));
            // Kiểm tra xem tệp Excel đã được tạo và ghi dữ liệu thành công hay không
            FileInfo eFile = new FileInfo(filePath);

            using (ExcelPackage item = new ExcelPackage(filePath))
            {
                //ExcelWorksheet worksheet = item.Workbook.Worksheets.Add("Sheet2");
                ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                // Ghi dữ liệu vào tệp Excel
                if (checkResults.Text.Contains("Không có sản phẩm nào"))
                {
                    worksheet.Cells["H5"].Value = "FAILED" + "_" + now;
                    //worksheet.Cells["T2"].Value = now; 
                }
                else
                {
                    worksheet.Cells["H5"].Value = "PASSED" + "_" + now;
                    // worksheet.Cells["T2"].Value = now;
                }
                // Lưu tệp Excel
                item.SaveAs(new FileInfo(filePath));
            }
            // Kiểm tra xem tệp Excel đã được tạo và ghi dữ liệu thành công hay không
            Assert.IsTrue(File.Exists(filePath));
        }
        //[TestCaseSource(nameof(GetDataTest))]
        public void Shop_Xoa(DataTest dataTest)
        {
            // Nhập đúng toàn bộ thông tin.
            driver.Navigate().GoToUrl("https://localhost:44366/");
            driver.FindElement(By.CssSelector(".bi-person")).Click();
            //Chon tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys(dataTest.userEmail);
            //Chon mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys(dataTest.userPassword);
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(4) span:nth-child(2)")).Click();
            //truyen id san pham chinh sua
            driver.Navigate().GoToUrl("https://localhost:44366/Admin/AdminProducts/Delete/" + dataTest.idSp);
            //khong tim thay id
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='content-container']"));
            if (elements.Count > 0)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H62"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));                 
                    driver.Quit();
                }
            }
          
            // Lấy URL hiện tại trước khi nhấn nút
            string currentUrl = "https://localhost:44366/Admin/AdminProducts/Delete/" + dataTest.idSp;

            // Nhấn nút
            driver.FindElement(By.XPath("//input[@value='Xóa']")).Click();

            // Lấy URL sau khi nhấn nút
            string newUrl = "https://localhost:44366/Admin/AdminProducts";

            // So sánh URL
            if(driver.Url == newUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H49"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));                 
                    driver.Quit();
                }
            }
            else if(driver.Url == currentUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H49"].Value = "FAILED" + "_" + now;
                    worksheet.Cells["H56"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            else
            {
                driver.Quit();

            }
        }



        //[TestCaseSource(nameof(GetDataTest))]
        public void Shop_ThuongHieu_Them(DataTest dataTest)
        {
            countEmpty = 0;
            // Nhập đúng toàn bộ thông tin.
            driver.Navigate().GoToUrl("https://localhost:44366/");
            driver.FindElement(By.CssSelector(".bi-person")).Click();
            //Chon tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys(dataTest.userEmail);
            //Chon mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys(dataTest.userPassword);
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(6) span:nth-child(2)")).Click();
            driver.FindElement(By.LinkText("Thêm hãng mới")).Click();
            driver.FindElement(By.Name("CategoryName")).Click();
            driver.FindElement(By.Name("CategoryName")).SendKeys(dataTest.brand);
            if (string.IsNullOrEmpty(driver.FindElement(By.Name("CategoryName")).GetAttribute("value")))
            {
                countEmpty++;
            }
            IWebElement fileInput = driver.FindElement(By.XPath("//input[@id='imgInp']"));
            string imagePath = "D:\\ThuongHieu.png";
            fileInput.SendKeys(imagePath);
            //check all
            if (countEmpty > 0)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H92"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    countEmpty = 0;
                    driver.Quit();
                }
            }
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            string currentUrl = "https://localhost:44366/Admin/AdminCategories/Create";
            string newUrl = "https://localhost:44366/Admin/AdminCategories";
            if(driver.Url == newUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H87"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            else if(driver.Url == newUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H87"].Value = "FAILED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
        }
        [TestCaseSource(nameof(GetDataTest))]
        public void Shop_ThuongHieu_Xoa(DataTest dataTest)
        {
            countEmpty = 0;
            // Nhập đúng toàn bộ thông tin.
            driver.Navigate().GoToUrl("https://localhost:44366/");
            driver.FindElement(By.CssSelector(".bi-person")).Click();
            //Chon tai khoan
            driver.FindElement(By.Name("UserEmail")).Click();
            driver.FindElement(By.Name("UserEmail")).SendKeys(dataTest.userEmail);
            //Chon mat khau
            driver.FindElement(By.Name("UserPassword")).Click();
            driver.FindElement(By.Name("UserPassword")).SendKeys(dataTest.userPassword);
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("li:nth-child(6) span:nth-child(2)")).Click();

            driver.Navigate().GoToUrl("https://localhost:44366/Admin/AdminCategories/Delete/" + dataTest.idSp);
            //
            //khong tim thay id
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='content-container']"));
            if (elements.Count > 0)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H105"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            //
            string currentUrl = "https://localhost:44366/Admin/AdminCategories/Delete/" + dataTest.idSp;
             string newUrl = "https://localhost:44366/Admin/AdminCategories";
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
           
            if (driver.Url == newUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H99"].Value = "PASSED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
            else if (driver.Url == currentUrl)
            {
                using (ExcelPackage item = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = item.Workbook.Worksheets[1];
                    worksheet.Cells["H105"].Value = "PASSED" + "_" + now;
                    worksheet.Cells["H99"].Value = "FAILED" + "_" + now;
                    item.SaveAs(new FileInfo(filePath));
                    driver.Quit();
                }
            }
        }
        [TearDown]
        public void TearDown()
        {
        
          driver.Quit();
        }


    }
}