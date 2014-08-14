using System.Collections.Generic;

namespace Mozu.Api.Test.Helpers
{
    public class Constant
    {
        public const string LocaleCode = "en-US";
        public const string Currency = "USD";
        public const string CountryCode = "US";
        public const string Password = "MozuPass1";

        public const string VISA = "Visa";
        public const string MASTER = "MasterCard";
        public const string DISCOVER = "Discover";
        public const string AMERICAN_EXPRESS = "American Express";

        public static List<string> Cards = new List<string>
                {
                    Constant.AMERICAN_EXPRESS,
                    Constant.DISCOVER,
                    Constant.MASTER,
                    Constant.VISA
                };

        //PackageTypes
        public const string TUBE = "TUBE";
        public const string LETTER = "LETTER";
        public const string PAK = "PAK";
        public const string CARRIER_BOX_SMALL = "CARRIER_BOX_SMALL";
        public const string CARRIER_BOX_MEDIUM = "CARRIER_BOX_MEDIUM";
        public const string CARRIER_BOX_LARGE = "CARRIER_BOX_LARGE";
        public const string CUSTOM = "CUSTOM";

        //Capability properties
        public const string SUPPORTED_COUNTRIES = "SupportedCountries";
        public const string ACTIVE_COUNTRIES = "ActiveCountries";
        public const string SUPPORTED_CARRIERS = "SupportedCarriers";
        public const string ACTIVE_CARRIERS = "ActiveCarriers";
        public const string SUPPORTED_CREDITTYPES = "SupportedCreditTypes";
        public const string ACTIVE_CREDITTYPES = "ActiveCreditTypes";

        //TenantName for testing
        public const string TENANT2_2 = "QA2_2";

        //Location Types
        public const string WAREHOUSE = "Warehouse";
        public const string RETAIL = "Retail Location";
    }
}
