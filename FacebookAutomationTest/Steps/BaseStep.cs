using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UILayerFramework.Tests;

namespace FacebookAutomationTest.Steps
{
    [Binding]
    public class BaseStep
    {
        [AfterScenario]
        public void Cleanup()
        {
            try
            {
                ScenarioContext.Current.Get<BaseTest>().TestCleanUp();
            }
            catch (KeyNotFoundException) { }
        }
    }
}
