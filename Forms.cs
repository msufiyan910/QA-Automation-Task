using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace QA_Automation___Practical_Task
{
    class Forms
    {
        public IWebDriver driver;
        public ExtentTest Test;
        public string fname;
        public string lname;
        public string gender;
        public string mobilenumber;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div/div[2]/div/div[2]/div/div[2]/svg/g/path")]
        private IWebElement FormsTab { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div/div[2]/div[1]/div/div/div[2]/div/ul/li")]
        private IWebElement PracticeFormTab { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div/div[2]/div[2]/div[1]/h5")]
        private IWebElement PracticeFormTitle { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement Firstname { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement Lastname { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-1")]
        private IWebElement genderOp1 { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-2")]
        private IWebElement genderOp2 { get; set; }

        [FindsBy(How = How.Id, Using = "gender-radio-3")]
        private IWebElement genderOp3 { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[1]/label")]
        private IWebElement GenderLabel { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        private IWebElement MobileNumber { get; set; }


        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "example-modal-sizes-title-lg")]
        private IWebElement SubmissionPopup { get; set; }


        public Forms(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
            Test = test;
        }

        public bool OpenFormsSection()
        {
            bool isOpen = false;
            try
            {
                if (FormsTab.Displayed)
                {
                    FormsTab.Click();
                    Thread.Sleep(2000);
                    isOpen = true;
                    
                    Test.Log(Status.Pass, "Forms tab opened Successfully");
                }
                else
                {
                    isOpen = false;
                    throw new Exception("Failed to opened Forms tab");
                }

            }
            catch (Exception)
            {
                isOpen = false;              
                Test.Log(Status.Fail, "Failed to opened Forms tab");
            }

            return isOpen;


        }

        public bool OpenPracticeForm()
        {
            bool isOpen = false;
            try
            {
                if (PracticeFormTab.Displayed)
                {
                    PracticeFormTab.Click();
                    Thread.Sleep(2000);
                   
                        if (PracticeFormTitle.Displayed)
                        {
                            isOpen = true;
                            Test.Log(Status.Pass, "Practice opened Successfully");
                        }
                        else
                        {
                            isOpen = false;
                            Test.Log(Status.Fail, "Failed to opened Practice Form");
                        }
                    
                   
                }
                else
                {
                    isOpen = false;
                    Test.Log(Status.Fail, "Failed to opened Practice Form");
                }

            }
            catch (Exception)
            {
                isOpen = false;
                Test.Log(Status.Fail, "Failed to opened Practice Form");
            }

            return isOpen;


        }

        public void Submitform()
        {
            try
            {
                Firstname.SendKeys(fname);
                Lastname.SendKeys(lname);
                if(gender.Equals("Male") || gender.Equals("male"))
                {
                    genderOp1.Click();
                }
                else if(gender.Equals("Female") || gender.Equals("female"))
                {
                    genderOp2.Click();
                }
                else
                {
                    genderOp3.Click();
                }
                MobileNumber.SendKeys(mobilenumber);
                SubmitBtn.Submit();
                try
                {
                    if (SubmissionPopup.Displayed)
                    {
                        Test.Log(Status.Pass, "Form submitted successfully");
                    }
                    else
                        Test.Log(Status.Fail, "Failed to Submit Form");
                }
               catch(Exception)
                {
                    Test.Log(Status.Fail, "Failed to Submit Form");
                }

            }
            catch (Exception)
            {
                
                Test.Log(Status.Fail, "Failed to Submit Form");
            }

        }
        public void verifyMandatoryFields()
        {
            try
            {
               SubmitBtn.Submit();
              
               string firstnameColor = Firstname.GetCssValue("border-color"); 
                if(firstnameColor.Equals("#dc3545"))
                {
                    Test.Log(Status.Pass, "Firstname is mandatory field");
                }
                else
                {
                    Test.Log(Status.Fail, "Firstname is not mandatory field");
                }
                string lastnameColor = Lastname.GetCssValue("border-color"); 
                if (firstnameColor.Equals("#dc3545"))
                {
                    Test.Log(Status.Pass, "Lastname is mandatory field");
                }
                else
                {
                    Test.Log(Status.Fail, "Lastname is not mandatory field");
                }
                string GenderLabelColor = GenderLabel.GetCssValue("color"); 
                if (firstnameColor.Equals("#dc3545"))
                {
                    Test.Log(Status.Pass, "Gender is mandatory field");
                }
                else
                {
                    Test.Log(Status.Fail, "Gender is not mandatory field");
                }
                string MobilenumberColor = MobileNumber.GetCssValue("border-color");
                if (firstnameColor.Equals("#dc3545"))
                {
                    Test.Log(Status.Pass, "Mobile number is mandatory field");
                }
                else
                {
                    Test.Log(Status.Fail, "Mobile number is not mandatory field");
                }
            }
            catch(Exception)
            {
                Test.Log(Status.Fail, "Failed to verify mandatory fields");
            }
        }



    }
}
