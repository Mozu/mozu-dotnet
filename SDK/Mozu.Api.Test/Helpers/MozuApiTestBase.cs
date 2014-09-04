using System.Configuration;
using System.Diagnostics;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Security;

namespace Mozu.Api.Test.Helpers
{
    /// <summary>
    /// Class MozuTestBase
    /// </summary>
    [TestClass]
    public class MozuApiTestBase
    {
        #region Fields

        /// <summary>
        /// The target environment.
        /// </summary>
        private Environments _targetEnvironment;

        /// <summary>
        /// The target scaleUnit.
        /// </summary>
        private ScaleUnitId _scaleUnitId;

        /// <summary>
        /// Common Global Variables.
        /// </summary>
        public static Mozu.Api.Contracts.Tenant.Tenant TestBaseTenant;
        public static Mozu.Api.Contracts.ProductAdmin.DiscountLocalizedContent DContent;

        public static ServiceClientMessageHandler ApiMsgHandler;
        public static ServiceClientMessageHandler ShopperMsgHandler;
        public static ServiceClientMessageHandler AnonShopperMsgHandler;

        public static Mozu.Api.Security.AuthTicket ShopperuserAuthTicket = new Mozu.Api.Security.AuthTicket() { AuthenticationScope = AuthenticationScope.Customer, AccessTokenExpiration = (DateTime.UtcNow.AddDays(1)) };
        
        public static int tenantId;
        //public static int siteGroupId;
        public static int siteId;
        public static int masterCatalogId;
        public static int catalogId;

        #endregion

        static MozuApiTestBase()
        {
            Debug.WriteLine("*****Base Class Static Constructor");

        }

