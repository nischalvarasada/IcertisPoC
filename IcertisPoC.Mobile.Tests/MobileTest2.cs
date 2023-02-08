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
    public class MobileTest2
    {
        private AndroidDriver<AndroidElement> _driver;
        private static string appiumServerUri = "http://127.0.0.1:4724/wd/hub";


        [Fact]
        public void TestApp2()
        {
            var appiumService = Runners.Appium(4724);

            appiumService.Start();

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("deviceName", "Pixel 6 Pro API 33");
            capabilities.SetCapability("appPackage", "com.google.android.deskclock");
            capabilities.SetCapability("appActivity", "com.android.deskclock.DeskClock");
            capabilities.SetCapability("noReset", "true");
            capabilities.SetCapability("avd", "Pixel_6_Pro_API_33");
            capabilities.SetCapability("udid", "emulator-5554");
            capabilities.SetCapability("port", 4724);
            _driver = new AndroidDriver<AndroidElement>(new Uri(appiumServerUri), capabilities, TimeSpan.FromSeconds(180));

            appiumService.Dispose();
            //_driver.Quit();
        }
    }
}
