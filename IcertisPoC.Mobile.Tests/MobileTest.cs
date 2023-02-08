using System;
using Xunit;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System.IO;
using IcertisPoC.Mobile.Tests.Helpers;

namespace IcertisPoC.Mobile.Tests
{
    //[Collection("Mobile Test Collection")]
    public class MobileTest
    {
        private static string appiumServerUri = "http://127.0.0.1:4723/wd/hub";
        AndroidDriver<AndroidElement> _driver;

        [Fact]
        public void TestApp()
        {
            var appiumService = Runners.Appium(4723);

            appiumService.Start();

            try
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("deviceName", "Pixel 5 API 33");
                capabilities.SetCapability("appPackage", "com.google.android.deskclock");
                capabilities.SetCapability("appActivity", "com.android.deskclock.DeskClock");
                capabilities.SetCapability("noReset", "true");
                capabilities.SetCapability("avd", "Pixel_5_API_33");
                capabilities.SetCapability("udid", "emulator-5556");
                capabilities.SetCapability("avdArgs", "-no-window");
                capabilities.SetCapability("port", 4723);
                _driver = new AndroidDriver<AndroidElement>(new Uri(appiumServerUri), capabilities);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _driver.Quit();
            }
            

            appiumService.Dispose();
            //_driver.Quit();
        }

    }
}