        public MozuApiTestBase()
        {
            Debug.WriteLine("*****MozuApiTestBase Class Constructor");
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the service client message handler.
        /// </summary>
        /// <value>The service client message handler.</value>
        public static ServiceClientMessageHandler TestServiceHandler { get; set; }

        /// <summary>
        /// Gets or sets the test API context.
        /// </summary>
        /// <value>The test API context.</value>
        public static ApiContext TestApiContext { get; set; }

        /// <summary>
        /// Gets or sets the Test's Service Client Message Handler.
        /// </summary>
        public ServiceClientMessageHandler TestHandler { get; set; }
        // Use ClassInitialize to run code before running the first test in the class

        public string EnvironmentHost { get; set; }
        public string ScaleUnitSetting { get; set; }

        /// <summary>
        /// Target the Correct Scale Units
        /// </summary>
        public virtual ScaleUnitId ScaleUnit
        {
            get
            {
                return this._scaleUnitId;
            }

            set
            {
                string scaleUnitString;
                switch (value)
                {
                    case ScaleUnitId.HP1:
                        scaleUnitString = "Hp1";
                        break;
                    case ScaleUnitId.TP1:
                        scaleUnitString = "Tp1";
                        break;
                    case ScaleUnitId.TP2:
                        scaleUnitString = "Tp2";
                        break;
                    case ScaleUnitId.SB:
                        scaleUnitString = "SB";
                        break;
                    case ScaleUnitId.PC1:
                        scaleUnitString = "PC1";
                        break;
                    case ScaleUnitId.PCI:
                        scaleUnitString = "PCI";
                        break;
                    default:
                        scaleUnitString = "SB";
                        break;
                }
                Environment.UpdateConfigSetting("ScaleUnitId", scaleUnitString);
                this._scaleUnitId = value;
                Debug.WriteLine("ScaleUnit Settings pointed to: " + scaleUnitString);
            }
        }

        /// <summary>
        /// Gets or sets the target environment.
        /// </summary>
        /// <value>The target environment.</value>
        public virtual Environments TargetEnvironment
        {
            get
            {
                return this._targetEnvironment;
            }

            set
            {
                string environmentString;
                switch (value)
                {
                    case Environments.Dev:
                        environmentString = "Dev";
                        ScaleUnit = ScaleUnitId.Su1;
                        break;

                    case Environments.CI:
                        environmentString = "CI";
                        ScaleUnit = ScaleUnitId.Su1;
                        break;

                    case Environments.SI:
                        environmentString = "SI";
                        ScaleUnit = ScaleUnitId.Su1;
                        break;

                    case Environments.QA:
                        environmentString = "QA";
                        break;

                    case Environments.Demo:
                        environmentString = "DEMO";
                        break;

                    case Environments.Prod:
                        environmentString = "PROD";
                        break;

                    default:
                        environmentString = "QA";
                        break;
                }
                Environment.UpdateConfigSetting("Environment", environmentString);
                this._targetEnvironment = value;
                Debug.WriteLine("Environment Settings path pointed to: " + environmentString);
            }
        }




        // Use TestCleanup to run code after each test has run

        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Tests the class cleanup.
        /// </summary>
        [ClassCleanup]
        public static void TestClassCleanup()
        {
            Debug.WriteLine("*****MozuApiTestBaseClass Static Cleanup*****");
        }

        /// <summary>
        /// Initialize the Test Run.
        /// </summary>
        /// <param name="TestContext">The test context.</param>
        [ClassInitialize]
        public static void TestClassInitialize(TestContext TestContext)
        {
            Debug.WriteLine("*****MozuApiTestBaseClass Static Class Init*****");
        }

        /// <summary>
        /// Bases the test cleanup.
        /// </summary> 
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("*****MozuApiTestBaseClass Test Cleanup*****");
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Initialize the Test Case.
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            Debug.WriteLine("*****MozuApiTestBaseClass Test Init*****");

            // This is useful if you hook in MTM Labmanager to run test cases.
            // In the configuration of the test case in Labmanager you can set the environment to run the test case. 
            // For example Dev, SI, CI, QA, Demo, Prod
            if (TestContext.Properties["__Tfs_TestConfigurationName__"] != null)
            {
                var selectedBrowser = TestContext.Properties["__Tfs_TestConfigurationName__"].ToString();
                Debug.WriteLine(
                    string.Format("Selected browser configuration '__Tfs_TEstConfigurationName__' == {0}",
                                  selectedBrowser));
                Debug.WriteLine(
                    string.Format("Build Number Used for Test Run: '__Tfs_BuildNumber__' == {0}",
                                  TestContext.Properties["__Tfs_BuildNumber__"].ToString()));
                Debug.WriteLine(
                    string.Format("Build Transform Used for Test Run: '__Tfs_BuildFlavor__' == {0}",
                                  TestContext.Properties["__Tfs_BuildFlavor__"].ToString()));
                Debug.WriteLine(
                    string.Format("Test Case Related from MTM: '__Tfs_TestCaseId__' == {0}",
                                  TestContext.Properties["__Tfs_TestCaseId__"].ToString()));
                Debug.WriteLine(
                    string.Format("Test Plan from MTM: '__Tfs_TestPlanId__' == {0}",
                                  TestContext.Properties["__Tfs_TestPlanId__"].ToString()));


                if (!string.IsNullOrEmpty(selectedBrowser))
                {
                    var environmentName = "";
                    var envUrl = "";

                    Debug.WriteLine("*****MozuApiTestBaseClass Setting Environment to " + environmentName + "*****");
                    // Get Environment.
                    if (selectedBrowser.ToUpper().Contains("1.DEV"))
                    {
                        environmentName = "Dev";
                        TargetEnvironment = Environments.Dev;
                    }
                    else if (selectedBrowser.ToUpper().Contains("2.CI"))
                    {
                        environmentName = "CI";
                        TargetEnvironment = Environments.CI;
                    }
                    else if (selectedBrowser.ToUpper().Contains("3.SI"))
                    {
                        environmentName = "SI";
                        TargetEnvironment = Environments.SI;
                    }
                    else if (selectedBrowser.ToUpper().Contains("4.QA"))
                    {
                        environmentName = "QA";
                        TargetEnvironment = Environments.QA;
                    }
                    else if (selectedBrowser.ToUpper().Contains("5.DEMO"))
                    {
                        environmentName = "DEMO";
                        TargetEnvironment = Environments.Demo;
                    }
                    else if (selectedBrowser.ToUpper().Contains("6.PROD"))
                    {
                        environmentName = "PROD";
                        TargetEnvironment = Environments.Prod;
                    }
                    else
                    {
                        environmentName = "SI";
                        TargetEnvironment = Environments.SI;
                        Debug.WriteLine("*****MozuApiTestBaseClass DEFAULT Environment to " + environmentName + "*****");
                    }


                }
                else
                {
                    Debug.WriteLine("*****MozuApiTestBaseClass No Override of Config File Needed*****");

                }
            }
        }

        #endregion
    }
}