using ClosedXML.Excel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebBanDienThoai1.ThuongHoangPhuc
{
    [TestFixture]
    internal class DangKy
    {
        public static string excelPath = @"C:\Users\pthuo\Desktop\BaoDamChatLuongPM\MobileShopOnline - Copy\MobileShopOnline\TestWebBanDienThoai1\output\Output_dangky_exceute.xlsx";
        public IWebDriver driverXuatExcel;
        public IDictionary<string, object> vars1 { get; private set; }
        private IJavaScriptExecutor js1;


        [SetUp]
        public void SetUp()
        {
            driverXuatExcel = new ChromeDriver();
            js1 = (IJavaScriptExecutor)driverXuatExcel;
            vars1 = new Dictionary<string, object>();
        }

        [TearDown]
        public void TearDown()
        {
            driverXuatExcel.Quit();
        }


        [TestCaseSource(nameof(ReadFileExcel))]
        public void TestXuatExcel(TestCaseData testCaseData)
        {
            driverXuatExcel.Manage().Window.Maximize();

            driverXuatExcel.Navigate().GoToUrl("https://localhost:44366/");

            driverXuatExcel.FindElement(By.Id("login")).Click();
            Thread.Sleep(2000);
            driverXuatExcel.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[2]/form[1]/div[3]/a[1]")).Click();
            Thread.Sleep(2000);

            driverXuatExcel.FindElement(By.Name("userName")).SendKeys(testCaseData.NameUser);

            driverXuatExcel.FindElement(By.Name("userEmail")).SendKeys(testCaseData.Email);

            driverXuatExcel.FindElement(By.Name("phoneNumber")).SendKeys(testCaseData.Phone);

            driverXuatExcel.FindElement(By.Name("userPassword")).SendKeys(testCaseData.Password);

            driverXuatExcel.FindElement(By.Name("rePassword")).SendKeys(testCaseData.ComfirmPassword);
            Thread.Sleep(2000);

            driverXuatExcel.FindElement(By.Name("rulesAcp")).Click();
            Thread.Sleep(2000);

            driverXuatExcel.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[2]/form[1]/div[1]/div[6]/div[2]/button[1]")).Click();

            var emailValue = driverXuatExcel.FindElement(By.Name("userEmail")).GetAttribute("value");
            if (testCaseData.ComfirmPassword != null && testCaseData.Password != null)
            {
                WriteFileExcel(testCaseData.CurrentRowId, testCaseData.Expected, testCaseData.Password == testCaseData.ComfirmPassword ? "Passed" : "Failed", testCaseData.Password, testCaseData.ComfirmPassword);
            }
            else if (emailValue.Contains("@"))
            {
                WriteFileExcel(testCaseData.CurrentRowId, testCaseData.Expected, testCaseData.Expected = "Passed", testCaseData.Password, testCaseData.ComfirmPassword);
            }
            else
            {
                WriteFileExcel(testCaseData.CurrentRowId, testCaseData.Expected, testCaseData.Expected = "Failed", testCaseData.Password, testCaseData.ComfirmPassword);
            }


        }



        public class TestCaseData
        {
            public string NameUser { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
            public string ComfirmPassword { get; set; }
            public string Expected { get; set; }
            public int CurrentRowId { get; set; }

        }

        static TestCaseData[] ReadFileExcel()
        {
            List<TestCaseData> testCase = new List<TestCaseData>();
            TestCaseData item = new TestCaseData();

            using (var workbook = new XLWorkbook(excelPath))
            {
                var worksheet = workbook.Worksheet("TestCaseDangKy");

                if (worksheet == null)
                {
                    throw new Exception("Không tìm thấy trang tính");
                }

                for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                {
                    item = new TestCaseData();

                    item.NameUser = worksheet.Cell(row, 1).Value.ToString();
                    item.Email = worksheet.Cell(row, 2).Value.ToString();
                    item.Phone = worksheet.Cell(row, 3).Value.ToString();
                    item.Password = worksheet.Cell(row, 4).Value.ToString();
                    item.ComfirmPassword = worksheet.Cell(row, 5).Value.ToString();
                    item.Expected = worksheet.Cell(row, 6).Value.ToString();
                    item.CurrentRowId = row;

                    testCase.Add(item);
                }
            }
            return testCase.ToArray();
        }

        public void WriteFileExcel(int currentRow, string expect, string actual, string password, string comPass)
        {
            //Mở file Excel 
            using (var workbook = new XLWorkbook(excelPath))
            {
                //chọn trang tính muốn cập nhập
                var worksheet = workbook.Worksheet("TestCaseDangKy");

                if (worksheet == null)
                {
                    throw new Exception("Không tìm thấy trang tính");
                }

                worksheet.Cell(currentRow, 7).Value = actual;
                worksheet.Cell(currentRow, 8).Value = expect == actual ? "passed" : "failed";
                workbook.Save();
            }
        }
    }
}
