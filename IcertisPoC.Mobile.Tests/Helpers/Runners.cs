using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IcertisPoC.Mobile.Tests.Helpers
{
    public static class Runners
    {
        public static AppiumLocalService Appium(int port)
        {
            string appiumPath = @"C:\Users\c-Nishchal.Varasada\AppData\Roaming\npm\node_modules\appium\build\lib\main.js";

            var appiumService = new AppiumServiceBuilder()
                .WithAppiumJS(new FileInfo(appiumPath))
                .WithIPAddress("127.0.0.1")
                .UsingPort(port)
                .Build();

            return appiumService;
        }
    }
}
