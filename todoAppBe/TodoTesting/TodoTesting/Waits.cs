using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TodoTesting
{
    public static class Waits
    {
        public static void ShouldLocate(IWebDriver webDriver,string url) 
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(url));
            }
            catch(WebDriverTimeoutException e) 
            {
                throw new Exception("error");
            }
        }

        public static void WaitSomeTime(int timeout) 
        {

            Task.Delay(TimeSpan.FromSeconds(timeout)).Wait();
        }

        public static void WaitForElement(IWebDriver webDtiver, By locator,int timeout =20) 
        { 
            new WebDriverWait(webDtiver,TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDtiver,TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(locator));
            
        }
    }
}
