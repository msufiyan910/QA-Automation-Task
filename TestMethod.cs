using System;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using System.Configuration;
using AventStack.ExtentReports.Reporter;


namespace QA_Automation___Practical_Task
{
    public class Tests
    {
        public IWebDriver driver;
        public ExtentReports TestReport;
        public ExtentHtmlReporter htmlReporter;

        [SetUp]
        public void Setup()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string time = DateTime.Now.ToString("dd MMMM yyyy hh-mm tt");
            string reportPath = projectPath + "Reports\\" + time + "Test Results.html";
            TestReport = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(reportPath);
            TestReport.AttachReporter(htmlReporter);
            
            string URL = "https://demoqa.com/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;


        }

        [Test]
        public void TestSubmitForm()
        {
            
            ExtentTest Test = TestReport.CreateTest("Test Submit Form");
            Forms formObj = new Forms(driver, Test);
            formObj.fname = "Muhammad";
            formObj.lname = "Sufiyan";
            formObj.gender = "Male";
            formObj.mobilenumber = "3001111111";
            bool isOpenFormTab = formObj.OpenFormsSection();
            
            if(isOpenFormTab)
            {
                bool isOpenPracticeForm = formObj.OpenPracticeForm();
                if(isOpenPracticeForm)
                {
                    formObj.Submitform();
                }
            }
            
            

        }

        public void TestMandatoryFields()
        {

            ExtentTest Test = TestReport.CreateTest("Test Mandatory Fields");
            Forms formObj = new Forms(driver, Test);
            bool isOpenFormTab = formObj.OpenFormsSection();

            if (isOpenFormTab)
            {
                bool isOpenPracticeForm = formObj.OpenPracticeForm();
                if (isOpenPracticeForm)
                {
                    formObj.verifyMandatoryFields();
                }
            }



        }


        [TearDown]
        public void after_test()
        {

            TestReport.Flush();
            driver.Quit();

        }
    }
}