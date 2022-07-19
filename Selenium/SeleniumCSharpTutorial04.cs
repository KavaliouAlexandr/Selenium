﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    [TestFixture] 
    public class SeleniumCSharpTutorial04
    {
        [Test]
        [Author("Alexandr","alexandr.kavaliou@microsoft.wsei.edu.pl")]
        [Description("Facebook login Verify")]
        [TestCaseSource("DataDrivenTesting")]
        public void Test1(String urlName)
        {
            IWebDriver driver = null;
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                // driver.Url = "https://pl-pl.facebook.com/";
                driver.Url = urlName;
                IWebElement emailtextfield = driver.FindElement(By.XPath(".//*[@id='email']"));
                //IWebElement emailtextfield = driver.FindElement(By.XPath(".//*[@id='abcd']"));
                emailtextfield.SendKeys("selenium c#"); 
                driver.Quit(); 
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Aleks\\Documents\\GitHub\\Selenium\\Selenium\\ScreenShots", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if (driver!=null)
                {
                    driver.Quit();
                }
            }
           
        }
        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();
            list.Add("https://www.facebook.com/");
            //list.Add("https://www.youtube.com/");
            //list.Add("https://www.gmail.com/");
            return list;
        }
        /*[Test]
        [Author("Alexandr.kavaliou@microsoft.wsei.edu.pl")]
        [Description("Facebook login Verify")]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://pl-pl.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium c#");
            driver.Quit();
        }*/
    }
}
