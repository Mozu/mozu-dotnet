using System;
using System.Collections;
using Mozu.Api.Contracts.Core;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Contracts.PricingRuntime;
using Mozu.Api.Contracts.ProductAdmin;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization;
using Mozu.Api.Test.Factories;
using System.Net;
using System.Dynamic;
using Mozu.Api.Contracts.CommerceRuntime.Wishlists;
using Attribute = Mozu.Api.Contracts.ProductAdmin.Attribute;
using ProductProperty = Mozu.Api.Contracts.ProductAdmin.ProductProperty;
using ProductPropertyValue = Mozu.Api.Contracts.ProductAdmin.ProductPropertyValue;

namespace Mozu.Api.Test.Helpers
{
    /// <summary>
    /// Class Generator
    /// </summary>
    public class Generator
    {
        public static ServiceClientMessageHandler GetTestClientMessage(int tenantId = 0, int? siteId = null)
        {
            var apiContext = new ApiContext(tenantId, siteId);
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        #region "Random Data"
        /// <summary>
        /// The _random
        /// </summary>
        private static readonly Random _random = new Random();
        /// <summary>
        /// The alpha chars
        /// </summary>
        private const string AlphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        /// <summary>
        /// The numeric chars
        /// </summary>
        private const string NumericChars = "0123456789";
        /// <summary>
        /// The alpha numeric chars
        /// </summary>
        private const string AlphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        /// <summary>
        /// The special valid email chars
        /// </summary>
        private const string SpecialValidEmailChars = "-_.";

        /// <summary>
        /// All valid chars
        /// </summary>
        private const string AllValidChars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789,./?;:'*&^%$#@!~` ";

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="characterSet">The character set.</param>
        /// <returns>System.String.</returns>
        public static string RandomString(int maxLength, string characterSet)
        {
            var buffer = new char[maxLength];

            for (var i = 0; i < maxLength; i++)
            {
                buffer[i] = characterSet[_random.Next(characterSet.Length)];
            }

            return new string(buffer);
        }

        /// <summary>
        /// Returns a random boolean value
        /// </summary>
        /// <returns>Random boolean value</returns>
        public static bool RandomBool()
        {
            return (_random.NextDouble() > 0.5);
        }

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="characterGroup">The character group.</param>
        /// <returns>System.String.</returns>
        public static string RandomString(int maxLength, RandomCharacterGroup characterGroup)
        {
            switch (characterGroup)
            {
                case RandomCharacterGroup.AlphaOnly:
                    return RandomString(maxLength, AlphaChars);
                case RandomCharacterGroup.NumericOnly:
                    return RandomString(maxLength, NumericChars);
                case RandomCharacterGroup.AlphaNumericOnly:
                    return RandomString(maxLength, AlphaNumericChars);
                default:
                    return RandomString(maxLength, AllValidChars);

            }

        }

        /// <summary>
        /// Enum RandomCharacterGroup
        /// </summary>
        public enum RandomCharacterGroup
        {
            /// <summary>
            /// The alpha only
            /// </summary>
            AlphaOnly,
            /// <summary>
            /// The numeric only
            /// </summary>
            NumericOnly,
            /// <summary>
            /// The alpha numeric only
            /// </summary>
            AlphaNumericOnly,
            /// <summary>
            /// Any character
            /// </summary>
            AnyCharacter
        }

        /// <summary>
        /// Generates a random Email address using the supplied top level domain.
        /// </summary>
        /// <param name="tld">Top Level Domain (e.g. "com", "net", "org", etc)</param>
        /// <returns>A randomly generated email address with the top level domain passed in.</returns>
        public static string RandomEmailAddress(string tld)
        {
            return string.Format("{0}@{1}.{2}", RandomString(10, RandomCharacterGroup.AlphaOnly),
                                 RandomString(15, RandomCharacterGroup.AlphaNumericOnly), tld);
        }

        /// <summary>
        /// Randoms the email address.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string RandomEmailAddress()
        {
            return string.Format("{0}@{1}.{2}", RandomString(10, RandomCharacterGroup.AlphaOnly),
                                 RandomString(15, RandomCharacterGroup.AlphaNumericOnly), "com");
        }

        /// <summary>
        /// Randoms the email address with Mozu ending..
        /// </summary>
        /// <returns>System.String.</returns>
        public static string RandomEmailAddressMozu()
        {
            return string.Format("mozuqa+{0}@gmail.com", RandomString(10, RandomCharacterGroup.AlphaOnly));
        }

        public static string RandomAddressType()
        {
            string[] types = { AddressType.Commercial.ToString(), AddressType.Residential.ToString(), AddressType.None.ToString() };

            return types[new Random().Next(0, types.Length)];
        }

        /// <summary>
        /// Randoms the day func.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <returns>Func{DateTime}.</returns>
        public static Func<DateTime> RandomDayFunc(DateTime startDate)
        {

            Random gen = new Random();
            var timeSpan = DateTime.Today - startDate;
            {
                int range = ((TimeSpan)timeSpan).Days;

                return () => startDate.AddDays(gen.Next(range));
            }
        }

        /// <summary>
        /// Randoms the type of the customer contact.
        /// </summary>
        /// <returns>CustomerContactType.</returns>
        //public static CustomerContactType RandomCustomerContactType()
        //{
        //    var values = Enum.GetValues(typeof(CustomerContactType));
        //    return (CustomerContactType)values.GetValue(_random.Next((values.Length)));
        //}

        /// <summary>
        /// Randoms the int32.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int RandomInt32()
        {
            unchecked
            {
                int firstBits = _random.Next(0, 1 << 4) << 28;
                int lastBits = _random.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        /// <summary>
        /// Randoms the int32.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int RandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        /// <summary>
        /// Randoms the decimal.
        /// </summary>
        /// <param name="nonNegative">if set to <c>true</c> [non negative].</param>
        /// <returns>System.Decimal.</returns>
        public static decimal RandomDecimal(bool nonNegative)
        {
            var scale = (byte)_random.Next(29);
            return new decimal(RandomInt32(), RandomInt32(), RandomInt32(), nonNegative, scale);
        }

        /// <summary>
        /// Randoms the decimal.
        /// </summary>
        /// <param name="low">The low.</param>
        /// <param name="mid">The mid.</param>
        /// <param name="high">The high.</param>
        /// <param name="nonNegative">if set to <c>true</c> [non negative].</param>
        /// <returns>System.Decimal.</returns>
        public static decimal RandomDecimal(int low, int mid, int high, bool nonNegative)
        {
            var scale = (byte)_random.Next(29);
            return new decimal(low, mid, high, nonNegative, scale);
        }

        /// <summary>
        /// Random the decimal
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static decimal RandomDecimal(decimal min, decimal max)
        {
            decimal result = Convert.ToDecimal(_random.Next((int)(min * 100), (int)(max * 100))) / 100;
            return result;
        }



        /// <summary>
        /// Random IP address
        /// </summary>
        /// <returns></returns>
        public static string RandomIPAddress()
        {
            return RandomString(3, RandomCharacterGroup.NumericOnly) + "." +
            RandomString(3, RandomCharacterGroup.NumericOnly) + "." +
            RandomString(3, RandomCharacterGroup.NumericOnly) + "." +
            RandomString(3, RandomCharacterGroup.NumericOnly);
        }

        /// <summary>
        /// Random url
        /// </summary>
        /// <returns></returns>
        public static string RandomURL()
        {
            return "http://" + RandomString(4, RandomCharacterGroup.AlphaNumericOnly) + "/" +
                   RandomString(5, RandomCharacterGroup.AlphaNumericOnly);
        }

        /// <summary>
        /// Random UPC code
        /// </summary>
        /// <returns></returns>
        public static string RandomUPC()
        {
            string upc = "";
            int j;
            for (int i = 0; i < 12; i++)
            {
                j = _random.Next(0, 9) * 10 ^ i;
                upc += j.ToString();
            }
            return upc;
        }

        /// <summary>
        /// Random State
        /// </summary>
        /// <returns></returns>
        public static string RandomState()
        {
            string[] state =
                {
                    "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "GU", "HI", "ID",
                    "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MH", "MA", "MI", "FM", "MN", "MS", "MO", "MT", "NE",
                    "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD",
                    "TN", "TX", "UT", "VT", "VA", "VI", "WA", "WV", "WI", "WY"
                };

            return state[new Random().Next(0, state.Length)];
        }

        public static string RandomCompanyName()
        {
            string[] companyName = {"Idea","Ideaa","Aedi","Idea Idea","Idea Ine","Idea Wiki","Idea Leader","Idea Canvas","Idea Workshop","Idea Horizon","Idea Simple","Idea Niche", "Idea Lens","Idea Cent","Idea Vine","Idea Systems","Idea Strategy","Idea Emporium","Ideaa","Ideaar","Ideamow","Idea Next","Idea Alliance","Idea Technology", "Idea Crowd","Ide Ine","Ide Wiki","Ide Leader","Idea Cube","Idea Network","Idea Capital","Idea Live","Ide Niche","Ide Lens","Ide Cent","Idea Venture","Idea Affiliate","Idea Future", "Idea Dev","Idea","Idear","Idemow","Idea Consultancy","Idea Professionals","Idea Topia","Idea Strategies", "Id Ine","Id Wiki","Id Leader", "Mozuu", "Uzom", "Mozu Mozu","Mozu Gam", "Mozu Number","Mozu Giga","Mozu Essence", "Mozu Insider","Mozu Line","Mozu Cube","Mozu Ratio","Mozu Tsar", "Mozu Tank","Mozu Guardian","Mozu Direct","Mozu Lab","Mozu Smart","Mozuk","Mozuwo", "Mozumoc","Mozu Alliance","Mozu Royal","Mozu Launch","Mozu Financial","Moz Gam","Moz Number","Moz Giga","Mozu Wise","Mozu Enterprise","Mozu Rockstar","Mozu Crowd","Moz Ratio","Moz Tsar","Moz Tank","Mozu Consultancy","Mozu Equinox","Mozu Industries", "Mozu Boulevard","Mozk","Mozwo","Mozmoc","Mozu Foundry","Mozu Vivid","Mozu Division","Mozu Epic","Mo Gam","Mo Number","Mo Giga","Mozu Group","Mozu Vertical","Mozu Business", "Mozu Lock","Mo Ratio","Mo Tsar","Mo Tank","Mozu Sage","Mozu Dynamic","Mozu Unlimited","Mok","Mowo","Momoc","Mozu Data","Mozu Tracker","Mozu Strategy","Mozu Motion","Sanct Mozu", "Number Mozu","Giga Mozu","Mozu Certified","Mozu Vine","Mozu Central", "Mozu Strategic","Ratio Mozu","Tsar Mozu","Tank Mozu","Mozu Fire","Mozu Performance","Mozu Innovation","Mozu Arc","Kmozu","Womozu","Mocmozu","Mozu Designs","Mozu Partners","Mozu Vision", "Mozu Research","Sanct Ozu","Number Ozu","Giga Ozu","Mozu Quality","Mozu Canvas","Mozu Zone","Mozu Synergy","Ratio Ozu","Tsar Ozu","Tank Ozu","Mozu Platinum", "Mozu Logistics","Mozu App","Mozu Edge","Kozu","Woozu","Mocozu","Mozu Outlet","Mozu Theory","Mozu Future","Mozu Velocity","Sanct Zu","Number Zu","Giga Zu","Mozu Emporium", "Mozu Online","Mozu Ondemand","Mozu Strategies", "Ratio Zu","Tsar Zu","Tank Zu","Mozu Bureau","Mozu Charter","Mozu Impact","Mozu Fuse","Kzu","Wozu","Moczu","Mozu Target","Mozu Network","Mozu First", "Mozu Cyber","Mozu Number", "Number Mozu","Mozu Giga","Mozu Interactive","Mozu Hub","Mozu Street","Mozu Ninja","Giga Mozu","Mozu Ratio","Ratio Mozu","Mozu Quick", "Mozu Beacon","Mozu Capital","Mozu Tsar","Tsar Mozu","Mozu Tank", "Mozu Topia","Mozu Cloud","Mozu Bold","Mozu Studios","Tank Mozu","Mozu Ine", "Mozu Ping","Mozu Supplies","Mozu Systems","Mozu Ventures","Mozu Software","Mozu Vertical","Mozu Mass", "Mozu Faux","Mozu Professionals","Mozu Rank","Mozu Worldwide","Mozu Centric", "Mozu Dude","Mozuo","Mozude","Mozu Tactical", "Mozu Authority","Mozu Consulting","Mozu Work", "Mozuwon","Moz Ine","Moz Ping", "Mozu Foundary","Mozu Web", "Mozu Anchor", "Mozu Zoom","Moz Vertical","Moz Mass", "Moz Faux","Mozu Horizon", "Mozu Circle","Mozu Ruby", "Mozu Labs", "Moz Dude","Mozo", "Mozde", "Mozu Option", "Mozu Nexus","Mozu Modern", "Mozu Live", "Mozwon", "Mo Ine", "Mo Ping", "Mozu Source", "Mozu Agent"};

            return companyName[new Random().Next(0, companyName.Length)];
        }

        /// <summary>
        /// generate measurement object
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Measurement GenerateMeasurement(string unit, decimal? value)
        {
            return new Mozu.Api.Contracts.Core.Measurement()
            {
                Unit = unit,
                Value = value
            };

        }

        public static Mozu.Api.Contracts.Core.AuditInfo GenerateAuditInfoRandom()
        {
            return new Mozu.Api.Contracts.Core.AuditInfo()
            {
                CreateBy = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                CreateDate = DateTime.Now.AddDays(Generator.RandomInt(-10, -2)),
                UpdateBy = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                UpdateDate = DateTime.Now.AddDays(Generator.RandomInt(-10, -2))
            };
        }
        #endregion


        #region "GenerateAttribute"

        /// <summary>
        /// Generate Mozu.Api.Contracts.ProductAdmin.AttributeObject
        /// </summary>
        /// <param name="inputType"></param>
        /// <param name="valueType"></param>
        /// <param name="dataType"></param>
        /// <param name="isOption"></param>
        /// <param name="isExtra"></param>
        /// <param name="isProperty"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute GenerateAttribute(string inputType = "List", string valueType = "Predefined",
                                                                         string dataType = "String", bool? isOption = false, bool? isExtra = false, bool? isProperty = false)
        {
            return new Mozu.Api.Contracts.ProductAdmin.Attribute
            {
                AttributeCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                AdminName = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly),
                InputType = inputType,
                ValueType = valueType,
                DataType = dataType,
                IsOption = isOption,
                IsExtra = isExtra,
                IsProperty = isProperty,
                Content = GenerateAttributeLocalizedContent(),
                Validation = GenerateAttributeValidation()
            };
        }

        /// <summary>
        /// Generate Mozu.Api.Contracts.ProductAdmin.AttributeObject
        /// </summary>
        /// <param name="inputType"></param>
        /// <param name="valueType"></param>
        /// <param name="dataType"></param>
        /// <param name="isOption"></param>
        /// <param name="isExtra"></param>
        /// <param name="isProperty"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute GenerateAttributeSDK(string inputType = "List", string valueType = "Predefined",
                                                                                string dataType = "String", bool? isOption = false, bool? isExtra = false, bool? isProperty = false)
        {
            return new Api.Contracts.ProductAdmin.Attribute
            {
                AttributeCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                AdminName = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly),
                InputType = inputType,
                ValueType = valueType,
                DataType = dataType,
                IsOption = isOption,
                IsExtra = isExtra,
                IsProperty = isProperty,
                Content = GenerateAttributeLocalizedContentSDK(),
                Validation = GenerateAttributeValidationSDK()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeCode"></param>
        /// <param name="adminName"></param>
        /// <param name="inputType"></param>
        /// <param name="valueType"></param>
        /// <param name="dataType"></param>
        /// <param name="isOption"></param>
        /// <param name="isExtra"></param>
        /// <param name="isProperty"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute GenerateAttribute(string attributeCode, string adminName, string inputType = "List", string valueType = "Predefined",
                                                                         string dataType = "String", bool? isOption = false, bool? isExtra = false, bool? isProperty = false)
        {
            var attr = new Mozu.Api.Contracts.ProductAdmin.Attribute
            {
                AttributeCode = attributeCode,
                AdminName = adminName,
                InputType = inputType,
                ValueType = valueType,
                DataType = dataType,
                IsOption = isOption,
                IsExtra = isExtra,
                IsProperty = isProperty,
                AttributeMetadata = new List<AttributeMetadataItem>(),
                Content = GenerateAttributeLocalizedContent(),
                Validation = GenerateAttributeValidation(),
                //                VocabularyValues = new List<AttributeVocabularyValue>()
            };
            attr.AttributeMetadata.Add(GenerateAttributeMetadataItem());
            if (attr.ValueType.ToLower() == "predefined")
            {
                attr.VocabularyValues = new List<AttributeVocabularyValue>
                    {
                        GenerateAttributeVocabularyValueRandom(),
                        GenerateAttributeVocabularyValueRandom()
                    };
            }
            return attr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeCode"></param>
        /// <param name="adminName"></param>
        /// <param name="inputType"></param>
        /// <param name="valueType"></param>
        /// <param name="dataType"></param>
        /// <param name="isOption"></param>
        /// <param name="isExtra"></param>
        /// <param name="isProperty"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute GenerateAttributeSDK(string attributeCode, string adminName, string inputType = "List", string valueType = "Predefined",
                                                                                string dataType = "String", bool? isOption = false, bool? isExtra = false, bool? isProperty = false)
        {
            var attr = new Api.Contracts.ProductAdmin.Attribute
            {
                AttributeCode = attributeCode,
                AdminName = adminName,
                InputType = inputType,
                ValueType = valueType,
                DataType = dataType,
                IsOption = isOption,
                IsExtra = isExtra,
                IsProperty = isProperty,
                AttributeMetadata = new List<Api.Contracts.ProductAdmin.AttributeMetadataItem>(),
                Content = GenerateAttributeLocalizedContentSDK(),
                Validation = GenerateAttributeValidationSDK(),
                //                VocabularyValues = new List<AttributeVocabularyValue>()
            };
            attr.AttributeMetadata.Add(GenerateAttributeMetadataItemSDK());
            if (attr.ValueType.ToLower() == "predefined")
            {
                attr.VocabularyValues = new List<Api.Contracts.ProductAdmin.AttributeVocabularyValue>
                    {
                        GenerateAttributeVocabularyValueRandomSDK(),
                        GenerateAttributeVocabularyValueRandomSDK()
                    };
            }
            return attr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute GenerateAttribute(AttributeTypeRule rule)
        {
            var attr = GenerateAttribute();
            attr.InputType = rule.AttributeInputType;
            attr.DataType = rule.AttributeDataType;
            attr.ValueType = rule.AttributeValueType;
            switch (rule.AttributeUsageType.ToLower())
            {
                case "property":
                    attr.IsProperty = true;
                    attr.IsExtra = null;
                    attr.IsOption = null;
                    break;
                case "extra":
                    attr.IsProperty = null;
                    attr.IsExtra = true;
                    attr.IsOption = null;
                    break;
                case "option":
                    attr.IsProperty = null;
                    attr.IsExtra = null;
                    attr.IsOption = true;
                    break;
            }
            return attr;
        }


        #endregion
        #region "GenerateAttributeInProductType"

        /// <summary>
        /// Generate AttributeInProductType object
        /// </summary>
        /// <param name="attributeFQN"></param>
        /// <param name="valueList"></param>
        /// <param name="order"></param>
        /// <param name="isHiddenProperty"></param>
        /// <param name="isInheritedFromBaseType"></param>
        /// <param name="isMultiValueProperty"></param>
        /// <param name="IsRequiredByAdmin"></param>
        /// <returns></returns>
        public static AttributeInProductType GenerateAttributeInProductType(Mozu.Api.Contracts.ProductAdmin.Attribute attr, int? order = null, bool? isHiddenProperty = null, bool? isInheritedFromBaseType = null, bool? isMultiValueProperty = null, bool? IsRequiredByAdmin = null)
        {
            var attrtp = new AttributeInProductType()
            {
                AttributeFQN = attr.AttributeFQN,
                IsHiddenProperty = isHiddenProperty,
                IsInheritedFromBaseType = isInheritedFromBaseType,
                IsMultiValueProperty = isMultiValueProperty,
                IsRequiredByAdmin = IsRequiredByAdmin,
                Order = order,
                //         AttributeDetail = ,
            };
            if (attr.VocabularyValues != null)
            {
                attrtp.VocabularyValues = new List<AttributeVocabularyValueInProductType>();
                foreach (var value in attr.VocabularyValues)
                {
                    attrtp.VocabularyValues.Add(GenerateAttributeVocabularyValueInProductType(value.Value, null));
                }
            }
            return attrtp;
        }

        #endregion
        #region "GenerateAttributeLocalizedContent"

        /// <summary>
        /// generate AttributeLocalizedContent object
        /// </summary>
        /// <param name="localeCode"></param>
        /// <returns></returns>
        public static AttributeLocalizedContent GenerateAttributeLocalizedContent(string localeCode = Constant.LocaleCode)
        {
            return new AttributeLocalizedContent()
            {
                Description = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                LocaleCode = localeCode,
                Name = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly)
            };
        }

        /// <summary>
        /// generate AttributeLocalizedContent object
        /// </summary>
        /// <param name="localeCode"></param>
        /// <returns></returns>
        public static Api.Contracts.ProductAdmin.AttributeLocalizedContent GenerateAttributeLocalizedContentSDK(string localeCode = Constant.LocaleCode)
        {
            return new Api.Contracts.ProductAdmin.AttributeLocalizedContent()
            {
                Description = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                LocaleCode = localeCode,
                Name = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly)
            };
        }

        #endregion
        #region "GenerateAttributeMetaDataItem"

        /// <summary>
        /// generate AttributeMetadataItem object
        /// </summary>
        /// <returns></returns>
        public static AttributeMetadataItem GenerateAttributeMetadataItem()
        {
            return new AttributeMetadataItem()
            {
                Key = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                Value = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly)
            };
        }

        /// <summary>
        /// generate AttributeMetadataItem object
        /// </summary>
        /// <returns></returns>
        public static List<AttributeMetadataItem> GenerateAttributeMetadataItemList()
        {
            return new List<AttributeMetadataItem>();
        }

        /// <summary>
        /// generate AttributeMetadataItem object
        /// </summary>
        /// <returns></returns>
        public static Api.Contracts.ProductAdmin.AttributeMetadataItem GenerateAttributeMetadataItemSDK()
        {
            return new Api.Contracts.ProductAdmin.AttributeMetadataItem()
            {
                Key = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                Value = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly)
            };
        }

        #endregion
        #region "GenerateAttributeValidation"

        /// <summary>
        /// generate AttributeValidation object
        /// </summary>
        /// <param name="maxDate"></param>
        /// <param name="minDate"></param>
        /// <param name="maxNumeric"></param>
        /// <param name="minNumeric"></param>
        /// <param name="maxStringLen"></param>
        /// <param name="minStringLen"></param>
        /// <returns></returns>
        public static AttributeValidation GenerateAttributeValidation(DateTime? maxDate = null, DateTime? minDate = null, decimal? maxNumeric = null,
                                                                      decimal? minNumeric = null, int? maxStringLen = null, int? minStringLen = null, string expression = null)
        {
            return new AttributeValidation()
            {
                MaxDateValue = maxDate,
                MaxNumericValue = maxNumeric,
                MaxStringLength = maxStringLen,
                MinDateValue = minDate,
                MinNumericValue = minNumeric,
                MinStringLength = minStringLen,
                RegularExpression = expression
            };
        }

        /// <summary>
        /// generate AttributeValidation object
        /// </summary>
        /// <param name="maxDate"></param>
        /// <param name="minDate"></param>
        /// <param name="maxNumeric"></param>
        /// <param name="minNumeric"></param>
        /// <param name="maxStringLen"></param>
        /// <param name="minStringLen"></param>
        /// <returns></returns>
        public static Api.Contracts.ProductAdmin.AttributeValidation GenerateAttributeValidationSDK(DateTime? maxDate = null, DateTime? minDate = null, decimal? maxNumeric = null,
                                                                                                    decimal? minNumeric = null, int? maxStringLen = null, int? minStringLen = null, string expression = null)
        {
            return new Api.Contracts.ProductAdmin.AttributeValidation()
            {
                MaxDateValue = maxDate,
                MaxNumericValue = maxNumeric,
                MaxStringLength = maxStringLen,
                MinDateValue = minDate,
                MinNumericValue = minNumeric,
                MinStringLength = minStringLen,
                RegularExpression = expression
            };
        }

        #endregion
        #region "GenerateAttributeVocabularyValue"

        /// <summary>
        /// generate AttributeVocabularyValue object
        /// </summary>
        /// <returns></returns>
        public static AttributeVocabularyValue GenerateAttributeVocabularyValueRandom()
        {
            return new AttributeVocabularyValue()
            {
                Content = GenerateAttributeVocabularyValueLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly)),
                Value = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                //       ValueSequence = 
            };
        }

        /// <summary>
        /// generate AttributeVocabularyValue object
        /// </summary>
        /// <returns></returns>
        public static Api.Contracts.ProductAdmin.AttributeVocabularyValue GenerateAttributeVocabularyValueRandomSDK()
        {
            return new Api.Contracts.ProductAdmin.AttributeVocabularyValue()
            {
                Content = GenerateAttributeVocabularyValueLocalizedContentSdk(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly)),
                Value = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                //       ValueSequence = 
            };
        }

        /// <summary>
        /// generate AttributeVocabularyValue object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AttributeVocabularyValue GenerateAttributeVocabularyValue(string value)
        {
            return new AttributeVocabularyValue()
            {
                Content = GenerateAttributeVocabularyValueLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly)),
                Value = value
            };
        }
        /// <summary>
        /// generate AttributeVocabularyValue object
        /// </summary>
        /// <returns></returns>
        public static List<AttributeVocabularyValue> GenerateAttributeVocabularyValueList()
        {
            return new List<AttributeVocabularyValue>();
        }

        #endregion
        #region "GenerateAttributeVocabularyValueInProductType"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static AttributeVocabularyValueInProductType GenerateAttributeVocabularyValueInProductType(object value, int? order = 0)
        {
            return new AttributeVocabularyValueInProductType()
            {
                Value = value,
                Order = order
            };
        }
        public static List<AttributeVocabularyValueInProductType> GenerateAttributeVocabularyValueInProductTypeList()
        {
            return new List<AttributeVocabularyValueInProductType>();
        }
        #endregion
        #region "GenerateAttributeVocabularyValueLocalizedContent"

        /// <summary>
        /// generate AttributeVocabularyValueLocalizedContent object
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="localeCode"></param>
        /// <returns></returns>
        public static AttributeVocabularyValueLocalizedContent GenerateAttributeVocabularyValueLocalizedContent(string stringValue = null, string localeCode = Constant.LocaleCode)
        {
            return new AttributeVocabularyValueLocalizedContent()
            {
                LocaleCode = localeCode,
                StringValue = stringValue
            };
        }

        /// <summary>
        /// generate AttributeVocabularyValueLocalizedContent object
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="localeCode"></param>
        /// <returns></returns>
        public static Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent GenerateAttributeVocabularyValueLocalizedContentSdk(string stringValue = null, string localeCode = Constant.LocaleCode)
        {
            return new Api.Contracts.ProductAdmin.AttributeVocabularyValueLocalizedContent()
            {
                LocaleCode = localeCode,
                StringValue = stringValue
            };
        }

        #endregion

        #region "GenerateBillingInfo"

        /// <summary>
        /// Generates a new BillingInfo object using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="type"> Type of payment, such as credit card or check by mail.</param>
        /// <param name="contact">Card holder's billing address.</param>
        /// <param name="isSameShippingAddr">Indicates that billing and shipping address are the same</param>
        /// <param name="card">Card information if the customer is paying by credit card.</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(string type,
            Mozu.Api.Contracts.Core.Contact contact, bool isSameShippingAddr, Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard card)
        {

            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = type,
                BillingContact = contact,
                IsSameBillingShippingAddress = isSameShippingAddr,
                Card = card
            };
        }


        /// <summary>
        /// Generates a new BillingInfo object when pay by check using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="state">The state of credit card holder's billing address.</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(string state, string zip)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = "Check",
                BillingContact = GenerateContactRandom(state, zip),
                IsSameBillingShippingAddress = false
            };
        }


        /// <summary>
        /// Generates a new BillingInfo object when pay by credit card using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="state">The state of credit card holder's billing address.</param>
        /// <param name="cardType">Card type such as Visa, MasterCard, American Express, or Discover.</param>
        /// <param name="month">Month when the card expires.</param>
        /// <param name="year">Year when the card expires.</param>
        /// <param name="card"></param>
        /// <param name="cardId"></param>
        /// <param name="savePart"></param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(string state, string zip,
            Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard card,
            string savePart, bool sameShippingAddr = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = "CreditCard",
                BillingContact = GenerateContactRandom(state, zip),
                IsSameBillingShippingAddress = sameShippingAddr,
                Card = card
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(string state, string zip,
            bool sameShippingAddr = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = "PaypalExpress",
                BillingContact = GenerateContactRandom(state, zip),
                IsSameBillingShippingAddress = sameShippingAddr
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(string state, string zip,
            string creditCode, bool sameShippingAddr = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = "StoreCredit",
                BillingContact = GenerateContactRandom(state, zip),
                IsSameBillingShippingAddress = sameShippingAddr,
                StoreCreditCode = creditCode
            };
        }

        //use for address validation tests
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo GenerateBillingInfo(
            Mozu.Api.Contracts.Core.Contact contact)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo()
            {
                PaymentType = "Check",
                BillingContact = contact,
                IsSameBillingShippingAddress = true
            };
        }
        #endregion

        #region "GenerateCategory"

        /// <summary>
        /// generate Category object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isDisplayed"></param>
        /// <param name="parentCategoryId"></param>
        /// <returns></returns>
        public static Category GenerateCategory(string name, bool? isDisplayed = true, int? parentCategoryId = null)
        {
            return new Category()
            {
                Content = GenerateCategoryLocalizedContent(name),
                IsDisplayed = isDisplayed,
                ParentCategoryId = parentCategoryId,
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Category GenerateCategory()
        {
            return new Category()
            {
                Content = GenerateCategoryLocalizedContent(Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly)),
                IsDisplayed = true
            };
        }

        #endregion

        #region "GenerateCategoryLocalizedContent"

        /// <summary>
        /// generate CategoryLocalizedContent object
        /// </summary>
        /// <param name="localeCode"></param>
        /// <returns></returns>
        public static CategoryLocalizedContent GenerateCategoryLocalizedContent(string name = null, string localeCode = Constant.LocaleCode)
        {
            return new CategoryLocalizedContent()
            {
                Description = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                LocaleCode = localeCode,
                MetaTagDescription = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                MetaTagKeywords = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                MetaTagTitle = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly),
                Name = name,
                PageTitle = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                Slug = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
            };
        }

        #endregion

        #region "GenerateCards"

        /// <summary>
        /// Used for testing authorize.net --> for error case, type = null
        /// </summary>
        /// <param name="sendPart"></param>
        /// <param name="paymentServiceCardId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard GenerateDefaultCard(string sendPart, string paymentServiceCardId, string type = null)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard
            {
                //NumberPart = sendPart,
                //CVV = "223",
                //PersistCard = true,
                //CardType = type ?? "Visa",
                ExpireMonth = 12,
                ExpireYear = 2020,
                NameOnCard = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                CardNumberPartOrMask = sendPart,
                IsCardInfoSaved = false,
                IsUsedRecurring = false,
                PaymentOrCardType = type ?? "Visa",
                PaymentServiceCardId = paymentServiceCardId
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard GenerateCard(string numberPart = "411111111111****",
                                                                      short expireYear = 2018,
                                                                      short expireMonth = 4,
                                                                      int cardIssueYear = 2010,
                                                                      int cardIssueMonth = 8,
                                                                      string cardType = "Visa",
                                                                      string cardIssueNumber = "123",
                                                                      string cVV = "123",
                                                                      bool persistCard = true,
                                                                      string cardHolderName = "Test User"
            )
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard
            {
                CardNumberPartOrMask = numberPart,
                ExpireYear = expireYear,
                ExpireMonth = expireMonth,
                IsCardInfoSaved = false,
                IsUsedRecurring = false,
                NameOnCard = cardHolderName,
                PaymentOrCardType = cardType,
                PaymentServiceCardId = null
                //PaymentOrCardType = cardType,
                //CardIssueYear = cardIssueYear,
                //CardIssueMonth = cardIssueMonth,
                //CardType = cardType,
                //CardIssueNumber = cardIssueNumber,
                //CVV = cVV,
                //PersistCard = persistCard,
                //CardHolderName = cardHolderName
            };
        }
        #endregion

        #region "GenerateCustomerAccountAndAuthInfo"

        public static CustomerAccountAndAuthInfo GenerateCustomerAccountAndAuthInfo(CustomerAccount customerAccount, bool isImport = false, string passwd = Constant.Password)
        {
            return new CustomerAccountAndAuthInfo()
            {
                Account = customerAccount ?? GenerateCustomerAccountRandom(),
                Password = passwd,
                IsImport = isImport
            };
        }
        public static CustomerLoginInfo GenerateCustomerLoginInfo(string email, string userName, string passwd = Constant.Password)
        {
            return new CustomerLoginInfo()
            {
                EmailAddress = email,
                Username = userName,
                Password = passwd
            };
        }
        #endregion
        #region "GenerateCustomerAuthInfo"

        /// <summary>
        /// Generate CustomerUserAuthInfo Object.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public static CustomerUserAuthInfo GenerateCustomerUserAuthInfo(string userName, string passwd = "MozuPass1")
        {
            if (string.IsNullOrEmpty(userName))
                userName = Generator.RandomString(15, RandomCharacterGroup.AlphaNumericOnly);

            return new CustomerUserAuthInfo()
            {
                Username = userName,
                Password = passwd
            };
        }

        /// <summary>
        /// Generate CustomerUserAuthInfo Object.
        /// </summary>
        /// <returns></returns>
        public static CustomerUserAuthInfo GenerateCustomerUserAuthInfo()
        {
            return new CustomerUserAuthInfo();
        }
        #endregion
        #region "GenerateCustomerAddress"
        public enum AddressType
        {
            [EnumMember]
            None,
            [EnumMember]
            Residential,
            [EnumMember]
            Commercial,
        }
        /// <summary>
        /// Generates a new Address object using <see cref="Address" /> class.
        /// </summary>
        /// <param name="addr1"></param>
        /// <param name="addr2"></param>
        /// <param name="addr3"></param>
        /// <param name="addr4"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddress(string addr1, string addr2, string addr3, string addr4,
            string city, string country, string zip, string state, AddressType addressType = AddressType.Residential)
        {
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = addr1,
                Address2 = addr2,
                Address3 = addr3,
                Address4 = addr4,
                CountryCode = country,
                CityOrTown = city,
                PostalOrZipCode = zip,
                StateOrProvince = state,
                AddressType = addressType.ToString()
            };
        }
        /// <summary>
        /// Generates a new Address object using <see cref="Address" /> class.
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddressReal(bool isValidated = true, string addressType = "Residential")
        {

            return ReturnValidAddresses();
            /*
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = "360 Nueces St",
                Address2 = null,
                Address3 = null,
                Address4 = null,
                CountryCode = "US",
                CityOrTown = "Austin",
                PostalOrZipCode = "78701-4195",
                StateOrProvince = "TX",
                AddressType = addressType,
                IsValidated = isValidated
            };*/
        }



        /// <summary>
        /// Generate Random Address Object.
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddressRandom(AddressType addressType = AddressType.Residential)
        {
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = string.Format("{0} {1}", Generator.RandomString(8, Generator.RandomCharacterGroup.NumericOnly), Generator.RandomString(75, Generator.RandomCharacterGroup.AlphaNumericOnly)),
                Address2 = Generator.RandomString(49, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address3 = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address4 = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaNumericOnly),
                CityOrTown = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                CountryCode = Generator.RandomString(2, Generator.RandomCharacterGroup.AlphaOnly),
                PostalOrZipCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                StateOrProvince = RandomState(),
                AddressType = addressType.ToString()
            };
        }

        public static Mozu.Api.Contracts.Core.Address GenerateAddress(bool random = true, bool validated = true, string state = "", AddressType addressType = AddressType.Residential)
        {
            if (random && validated)
            {
                return GenerateAddressValidated(addressType);
            }
            else if (random)
            {
                return GenerateAddressRandom(addressType);
            }
            else //(!random)
            {
                return GenerateAddressReal(true);
            }

        }

        /// <summary>
        /// Generate Random Address Object.
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddressValidated(AddressType addressType = AddressType.Residential)
        {
            Mozu.Api.Contracts.Core.Address address = ReturnValidAddresses();
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                Address3 = address.Address3,
                Address4 = address.Address4,
                CityOrTown = address.CityOrTown,
                CountryCode = address.CountryCode,
                PostalOrZipCode = address.PostalOrZipCode,
                StateOrProvince = address.StateOrProvince,
                AddressType = addressType.ToString(),
                IsValidated = true
            };
        }


        public static Mozu.Api.Contracts.Core.Address ReturnValidAddresses(string addressType = "Residential", string state = "")
        {
            var validAddress = new List<Mozu.Api.Contracts.Core.Address>();
            var i = 0;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Alabama Bureau of Tourism & Travel";
            validAddress[i].Address2 = "PO Box 4927";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Montgomery";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "36103";
            validAddress[i].StateOrProvince = "AL";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Alaska Division of Tourism";
            validAddress[i].Address2 = "PO Box 110801";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Juneau";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "99811-0801";
            validAddress[i].StateOrProvince = "AK";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Arizona Office of Tourism";
            validAddress[i].Address2 = "1110 W. Washington Street, Suite 155";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Phoenix";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "85007";
            validAddress[i].StateOrProvince = "AZ";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true; 
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Arkansas Department of Parks and Tourism";
            validAddress[i].Address2 = "One Capitol Mall";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Little Rock";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "72201";
            validAddress[i].StateOrProvince = "AR";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "California Division of Tourism";
            validAddress[i].Address2 = "PO Box 1499";
            validAddress[i].Address3 = "Dept TIA";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Sacramento";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "95812";
            validAddress[i].StateOrProvince = "CA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Colorado Tourism Office";
            validAddress[i].Address2 = "1625 Broadway";
            validAddress[i].Address3 = "Suite 2700";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Denver";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "80202";
            validAddress[i].StateOrProvince = "CO";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Connecticut Commission on Culture & Tourism";
            validAddress[i].Address2 = "One Financial Plaza";
            validAddress[i].Address3 = "755 Main Street";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Hartford";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "06103";
            validAddress[i].StateOrProvince = "CT";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Delaware Tourism Office";
            validAddress[i].Address2 = "99 Kings Highway";
            validAddress[i].Address3 = "PO Box 1401";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Dover";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "19903";
            validAddress[i].StateOrProvince = "DE";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Florida Office of Tourism";
            validAddress[i].Address2 = "PO Box 1100";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Tallahassee";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "32302";
            validAddress[i].StateOrProvince = "FL";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Georgia Department of Economic Development";
            validAddress[i].Address2 = "75 Fifth Street, N.W., Suite 1200";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Atlanta";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "30308";
            validAddress[i].StateOrProvince = "GA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Hawaii Department of Business, Economic ";
            validAddress[i].Address2 = "PO Box 2359";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Honolulu";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "96804";
            validAddress[i].StateOrProvince = "HI";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Idaho Department of Commerce, Travel, Leisure";
            validAddress[i].Address2 = "700 West State St.";
            validAddress[i].Address3 = "PO Box 83720";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Boise";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "83720-0093";
            validAddress[i].StateOrProvince = "ID";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Illinois Dept. of Commerce and Community Affairs";
            validAddress[i].Address2 = "620 E. Adams";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Springfield";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "62701";
            validAddress[i].StateOrProvince = "IL";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Indiana Department of Tourism";
            validAddress[i].Address2 = "One North Capitol";
            validAddress[i].Address3 = "Suite 700";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Indianapolis";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "46204";
            validAddress[i].StateOrProvince = "IN";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Iowa Dept. of Economic Development";
            validAddress[i].Address2 = "200 East Grand Ave.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Des Moines";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "50309";
            validAddress[i].StateOrProvince = "IA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Kansas Dept. of Commerce";
            validAddress[i].Address2 = "Travel And Tourism Div.";
            validAddress[i].Address3 = "1000 S.W. Jackson Street Suite 100";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Topeka";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "66612";
            validAddress[i].StateOrProvince = "KS";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Kentucky Department of Travel";
            validAddress[i].Address2 = "500 Mero St. #2200";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Frankfurt";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "40601";
            validAddress[i].StateOrProvince = "KY";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Louisiana Dept. of Culture, Recreation and Tourism";
            validAddress[i].Address2 = "PO Box 94291";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Baton Rouge";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "70804-9291";
            validAddress[i].StateOrProvince = "LA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Maine Office of Tourism";
            validAddress[i].Address2 = "59 Statehouse Station";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Augusta";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "04333-0059";
            validAddress[i].StateOrProvince = "ME";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Maryland Office of Tourism Development ";
            validAddress[i].Address2 = "217 E. Redwood St., 9th Floor";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Baltimore";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "21202";
            validAddress[i].StateOrProvince = "MD";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Massachusetts Office of Travel and Tourism";
            validAddress[i].Address2 = "10 Park Plaza, Suite 4510";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Boston";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "02116";
            validAddress[i].StateOrProvince = "MA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Travel Michigan";
            validAddress[i].Address2 = "P.O. Box 30226";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Lansing";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "48909-7726";
            validAddress[i].StateOrProvince = "MI";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Minnesota Office of Tourism ";
            validAddress[i].Address2 = "100 Metro Square, 121 7th Place E.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "St. Paul";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "55101-2146";
            validAddress[i].StateOrProvince = "MN";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Mississippi Division of Tourism Development ";
            validAddress[i].Address2 = "P.O. Box 849";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Jackson";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "39205";
            validAddress[i].StateOrProvince = "MS";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Missouri Division of Tourism";
            validAddress[i].Address2 = "P.O. Box 1055";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Jefferson City";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "65102";
            validAddress[i].StateOrProvince = "MO";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Travel Montana";
            validAddress[i].Address2 = "P.O. Box 200533";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Helena";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "59620-0533";
            validAddress[i].StateOrProvince = "MT";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Nebraska Tourism Information Center ";
            validAddress[i].Address2 = "P.O. Box 98907";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Lincoln";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "68509-8907";
            validAddress[i].StateOrProvince = "NE";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Nevada Commission on Tourism ";
            validAddress[i].Address2 = "401 N. Carson St.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Carson City";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "89701";
            validAddress[i].StateOrProvince = "NV";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "New Hampshire Division of Travel and Tourism";
            validAddress[i].Address2 = "P.O. Box 1856";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Concord";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "03302-1856";
            validAddress[i].StateOrProvince = "NH";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "New Jersey Commerce and Economic Growth Commission,";
            validAddress[i].Address2 = "20 W. State St., P.O. Box 820";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Trenton";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "08625";
            validAddress[i].StateOrProvince = "NJ";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "New Mexico Department of Tourism ";
            validAddress[i].Address2 = "491 Old Santa Fe Trail";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Santa Fe";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "87501";
            validAddress[i].StateOrProvince = "NM";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "New York State, Division of Tourism ";
            validAddress[i].Address2 = "P.O. Box 2603";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Albany";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "12220-0603";
            validAddress[i].StateOrProvince = "NY";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "North Carolina Division of Tourism";
            validAddress[i].Address2 = "301 N. Wilmington St., 4324 ";
            validAddress[i].Address3 = "Mail Service Center";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Raleigh";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "27699";
            validAddress[i].StateOrProvince = "NC";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "North Dakota Tourism";
            validAddress[i].Address2 = "400 E. Broadway, Suite 50, P.O. Box 2057";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Bismarck";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "58502";
            validAddress[i].StateOrProvince = "ND";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Ohio Division of Travel and Tourism ";
            validAddress[i].Address2 = "P.O. Box 1001";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Columbus";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "43216-1001";
            validAddress[i].StateOrProvince = "OH";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Oklahoma Department of Tourism";
            validAddress[i].Address2 = "P.O. Box 60789";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Oklahoma City";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "73146";
            validAddress[i].StateOrProvince = "OK";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Oregon Tourism Commission";
            validAddress[i].Address2 = "775 Summer St. N.E.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Salem";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "97301-1282";
            validAddress[i].StateOrProvince = "OR";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Pennsylvania Center for Travel, Tourism and Film Promotion ";
            validAddress[i].Address2 = "400 North St., 4th Floor";
            validAddress[i].Address3 = "Commonwealth Keystone Building";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Harrisburg";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "17120-0225";
            validAddress[i].StateOrProvince = "PA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Puerto Rico Tourism Co. ";
            validAddress[i].Address2 = "3575 W. Cahuenga Blvd., Suite 405";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Los Angeles";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "90068";
            validAddress[i].StateOrProvince = "CA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Rhode Island Travel and Tourism Division";
            validAddress[i].Address2 = "1 W. Exchange St.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Providence";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "29201";
            validAddress[i].StateOrProvince = "RI";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "South Carolina Parks, Recreation and Tourism";
            validAddress[i].Address2 = "1205 Pendleton St.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Columbia";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "29201";
            validAddress[i].StateOrProvince = "SC";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "South Dakota Department of Tourism ";
            validAddress[i].Address2 = "711 E. Wells Ave.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Pierre";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "57501";
            validAddress[i].StateOrProvince = "SD";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Tennessee Department of Tourist Development, Rachel Jackson Building ";
            validAddress[i].Address2 = "5th Floor, 320 6th Ave. N.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Nashville";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "37243";
            validAddress[i].StateOrProvince = "TN";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Texas Department of Economic Development-Tourism Division ";
            validAddress[i].Address2 = "P.O. Box 12728";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Austin";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "78711-2728";
            validAddress[i].StateOrProvince = "TX";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "U.S. Virgin Islands Department of Tourism ";
            validAddress[i].Address2 = "3460 Wilshire Blvd., Suite 412";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Los Angeles";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "90010";
            validAddress[i].StateOrProvince = "CA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Utah Travel Council, Capitol Hill/Council Hall ";
            validAddress[i].Address2 = "300 N. State St.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Salt Lake City";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "84114";
            validAddress[i].StateOrProvince = "UT";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Vermont Department of Tourism and Marketing";
            validAddress[i].Address2 = "6 Baldwin St., Drawer 33";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Montpelier";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "05633-1301";
            validAddress[i].StateOrProvince = "VT";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Virginia Tourism Corp. ";
            validAddress[i].Address2 = "901 E. Byrd St.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Richmond";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "23219";
            validAddress[i].StateOrProvince = "VA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Washington State Tourism ";
            validAddress[i].Address2 = "P.O. Box 42500";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Olympia";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "98504-2500";
            validAddress[i].StateOrProvince = "WA";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Washington, D.C., Convention and Tourism Corp.";
            validAddress[i].Address2 = "1212 New York Ave. N.W., Suite 600";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Washington";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "20005";
            validAddress[i].StateOrProvince = "DC";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "West Virginia Tourism ";
            validAddress[i].Address2 = "90 MacCorkle Ave. S.W.";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "South Charleston";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "25303";
            validAddress[i].StateOrProvince = "WV";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Wisconsin Department of Tourism and Travel Information ";
            validAddress[i].Address2 = "P.O. Box 7606";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Madison";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "53707";
            validAddress[i].StateOrProvince = "WI";
            validAddress[i].AddressType = addressType;
            validAddress[i].IsValidated = true;
            i++;
            validAddress.Add(new Mozu.Api.Contracts.Core.Address());
            validAddress[i].Address1 = "Wyoming Division of Tourism ";
            validAddress[i].Address2 = "I-25 at College Drive";
            validAddress[i].Address3 = "";
            validAddress[i].Address4 = "";
            validAddress[i].CityOrTown = "Cheyenne";
            validAddress[i].CountryCode = "US";
            validAddress[i].PostalOrZipCode = "82002";
            validAddress[i].StateOrProvince = "WY";
            validAddress[i].AddressType = addressType;

            return validAddress[new Random().Next(0, validAddress.Count)];

        }


        /// <summary>
        /// Generate Address Object with meaningful CountryCode, ZipCode and State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddress(string state, string zip, string country = "US")
        {
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = string.Format("{0} {1}", Generator.RandomString(8, Generator.RandomCharacterGroup.NumericOnly), Generator.RandomString(75, Generator.RandomCharacterGroup.AlphaNumericOnly)),
                Address2 = Generator.RandomString(49, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address3 = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address4 = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaNumericOnly),
                CityOrTown = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                CountryCode = country,
                PostalOrZipCode = zip,
                StateOrProvince = state
            };
        }


        public static Mozu.Api.Contracts.Core.Address GenerateInternationalAddress(string country)
        {
            var address = new Mozu.Api.Contracts.Core.Address();
            address.CountryCode = country;
            address.IsValidated = true;
            switch (country)
            {
                case "CA":
                    address.Address1 = "1 Sussex Drive";
                    address.CityOrTown = "Ottawa";
                    address.PostalOrZipCode = "K1A 0A1";
                    address.StateOrProvince = "Ontario";
                    break;
                case "GB":
                    address.Address1 = "HARTMANNSTRASSE 7";
                    address.CityOrTown = "BONN";
                    address.PostalOrZipCode = "53001";
                    address.StateOrProvince = "";
                    break;
                case "TW":
                    address.Address1 = "3F #12 LN 410 SEC 2 PA-TEH RD";
                    address.CityOrTown = "TAIPEI";
                    address.PostalOrZipCode = "105";
                    address.StateOrProvince = "";
                    break;
            }
            return (address);
        }


        /// <summary>
        /// Generate Address Object with meaningful CountryCode, ZipCode and State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddress(string state, string zip, bool realAddress = false, string country = "US")
        {
            var address = new Mozu.Api.Contracts.Core.Address
            {
                CountryCode = country,
                PostalOrZipCode = zip,
                StateOrProvince = state,
                IsValidated = true
            };
            if (realAddress)
            {
                if (state.ToUpper().Equals("TX") && zip.Equals("78717"))
                {
                    address.Address1 = "9900 W. Parmer Lane";
                    address.CityOrTown = "Austin";
                }
                else if (state.ToUpper().Equals("NY") && zip.Equals("11238"))
                {
                    address.Address1 = "950 Fulton St";
                    address.CityOrTown = "Brooklyn";
                }
                else if (state.ToUpper().Equals("NC") && zip.Equals("27601"))
                {
                    address.Address1 = "91 E Edenton St";
                    address.CityOrTown = "Raleigh";
                }
                else if (state.ToUpper().Equals("CA") && zip.Equals("95814"))
                {
                    address.Address1 = "State Capital, Suite 1173";
                    address.CityOrTown = "Sacramento";
                }
                else
                {
                    throw (new TestInconclusiveException(0, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(CultureInfo.InvariantCulture),
                       null, "No real address found."));
                }
            }
            else
            {
                return new Mozu.Api.Contracts.Core.Address()
                {
                    Address1 =
                        string.Format("{0} {1}",
                                      Generator.RandomString(8, Generator.RandomCharacterGroup.NumericOnly),
                                      Generator.RandomString(75, Generator.RandomCharacterGroup.AlphaNumericOnly)),
                    Address2 = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                    Address3 = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaNumericOnly),
                    Address4 = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaNumericOnly),
                    CityOrTown = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                    CountryCode = country,
                    PostalOrZipCode = zip,
                    StateOrProvince = state
                };
            }
            return address;
        }

        /// <summary>
        /// Generate Random Address Object.
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Address GenerateAddress(string addressType)
        {
            addressType = addressType.ToUpper();
            AddressType type;

            switch (addressType)
            {
                case "RESIDENTIAL":
                    {
                        type = AddressType.Residential;
                        break;
                    }
                case "COMMERCIAL":
                    {
                        type = AddressType.Commercial;
                        break;
                    }
                case "NONE":
                    {
                        type = AddressType.None;
                        break;
                    }
                default:
                    {
                        //type = AddressType.None;
                        type = AddressType.Residential;

                        break;
                    }
                    break;
            }
            return new Mozu.Api.Contracts.Core.Address()
            {
                Address1 = string.Format("{0} {1}", Generator.RandomString(8, Generator.RandomCharacterGroup.NumericOnly), Generator.RandomString(75, Generator.RandomCharacterGroup.AlphaNumericOnly)),
                Address2 = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address3 = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Address4 = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaNumericOnly),
                CityOrTown = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                CountryCode = Generator.RandomString(2, Generator.RandomCharacterGroup.AlphaOnly),
                PostalOrZipCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                StateOrProvince = RandomState(),
                AddressType = type.ToString()
            };
        }

        #endregion

        #region "GenerateContact"

        public static Mozu.Api.Contracts.Core.Contact GenerateContactRandom()
        {
            return new Mozu.Api.Contracts.Core.Contact
            {
                Address = Generator.GenerateAddressRandom(),
                CompanyOrOrganization = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                LastNameOrSurname = Generator.RandomString(35, Generator.RandomCharacterGroup.AlphaOnly),
                PhoneNumbers = Generator.GeneratePhoneRandom()
            };
        }

        public static Mozu.Api.Contracts.Core.Contact GenerateContactRandom(string state, string zip)
        {
            return new Mozu.Api.Contracts.Core.Contact
            {
                Address = Generator.GenerateAddress(state, zip, "US"),
                CompanyOrOrganization = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                LastNameOrSurname = Generator.RandomString(35, Generator.RandomCharacterGroup.AlphaOnly),
                PhoneNumbers = Generator.GeneratePhoneRandom(),
            };
        }

        public static Mozu.Api.Contracts.Core.Contact GenerateContactRealAddress(bool isValidated = false)
        {
            return new Mozu.Api.Contracts.Core.Contact
            {
                Address = Generator.GenerateAddressReal(isValidated),
                CompanyOrOrganization = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                LastNameOrSurname = Generator.RandomString(35, Generator.RandomCharacterGroup.AlphaOnly),
                PhoneNumbers = Generator.GeneratePhoneRandom(),
            };
        }

        public static Mozu.Api.Contracts.Core.Contact GenerateContactRealAddress(bool isValidated, string firstname, string lastname, string email, string addressType = "Residential")
        {
            return new Mozu.Api.Contracts.Core.Contact
            {
                Address = Generator.GenerateAddressReal(isValidated, addressType: addressType),
                CompanyOrOrganization = Generator.RandomString(50, Generator.RandomCharacterGroup.AlphaNumericOnly),
                Email = email,
                FirstName = firstname,
                MiddleNameOrInitial = "",
                LastNameOrSurname = lastname,
                PhoneNumbers = Generator.GeneratePhoneRandom(),
            };
        }

        public static Mozu.Api.Contracts.Core.Contact GenerateInternationalContact(string country)
        {
            return new Mozu.Api.Contracts.Core.Contact()
            {
                Address = GenerateInternationalAddress(country),
                CompanyOrOrganization = Generator.RandomString(8, Generator.RandomCharacterGroup.AlphaOnly),
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                LastNameOrSurname = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                PhoneNumbers = GeneratePhoneRandom()
            };
        }
        /// <summary>
        /// Generates a new Contact object using <see cref="RandomContact" /> class.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Contact GenerateContact(string state, string zip, bool isRealAddress = false)
        {
            return new Mozu.Api.Contracts.Core.Contact()
            {
                Address = GenerateAddress(state, zip, isRealAddress),
                CompanyOrOrganization = "Volusion",
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                LastNameOrSurname = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                PhoneNumbers = GeneratePhoneRandom()
            };
        }
        #endregion

        #region "GenerateCustomerAccount"

        /// <summary>
        /// Generate Customer Account
        /// </summary>
        /// <param name="taxExempt"></param>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public static CustomerAccountAndAuthInfo GenerateCustomerAccountAndAuthInfo(bool taxExempt = false, string taxId = null)
        {
            var firstname = GenerateFirstName();
            var lastname = GenerateLastName();
            var username = firstname + lastname; // or use Generator.RandomString(12, RandomCharacterGroup.AlphaOnly);
            var email = RandomEmailAddressMozu();
            var customer = new CustomerAccount()
            {
                AcceptsMarketing = false,
                CompanyOrOrganization = RandomCompanyName(),
                Contacts = new List<CustomerContact>() { GenerateCustomerContact(0, GenerateAddressRandom(addressType: AddressType.Residential), email, firstname, "", lastname) },
                EmailAddress = email, // username + "@mozu.com",//Generator.RandomEmailAddress(),
                FirstName = firstname, // or use Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                LastName = lastname, // or use Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                UserName = username,
                TaxExempt = taxExempt,
                TaxId = taxId,
                LocaleCode = Constant.LocaleCode,
                Notes = new List<CustomerNote>() { GenerateCustomerNote() }
            };

            var customerAccountAndAuthInfo = new CustomerAccountAndAuthInfo
            {
                Account = customer,
                Password = Constant.Password
            };

            return customerAccountAndAuthInfo;
        }

        /// <summary>
        /// Generate Customer Account
        /// </summary>
        /// <param name="taxExempt"></param>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public static CustomerAccountAndAuthInfo GenerateCustomerAccountAndAuthInfoRandom(bool taxExempt = false, string taxId = null)
        {
            var firstname = Generator.RandomString(8, RandomCharacterGroup.AlphaOnly);
            var lastname = Generator.RandomString(8, RandomCharacterGroup.AlphaOnly);
            var username = firstname + lastname; // or use Generator.RandomString(12, RandomCharacterGroup.AlphaOnly);
            var customer = new CustomerAccount()
            {
                AcceptsMarketing = false,
                CompanyOrOrganization = "Volusion",
                Contacts = new List<CustomerContact>() { GenerateCustomerContact(0, GenerateAddressRandom(addressType: AddressType.Residential), username + "@mozu.com", firstname, "", lastname) },
                EmailAddress = username + "@mozu.com",//Generator.RandomEmailAddress(),
                FirstName = firstname, // or use Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                LastName = lastname, // or use Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                UserName = username,
                TaxExempt = taxExempt,
                TaxId = taxId,
                LocaleCode = Constant.LocaleCode,
                Notes = new List<CustomerNote>() { GenerateCustomerNote() }
            };

            var customerAccountAndAuthInfo = new CustomerAccountAndAuthInfo
            {
                Account = customer,
                Password = Constant.Password
            };

            return customerAccountAndAuthInfo;
        }

        /// <summary>
        /// Generate Customer Account
        /// </summary>
        /// <param name="customerAccount"></param>
        /// <returns></returns>
        public static CustomerAccountAndAuthInfo GenerateCustomerAccountAndAuthInfo(CustomerAccount customerAccount)
        {
            var customerAccountAndAuthInfo = new CustomerAccountAndAuthInfo
            {
                Account = customerAccount,
                Password = Constant.Password
            };

            return customerAccountAndAuthInfo;
        }

        public static CustomerAccountAndAuthInfo GenerateCustomerAccountAndAuthInfo()
        {
            return new CustomerAccountAndAuthInfo();
        }
        /// <summary>
        /// Generate Random Customer Note
        /// </summary>
        /// <returns></returns>
        public static CustomerNote GenerateCustomerNote()
        {
            return new CustomerNote()
            {
                Content = Generator.RandomString(maxLength: 25, characterGroup: RandomCharacterGroup.AnyCharacter)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="numAccounts"></param>
        /// <param name="numContacts"></param>
        /// <param name="expectedCode"></param>
        /// <param name="successCode"></param>
        /// <returns></returns>
        public static List<CustomerAccount> AddAccountsRandom(ServiceClientMessageHandler handler, int numAccounts,
                                                              int numContacts,
                                                              HttpStatusCode expectedCode = HttpStatusCode.Created,
                                                              HttpStatusCode successCode = HttpStatusCode.Created)
        {

            var custAccts = new List<CustomerAccount>();
            for (int i = 0; i < numAccounts; i++)
            {
                var accountObj = GenerateCustomerAccountRandom();
                var customerAccount = CustomerAccountFactory.AddAccount(handler: handler, account: accountObj,
                                                                        expectedCode: expectedCode);
                custAccts.Add(customerAccount);
                for (int x = 0; x < numContacts; x++)
                {
                    var contacts = GenerateCustomerContactsRandom(accountId: customerAccount.Id,
                                                                  numContacts: numContacts);
                    CustomerContactFactory.AddAccountContact(handler: handler, contact: contacts[x],
                                                             accountId: customerAccount.Id);
                }
            }
            return custAccts;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccount(string userId)
        {
            return new CustomerAccount()
            {
                UserId = userId,
                CompanyOrOrganization = RandomCompanyName()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccount(string userId, CustomerContact item)
        {
            return new CustomerAccount()
            {
                UserId = userId,
                Contacts = new List<CustomerContact>() { item }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccountRandom(bool taxExempt = false, string taxId = null, string emailAddress = null, bool acceptsMarketing = true)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                emailAddress = Generator.RandomEmailAddress();
            }
            return new CustomerAccount()
            {
                AcceptsMarketing = acceptsMarketing,
                CompanyOrOrganization = RandomCompanyName(),
                Contacts = new List<CustomerContact>() { GenerateCustomerContact(0, GenerateAddressRandom(addressType: AddressType.Residential)) },
                EmailAddress = emailAddress,
                FirstName = GenerateFirstName(), //  Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                LastName = GenerateLastName(), // Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                UserName = Generator.RandomString(14, RandomCharacterGroup.AlphaOnly),
                TaxExempt = taxExempt,
                TaxId = taxId,
                LocaleCode = Constant.LocaleCode,
                Notes = new List<CustomerNote>() { GenerateCustomerNote() }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccountVeryRandom(bool taxExempt = false, string taxId = null, string emailAddress = null)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                emailAddress = Generator.RandomEmailAddress();
            }
            return new CustomerAccount()
            {
                AcceptsMarketing = false,
                CompanyOrOrganization = RandomCompanyName(),
                Contacts = new List<CustomerContact>() { GenerateCustomerContact(0, GenerateAddressRandom(addressType: AddressType.Residential)) },
                EmailAddress = emailAddress,
                FirstName =  Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                LastName = Generator.RandomString(10, RandomCharacterGroup.AlphaOnly),
                UserName = Generator.RandomString(14, RandomCharacterGroup.AlphaOnly),
                TaxExempt = taxExempt,
                TaxId = taxId,
                LocaleCode = Constant.LocaleCode,
               
                Notes = new List<CustomerNote>() { GenerateCustomerNote() }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccountValidatedRandom(bool taxExempt = false, string taxId = null, string emailAddress = null, bool acceptsMarketing = true)
        {
            var firstName = GenerateFirstName();
            var lastName = GenerateLastName();
            var companyName = RandomCompanyName();
            if (string.IsNullOrEmpty(emailAddress))
            {
                emailAddress = Generator.RandomEmailAddressMozu();
            }


            return new CustomerAccount()
            {
                AcceptsMarketing = acceptsMarketing,
                CompanyOrOrganization = companyName,
                Contacts = new List<CustomerContact>() { GenerateCustomerContact(accountId:0,address: GenerateAddress(random: true, validated: true, 
                                                        addressType: AddressType.Residential), email:emailAddress, firstname:firstName,lastnameorsurname :lastName, middlename:"",
                                                        companyName: companyName) },
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName,
                UserName = emailAddress.Replace("@Mozu.com","").Replace("@gmail.com",""),
                TaxExempt = taxExempt,
                TaxId = taxId,
                LocaleCode = Constant.LocaleCode,
                
                Notes = new List<CustomerNote>() { GenerateCustomerNote() }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyOrOrganization"></param>
        /// <param name="commerceSummary"></param>
        /// <param name="item"></param>
        /// <param name="groups"></param>
        /// <param name="attributes"></param>
        /// <param name="notes"></param>
        /// <param name="acceptsMarketing"></param>
        /// <param name="taxExempt"></param>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public static CustomerAccount GenerateCustomerAccount(string userId, string companyOrOrganization, CommerceSummary commerceSummary,
            CustomerContact item, List<CustomerAttribute> attributes, List<CustomerNote> notes, bool acceptsMarketing,
            bool taxExempt, string taxId)
        {
            return new CustomerAccount()
            {
                UserId = userId,
                CommerceSummary = commerceSummary,
                CompanyOrOrganization = companyOrOrganization,
                Contacts = new List<CustomerContact>() { item },
                Attributes = attributes,
                Notes = notes,
                AcceptsMarketing = acceptsMarketing,
                TaxExempt = taxExempt,
                TaxId = taxId
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalOrderAmount"></param>
        /// <param name="orderCount"></param>
        /// <param name="wishlistCount"></param>
        /// <param name="lastOrderDate"></param>
        /// <returns></returns>
        public static CommerceSummary GenerateCommerceSummary(decimal totalOrderAmount, int orderCount,
                                                              int wishlistCount, DateTime? lastOrderDate = null)
        {
            var amount = new CurrencyAmount
            {
                Amount = totalOrderAmount,
                CurrencyCode = "USD"
            };
            return new CommerceSummary()
            {
                TotalOrderAmount = amount,
                OrderCount = orderCount,
                WishlistCount = wishlistCount,
                LastOrderDate = lastOrderDate
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalOrderAmount"></param>
        /// <param name="orderCount"></param>
        /// <param name="wishlistCount"></param>
        /// <param name="lastOrderDate"></param>
        /// <returns></returns>
        public static CommerceSummary GenerateCommerceSummary(CurrencyAmount totalOrderAmount, int orderCount,
                                                              int wishlistCount, DateTime? lastOrderDate = null)
        {
            return new CommerceSummary()
            {
                TotalOrderAmount = totalOrderAmount,
                OrderCount = orderCount,
                WishlistCount = wishlistCount,
                LastOrderDate = lastOrderDate
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public static CurrencyAmount GenerateCurrencyAmount(decimal amount, string currencyCode)
        {
            return new CurrencyAmount()
            {
                Amount = amount,
                CurrencyCode = currencyCode
            };
        }
        #endregion
        #region "GenerateCustomerContact"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="id"></param>
        /// <param name="lastname"></param>
        /// <param name="middlename"></param>
        /// <param name="company"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId, string email, string firstname,
                                                              int id, string lastname, string middlename, string company,
                                                              Mozu.Api.Contracts.Core.Address address, Mozu.Api.Contracts.Core.Phone phone)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = email,
                FirstName = firstname,
                Id = id,
                LastNameOrSurname = lastname,
                MiddleNameOrInitial = middlename,
                CompanyOrOrganization = company,
                Address = address,
                PhoneNumbers = phone
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="numContacts"></param>
        /// <returns></returns>
        public static List<CustomerContact> GenerateCustomerContactsRandom(int accountId, int numContacts)
        {
            var contacts = new List<CustomerContact>();
            for (int i = 0; i < numContacts; i++)
            {
                var contact = GenerateCustomerContact(accountId);
                contacts.Add(contact);
            }
            return contacts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = GenerateAddressRandom(),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContactReal(int accountId)
        {
            var firstname = GenerateFirstName();
            var lastname = GenerateLastName();
            var username = Generator.RandomString(13, RandomCharacterGroup.AlphaOnly);

            return new CustomerContact()
            {
                AccountId = accountId,
                Email = username + "@mozu.com", // or use Generator.RandomEmailAddress(),
                FirstName = firstname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = GenerateAddressReal(),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContactReal(int accountId, string firstname, string lastname, string username)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = RandomEmailAddressMozu(), // username + "@mozu.com", // or use Generator.RandomEmailAddress(),
                FirstName = firstname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = GenerateAddressReal(),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContactReal(int accountId, string firstname, string lastname, string username, string email, string addressType = "Residential")
        {
            var companyname = "";
            if (addressType != "Residential")
            {
                companyname = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly);
            }

            return new CustomerContact()
            {
                AccountId = accountId,
                Email = email, // username + "@mozu.com", // or use Generator.RandomEmailAddress(),
                FirstName = firstname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastname, // or use Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(1, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = companyname,
                Address = GenerateAddressReal(true, addressType),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId, Mozu.Api.Contracts.Core.Address address)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = address,
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="middlename"></param>
        /// <param name="lastnameorsurname"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId,
            Mozu.Api.Contracts.Core.Address address, string email, string firstname, string middlename, string lastnameorsurname)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = email,
                FirstName = firstname,
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastnameorsurname,
                MiddleNameOrInitial = middlename,
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = address,
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="middlename"></param>
        /// <param name="lastnameorsurname"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId,
            Mozu.Api.Contracts.Core.Address address, string email, string firstname, string middlename, string lastnameorsurname, string companyName)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = email,
                FirstName = firstname,
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastnameorsurname,
                MiddleNameOrInitial = middlename,
                CompanyOrOrganization = companyName,
                Address = address,
                PhoneNumbers = GeneratePhoneRandom()

            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="lastnameorsurname"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId, string email, string firstname,
                                                              string lastnameorsurname)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = email,
                FirstName = firstname,
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = lastnameorsurname,
                MiddleNameOrInitial = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = GenerateAddressRandom(),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="firstname"></param>
        /// <returns></returns>
        public static CustomerContact GenerateCustomerContact(int accountId, string firstname)
        {
            return new CustomerContact()
            {
                AccountId = accountId,
                Email = Generator.RandomEmailAddress(),
                FirstName = firstname,
                Id = Generator.RandomInt(4, 10),
                LastNameOrSurname = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                MiddleNameOrInitial = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                CompanyOrOrganization = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaOnly),
                Address = GenerateAddressRandom(),
                PhoneNumbers = GeneratePhoneRandom()

            };
        }

        #endregion
        #region "GenerateCustomerNames"

        public static string GenerateFirstName()
        {
            string[] names =
            {
                "Sophia", "Emma", "Olivia", "Isabella", "Darrin", "Mia", "Ava", "Lily", "Zoe", "Emily", "Chloe", "Layla",
                "Madison", "Madelyn", "Abigail", "Aubrey", "Charlotte", "Amelia", "Ella",
                "Kaylee", "Avery", "Aaliyah", "Hailey", "Hannah", "Addison", "Riley", "Harper", "Aria", "Arianna",
                "Mackenzie", "Lila", "Evelyn", "Adalyn", "Grace", "Brooklyn", "Ellie", "Anna", "Kaitlyn",
                "Isabelle", "Sophie", "Scarlett", "Natalie", "Leah", "Sarah", "Nora", "Mila", "Elizabeth", "Lillian",
                "Kylie", "Audrey", "Lucy", "Maya", "Annabelle", "Makayla", "Gabriella", "Elena",
                "Victoria", "Claire", "Savannah", "Peyton", "Maria", "Alaina", "Kennedy", "Stella", "Liliana", "Allison",
                "Samantha", "Keira", "Alyssa", "Reagan", "Molly", "Alexandra", "Violet", "Charlie", "Julia",
                "Sadie", "Ruby", "Eva", "Alice", "Eliana", "Taylor", "Callie", "Penelope", "Camilla", "Bailey", "Kaelyn",
                "Alexis", "Kayla", "Katherine", "Sydney", "Lauren", "Jasmine", "London", "Bella", "Adeline",
                "Caroline", "Vivian", "Juliana", "Gianna", "Skyler", "Jordyn", "Jackson", "Aiden", "Liam", "Lucas",
                "Noah", "Mason", "Jayden", "Ethan", "Jacob", "Jack", "Caden", "Logan", "Benjamin", "Michael", "Caleb",
                "Ryan", "Alexander", "Elijah", "James", "William", "Oliver", "Connor", "Matthew", "Daniel", "Luke",
                "Brayden", "Jayce", "Henry", "Carter", "Dylan", "Gabriel", "Joshua", "Nicholas", "Isaac", "Owen",
                "Nathan", "Grayson", "Eli", "Landon", "Andrew", "Max", "Samuel", "Gavin", "Wyatt", "Christian", "Hunter",
                "Cameron", "Evan", "Charlie", "David", "Sebastian", "Joseph", "Dominic", "Anthony",
                "Colton", "John", "Tyler", "Zachary", "Thomas", "Julian", "Levi", "Adam", "Isaiah", "Alex", "Aaron",
                "Parker", "Cooper", "Miles", "Chase", "Muhammad", "Christopher", "Blake", "Austin", "Jordan",
                "Leo", "Jonathan", "Adrian", "Colin", "Hudson", "Ian", "Xavier", "Camden", "Tristan", "Carson", "Jason",
                "Nolan", "Riley", "Lincoln", "Brody", "Bentley", "Nathaniel", "Josiah", "Declan", "Jake",
                "Asher", "Jeremiah", "Cole", "Mateo", "Micah", "Elliot", "Sophia", "Isabella", "Emma", "Olivia", "Ava",
                "Emily", "Abigail", "Madison", "Mia", "Chloe", "Elizabeth", "Ella", "Addison", "Natalie", "Lily",
                "Grace", "Samantha", "Avery", "Sofia", "Aubrey", "Brooklyn", "Lillian", "Victoria", "Evelyn", "Hannah",
                "Alexis", "Charlotte", "Zoey", "Leah", "Amelia", "Zoe", "Hailey", "Layla", "Gabriella", "Nevaeh",
                "Kaylee", "Alyssa", "Anna", "Sarah", "Allison", "Savannah", "Ashley", "Audrey", "Taylor", "Brianna",
                "Aaliyah", "Riley", "Camila", "Khloe", "Claire", "Sophie", "Arianna", "Peyton", "Harper", "Alexa",
                "Makayla", "Julia", "Kylie", "Kayla", "Bella", "Katherine", "Lauren", "Gianna", "Maya", "Sydney",
                "Serenity", "Kimberly", "Mackenzie", "Autumn", "Jocelyn", "Faith", "Lucy", "Stella", "Jasmine", "Morgan",
                "Alexandra", "Trinity", "Molly", "Madelyn", "Scarlett", "Andrea", "Genesis", "Eva", "Ariana", "Madeline",
                "Brooke", "Caroline", "Bailey", "Melanie", "Kennedy", "Destiny", "Maria", "Naomi", "London", "Payton",
                "Lydia", "Ellie", "Mariah", "Aubree", "Kaitlyn", "Violet", "Rylee", "Lilly", "Angelina", "Katelyn",
                "Mya", "Paige", "Natalia", "Ruby", "Piper", "Annabelle", "Mary", "Jade", "Isabelle", "Liliana", "Nicole",
                "Rachel", "Vanessa", "Gabrielle", "Jessica", "Jordyn", "Reagan", "Kendall", "Sadie", "Valeria",
                "Brielle", "Lyla", "Isabel", "Brooklynn", "Reese", "Sara", "Adriana", "Aliyah", "Jennifer", "Mckenzie",
                "Gracie", "Nora", "Kylee", "Makenzie", "Izabella", "Laila", "Alice", "Amy", "Michelle", "Skylar",
                "Stephanie", "Juliana", "Rebecca", "Jayla", "Eleanor", "Clara", "Giselle", "Valentina", "Vivian",
                "Alaina", "Eliana", "Aria", "Valerie", "Haley", "Elena", "Catherine", "Elise", "Lila", "Megan",
                "Gabriela", "Daisy", "Jada", "Daniela", "Penelope", "Jenna", "Ashlyn", "Delilah", "Summer", "Mila",
                "Kate", "Keira", "Adrianna", "Hadley", "Julianna", "Maci", "Eden", "Josephine", "Aurora", "Melissa",
                "Hayden", "Alana", "Margaret", "Quinn", "Angela", "Brynn", "Alivia", "Katie", "Ryleigh", "Kinley",
                "Paisley", "Jordan", "Aniyah", "Allie", "Miranda", "Jacqueline", "Melody", "Willow", "Diana", "Cora",
                "Alexandria", "Mikayla", "Danielle", "Londyn", "Addyson", "Amaya", "Hazel", "Callie", "Teagan", "Adalyn",
                "Ximena", "Angel", "Kinsley", "Shelby", "Makenna", "Ariel", "Jillian", "Chelsea", "Alayna", "Harmony",
                "Sienna", "Amanda", "Presley", "Maggie", "Tessa", "Leila", "Hope", "Genevieve", "Erin", "Briana",
                "Delaney", "Esther", "Kathryn", "Ana", "Mckenna", "Camille", "Cecilia", "Lucia", "Lola", "Leilani",
                "Leslie", "Ashlynn", "Kayleigh", "Alondra", "Alison", "Haylee", "Carly", "Juliet", "Lexi", "Kelsey",
                "Eliza", "Josie", "Marissa", "Marley", "Alicia", "Amber", "Sabrina", "Kaydence", "Norah", "Allyson",
                "Alina", "Ivy", "Fiona", "Isla", "Nadia", "Kyleigh", "Christina", "Emery", "Laura", "Cheyenne", "Alexia",
                "Emerson", "Sierra", "Luna", "Cadence", "Daniella", "Fatima", "Bianca", "Cassidy", "Veronica", "Kyla",
                "Evangeline", "Karen", "Adeline", "Jazmine", "Mallory", "Rose", "Jayden", "Kendra", "Camryn", "Macy",
                "Abby", "Dakota", "Mariana", "Gia", "Adelyn", "Madilyn", "Jazmin", "Iris", "Nina", "Georgia", "Lilah",
                "Breanna", "Kenzie", "Jayda", "Phoebe", "Lilliana", "Kamryn", "Athena", "Malia", "Nyla", "Miley",
                "Heaven", "Audrina", "Madeleine", "Kiara", "Selena", "Maddison", "Giuliana", "Emilia", "Lyric", "Joanna",
                "Adalynn", "Annabella", "Fernanda", "Aubrie", "Heidi", "Esmeralda", "Kira", "Elliana", "Arabella",
                "Kelly", "Karina", "Paris", "Caitlyn", "Kara", "Raegan", "Miriam", "Crystal", "Alejandra", "Tatum",
                "Savanna", "Tiffany", "Ayla", "Carmen", "Maliyah", "Karla", "Bethany", "Guadalupe", "Kailey", "Macie",
                "Gemma", "Noelle", "Rylie", "Elaina", "Lena", "Amiyah", "Ruth", "Ainsley", "Finley", "Danna", "Parker",
                "Emely", "Jane", "Joselyn", "Scarlet", "Anastasia", "Journey", "Angelica", "Sasha", "Yaretzi", "Charlie",
                "Juliette", "Lia", "Brynlee", "Angelique", "Katelynn", "Nayeli", "Vivienne", "Addisyn", "Kaelyn",
                "Annie", "Tiana", "Kyra", "Janelle", "Cali", "Aleah", "Caitlin", "Imani", "Jayleen", "April", "Julie",
                "Alessandra", "Julissa", "Kailyn", "Jazlyn", "Janiyah", "Kaylie", "Madelynn", "Baylee", "Itzel",
                "Monica", "Adelaide", "Brylee", "Michaela", "Madisyn", "Cassandra", "Elle", "Kaylin", "Aniya", "Dulce",
                "Olive", "Jaelyn", "Courtney", "Brittany", "Madalyn", "Jasmin", "Kamila", "Kiley", "Tenley", "Braelyn",
                "Holly", "Helen", "Hayley", "Carolina", "Cynthia", "Talia", "Anya", "Estrella", "Bristol", "Jimena",
                "Harley", "Jamie", "Rebekah", "Charlee", "Lacey", "Jaliyah", "Cameron", "Sarai", "Caylee", "Kennedi",
                "Dayana", "Tatiana", "Serena", "Eloise", "Daphne", "Mckinley", "Mikaela", "Celeste", "Hanna", "Lucille",
                "Skyler", "Nylah", "Camilla", "Lilian", "Lindsey", "Sage", "Viviana", "Danica", "Liana", "Melany",
                "Aileen", "Lillie", "Kadence", "Zariah", "June", "Lilyana", "Bridget", "Anabelle", "Lexie", "Anaya",
                "Skye", "Alyson", "Angie", "Paola", "Elsie", "Erica", "Gracelyn", "Kiera", "Myla", "Aylin", "Lana",
                "Priscilla", "Kassidy", "Natasha", "Nia", "Kenley", "Dylan", "Kali", "Ada", "Miracle", "Raelynn",
                "Briella", "Emilee", "Lorelei", "Francesca", "Arielle", "Madyson", "Amira", "Jaelynn", "Nataly",
                "Annika", "Joy", "Alanna", "Shayla", "Brenna", "Sloane", "Vera", "Abbigail", "Amari", "Jaycee", "Lauryn",
                "Skyla", "Whitney", "Aspen", "Johanna", "Jaylah", "Nathalie", "Laney", "Logan", "Brinley", "Leighton",
                "Marlee", "Ciara", "Justice", "Brenda", "Kayden", "Erika", "Elisa", "Lainey", "Rowan", "Annabel",
                "Teresa", "Dahlia", "Janiya", "Lizbeth", "Nancy", "Aleena", "Kaliyah", "Farrah", "Marilyn", "Eve",
                "Anahi", "Rosalie", "Jaylynn", "Bailee", "Emmalyn", "Madilynn", "Lea", "Sylvia", "Annalise", "Averie",
                "Yareli", "Zoie", "Samara", "Amani", "Regina", "Hailee", "Arely", "Evelynn", "Luciana", "Natalee",
                "Anika", "Liberty", "Giana", "Haven", "Gloria", "Gwendolyn", "Jazlynn", "Marisol", "Ryan", "Virginia",
                "Myah", "Elsa", "Selah", "Melina", "Aryanna", "Adelynn", "Raelyn", "Miah", "Sariah", "Kaylynn", "Amara",
                "Helena", "Jaylee", "Maeve", "Raven", "Linda", "Anne", "Desiree", "Madalynn", "Meredith", "Clarissa",
                "Elyse", "Marie", "Alissa", "Anabella", "Hallie", "Denise", "Elisabeth", "Kaia", "Danika", "Kimora",
                "Milan", "Claudia", "Dana", "Siena", "Zion", "Ansley", "Sandra", "Cara", "Halle", "Maleah", "Marina",
                "Saniyah", "Casey", "Harlow", "Kassandra", "Charley", "Rosa", "Shiloh", "Tori", "Adele", "Kiana",
                "Ariella", "Jaylene", "Joslyn", "Kathleen", "Aisha", "Amya", "Ayanna", "Isis", "Karlee", "Cindy",
                "Perla", "Janessa", "Lylah", "Raquel", "Zara", "Evie", "Phoenix", "Catalina", "Lilianna", "Mollie",
                "Simone", "Briley", "Bria", "Kristina", "Lindsay", "Rosemary", "Cecelia", "Kourtney", "Aliya", "Asia",
                "Elin", "Isabela", "Kristen", "Yasmin", "Alani", "Aiyana", "Amiya", "Felicity", "Patricia", "Kailee",
                "Adrienne", "Aliana", "Ember", "Mariyah", "Mariam", "Ally", "Bryanna", "Tabitha", "Wendy", "Sidney",
                "Clare", "Aimee", "Laylah", "Maia", "Karsyn", "Greta", "Noemi", "Jayde", "Kallie", "Leanna", "Irene",
                "Jessie", "Paityn", "Kaleigh", "Lesly", "Gracelynn", "Amelie", "Iliana", "Elaine", "Lillianna", "Ellen",
                "Taryn", "Lailah", "Rylan", "Lisa", "Emersyn", "Braelynn", "Shannon", "Beatrice", "Heather", "Jaylin",
                "Taliyah", "Arya", "Emilie", "Ali", "Janae", "Chaya", "Cherish", "Jaida", "Journee", "Sawyer",
                "Destinee", "Emmalee", "Ivanna", "Charli", "Jocelynn", "Kaya", "Elianna", "Armani", "Kaitlynn",
                "Rihanna", "Reyna", "Christine", "Alia", "Leyla", "Mckayla", "Celia", "Raina", "Alayah", "Macey",
                "Meghan", "Zaniyah", "Carolyn", "Kynlee", "Carlee", "Alena", "Bryn", "Jolie", "Carla", "Eileen", "Keyla",
                "Saniya", "Livia", "Amina", "Angeline", "Krystal", "Zaria", "Emelia", "Renata", "Mercedes", "Paulina",
                "Diamond", "Jenny", "Aviana", "Ayleen", "Barbara", "Alisha", "Jaqueline", "Maryam", "Julianne",
                "Matilda", "Sonia", "Edith", "Martha", "Audriana", "Kaylyn", "Emmy", "Giada", "Tegan", "Charleigh",
                "Haleigh", "Nathaly", "Susan", "Kendal", "Leia", "Jordynn", "Amirah", "Giovanna", "Mira", "Addilyn",
                "Frances", "Kaitlin", "Kyndall", "Myra", "Abbie", "Samiyah", "Taraji", "Braylee", "Corinne", "Jazmyn",
                "Kaiya", "Lorelai", "Abril", "Kenya", "Mae", "Hadassah", "Alisson", "Haylie", "Brisa", "Deborah", "Mina",
                "Rayne", "America", "Ryann", "Milania", "Pearl", "Blake", "Millie", "Deanna", "Araceli", "Demi",
                "Gisselle", "Paula", "Karissa", "Sharon", "Kensley", "Rachael", "Aryana", "Chanel", "Natalya",
                "Hayleigh", "Paloma", "Avianna", "Jemma", "Moriah", "Renee", "Alyvia", "Zariyah", "Hana", "Judith",
                "Kinsey", "Salma", "Kenna", "Mara", "Patience", "Saanvi", "Cristina", "Dixie", "Kaylen", "Averi",
                "Carlie", "Kirsten", "Lilyanna", "Charity", "Larissa", "Zuri", "Chana", "Ingrid", "Lina", "Tianna",
                "Lilia", "Marisa", "Nahla", "Sherlyn", "Adyson", "Cailyn", "Princess", "Yoselin", "Aubrianna", "Maritza",
                "Rayna", "Luz", "Cheyanne", "Azaria", "Jacey", "Roselyn", "Elliot", "Jaiden", "Tara", "Alma",
                "Esperanza", "Jakayla", "Yesenia", "Kiersten", "Marlene", "Nova", "Adelina", "Ayana", "Kai", "Nola",
                "Sloan", "Avah", "Carley", "Meadow", "Neveah", "Tamia", "Alaya", "Jadyn", "Sanaa", "Kailynn", "Diya",
                "Rory", "Abbey", "Karis", "Maliah", "Belen", "Bentley", "Jaidyn", "Shania", "Britney", "Yazmin", "Aubri",
                "Malaya", "Micah", "River", "Alannah", "Jolene", "Shaniya", "Tia", "Yamilet", "Bryleigh", "Carissa",
                "Karlie", "Libby", "Lilith", "Lara", "Tess", "Aliza", "Laurel", "Kaelynn", "Leona", "Regan", "Yaritza",
                "Kasey", "Mattie", "Audrianna", "Blakely", "Campbell", "Dorothy", "Julieta", "Kylah", "Kyndal",
                "Temperance", "Tinley", "Akira", "Saige", "Ashtyn", "Jewel", "Kelsie", "Miya", "Cambria", "Analia",
                "Janet", "Kairi", "Aleigha", "Bree", "Dalia", "Liv", "Sarahi", "Yamileth", "Carleigh", "Geraldine",
                "Izabelle", "Riya", "Samiya", "Abrielle", "Annabell", "Leigha", "Pamela", "Caydence", "Joyce", "Juniper",
                "Malaysia", "Isabell", "Blair", "Jaylyn", "Marianna", "Rivka", "Alianna", "Gwyneth", "Kendyl", "Sky",
                "Esme", "Jaden", "Sariyah", "Stacy", "Kimber", "Kamille", "Milagros", "Karly", "Karma", "Thalia",
                "Willa", "Amalia", "Hattie", "Payten", "Anabel", "Ann", "Galilea", "Milana", "Yuliana", "Damaris",
                "Jacob", "Mason", "William", "Jayden", "Noah", "Michael", "Ethan", "Alexander", "Aiden", "Daniel",
                "Anthony", "Matthew", "Elijah", "Joshua", "Liam", "Andrew", "James", "David", "Benjamin", "Logan",
                "Christopher", "Joseph", "Jackson", "Gabriel", "Ryan", "Samuel", "John", "Nathan", "Lucas", "Christian",
                "Jonathan", "Caleb", "Dylan", "Landon", "Isaac", "Gavin", "Brayden", "Tyler", "Luke", "Evan", "Carter",
                "Nicholas", "Isaiah", "Owen", "Jack", "Jordan", "Brandon", "Wyatt", "Julian", "Aaron", "Jeremiah",
                "Angel", "Cameron", "Connor", "Hunter", "Adrian", "Henry", "Eli", "Justin", "Austin", "Robert",
                "Charles", "Thomas", "Zachary", "Jose", "Levi", "Kevin", "Sebastian", "Chase", "Ayden", "Jason", "Ian",
                "Blake", "Colton", "Bentley", "Dominic", "Xavier", "Oliver", "Parker", "Josiah", "Adam", "Cooper",
                "Brody", "Nathaniel", "Carson", "Jaxon", "Tristan", "Luis", "Juan", "Hayden", "Carlos", "Jesus", "Nolan",
                "Cole", "Alex", "Max", "Grayson", "Bryson", "Diego", "Jaden", "Vincent", "Easton", "Eric", "Micah",
                "Kayden", "Jace", "Aidan", "Ryder", "Ashton", "Bryan", "Riley", "Hudson", "Asher", "Bryce", "Miles",
                "Kaleb", "Giovanni", "Antonio", "Kaden", "Colin", "Kyle", "Brian", "Timothy", "Steven", "Sean", "Miguel",
                "Richard", "Ivan", "Jake", "Alejandro", "Santiago", "Axel", "Joel", "Maxwell", "Brady", "Caden",
                "Preston", "Damian", "Elias", "Jaxson", "Jesse", "Victor", "Patrick", "Jonah", "Marcus", "Rylan",
                "Emmanuel", "Edward", "Leonardo", "Cayden", "Grant", "Jeremy", "Braxton", "Gage", "Jude", "Wesley",
                "Devin", "Roman", "Mark", "Camden", "Kaiden", "Oscar", "Alan", "Malachi", "George", "Peyton", "Leo",
                "Nicolas", "Maddox", "Kenneth", "Mateo", "Sawyer", "Collin", "Conner", "Cody", "Andres", "Declan",
                "Lincoln", "Bradley", "Trevor", "Derek", "Tanner", "Silas", "Eduardo", "Seth", "Jaiden", "Paul", "Jorge",
                "Cristian", "Garrett", "Travis", "Abraham", "Omar", "Javier", "Ezekiel", "Tucker", "Harrison", "Peter",
                "Damien", "Greyson", "Avery", "Kai", "Weston", "Ezra", "Xander", "Jaylen", "Corbin", "Fernando",
                "Calvin", "Jameson", "Francisco", "Maximus", "Josue", "Ricardo", "Shane", "Trenton", "Cesar", "Chance",
                "Drake", "Zane", "Israel", "Emmett", "Jayce", "Mario", "Landen", "Kingston", "Spencer", "Griffin",
                "Stephen", "Manuel", "Theodore", "Erick", "Braylon", "Raymond", "Edwin", "Charlie", "Abel", "Myles",
                "Bennett", "Johnathan", "Andre", "Alexis", "Edgar", "Troy", "Zion", "Jeffrey", "Hector", "Shawn",
                "Lukas", "Amir", "Tyson", "Keegan", "Kyler", "Donovan", "Graham", "Simon", "Everett", "Clayton",
                "Braden", "Luca", "Emanuel", "Martin", "Brendan", "Cash", "Zander", "Jared", "Ryker", "Dante",
                "Dominick", "Lane", "Kameron", "Elliot", "Paxton", "Rafael", "Andy", "Dalton", "Erik", "Sergio",
                "Gregory", "Marco", "Emiliano", "Jasper", "Johnny", "Dean", "Drew", "Caiden", "Skyler", "Judah",
                "Maximiliano", "Aden", "Fabian", "Zayden", "Brennan", "Anderson", "Roberto", "Reid", "Quinn", "Angelo",
                "Holden", "Cruz", "Derrick", "Grady", "Emilio", "Finn", "Elliott", "Pedro", "Amari", "Frank", "Rowan",
                "Lorenzo", "Felix", "Corey", "Dakota", "Colby", "Braylen", "Dawson", "Brycen", "Allen", "Jax",
                "Brantley", "Ty", "Malik", "Ruben", "Trey", "Brock", "Colt", "Dallas", "Joaquin", "Leland", "Beckett",
                "Jett", "Louis", "Gunner", "Adan", "Jakob", "Cohen", "Taylor", "Arthur", "Marcos", "Marshall", "Ronald",
                "Julius", "Armando", "Kellen", "Dillon", "Brooks", "Cade", "Danny", "Nehemiah", "Beau", "Jayson",
                "Devon", "Tristen", "Enrique", "Randy", "Gerardo", "Pablo", "Desmond", "Raul", "Romeo", "Milo", "Julio",
                "Kellan", "Karson", "Titus", "Keaton", "Keith", "Reed", "Ali", "Braydon", "Dustin", "Scott", "Trent",
                "Waylon", "Walter", "Donald", "Ismael", "Phillip", "Iker", "Esteban", "Jaime", "Landyn", "Darius",
                "Dexter", "Matteo", "Colten", "Emerson", "Phoenix", "King", "Izaiah", "Karter", "Albert", "Jerry",
                "Tate", "Larry", "Saul", "Payton", "August", "Jalen", "Enzo", "Jay", "Rocco", "Kolton", "Russell",
                "Leon", "Philip", "Gael", "Quentin", "Tony", "Mathew", "Kade", "Gideon", "Dennis", "Damon", "Darren",
                "Kason", "Walker", "Jimmy", "Alberto", "Mitchell", "Alec", "Rodrigo", "Casey", "River", "Maverick",
                "Amare", "Brayan", "Mohamed", "Issac", "Yahir", "Arturo", "Moises", "Maximilian", "Knox", "Barrett",
                "Davis", "Gustavo", "Curtis", "Hugo", "Reece", "Chandler", "Mauricio", "Jamari", "Abram", "Uriel",
                "Bryant", "Archer", "Kamden", "Solomon", "Porter", "Zackary", "Adriel", "Ryland", "Lawrence", "Noel",
                "Alijah", "Ricky", "Ronan", "Leonel", "Maurice", "Chris", "Atticus", "Brenden", "Ibrahim", "Zachariah",
                "Khalil", "Lance", "Marvin", "Dane", "Bruce", "Cullen", "Orion", "Nikolas", "Pierce", "Kieran",
                "Braeden", "Kobe", "Finnegan", "Remington", "Muhammad", "Prince", "Orlando", "Alfredo", "Mekhi", "Sam",
                "Rhys", "Jacoby", "Eddie", "Zaiden", "Ernesto", "Joe", "Kristopher", "Jonas", "Gary", "Jamison", "Nico",
                "Johan", "Giovani", "Malcolm", "Armani", "Warren", "Gunnar", "Ramon", "Franklin", "Kane", "Byron",
                "Cason", "Brett", "Ari", "Deandre", "Finley", "Justice", "Douglas", "Cyrus", "Gianni", "Talon", "Camron",
                "Cannon", "Nash", "Dorian", "Kendrick", "Moses", "Arjun", "Sullivan", "Kasen", "Dominik", "Ahmed",
                "Korbin", "Roger", "Royce", "Quinton", "Salvador", "Isaias", "Skylar", "Raiden", "Terry", "Brodie",
                "Tobias", "Morgan", "Frederick", "Madden", "Conor", "Reese", "Braiden", "Kelvin", "Julien", "Kristian",
                "Rodney", "Wade", "Davion", "Nickolas", "Xzavier", "Alvin", "Asa", "Alonzo", "Ezequiel", "Boston",
                "Nasir", "Nelson", "Jase", "London", "Mohammed", "Rhett", "Jermaine", "Roy", "Matias", "Ace", "Chad",
                "Moshe", "Aarav", "Keagan", "Aldo", "Blaine", "Marc", "Rohan", "Bently", "Trace", "Kamari", "Layne",
                "Carmelo", "Demetrius", "Lawson", "Nathanael", "Uriah", "Terrance", "Ahmad", "Jamarion", "Shaun", "Kale",
                "Noe", "Carl", "Jaydon", "Callen", "Micheal", "Jaxen", "Lucian", "Jaxton", "Rory", "Quincy", "Guillermo",
                "Javon", "Kian", "Wilson", "Jeffery", "Joey", "Kendall", "Harper", "Jensen", "Mohammad", "Dayton",
                "Billy", "Jonathon", "Jadiel", "Willie", "Jadon", "Clark", "Rex", "Francis", "Kash", "Malakai",
                "Terrell", "Melvin", "Cristopher", "Layton", "Ariel", "Sylas", "Gerald", "Kody", "Messiah", "Semaj",
                "Triston", "Bentlee", "Lewis", "Marlon", "Tomas", "Aidyn", "Tommy", "Alessandro", "Isiah", "Jagger",
                "Nikolai", "Omari", "Sincere", "Cory", "Rene", "Terrence", "Harley", "Kylan", "Luciano", "Aron",
                "Felipe", "Reginald", "Tristian", "Urijah", "Beckham", "Jordyn", "Kayson", "Neil", "Osvaldo", "Aydin",
                "Ulises", "Deacon", "Giovanny", "Case", "Daxton", "Will", "Lee", "Makai", "Raphael", "Tripp", "Kole",
                "Channing", "Santino", "Stanley", "Allan", "Alonso", "Jamal", "Jorden", "Davin", "Soren", "Aryan",
                "Aydan", "Camren", "Jasiah", "Ray", "Ben", "Jon", "Bobby", "Darrell", "Markus", "Branden", "Hank",
                "Mathias", "Adonis", "Darian", "Jessie", "Marquis", "Vicente", "Zayne", "Kenny", "Raylan", "Jefferson",
                "Steve", "Wayne", "Leonard", "Kolby", "Ayaan", "Emery", "Harry", "Rashad", "Adrien", "Dax", "Dwayne",
                "Samir", "Zechariah", "Yusuf", "Ronnie", "Tristin", "Benson", "Memphis", "Lamar", "Maxim", "Bowen",
                "Ellis", "Javion", "Tatum", "Clay", "Alexzander", "Draven", "Odin", "Branson", "Elisha", "Rudy", "Zain",
                "Rayan", "Sterling", "Brennen", "Jairo", "Brendon", "Kareem", "Rylee", "Winston", "Jerome", "Kyson",
                "Lennon", "Luka", "Crosby", "Deshawn", "Roland", "Zavier", "Cedric", "Vance", "Niko", "Gauge", "Kaeden",
                "Killian", "Vincenzo", "Teagan", "Trevon", "Kymani", "Valentino", "Abdullah", "Bo", "Darwin", "Hamza",
                "Kolten", "Edison", "Jovani", "Augustus", "Gavyn", "Toby", "Davian", "Rogelio", "Matthias", "Brent",
                "Hayes", "Brogan", "Jamir", "Damion", "Emmitt", "Landry", "Chaim", "Jaylin", "Yosef", "Kamron", "Lionel",
                "Van", "Bronson", "Casen", "Junior", "Misael", "Yandel", "Alfonso", "Giancarlo", "Rolando", "Abdiel",
                "Aaden", "Deangelo", "Duncan", "Ishaan", "Jamie", "Maximo", "Cael", "Conrad", "Ronin", "Xavi",
                "Dominique", "Ean", "Tyrone", "Chace", "Craig", "Mayson", "Quintin", "Derick", "Bradyn", "Izayah",
                "Zachery", "Westin", "Alvaro", "Johnathon", "Ramiro", "Konner", "Lennox", "Marcelo", "Blaze", "Eugene",
                "Keenan", "Bruno", "Deegan", "Rayden", "Cale", "Camryn", "Eden", "Jamar", "Leandro", "Sage", "Marcel",
                "Jovanni", "Rodolfo", "Seamus", "Cain", "Damarion", "Harold", "Jaeden", "Konnor", "Jair", "Callum",
                "Rowen", "Rylen", "Arnav", "Ernest", "Gilberto", "Irvin", "Fisher", "Randall", "Heath", "Justus",
                "Lyric", "Masen", "Amos", "Frankie", "Harvey", "Kamryn", "Alden", "Hassan", "Salvatore", "Theo",
                "Darien", "Gilbert", "Krish", "Mike", "Todd", "Jaidyn", "Isai", "Samson", "Cassius", "Hezekiah", "Makhi",
                "Antoine", "Darnell", "Remy", "Stefan", "Camdyn", "Kyron", "Callan", "Dario", "Jedidiah", "Leonidas",
                "Deven", "Fletcher", "Sonny", "Reagan", "Yadiel", "Jerimiah", "Efrain", "Sidney", "Santos", "Aditya",
                "Brenton", "Brysen", "Nixon", "Tyrell", "Vaughn", "Elvis", "Freddy", "Demarcus", "Gaige", "Jaylon",
                "Gibson", "Thaddeus", "Zaire", "Coleman", "Roderick", "Jabari", "Zackery", "Agustin", "Alfred", "Arlo",
                "Braylin", "Leighton", "Turner", "Arian", "Clinton", "Legend", "Miller", "Quinten", "Mustafa", "Jakobe",
                "Lathan", "Otto", "Blaise", "Vihaan", "Enoch", "Ross", "Brice", "Houston", "Rey", "Benton", "Bodhi",
                "Graysen", "Johann", "Reuben", "Crew", "Darryl", "Donte", "Flynn", "Jaycob", "Jean", "Maxton", "Anders",
                "Hugh", "Ignacio", "Ralph", "Trystan", "Devan", "Franco", "Mariano", "Tyree", "Bridger", "Howard",
                "Jaydan", "Brecken", "Joziah", "Valentin", "Broderick", "Maxx", "Elian", "Eliseo", "Haiden", "Tyrese",
                "Zeke", "Keon", "Maksim", "Coen", "Cristiano", "Hendrix", "Damari", "Princeton", "Davon", "Deon", "Kael",
                "Dimitri", "Jaron", "Jaydin", "Kyan", "Corban", "Kingsley", "Major", "Pierre", "Yehuda", "Cayson",
                "Dangelo", "Jeramiah", "Kamren", "Kohen", "Camilo", "Cortez", "Keyon", "Malaki", "Ethen"
            };

            var random = new Random();
            var randomNumber = random.Next(0, names.Length);
            return names[randomNumber];
        }
        public static string GenerateLastName()
        {
            string[] names = { "Smith","Johnson","Williams","Jones","Brown","Davis","Miller","Wilson","Moore","Taylor","Anderson","Thomas","Jackson","White","Harris","Martin",
                                 "Thompson","Garcia","Martinez","Robinson","Duncan","Cherry","Clark","Rodriguez","Lewis","Lee","Walker","Hall","Allen","Young","Hernandez","King","Wright","Lopez",
                                 "Hill","Scott","Green","Adams","Baker","Gonzalez","Nelson","Carter","Mitchell","Perez","Roberts","Turner","Phillips","Campbell","Parker","Evans",
                                 "Edwards","Collins","Stewart","Sanchez","Morris","Rogers","Reed","Cook","Morgan","Bell","Murphy","Bailey","Rivera","Cooper","Richardson","Cox",
                                 "Howard","Ward","Torres","Peterson","Gray","Ramirez","James","Watson","Brooks","Kelly","Sanders","Price","Bennett","Wood","Barnes","Ross","Henderson",
                                 "Coleman","Jenkins","Perry","Powell","Long","Patterson","Hughes","Flores","Washington","Butler","Simmons","Foster","Gonzales","Bryant","Alexander",
                                 "Russell","Griffin","Diaz","Hayes"};

            var random = new Random();
            var randomNumber = random.Next(0, names.Length);
            return names[randomNumber] + " Test";
        }
        #endregion

        #region "Discount"

        /// <summary>
        /// Generate Discount Object.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="scope"></param>
        /// <param name="target"></param>
        /// <param name="conditions"></param>
        /// <param name="currentRedemptionCnt"></param>
        /// <param name="amt"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Discount GenerateDiscount(DiscountLocalizedContent content, string scope, DiscountTarget target,
            DiscountCondition conditions, int? currentRedemptionCnt, decimal? amt, string type)
        {
            return new Discount()
            {
                Content = content,
                Scope = scope,
                Target = target,
                Conditions = conditions,
                CurrentRedemptionCount = currentRedemptionCnt,
                Amount = amt,
                AmountType = type,
            };
        }


        /// <summary>
        /// Generate Discount Object which requires Coupon.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="scope"></param>
        /// <param name="target"></param>
        /// <param name="conditions"></param>
        /// <param name="amt"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Discount GenerateDiscount(DiscountLocalizedContent content, string scope, DiscountTarget target,
            DiscountCondition conditions, decimal? amt, string type)
        {
            return new Discount()
            {
                Content = content,
                Scope = scope,
                Target = target,
                Conditions = conditions,
                Amount = amt,
                AmountType = type
            };
        }


        /// <summary>
        /// Generate Discount Object without Coupon.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="scope"></param>
        /// <param name="target"></param>
        /// <param name="conditions"></param>
        /// <param name="currentRedemption"></param>
        /// <param name="amt"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Discount GenerateDiscount(DiscountLocalizedContent content, string scope, DiscountTarget target,
            DiscountCondition conditions, int currentRedemption, decimal? amt, string type)
        {
            return new Discount()
            {
                Content = content ?? GenerateDiscountLocalizedContent(),
                Scope = scope,
                Target = target,
                Conditions = conditions,
                CurrentRedemptionCount = currentRedemption,
                Amount = amt,
                AmountType = type
            };
        }

        #endregion

        #region "GenerateDiscountCondition"

        public static DiscountCondition GenerateDiscountCondition(List<CategoryDiscountCondition> includeCategories,
            List<CategoryDiscountCondition> excludeCategories, List<ProductDiscountCondition> includeProducts, List<ProductDiscountCondition> excludeProducts,
            int? maxRedemption, decimal? minOrderAmt, decimal? minLifetimeAmt, int discountDuration, DateTime? startDate, DateTime? expireDate)
        {
            return new DiscountCondition()
            {
                MaxRedemptionCount = maxRedemption,
                RequiresCoupon = false,
                IncludedCategories = includeCategories,
                ExcludedCategories = excludeCategories,
                IncludedProducts = includeProducts,
                ExcludedProducts = excludeProducts,
                MinimumOrderAmount = minOrderAmt,
                MinimumLifetimeValueAmount = minLifetimeAmt,
                StartDate = startDate ?? DateTime.Today,
                ExpirationDate = expireDate ?? DateTime.Today.AddDays(discountDuration)
            };
        }


        public static DiscountCondition GenerateDiscountCondition(List<CategoryDiscountCondition> includeCategories,
            List<CategoryDiscountCondition> excludeCategories, List<ProductDiscountCondition> includeProducts, List<ProductDiscountCondition> excludeProducts,
            int? maxRedemption, bool requireCoupon, string couponCode, decimal? minOrderAmt, decimal? minLifetimeAmt,
            int discountDuration, DateTime? startDate, DateTime? expireDate)
        {
            return new DiscountCondition()
            {
                MaxRedemptionCount = maxRedemption,
                RequiresCoupon = requireCoupon,
                CouponCode = couponCode,
                IncludedCategories = includeCategories,
                ExcludedCategories = excludeCategories,
                IncludedProducts = includeProducts,
                ExcludedProducts = excludeProducts,
                MinimumOrderAmount = minOrderAmt,
                MinimumLifetimeValueAmount = minLifetimeAmt,
                StartDate = startDate,
                ExpirationDate = expireDate
            };
        }

        #endregion
        #region "GenerateDiscountLocalizedContent"

        /// <summary>
        /// Generate DiscountLocalizedContent Object.
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static DiscountLocalizedContent GenerateDiscountLocalizedContent(string locale = "en-US")
        {
            return new DiscountLocalizedContent()
            {
                LocaleCode = locale,
                Name = Generator.RandomString(20, Generator.RandomCharacterGroup.AlphaNumericOnly),
                //                  AuditInfo = 
            };
        }

        #endregion
        #region "GenerateDiscountTarget"

        /// <summary>
        /// Generate DiscountTarget Object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="includeAllProds"></param>
        /// <param name="categories"></param>
        /// <param name="excluedCategories"></param>
        /// <param name="products"></param>
        /// <param name="excludeProducts"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        public static DiscountTarget GenerateDiscountTarget(string type, bool? includeAllProds, List<TargetedCategory> categories,
            List<TargetedCategory> excluedCategories, List<TargetedProduct> products, List<TargetedProduct> excludeProducts,
            List<TargetedShippingMethod> methods)
        {
            return new DiscountTarget()
            {
                Type = type,
                IncludeAllProducts = includeAllProds,
                Categories = categories,
                ExcludedCategories = excluedCategories,
                Products = products,
                ExcludedProducts = excludeProducts,
                ShippingMethods = methods
            };
        }


        public static DiscountTarget GenerateDiscountTarget(string type, bool? includeAllProds, List<TargetedCategory> categories,
            List<TargetedProduct> products, List<TargetedShippingMethod> methods)
        {
            return new DiscountTarget()
            {
                Type = type,
                IncludeAllProducts = includeAllProds,
                Categories = categories,
                Products = products,
                ShippingMethods = methods
            };
        }


        public static DiscountTarget GenerateDiscountTarget(string type, bool includeAllProds, List<TargetedShippingMethod> methods)
        {
            return new DiscountTarget()
            {
                Type = type,
                IncludeAllProducts = includeAllProds,
                ShippingMethods = methods ?? new List<TargetedShippingMethod>()
            };
        }

        public static List<TargetedCategory> GenerateTargetedCategories()
        {
            return new List<TargetedCategory>();
        }


        #endregion
        #region "GenerateRedemption"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discountId"></param>
        /// <param name="redeemedOn"></param>
        /// <param name="orderNumber"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /*public static Mozu.Api.Contracts.ProductAdmin.Redemption GenerateRedemption(int discountId, DateTime redeemedOn, int orderNumber, string userId)
        {
            return new Mozu.Api.Contracts.ProductAdmin.Discounts.Redemption()
            {
                DiscountId = discountId,
                RedeemedOn = redeemedOn,
                OrderNumber = orderNumber

            };
        }*/

        #endregion
        #region "GenerateTargetedProduct"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TargetedProduct GenerateTargetedProduct(string code, string name)
        {
            return new TargetedProduct()
            {
                //Code = code,
                //Name = name
                ProductCode = code
            };
        }

        #endregion
        #region "GenerateTargetedCategory"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TargetedCategory GenerateTargetedCategory(int id, string name)
        {
            return new TargetedCategory()
            {
                Id = id,
                //Name = name
            };
        }

        #endregion
        #region "GenerateTargetedShippingMethod"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TargetedShippingMethod GenerateTargetedShippingMethod(string code, string name)
        {
            return new TargetedShippingMethod()
            {
                Code = code,
                Name = name
            };
        }

        #endregion

        #region "GenerateFulfillmentAction"
        /// <summary>
        /// Generate ShipmentAction Object.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="pkgIds"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentAction GenerateFulfillmentAction(string action, List<string> pkgIds)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentAction()
            {
                ActionName = action,
                PackageIds = pkgIds
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentAction GenerateFulfillmentAction(string action, List<string> pkgIds, List<string> pickupIds)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentAction()
            {
                ActionName = action,
                PackageIds = pkgIds,
                PickupIds = pickupIds
            };
        }

        #endregion
        #region "GenerateFulfillmentInfo"

        /// <summary>
        /// Generates a new ShippingInfo object when pay by check using <see cref="Fulfillment" /> class.
        /// </summary>
        /// <param name="contact">Shipping address.</param>
        /// <param name="isDestCommercial">If true, the shipping is for commercial purpose.</param>
        /// <param name="methodCode">Code that uniquely identifies the shipping method such as "fedex_FEDEX_1_DAY_FREIGHT".</param>
        /// <param name="methodName">Name of the shipping method such as "FEDEX_1_DAY_FREIGHT".</param>
        /// <param name="estimateDeliveryDate">Estimated delivery date.</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Shipping.ShippingInfo</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo GenerateFulfillmentInfo(Mozu.Api.Contracts.Core.Contact contact,
            bool? isDestCommercial, string methodCode, string methodName, System.DateTime? estimateDeliveryDate)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo()
            {
                FulfillmentContact = contact,
                IsDestinationCommercial = isDestCommercial,
                ShippingMethodCode = methodCode,
                ShippingMethodName = methodName
            };
        }


        /// <summary>
        /// Generates a new ShippingInfo object when pay by check using <see cref="Fulfillment" /> class.
        /// </summary>
        /// <param name="state">The state of the shipping address.</param>
        /// <param name="isCommercial">If true, the shipping is for commercial purpose.</param>
        /// <param name="methodCode">Code that uniquely identifies the shipping method such as "fedex_FEDEX_1_DAY_FREIGHT".</param>
        /// <param name="methodName">Name of the shipping method such as "FEDEX_1_DAY_FREIGHT".</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Shipping.ShippingInfo</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo GenerateFulfillmentInfo(string state, string zip, bool isCommercial,
            string methodCode = null, string methodName = null, bool realAddress = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo()
            {
                FulfillmentContact = GenerateContact(state, zip, realAddress),
                // IsDestinationCommercial = isCommercial,
                ShippingMethodCode = methodCode,
                ShippingMethodName = methodName,
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo GenerateFulfillmentInfoForInternational(string country, string methodCode = null, string methodName = null)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.FulfillmentInfo()
            {
                FulfillmentContact = GenerateInternationalContact(country),
                ShippingMethodCode = methodCode,
                ShippingMethodName = methodName
            };
        }

        #endregion

        #region "LocationInventory"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locCode"></param>
        /// <param name="prodCode"></param>
        /// <param name="prodName"></param>
        /// <param name="stockAvailable"></param>
        /// <param name="stockOnHand"></param>
        /// <returns></returns>
        public static LocationInventory GenerateLocationInventory(string locCode, string prodCode, string prodName = null, int? stockAvailable = null, int? stockOnHand = null)
        {
            return new LocationInventory()
            {
                LocationCode = locCode,
                ProductCode = prodCode,
                ProductName = prodName ?? Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                StockAvailable = stockAvailable,
                StockOnHand = stockOnHand,
            };
        }
        public static LocationInventory GenerateLocationInventory()
        {
            return new LocationInventory();
        }
        public static List<LocationInventory> GenerateLocationInventoryList()
        {
            return new List<LocationInventory>();
        }
        #endregion


        #region "LocationInventoryAdjustment"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locCode"></param>
        /// <param name="prodCode"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LocationInventoryAdjustment GenerateLocationInventoryAdjustment(string locCode, string prodCode, int value, string type = "Absolute")
        { 
           //const string ABSOLUTE = "Absolute";
           //const string DELTA = "Delta";
            return new LocationInventoryAdjustment()
            {
                ProductCode = prodCode,
                LocationCode = locCode,
                Type = type,
                Value = value
            };
        }

        #endregion

        #region "GenerateLocationInventoryLists"

        public static List<LocationInventory> GenerateListOfLocationInventory()
        {
            return new List<LocationInventory>();
        }
        public static List<LocationInventory> GenerateListOfLocationInventory(string locationCode, string productCode, int stockAvailable = 0, int stockOnBackOrder = 0, int stockOnHand = 0)
        {
            var location = new LocationInventory { LocationCode = locationCode, ProductCode = productCode, StockAvailable = stockAvailable, StockOnBackOrder = stockOnBackOrder, StockOnHand = stockOnHand };

            return new List<LocationInventory>() { location };
        }

        public static List<LocationInventoryAdjustment> GenerateListOfLocationInventoryAdjustments()
        {
            return new List<LocationInventoryAdjustment>();
        }
        public static List<LocationInventoryAdjustment> GenerateListOfLocationInventoryAdjustments(string locationCode, string productCode, int valueChange, string stockAdjustmentType = "Delta")
        {
            //const string ABSOLUTE = "Absolute";
            //const string DELTA = "Delta";
            var location = new LocationInventoryAdjustment { LocationCode = locationCode, ProductCode = productCode, Value = valueChange, Type = stockAdjustmentType };

            return new List<LocationInventoryAdjustment>(){location};
        }

        #endregion

        #region "GeneratePackage"

        /// <summary>
        /// Generate Package Object.
        /// </summary>
        /// <param name="shippingMethodCode"></param>
        /// <param name="shippingMethodName"></param>
        /// <param name="items"></param>
        /// <param name="pkgType"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package GeneratePackage(string shippingMethodCode, string shippingMethodName,
              List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PackageItem> items, string pkgType = Constant.CARRIER_BOX_MEDIUM, decimal weight = 10)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package()
            {
                ShippingMethodCode = shippingMethodCode,
                ShippingMethodName = shippingMethodName,
                PackagingType = pkgType,
                Items = items,
                Measurements = GeneratePackageMeasurements("lbs", weight)
            };
        }

        #endregion
        #region "GeneratePackageItem"

        /// <summary>
        /// Generate PackageItem Object List.
        /// </summary>
        /// <returns></returns>
        public static List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PackageItem> GeneratePackageItemList()
        {
            return new List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PackageItem>();
        }

        /// <summary>
        /// Generate PackageItem Object.
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PackageItem GeneratePackageItem(string productCode, int quantity)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PackageItem()
            {
                ProductCode = productCode,
                Quantity = quantity
            };
        }

        /// <summary>
        /// Generate PackageMeasurement Object.
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Commerce.PackageMeasurements GeneratePackageMeasurements(string weightUnit, decimal weight)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Commerce.PackageMeasurements()
            {
                Weight = GenerateMeasurement(weightUnit, weight)
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Commerce.PackageMeasurements GeneratePackageMeasurements(string dimensionUnit, decimal length, decimal width, decimal height, string weightUnit, decimal weight)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Commerce.PackageMeasurements()
            {
                Height = GenerateMeasurement(dimensionUnit, height),
                Length = GenerateMeasurement(dimensionUnit, length),
                Width = GenerateMeasurement(dimensionUnit, width),
                Weight = GenerateMeasurement(weightUnit, weight)
            };
        }

        #endregion

        #region "GeneratePaymentActions"
        /// <summary>
        /// Generate PaymentAction Object when using the same credit card.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="checkNumber"></param>
        /// <param name="amt"></param>
        /// <param name="zip"></param>
        /// <param name="paymentSourceId"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, string checkNumber, decimal amt, string paymentSourceId = null,
            Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo newInfo = null)
        {
            //Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentInteractionType
            //  Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentType

            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = "USD",
                CheckNumber = checkNumber,
                Amount = amt,
                ReferenceSourcePaymentId = paymentSourceId,
                NewBillingInfo = newInfo
            };
        }

        /// <summary>
        /// Generate PaymentAction Object when using different credit card for the payment transactions.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="amt"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="card"></param>
        /// <param name="cardId"></param>
        /// <param name="savePart"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, decimal amt,
            string state, string zip,
            Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard card, string savePart)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = "USD",
                Amount = amt,
                NewBillingInfo = GenerateBillingInfo(state, zip, card, savePart),
                ReferenceSourcePaymentId = null
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, decimal amt, Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo billingInfo, string checkNumber = null)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = Constant.Currency,
                Amount = amt,
                NewBillingInfo = billingInfo,
                CancelUrl = Generator.RandomURL(),
                ReturnUrl = Generator.RandomURL(),
                CheckNumber = checkNumber

            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, decimal amt, string state, string zip)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = Constant.Currency,
                Amount = amt,
                NewBillingInfo = GenerateBillingInfo(state, zip, false),
                CancelUrl = Generator.RandomURL(),
                ReturnUrl = Generator.RandomURL()
            };
        }


        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, decimal amt, string state, string zip, string creditCode)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = Constant.Currency,
                Amount = amt,
                NewBillingInfo = GenerateBillingInfo(state, zip, creditCode)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="amt"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="card"></param>
        /// <param name="cardId"></param>
        /// <param name="savePart"></param>
        /// <param name="manualInteraction"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, decimal amt, string state, string zip,
            Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard card, string savePart,
            Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentGatewayInteraction manualInteraction)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = "USD",
                Amount = amt,
                NewBillingInfo = GenerateBillingInfo(state, zip, card, savePart),
                ReferenceSourcePaymentId = null,
                ManualGatewayInteraction = manualInteraction
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="checkNumber"></param>
        /// <param name="amt"></param>
        /// <param name="manualInteraction"></param>
        /// <param name="paymentSourceId"></param>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction GeneratePaymentAction(string action, string checkNumber, decimal amt,
            Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentGatewayInteraction manualInteraction,
            string paymentSourceId = null, Mozu.Api.Contracts.CommerceRuntime.Payments.BillingInfo newInfo = null)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentAction()
            {
                ActionName = action,
                CurrencyCode = "USD",
                CheckNumber = checkNumber,
                Amount = amt,
                ReferenceSourcePaymentId = paymentSourceId,
                NewBillingInfo = newInfo,
                ManualGatewayInteraction = manualInteraction
            };
        }

        #endregion

        #region "GeneratePaymentCards"
        /// <summary>
        /// Generates a new PaymentCard object using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="cardNum">Credit card number.</param>
        /// <param name="type">Card type such as Visa, MasterCard, American Express, or Discover.</param>
        /// <param name="mask">The visible part of the card number that the merchant uses to refer to payment information.</param>
        /// <param name="month">Month when the card expires.</param>
        /// <param name="year">Year when the card expires.</param>
        /// <param name="isUsedRecurring">If true, the credit card is charged on a regular interval.</param>
        /// <param name="name">Card holder's name as it appears on the card.</param>
        /// <param name="isInfoSaved">If true, the card information is stored in the customer's account.</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard GeneratePaymentCard(string cardNum, string type, string mask,
            short month, short year, bool isUsedRecurring, string name, bool isInfoSaved)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard()
            {
                PaymentServiceCardId = cardNum,
                PaymentOrCardType = type,
                CardNumberPartOrMask = mask,
                ExpireMonth = month,
                ExpireYear = year,
                IsUsedRecurring = isUsedRecurring,
                NameOnCard = name,
                IsCardInfoSaved = isInfoSaved
            };
        }


        /// <summary>
        /// Generates a new PaymentCard object using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="type">Card type such as Visa, MasterCard, American Express, or Discover.</param>
        /// <param name="month">Month when the card expires.</param>
        /// <param name="year">Year when the card expires.</param>
        /// <param name="isUsedRecurring">If true, the credit card is charged on a regular interval.</param>
        /// <param name="isCardInfoSaved">If true, the card information is stored in the customer's account.</param>
        /// <returns>Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard</returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard GeneratePaymentCard(string type, short month, short year,
            bool isUsedRecurring = false, bool isCardInfoSaved = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard()
            {
                PaymentServiceCardId = Generator.RandomString(16, Generator.RandomCharacterGroup.NumericOnly),
                PaymentOrCardType = type,
                CardNumberPartOrMask = Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                ExpireMonth = month,
                ExpireYear = year,
                IsUsedRecurring = isUsedRecurring,
                NameOnCard = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaOnly),
                IsCardInfoSaved = isCardInfoSaved
            };
        }


        /// <summary>
        /// Generates a new PaymentCard object using <see cref="Payments" /> class.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="cardId"></param>
        /// <param name="savePart"></param>
        /// <param name="isCardInfoSaved"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard GeneratePaymentCard(Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard card,
            string cardId, string savePart, bool isCardInfoSaved = false)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentCard()
            {
                PaymentServiceCardId = cardId,
                PaymentOrCardType = card.PaymentOrCardType,
                CardNumberPartOrMask = savePart,
                ExpireMonth = (short)card.ExpireMonth,
                ExpireYear = (short)card.ExpireYear,
                IsUsedRecurring = false,
                NameOnCard = card.NameOnCard,
                IsCardInfoSaved = isCardInfoSaved
            };
        }
        #endregion
        #region "GeneratePaymentGatewayInteraction"

        /// <summary>
        /// For manual interaction process
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentGatewayInteraction GeneratePaymentGatewayInteraction()
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Payments.PaymentGatewayInteraction()
            {
                GatewayInteractionId = Generator.RandomInt(22222, 99999),
                GatewayTransactionId = Generator.RandomString(2, Generator.RandomCharacterGroup.NumericOnly),
                GatewayAuthCode = Generator.RandomString(6, Generator.RandomCharacterGroup.NumericOnly),
                GatewayAVSCodes = "P",
                GatewayCVV2Codes = "",
                GatewayResponseCode = "1"
            };
        }

        #endregion
        #region "GeneratePickup"
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup GeneratePickup()
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup();
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup GeneratePickup(
                List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem> items, string fulfillmentLocationCode)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup()
            {
                FulfillmentDate = DateTime.UtcNow,
                FulfillmentLocationCode = fulfillmentLocationCode,
                Items = items
            };
        }
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup GeneratePickup(
                List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem> items)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup()
            {
                FulfillmentDate = DateTime.UtcNow,
                Items = items
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup GeneratePickup(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem item)
        {
            var itemList = new List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem>() { item };
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup()
            {
                FulfillmentDate = DateTime.UtcNow,
                Items = itemList
            };
        }
        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup GeneratePickup(Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem item, string fulfillmentLocationCode)
        {
            var itemList = new List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem>() { item };
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Pickup()
            {
                FulfillmentDate = DateTime.UtcNow,
                FulfillmentLocationCode = fulfillmentLocationCode,
                Items = itemList
            };
        }

        public static List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem> GeneratePickupItemList()
        {
            return new List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem>();
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem GeneratePickupItem(string productCode, int quantity)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Fulfillment.PickupItem()
            {
                //OrderItemId = itemId,
                ProductCode = productCode,
                Quantity = quantity
            };
        }
        #endregion

        #region "GeneratePhone"
        /// <summary>
        /// Generates a new Phone object using <see cref="Generator" /> class.
        /// </summary>
        /// <param name="home"></param>
        /// <param name="mobile"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Phone GeneratePhone(string home, string mobile, string work)
        {
            return new Mozu.Api.Contracts.Core.Phone()
            {
                Home = home,
                Mobile = mobile,
                Work = work
            };
        }


        /// <summary>
        /// Generates a new Phone object using <see cref="Generator" /> class.
        /// </summary>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.Phone GeneratePhoneRandom()
        {
            return new Mozu.Api.Contracts.Core.Phone()
            {
                Home = string.Format("{0}-{1}-{2}", Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly)),
                Mobile = string.Format("{0}-{1}-{2}", Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly)),
                Work = string.Format("{0}-{1}-{2}", Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                 Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly))
            };
        }
        #endregion

        #region "GenerateProduct"

        /// <summary>
        /// generate Product object
        /// </summary>
        /// <param name="productTypeId"> producttype id. If null, it will use the default one</param>
        /// <param name="extras"></param>
        /// <param name="options"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static Product GenerateProduct(int? productTypeId = null,
                                                                     List<ProductExtra> extras = null,
                                                                     List<ProductOption> options = null,
                                                                     List<ProductProperty> properties = null)
        {
            Product PTobj;
            PTobj = new Product()
            {
                ProductCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                Price = GenerateProductPrice(price: Generator.RandomDecimal(50, 200)),
                //SeoContent = GenerateProductLocalizedSEOContent(),
                Content = GenerateProductLocalizedContent(Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly)),
                Extras = extras,
                Options = options,
                Properties = properties,
                ProductTypeId = productTypeId,
                PackageWeight = GenerateMeasurement("lbs", Generator.RandomDecimal(50, 200)),
                ProductUsage = "Standard" // Bundle,Component,Standard
                //                   ProductInSites = ,
                //                   UPC = ,
                //                   IsHiddenWhenOutOfStock = ,
                //                   IsBackOrderAllowed = ,
                //                    IsPackagedStandAlone = ,
                //                    IsTaxable = ,
                //                    ManageStock = ,
                //                    StockOnHandAdjustment = ,
                //                    IsRecurring = ,
                //                    StandAlonePackageType = ,
                //                    PackageHeight = ,
                //                    PackageLength = ,
                //                    PackageWidth = ,
                //the following are readonly
                //                    ApplicableDiscounts = ,
                //                    StockAvailable = ,
                //                    StockOnBackOrder = ,
                //                    StockOnHand = ,
                //                    ShippingClassId = ,
                //                    IsValidForProductType = ,
                //                    ProductSequence = ,
                //                    SiteGroupId = ,
                //                    HasConfigurableOptions = ,
                //                    HasStandAloneOptions = ,
                //                    AuditInfo = ,
                //                    BaseProductCode = ,                    
                //                    IsVariation = ,
                //                    VariationKey = ,
                //                    VariationOptions = 
            };
            return PTobj;
        }

        /// <summary>
        /// generate product object
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static Product GenerateProduct(ProductType productType)
        {
            List<string> attributeFQNs = new List<string>();
            List<ProductExtra> extras = null;
            List<ProductProperty> properties = null;
            List<ProductOption> options = null;
            if (productType.Extras != null)
            {
                foreach (var extra in productType.Extras)
                {
                    if (!attributeFQNs.Contains(extra.AttributeFQN))
                    {
                        if (extras == null)
                            extras = new List<ProductExtra>();
                        extras.Add(GenerateProductExtra(extra));
                        attributeFQNs.Add(extra.AttributeFQN);
                    }
                }
            }
            if (productType.Properties != null)
            {
                foreach (var property in productType.Properties)
                {
                    if (!attributeFQNs.Contains(property.AttributeFQN))
                    {
                        if (properties == null)
                            properties = new List<ProductProperty>();
                        properties.Add(GenerateProductProperty(property));
                        attributeFQNs.Add(property.AttributeFQN);
                    }
                }
            }
            if (productType.Options != null)
            {
                foreach (var option in productType.Options)
                {
                    if (!attributeFQNs.Contains(option.AttributeFQN))
                    {
                        if (options == null)
                            options = new List<ProductOption>();
                        options.Add(GenerateProductOption(option));
                        attributeFQNs.Add(option.AttributeFQN);
                    }
                }
            }
            return GenerateProduct(productType.Id, extras, options, properties);
        }

        /// <summary>
        /// generate product object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="salep"></param>
        /// <param name="stock"></param>
        /// <param name="productType"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static Product GenerateProduct(string name, decimal price,
                                                                     decimal salep, int stock, ProductType productType,
                                                                     decimal weight)
        {
            var pd = GenerateProduct(productType);
            pd.Content.ProductName = name;
            pd.Price = GenerateProductPrice(price: price, salePrice: salep);
            pd.PackageWeight = GenerateMeasurement("lbs", weight);
            return pd;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="salep"></param>
        /// <param name="stock"></param>
        /// <param name="weight"></param>
        /// <param name="unit"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="standAlonePkgType"></param>
        /// <param name="productTypeId"></param>
        /// <param name="pkgStandAlone"></param>
        /// <param name="taxable"></param>
        /// <param name="mgmtStock"></param>
        /// <param name="recurring"></param>
        /// <returns></returns>
        public static Product GenerateProduct(string productCode, string name, decimal? price,
                                                                     decimal? salep, int stock, decimal weight,
                                                                     string unit, int height, int length, int width,
                                                                     string standAlonePkgType,
                                                                     int? productTypeId = 1,
                                                                     bool? pkgStandAlone = false, bool? taxable = true,
                                                                     bool? mgmtStock = true, bool? recurring = false)
        {
            var pd = GenerateProduct(productTypeId);
            pd.ProductCode = productCode;
            pd.Content.ProductName = name;
            pd.Price = GenerateProductPrice(price: price, salePrice: salep);
            pd.IsPackagedStandAlone = pkgStandAlone;
            pd.IsTaxable = taxable;
            pd.InventoryInfo.ManageStock = mgmtStock;
            //            pd.StockOnHandAdjustment = stockAdjustment;
            pd.IsRecurring = recurring;
            pd.StandAlonePackageType = standAlonePkgType;
            pd.PackageHeight = GenerateMeasurement(unit, height);
            pd.PackageLength = GenerateMeasurement(unit, length);
            pd.PackageWidth = GenerateMeasurement(unit, width);
            pd.PackageWeight = GenerateMeasurement("lbs", weight);
            return pd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="variationProductCode"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Products.Product GenerateConfigurableProduct(string productCode, string variationProductCode)
        {

            return new Mozu.Api.Contracts.CommerceRuntime.Products.Product()
            {
                ProductCode = productCode,
                VariationProductCode = variationProductCode
            };
        }
        public static Mozu.Api.Contracts.CommerceRuntime.Products.Product GenerateNonConfigurableProduct(string productCode)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Products.Product()
            {
                Name = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                Description = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly),
                ProductCode = productCode
            };
        }

        public static List<Product> GenerateProductsRandom(ServiceClientMessageHandler handler, string name, int numProducts)
        {
            //var prodColl = GenerateProductCollection();
            var prodColl = new List<Product>();
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            for (var i = 0; i < numProducts; i++)
            {
                var createdPT = ProductTypeFactory.AddProductType(handler, myPT);
                var myProduct = Generator.GenerateProduct(createdPT);
                var prodName = myProduct.Content.ProductName;
                myProduct.Content.ProductName = name + prodName;
                var createdProduct = ProductFactory.AddProduct(handler, myProduct);
                var product = ProductFactory.GetProduct(handler, createdProduct.ProductCode);
                prodColl.Add(product);

            }
            return prodColl;
        }

        public static List<TargetedProduct> GenerateTargetedProductList()
        {
            return new List<TargetedProduct>();
        }
        public static List<TargetedShippingMethod> GenerateTargetedShippingMethodList()
        {
            return new List<TargetedShippingMethod>();
        }


        #endregion
        #region "GenerateProductBundle"
        public static BundledProduct GenerateBundledProduct(string productCode, int quantity, string productName)
        {

            return new BundledProduct()
            {
                ProductCode = productCode,
                Quantity = quantity,
                ProductName = productName,
            };
        }

        #endregion 
        #region "GenerateProductCategory"

        /// <summary>
        /// generate ProductCategory object
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public static ProductCategory GenerateProductCategory(int cateId)
        {
            return new ProductCategory()
            {
                CategoryId = cateId
            };
        }

        public static List<ProductCategory> GenerateProductCategoryList(List<int> cateIds)
        {
            return cateIds.Select(cat => new ProductCategory() { CategoryId = cat }).ToList();
        }

        #endregion

        #region "GenerateProductPrice"

        /// <summary>
        /// generate ProductPrice object
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="price"></param>
        /// <param name="salePrice"></param>
        /// <returns></returns>
        public static ProductPrice GenerateProductPrice(string currency = Constant.Currency, decimal? price = null, decimal? salePrice = null)
        {
            return new ProductPrice
            {
                IsoCurrencyCode = currency,
                Price = price,
                SalePrice = salePrice
            };
        }

        #endregion
        #region "GenerateProductExtra"

        /// <summary>
        /// generate ProductExtra object
        /// </summary>
        /// <param name="attributeInProductType"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="isRequired"></param>
        /// <returns></returns>
        public static ProductExtra GenerateProductExtra(AttributeInProductType attributeInProductType, bool? isMultiSelect = null, bool? isRequired = null)
        {
            var extra = new ProductExtra()
            {
                AttributeFQN = attributeInProductType.AttributeFQN,
                IsMultiSelect = isMultiSelect,
                IsRequired = isRequired
            };
            if (attributeInProductType.VocabularyValues != null)
            {
                foreach (var value in attributeInProductType.VocabularyValues)
                {
                    if (extra.Values == null)
                    {
                        extra.Values = new List<ProductExtraValue>();
                    }
                    extra.Values.Add(GenerateProductExtraValue(Generator.RandomDecimal(10, 20),
                                                                       value.Value, null, null));
                    //if (attr.IsMultiValueProperty != null && attr.IsMultiValueProperty == false)
                    //    break;
                }
            }
            return extra;
        }

        #endregion
        #region "GenerateProductExtraValue"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="value"></param>
        /// <param name="weight"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public static ProductExtraValue GenerateProductExtraValue(decimal price, object value, decimal? weight, bool? isDefault)
        {
            return new ProductExtraValue()
            {
                DeltaPrice = GenerateProductExtraValueDeltaPrice(price),
                Value = value,
                DeltaWeight = weight,
                IsDefaulted = isDefault
            };
        }

        #endregion
        #region "GenerateProductExtraValueDeltaPrice"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static ProductExtraValueDeltaPrice GenerateProductExtraValueDeltaPrice(decimal price, string currency = Constant.Currency)
        {
            return new ProductExtraValueDeltaPrice()
            {
                CurrencyCode = currency,
                DeltaPrice = price
            };
        }

        #endregion
        #region "GenerateProductInCatalogInfo"

        /// <summary>
        /// generate ProductInSiteInfo object
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="productCategories"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="isActive"></param>
        /// <param name="isContentOverridden"></param>
        /// <param name="isPriceOverridden"></param>
        /// <param name="isSeoContentOverridden"></param>
        /// <returns></returns>
        public static ProductInCatalogInfo GenerateProductInCatalogInfo(int catalogId, List<ProductCategory> productCategories, string name, decimal? price, bool? isActive,
                                                                  bool? isContentOverridden, bool? isPriceOverridden, bool? isSeoContentOverridden)
        {
            return new ProductInCatalogInfo
            {
                Content = GenerateProductLocalizedContent(name),
                //SeoContent = GenerateProductLocalizedSEOContent(),
                IsActive = isActive,
                IsContentOverridden = isContentOverridden,
                IsPriceOverridden = isPriceOverridden,
                //IsseoContentOverridden = isSeoContentOverridden,
                Price = GenerateProductPrice(price: price),
                ProductCategories = productCategories,
                CatalogId = catalogId,
            };
        }

        /// <summary>
        /// generate ProductInSiteInfo object
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="cateId"></param>
        /// <param name="isActive"></param>
        /// <param name="isContentOverridden"></param>
        /// <param name="isPriceOverridden"></param>
        /// <param name="isSeoContentOverridden"></param>
        /// <returns></returns>
        public static ProductInCatalogInfo GenerateProductInCatalogInfo(int siteId, int? cateId, bool? isActive = true,
                                                                  bool? isContentOverridden = true, bool? isPriceOverridden = true, bool? isSeoContentOverridden = true)
        {
            var info = GenerateProductInCatalogInfo(siteId, null, Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                Generator.RandomDecimal(10, 100), isActive, isContentOverridden, isPriceOverridden, isSeoContentOverridden);
            if (cateId.HasValue)
            {
                info.ProductCategories = new List<ProductCategory>() { new ProductCategory() { CategoryId = cateId.Value } };
            }
            return info;
        }

        /// <summary>
        /// generate empty ProductInSiteInfo object
        /// </summary>
        /// <returns></returns>
        public static List<ProductInCatalogInfo> GenerateProductInCatalogInfoList()
        {
            return new List<ProductInCatalogInfo>();
        }

        #endregion
        #region "GenerateProductInventoryInfo"
        /// <summary>
        ///
        /// </summary>
        /// <param name="manageStock"></param>
        /// <param name="outOfStockBehavior"></param>
        /// <returns></returns>
        public static ProductInventoryInfo GenerateProductInventoryInfo(bool? manageStock, string outOfStockBehavior = null)
        {
            return new ProductInventoryInfo()
            {
                ManageStock = manageStock,
                OutOfStockBehavior = outOfStockBehavior
            };
        }
        #endregion


        #region "GenerateProductLocalizedContent"

        /// <summary>
        /// Generate ProductLocalizedContent object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imageList"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ProductLocalizedContent GenerateProductLocalizedContent(string name,
                                                                                                     List<ProductLocalizedImage> imageList = null, string locale = Constant.LocaleCode)
        {
            return new ProductLocalizedContent
            {
                LocaleCode = locale,
                ProductFullDescription = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                ProductImages = imageList,
                ProductName = name,
                ProductShortDescription = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
            };
        }

        #endregion
        #region "GenerateProductLocalizedImage"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="videoUrl"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ProductLocalizedImage GenerateProductLocalizedImage(string imageUrl, string videoUrl, string locale = Constant.LocaleCode)
        {
            return new ProductLocalizedImage()
            {
                AltText = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                ImageLabel = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                //ImagePath = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly) + "/" + Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly),
                ImageUrl = imageUrl,
                LocaleCode = locale,
                VideoUrl = videoUrl
            };
        }
        public static List<ProductLocalizedImage> GenerateProductLocalizedImageList()
        {
            return new List<ProductLocalizedImage>();
        }

        #endregion
        #region "GenerateProductLocalizedSEOContent"

        /// <summary>
        /// generate ProductLocalizedSEOContent object
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ProductLocalizedSEOContent GenerateProductLocalizedSEOContent(string locale = Constant.LocaleCode)
        {
            return new ProductLocalizedSEOContent
            {
                LocaleCode = locale,
                MetaTagDescription = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly),
                MetaTagKeywords = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly),
                MetaTagTitle = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                //SeoFriendlyUrl = Generator.RandomURL(),
                TitleTagTitle = Generator.RandomString(8, Generator.RandomCharacterGroup.AlphaOnly)
            };
        }

        #endregion

        #region "GenerateProductOption"

        /// <summary>
        /// generate ProductOption object
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static ProductOption GenerateProductOption(AttributeInProductType attr)
        {
            var option = new ProductOption()
            {
                AttributeFQN = attr.AttributeFQN
            };
            if (attr.VocabularyValues != null)
            {
                foreach (var value in attr.VocabularyValues)
                {
                    if (option.Values == null)
                    {
                        option.Values = new List<ProductOptionValue>();
                    }
                    option.Values.Add(GenerateProductOptionValue(value.Value));
                    //if (attr.IsMultiValueProperty != null && attr.IsMultiValueProperty == false)
                    //    break;
                }
            }
            return option;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="valueCount"></param>
        /// <returns></returns>
        public static ProductOption GenerateProductOption(AttributeInProductType attr, int valueCount)
        {
            var option = new ProductOption()
            {
                AttributeFQN = attr.AttributeFQN
            };
            if (attr.VocabularyValues != null)
            {
                int count = 0;
                foreach (var value in attr.VocabularyValues)
                {
                    if (option.Values == null)
                    {
                        option.Values = new List<ProductOptionValue>();
                    }
                    option.Values.Add(GenerateProductOptionValue(value.Value));
                    count++;
                    if (count == valueCount)
                        break;
                }
            }
            return option;
        }

        public static List<ProductOption> GenerateProductOptionList()
        {
            return new List<ProductOption>();
        }
        /// <summary>
        /// Create an attribute with a list of options
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="attributeName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.ProductAdmin.Attribute CreateOptionAttribute(ServiceClientMessageHandler handler,
                string attributeName, List<string> values)
        {
            var attr =
                GenerateAttribute(
                    attributeCode:
                        attributeName + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly), isOption: true);
            attr.VocabularyValues.Clear();
            foreach (var value in values)
            {
                attr.VocabularyValues.Add(GenerateAttributeVocabularyValue(value));
            }
            var createdAttr = AttributeFactory.AddAttribute(handler, attr);
            return createdAttr;

        }
        #endregion
        #region "GenerateProductOptionValue"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ProductOptionValue GenerateProductOptionValue(object value)
        {
            return new ProductOptionValue()
            {
                Value = value
            };
        }

        #endregion
        #region "GenerateProductProperty"

        /// <summary>
        /// generate ProductProperty
        /// </summary>
        /// <param name="attributeFQN"></param>
        /// <returns></returns>
        public static ProductProperty GenerateProductProperty(AttributeInProductType attr)
        {
            var property = new ProductProperty()
            {
                AttributeFQN = attr.AttributeFQN
            };
            if (attr.VocabularyValues != null)
            {
                foreach (var value in attr.VocabularyValues)
                {
                    if (property.Values == null)
                    {
                        property.Values = new List<ProductPropertyValue>();
                    }
                    property.Values.Add(GenerateProductPropertyValue(value.Value,
                                                                     GenerateProductPropertyValueLocalizedContent(
                                                                         Generator.RandomString(5,
                                                                                                Generator.RandomCharacterGroup.AlphaOnly))));
                    if (attr.IsMultiValueProperty != null && attr.IsMultiValueProperty == false)
                        break;
                }
            }
            return property;
        }

        #endregion
        #region "GenerateProductPropertyValue"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static ProductPropertyValue GenerateProductPropertyValue(object value, ProductPropertyValueLocalizedContent content)
        {
            return new ProductPropertyValue()
            {
                Value = value,
                Content = content
            };
        }

        #endregion
        #region "GenerateProductPropertyValueLocalizedContent"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ProductPropertyValueLocalizedContent GenerateProductPropertyValueLocalizedContent(string value, string locale = Constant.LocaleCode)
        {
            return new ProductPropertyValueLocalizedContent()
            {
                LocaleCode = locale,
                StringValue = value
            };
        }

        #endregion
        #region "GenerateProductReservation"

        public static ProductReservation GenerateProductReservation(string locCode, string orderId, string orderItemId, string productCode, int quantity)
        {
            return new ProductReservation()
            {
                LocationCode = locCode,
                OrderId = orderId,
                OrderItemId = orderItemId,
                ProductCode = productCode,
                Quantity = quantity
            };
        }

        #endregion
        #region "GenerateProductType"

        /// <summary>
        /// Generate ProductType object
        /// </summary>
        /// <param name="options"></param>
        /// <param name="properties"></param>
        /// <param name="extras"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ProductType GenerateProductType(string name, List<AttributeInProductType> options = null,
                                                                             List<AttributeInProductType> properties = null, List<AttributeInProductType> extras = null)
        {
            return new ProductType()
            {
                Name = name,
                Options = options,
                Properties = properties,
                Extras = extras,
                //                AuditInfo = 
                //                SiteGroupId = 
                //                Id = 
                //                IsBaseProductType = 
            };
        }

        /// <summary>
        /// Generate a producttype from one attribute
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="name"> producttype name </param>
        /// <returns></returns>
        public static ProductType GenerateProductType(Mozu.Api.Contracts.ProductAdmin.Attribute attr, string name)
        {
            var attrs = new List<Mozu.Api.Contracts.ProductAdmin.Attribute> { attr };
            return GenerateProductType(attrs, name: name);
        }

        /// <summary>
        /// Generate product type
        /// </summary>
        /// <param name="attrs"> Mozu.Api.Contracts.ProductAdmin.Attributelist used in producttype </param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ProductType GenerateProductType(List<Mozu.Api.Contracts.ProductAdmin.Attribute> attrs,
                                                                             string name)
        {
            List<AttributeInProductType> extras = null;
            List<AttributeInProductType> properties = null;
            List<AttributeInProductType> options = null;
            foreach (var attr in attrs)
            {
                var attrInPT = GenerateAttributeInProductType(attr);
                if (attr.IsOption.HasValue)
                {
                    if ((bool)attr.IsOption)
                    {
                        if (options == null)
                            options = new List<AttributeInProductType>();
                        options.Add(attrInPT);
                    }
                }

                if (attr.IsExtra.HasValue)
                {
                    if ((bool)attr.IsExtra)
                    {
                        if (extras == null)
                            extras = new List<AttributeInProductType>();
                        extras.Add(attrInPT);
                    }
                }

                if (attr.IsProperty.HasValue)
                {
                    if ((bool)attr.IsProperty)
                    {
                        if (properties == null)
                        {
                            properties = new List<AttributeInProductType>();
                        }
                        attrInPT.IsMultiValueProperty = true;
                        properties.Add(attrInPT);
                    }
                }
            }
            return GenerateProductType(name, options, properties, extras);
        }

        public static ProductType GenerateBasicProductType(string name)
        {
            return new ProductType()
            {
                Name = name,
                ProductUsages = new List<string> { "Standard", "Configurable" }
            };
        }
        public static ProductType GenerateProductType(string name, List<string> usages)
        {
            return new ProductType()
            {
                Name = name,
                ProductUsages = usages
            };
        }
        public static ProductType PrepareProductType(ServiceClientMessageHandler handler)
        {
            var attrs = new List<string>();
            var colorAttr = Generator.CreateOptionAttribute(handler, "Color", new List<string>() { "Red", "Blue", "Green" });
            attrs.Add(colorAttr.AttributeFQN);
            var sizeAttr = Generator.CreateOptionAttribute(handler, "Size", new List<string>() { "Small", "Medium", "Large" });
            attrs.Add(sizeAttr.AttributeFQN);
            var decoAttr = Generator.CreateOptionAttribute(handler, "Blinking", new List<string>() { "Yes", "No" });
            attrs.Add(decoAttr.AttributeFQN);
            var attList = new List<Attribute>();

            attList.Clear();
            attList.Add(colorAttr);
            attList.Add(sizeAttr);
            attList.Add(decoAttr);
            var productType = GenerateProductType(attList, RandomString(10,RandomCharacterGroup.AlphaNumericOnly));
            return productType;
        }
        #endregion
        #region "GenerateProductVariationDeltaPrice"

        public static List<ProductVariation> GenerateProductVariationList()
        {
            return new List<ProductVariation>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ProductVariationDeltaPrice GenerateProductVariationDeltaPrice(decimal value)
        {
            return new ProductVariationDeltaPrice()
            {
                CurrencyCode = Constant.Currency,
                Value = value
            };
        }

        #endregion
        #region "GenerateProductVarationCollection

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static ProductVariationCollection GenerateProductVariationCollection(List<ProductVariation> items, int totalCount)
        {
            return new ProductVariationCollection()
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        #endregion

        #region "GeneratePublishingScope" 
        public static PublishingScope GeneratePublishingScope(bool? allPending, List<string> productCodes)
        {
            return new PublishingScope()
            {
                AllPending = allPending,
                ProductCodes = productCodes
            };
        }
        #endregion

        #region "GenerateReturn"
        public enum ReturnType
        {
            Replace,
            Refund,
        }
        public static Mozu.Api.Contracts.CommerceRuntime.Returns.Return GenerateReturn(ReturnType returnType,
            List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem> items,
            string originalOrderId, string returnOrderId, List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderNote> orderNote,
            List<Mozu.Api.Contracts.CommerceRuntime.Payments.Payment> payments,
            decimal? refundAmount,
            int? returnNumber,
            decimal totalLossAmount = 0)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.Return
            {
                Items = items,
                OriginalOrderId = originalOrderId,
                ReturnOrderId = returnOrderId,
                Notes = orderNote,
                Payments = payments,
                RefundAmount = refundAmount,
                ReturnNumber = returnNumber,
                ReturnType = returnType.ToString(),
                //TotalLossAmount = totalLossAmount
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Returns.Return GenerateReturn(ReturnType returnType,
            List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem> items, string orderId)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.Return
            {
                Items = items,
                OriginalOrderId = orderId,
                ReturnType = returnType.ToString()
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Returns.Return GenerateReturn(string returnType,
            List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem> items, string orderId)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.Return
            {
                Items = items,
                OriginalOrderId = orderId,
                ReturnType = returnType
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Returns.Return GenerateReturn(string orderId, string type,
            List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem> items,
            List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderNote> notes)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.Return()
            {
                OriginalOrderId = orderId,
                Items = items,
                ReturnType = type,
                Notes = notes
            };
        }
        #endregion

        #region "GenerateReturnItem"
        public static Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem GenerateReturnItem(string itemId, Dictionary<string, int> reasons)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem
            {
                OrderItemId = itemId,
                Reasons = GenerateReturnReasons(reasons)
            };
        }
        public static Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem GenerateReturnItem(string itemId, Dictionary<string, int> reasons,
           List<Mozu.Api.Contracts.CommerceRuntime.Orders.OrderNote> notes)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnItem
            {
                OrderItemId = itemId,
                Reasons = GenerateReturnReasons(reasons),
                Notes = notes
            };
        }

        private static List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnReason> GenerateReturnReasons(Dictionary<string, int> reasons)
        {
            var returnReasons = new List<Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnReason>();
            foreach (var r in reasons)
            {
                var reason = new Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnReason
                {
                    Quantity = r.Value,
                    Reason = r.Key
                };

                returnReasons.Add(reason);
            }
            return (returnReasons);
        }
        #endregion

        #region "GenerateReturnAction"
        public static Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnAction GenerateReturnAction(string actionName)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnAction
            {
                ActionName = actionName
            };
        }

        public static Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnAction GenerateReturnAction(string actionName, List<string> returnIds)
        {
            return new Mozu.Api.Contracts.CommerceRuntime.Returns.ReturnAction
            {
                ActionName = actionName,
                ReturnIds = returnIds
            };
        }
        #endregion
        #region "GenerateStandAlonePackageTypeConst"
        public static string GenerateStandAlonePackageTypeConst()
        {
            string type = null;
            int i = Generator.RandomInt(1, 7);
            switch (i)
            {
                case 1:
                    type = StandAlonePackageTypeConst.CARRIER_BOX_LARGE;
                    break;
                case 2:
                    type = StandAlonePackageTypeConst.CARRIER_BOX_MEDIUM;
                    break;
                case 3:
                    type = StandAlonePackageTypeConst.CARRIER_BOX_SMALL;
                    break;
                case 4:
                    type = StandAlonePackageTypeConst.CUSTOM;
                    break;
                case 5:
                    type = StandAlonePackageTypeConst.LETTER;
                    break;
                case 6:
                    type = StandAlonePackageTypeConst.PAK;
                    break;
                case 7:
                    type = StandAlonePackageTypeConst.TUBE;
                    break;
            }
            return type;
        }

        public static class StandAlonePackageTypeConst
        {
            public const string TUBE = "TUBE";
            public const string LETTER = "LETTER";
            public const string PAK = "PAK";
            public const string CARRIER_BOX_SMALL = "CARRIER_BOX_SMALL";
            public const string CARRIER_BOX_MEDIUM = "CARRIER_BOX_MEDIUM";
            public const string CARRIER_BOX_LARGE = "CARRIER_BOX_LARGE";
            public const string CUSTOM = "CUSTOM";
        }
        #endregion

        #region "GenerateUser"
        /// <summary>
        /// Generate User object
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="password"></param>
        /// <param name="localecode"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.User GenerateUser(bool isActive = true, string password = Constant.Password, string localecode = Constant.LocaleCode)
        {
            return new Mozu.Api.Contracts.Core.User
            {
                //EmailAddress = "mozuqa@volusion.com",
                EmailAddress = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                LastName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                IsActive = isActive,
                LocaleCode = localecode,
                Password = password
            };
        }

        /// <summary>
        /// Generate User object
        /// </summary>
        /// <param name="random"></param>
        /// <param name="localecode"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.User GenerateUser(bool random, string localecode = Constant.LocaleCode)
        {
            return new Mozu.Api.Contracts.Core.User
            {
                EmailAddress = Generator.RandomEmailAddress(),
                FirstName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                LastName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                IsActive = true,
                LocaleCode = localecode,
                Password = Constant.Password
            };
        }

        /// <summary>
        /// Generates a new User object.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="isActive"></param>
        /// <param name="password"></param>
        /// <param name="localecode"></param>
        /// <returns>Mozu.Core.Api.Contracts.User</returns>
        public static Mozu.Api.Contracts.Core.User GenerateUser(string email, bool isActive = true, string password = Constant.Password, string localecode = Constant.LocaleCode)
        {
            return new Mozu.Api.Contracts.Core.User
            {
                EmailAddress = email,
                FirstName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                LastName = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                IsActive = isActive,
                LocaleCode = localecode,
                Password = password,
            };
        }

        public static Mozu.Api.Contracts.Core.User GenerateUser(string email, string name)
        {
            var names = name.Split(' ');
            return new Mozu.Api.Contracts.Core.User
            {
                EmailAddress = email,
                FirstName = names.First(),
                LastName = names.Last(),
                IsActive = true,
                LocaleCode = Constant.LocaleCode,
                Password = Constant.Password,
            };
        }
        public static Mozu.Api.Contracts.Core.User GenerateUser(string email, string firstName, string lastName)
        {
            return new Mozu.Api.Contracts.Core.User
            {
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName,
                IsActive = true,
                LocaleCode = Constant.LocaleCode,
                Password = Constant.Password,
            };
        }
        #endregion
        #region "GenerateUserAuthInfo"

        /// <summary>
        /// Generate UserAuthInfo Object.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.Core.UserAuthInfo GenerateUserAuthInfo(string email, string passwd = "MozuPass1")
        {
            if (string.IsNullOrEmpty(email))
                email = Generator.RandomEmailAddress();

            return new Mozu.Api.Contracts.Core.UserAuthInfo()
            {
                EmailAddress = email,
                Password = passwd
            };
        }
        #endregion
        #region "GenerateWishLists"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeTag"></param>
        /// <param name="name"></param>
        /// <param name="items"></param>
        /// <param name="privacyType"></param>
        /// <returns></returns>
        public static Mozu.Api.Contracts.CommerceRuntime.Wishlists.Wishlist GenerateWishlist(int? customerAccountId, int? tenantId, int? siteId, string typeTag, string name,
            List<WishlistItem> items)
        {
            return new Wishlist()
            {
                CustomerAccountId = customerAccountId,
                TenantId = tenantId,
                SiteId = siteId,
                TypeTag = typeTag,
                Name = name,
                Items = items,
                CustomerInteractionType = "website" //store, call


            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Wishlist GenerateWishlist(string name, List<WishlistItem> items)
        {
            return new Wishlist()
            {
                Name = name,
                Items = items

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Wishlist GenerateWishlist(int customerAccountId, string name, List<WishlistItem> items)
        {
            return new Wishlist()
            {
                CustomerAccountId = customerAccountId,
                Name = name,
                Items = items

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Wishlist GenerateWishlist(string name)
        {
            return new Wishlist()
            {
                Name = name
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WishlistCollection GenerateWishlistCollection()
        {
            return new WishlistCollection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WishlistItemCollection GenerateWishlistItemCollection()
        {
            return new WishlistItemCollection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<WishlistItem> GenerateWishlistItemList()
        {
            return new List<WishlistItem>();
        }

        public static List<WishlistItem> GenerateWishlistItemListRandom(ProductCollection products, int numItems)
        {
            var productCode = "";
            var variationKey = "";
            var wishListItemList = GenerateWishlistItemList();
            for (int i = 0; i < numItems; i++)
            {
                //Generate Product
                if (i < products.Items.Count)
                {
                    productCode = products.Items[i].ProductCode;
                    variationKey = products.Items[i].VariationKey;
                }
                else
                {
                    productCode = products.Items[0].ProductCode;
                    variationKey = products.Items[0].VariationKey;
                }
                var product = Generator.GenerateConfigurableProduct(productCode, variationKey);
                var wishListItem = Generator.GenerateWishlistItem(product,
                Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaNumericOnly), "high",
                    "purchasable", 2, true, true);
                wishListItemList.Add(wishListItem);
            }
            return wishListItemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="comments"></param>
        /// <param name="priorityType"></param>
        /// <param name="purchasableStatusType"></param>
        /// <param name="quantity"></param>
        /// <param name="isRecurring"></param>
        /// <param name="isTaxable"></param>
        /// <param name="shippingDiscounts"></param>
        /// <returns></returns>
        public static WishlistItem GenerateWishlistItem(Mozu.Api.Contracts.CommerceRuntime.Products.Product product, string comments, string priorityType,
            string purchasableStatusType, int quantity, bool isRecurring, bool isTaxable, List<Mozu.Api.Contracts.CommerceRuntime.Discounts.ShippingDiscount> shippingDiscounts)
        {
            return new WishlistItem()
            {
                Id = Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly),
                Comments = comments,
                PriorityType = priorityType,
                PurchasableStatusType = purchasableStatusType,
                Product = product,
                ShippingDiscounts = shippingDiscounts,
                Quantity = quantity,
                IsRecurring = isRecurring,
                IsTaxable = isTaxable

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="comments"></param>
        /// <param name="priorityType"></param>
        /// <param name="purchasableStatusType"></param>
        /// <param name="quantity"></param>
        /// <param name="isRecurring"></param>
        /// <param name="isTaxable"></param>
        /// <returns></returns>
        public static WishlistItem GenerateWishlistItem(Mozu.Api.Contracts.CommerceRuntime.Products.Product product, string comments, string priorityType,
            string purchasableStatusType, int quantity, bool isRecurring, bool isTaxable)
        {
            return new WishlistItem()
            {
                //Id = Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly),
                Comments = comments,
                PriorityType = priorityType,
                PurchasableStatusType = purchasableStatusType,
                Product = product,
                Quantity = quantity,
                IsRecurring = isRecurring,
                IsTaxable = isTaxable

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WishlistItem GenerateWishlistItem()
        {
            return new WishlistItem()
            {
                Id = Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly),
                PriorityType = "low",
                PurchasableStatusType = "purchasable",
                Quantity = 1,
                IsRecurring = false,
                IsTaxable = true

            };
        }
        #endregion

        #region "Set Settings"
        public static MasterCatalog SetMasterCatalogLiveMode(ServiceClientMessageHandler handler, int masterCatalogId)
        {
            var mode = MasterCatalogFactory.GetMasterCatalog(handler, masterCatalogId);
            if (mode.ProductPublishingMode.Equals("Pending"))
            {
                try
                {
                    MasterCatalogFactory.UpdateMasterCatalog(handler, masterCatalog: mode, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Live );
                }
                catch
                {
                    PublishingScopeFactory.PublishDrafts(handler, Generator.GeneratePublishingScope(true, new List<string>() { "" }));
                    MasterCatalogFactory.UpdateMasterCatalog(handler, masterCatalog: mode, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Live);
                }

            }
            return MasterCatalogFactory.GetMasterCatalog(handler, masterCatalogId);
        }
        public static MasterCatalog SetMasterCatalogPendingMode(ServiceClientMessageHandler handler, int masterCatalogId)
        {
            var mode = MasterCatalogFactory.GetMasterCatalog(handler, masterCatalogId);
            if (mode.ProductPublishingMode.Equals("Live"))
            {
                try
                {
                    MasterCatalogFactory.UpdateMasterCatalog(handler, masterCatalog: mode,
                        masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending);
                }
                catch
                {
                    throw new Exception("Could not switch to Pending Setting");
                }
            }
            return MasterCatalogFactory.GetMasterCatalog(handler, masterCatalogId);
        }
        #endregion


        #region "PopulateSampleSite"

        /// <summary>
        /// populate 10 attributes, 3 product types and 13 product to a sitegroup
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="masterCatalogId"></param>
        public static void PopulateProductsToMasterCatalog(int tenantId, int masterCatalogId)
        {
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId);

            //create color attribute
            var createdColor = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(
                    attributeCode: "Color_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Color_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    isOption: true));

            //create upgrade attribute (shopper entered)
            var createdUpgrade = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(
                    attributeCode: "Upgrade_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Upgrade_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    inputType: "TextBox", valueType: "ShopperEntered", isExtra: true));

            //create rating attribute (admin entered)
            var createdRating = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Rating_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Rating_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    inputType: "TextBox", valueType: "AdminEntered", dataType: "Number", isProperty: true));

            //create size attribute
            var createdSize = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Size_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Size_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    isProperty: true));

            //create monogram attribute (shopper entered)
            var createdMonogram = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Monogram_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Monogram_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    inputType: "TextBox", valueType: "ShopperEntered", isExtra: true));

            //create brand attribute
            var createdBrand = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Brand_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Brand_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    isExtra: true));

            //create fabric attribute
            var createdFabric = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Fabric_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Fabric_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    isProperty: true));

            //create furniture material attribute
            var createdMaterial = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Material_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Material_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    isProperty: true));

            //create created date attribute (admin entered)
            var createdDiscountExpire = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode:
                        "DiscountExpire_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "DiscountExpire_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    inputType: "DateTime", valueType: "AdminEntered", dataType: "datetime", isProperty: true));

            //create warranty attribute (shopper entered)
            var createdWarranty = AttributeFactory.AddAttribute(ApiMsgHandler, GenerateAttribute(attributeCode: "Warranty_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    adminName: "Warranty_" + Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                    inputType: "YesNo", valueType: "ShopperEntered", dataType: "Bool", isExtra: true));

            //create product type for furnitures (size, color, fabric, brand, material) 
            var furniturePT =
                Generator.GenerateProductType(
                    new List<Mozu.Api.Contracts.ProductAdmin.Attribute>()
                        {
                            createdSize,
                            createdFabric,
                            createdBrand,
                            createdMaterial
                        }, "Furniture");
            //ProductType furniturePT = Product.GenerateProductType(new List<Attribute>(){createdSize, createdColor, createdFabric, createdBrand, createdMaterial}, "Furniture");
            var createdFurniturePT = ProductTypeFactory.AddProductType(ApiMsgHandler, furniturePT);

            //create product type for shoes (size, color, discountExpire)
            var shoePT =
                Generator.GenerateProductType(
                    new List<Mozu.Api.Contracts.ProductAdmin.Attribute>() { createdColor, createdDiscountExpire }, "Shoe");
            var createdShoePT = ProductTypeFactory.AddProductType(ApiMsgHandler, shoePT);

            //create product type for hats (size, color, monogram, upgrade)
            var hatPT =
                Generator.GenerateProductType(
                    new List<Mozu.Api.Contracts.ProductAdmin.Attribute>() { createdSize, createdMonogram, createdUpgrade },
                    "Hat");
            var createdHatPT = ProductTypeFactory.AddProductType(ApiMsgHandler, hatPT);

            //create sofas (Cangy, Walsh, Amani, Burton)
            var createdCangy = ProductFactory.AddProduct(ApiMsgHandler,
                                          GenerateProduct("Cagny Sofa", 200, 1800, 1000, createdFurniturePT, 60));
            var createdWalsh = ProductFactory.AddProduct(ApiMsgHandler,
                                          GenerateProduct("Walsh Sofa", 3000, 2900, 1000, createdFurniturePT, 70));
            var createdAmani = ProductFactory.AddProduct(ApiMsgHandler,
                                          GenerateProduct("Amani Sofa", 1200, 999, 5000, createdFurniturePT, 55));
            var createdBurton = ProductFactory.AddProduct(ApiMsgHandler,
                                           GenerateProduct("Burton Sofa", 1500, 1350, 8000, createdFurniturePT,
                                                                   68));

            //create tables (Wooden, Plastic)
            var createdCangyWoodTbl = ProductFactory.AddProduct(ApiMsgHandler,
                                                 GenerateProduct("Cagny Wood Table", 500, 450, 1000,
                                                                         createdFurniturePT, 50));
            var createdCangyPlasticTbl = ProductFactory.AddProduct(ApiMsgHandler,
                                                    GenerateProduct("Amani Plastic Table", 250, 180, 9000,
                                                                            createdFurniturePT, 30));

            //create different kinds of shoes (Flats, Sandals, HighHeels)
            var createdFlats = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("Flats", 18, 15, 6500, createdShoePT, 10));
            ActivateVariations(ApiMsgHandler, createdFlats);
            var createdSandals = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("Sandals", 20, 15, 8000, createdShoePT, 2));
            ActivateVariations(ApiMsgHandler, createdSandals);
            var createdHighHeels = ProductFactory.AddProduct(ApiMsgHandler,
                                              GenerateProduct("HighHeels", 28, 25, 5500, createdShoePT, 5));
            ActivateVariations(ApiMsgHandler, createdHighHeels);

            //create different knids of hats (Cowboy, Baseball, Straw, Newsboys)
            var createdCowboy = ProductFactory.AddProduct(ApiMsgHandler,
                                           GenerateProduct("Cowboy Hat", 10, 8, 1200, createdHatPT, 2));
            var createdBaseball = ProductFactory.AddProduct(ApiMsgHandler,
                                             GenerateProduct("Baseball Hat", 18, 12, 8500, createdHatPT, 8));
            var createdStraw = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("Straw Hat", 18, 15, 7500, createdHatPT, 2));
            var createdNewsboy = ProductFactory.AddProduct(ApiMsgHandler,
                                            GenerateProduct("Newsboy Hat", 12, 8, 1100, createdHatPT, 10));
        }

        /// <summary>
        /// add 13 products to a site and associate with categories
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="masterCatalogId"></param>
        /// <param name="catalogId"></param>
        public static void PopulateProductsToCatalog(int tenantId, int masterCatalogId, int catalogId)
        {
            PopulateProductsToMasterCatalog(tenantId, masterCatalogId);
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId);

            var products = ProductFactory.GetProducts(ApiMsgHandler, filter: null, noCount: null, q: null, qLimit: null, startIndex: null, pageSize: 13, sortBy: "ProductSequence desc");
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId, catalogId: catalogId);
            // create categories

            //     cate1         cate2          cate3
            //     /   \            |         /   |   \
            //   c1_1  c1_2        3ps      c3_1 c3_2 c3_3
            //    |     |                   /  \       |   
            //   2ps    3ps            c3_1_1  c3_1_2  rest
            //                            |       |
            //                           2ps     1ps

            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("cate1"));
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("cate2"));
            var cate3 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("cate3"));

            var cate1_1 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                         Generator.GenerateCategory("c1_1", parentCategoryId: cate1.Id));
            var cate1_2 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                         Generator.GenerateCategory("c1_2", parentCategoryId: cate1.Id));

            var cate3_1 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                         Generator.GenerateCategory("c3_1", parentCategoryId: cate3.Id));
            var cate3_2 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                         Generator.GenerateCategory("c3_2", parentCategoryId: cate3.Id));
            var cate3_3 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                         Generator.GenerateCategory("c3_3", parentCategoryId: cate3.Id));

            var cate3_1_1 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                           Generator.GenerateCategory("c3_1_1",
                                                                                     parentCategoryId: cate3_1.Id));
            var cate3_1_2 = CategoryFactory.AddCategory(ApiMsgHandler,
                                                           Generator.GenerateCategory("c3_1_2",
                                                                                     parentCategoryId: cate3_1.Id));

            // Assoicate products with categories
            int i = 0;
            var proCate = new ProductCategory();
            foreach (var product in products.Items)
            {
                switch (i)
                {
                    case 0:
                    case 1:
                        proCate.CategoryId = cate1_1.Id.Value;
                        break;
                    case 2:
                    case 3:
                    case 4:
                        proCate.CategoryId = cate1_2.Id.Value;
                        break;
                    case 5:
                    case 6:
                    case 7:
                        proCate.CategoryId = cate2.Id.Value;
                        break;
                    case 8:
                    case 9:
                        proCate.CategoryId = cate3_1_1.Id.Value;
                        break;
                    case 10:
                        proCate.CategoryId = cate3_1_2.Id.Value;
                        break;
                    case 11:
                    case 12:
                        proCate.CategoryId = cate3_3.Id.Value;
                        break;
                }

                var proInfo = GenerateProductInCatalogInfo(catalogId, productCategories: new List<ProductCategory>() { proCate },
                                                            name: Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly),
                                                            price: Generator.RandomDecimal(20, 1000),
                                                            isActive: true,
                                                            isPriceOverridden: true,
                                                            isSeoContentOverridden: false,
                                                            isContentOverridden: true);

                ProductFactory.AddProductInCatalog(handler: ApiMsgHandler, productInCatalogInfoIn: proInfo, productCode: product.ProductCode);
                i++;
            }
        }

        public static void ActivateVariations(ServiceClientMessageHandler messageHandler,
                                              Product product)
        {
            var vars = ProductTypeVariationFactory.GenerateProductVariations(messageHandler, productOptionsIn: product.Options,
                                                        productTypeId: (int)product.ProductTypeId);
            foreach (var variation in vars.Items)
            {
                variation.IsActive = true;
                variation.DeltaPrice =
                    GenerateProductVariationDeltaPrice(Generator.RandomDecimal(0,
                                                                                       (decimal)
                                                                                       (product.Price.Price - 1)));
                variation.DeltaWeight = Generator.RandomDecimal(0, (decimal)(product.PackageWeight.Value - 1));
                ProductVariationFactory.UpdateProductVariation(messageHandler, productVariation: variation, productCode: product.ProductCode, variationKey:
                                                        variation.Variationkey);
            }
        }


        public static void PopulateProductsToSiteForDiscounts(int tenantId, int masterCatalogId, int catalogId)
        {
            PopulateProductsToSitegrp1(tenantId, masterCatalogId);
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId);

            var products = ProductFactory.GetProducts(ApiMsgHandler, filter: null, noCount: null, q: null, startIndex: null, qLimit: null, pageSize: 25, sortBy: "ProductSequence desc");

            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId, catalogId: catalogId);

            var living = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("Living"));
            var dining = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("Dining"));

            //associate products to categories
            int cateId = 0;
            ProductInCatalogInfo proInfo = null;
            foreach (var product in products.Items)
            {
                switch (product.ProductCode)
                {
                    case "artichoke-dining-lamp":
                        cateId = living.Id.Value;
                        break;
                    case "case-study-sofa-bed":
                        cateId = living.Id.Value;
                        break;
                    case "helix-coffee-table":
                        cateId = living.Id.Value;
                        break;
                    case "metropolitan-chair":
                        cateId = living.Id.Value;
                        break;
                    case "nelson-coconut-chair":
                        cateId = living.Id.Value;
                        break;
                    case "ph-floor-lamp":
                        cateId = living.Id.Value;
                        break;
                    case "raleigh-sofa":
                        cateId = living.Id.Value;
                        break;
                    case "skagen-coffee-table":
                        cateId = living.Id.Value;
                        break;
                    case "bantam-sofa":
                        cateId = living.Id.Value;
                        break;
                    case "tripod-lamp":
                        cateId = living.Id.Value;
                        break;
                    case "cellula-dining-chandelier":
                        cateId = dining.Id.Value;
                        break;
                    case "cherner-dining-table":
                        cateId = dining.Id.Value;
                        break;
                    case "lancaster-dining-table":
                        cateId = dining.Id.Value;
                        break;
                    case "lancaster-dining-chair":
                        cateId = dining.Id.Value;
                        break;
                    case "lancaster_barstool":
                        cateId = dining.Id.Value;
                        break;
                    case "eames-dining-chair":
                        cateId = dining.Id.Value;
                        break;
                    case "fucsia-dining-lamp":
                        cateId = dining.Id.Value;
                        break;
                    case "profile-dining-chair":
                        cateId = dining.Id.Value;
                        break;
                    case "bottega-dining-chair":
                        cateId = dining.Id.Value;
                        break;
                    case "lc6-dining-table":
                        cateId = dining.Id.Value;
                        break;
                }
                proInfo = GenerateProductInCatalogInfo(catalogId, cateId, true, true, false, true);
                ProductFactory.AddProductInCatalog(handler: ApiMsgHandler, productInCatalogInfoIn: proInfo, productCode: product.ProductCode);
            }
            var proInSite = ProductFactory.GetProductInCatalog(handler: ApiMsgHandler, productCode: "artichoke-dining-lamp", catalogId: catalogId, expectedCode: HttpStatusCode.OK);
            var prodCates = new List<ProductCategory>();
            prodCates.Add(proInSite.ProductCategories[0]);
            prodCates.Add(GenerateProductCategory(dining.Id.Value));
            proInfo = GenerateProductInCatalogInfo(catalogId: catalogId,
                                                     productCategories: prodCates,
                                                     name: proInSite.Content.ProductName,
                                                     price: proInSite.Price.Price,
                                                     isActive: proInSite.IsActive,
                                                     isContentOverridden: proInSite.IsContentOverridden,
                                                     isPriceOverridden: proInSite.IsPriceOverridden,
                                                     isSeoContentOverridden: proInSite.IsseoContentOverridden
                                                     );
            ProductFactory.UpdateProductInCatalog(handler: ApiMsgHandler,
                                        productInCatalogInfoIn: proInfo,
                                        productCode: "artichoke-dining-lamp",
                                        catalogId: catalogId, successCode:
                                        HttpStatusCode.OK);
        }


        public static void PopulateProductsToSitegrp1(int tenantId, int masterCatalogId)
        {
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId);
            var pts = ProductTypeFactory.GetProductTypes(handler: ApiMsgHandler, pageSize: null, sortBy: null, startIndex: null, filter: "Name eq Base");

            //create products using base producttype (10 for living room)
            var createdArtichokeLamp = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("artichoke-dining-lamp", "Artichoke Lamp", 10260, 9999, 30, Convert.ToDecimal(15), "in", 10, 10, 10, "", pts.Items[0].Id));
            var createdSofaBed = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("case-study-sofa-bed", "Case Study Sofa Bed", 1895, null, 50, Convert.ToDecimal(70), "in", 27, 80, 33, "", pts.Items[0].Id));
            var createdHelixTable = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("helix-coffee-table", "Helix Coffee Table", 2200, 2100, 50, Convert.ToDecimal(40), "in", 16, 53, 35, "", pts.Items[0].Id));
            var createdMetropolitanChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("metropolitan-chair", "Metropolitan Chair", 3550, null, 65, Convert.ToDecimal(68), "in", 38, 40, 33, "", pts.Items[0].Id));
            var createdNelsonChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("nelson-coconut-chair", "Nelson Coconut Chair", 1900, 1750, 90, Convert.ToDecimal(30), "in", 33, 34, 40, "", pts.Items[0].Id));
            var createdPHLamp = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("ph-floor-lamp", "PH Floor Lamp", 1596, null, 250, Convert.ToDecimal(15), "in", 51, 10, 13, "", pts.Items[0].Id));
            var createdRaleighSofa = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("raleigh-sofa", "Raleigh Sofa", 6630, null, 50, Convert.ToDecimal(70), "in", 34, 85, 35, "", pts.Items[0].Id));
            var createdSkagenTable = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("skagen-coffee-table", "Skagen Coffee Table", 1260, null, 200, Convert.ToDecimal(42), "in", 17, 50, 20, "", pts.Items[0].Id));
            var createdBantamSofa = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("bantam-sofa", "Bantam Sofa", 6630, null, 50, Convert.ToDecimal(70), "in", 32, 87, 36, "", pts.Items[0].Id));
            var createdTripodLamp = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("tripod-lamp", "Tripod Lamp", 395, null, 200, Convert.ToDecimal(35), "in", 68, 22, 22, "", pts.Items[0].Id));

            //create products using base producttype (10 for dining room)
            var createdCellulaChandelier = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("cellula-dining-chandelier", "Cellula Dining Chandelier", 5995, 5000, 25, Convert.ToDecimal(15), "in", 12, 36, 9, "", pts.Items[0].Id));
            var createdChernerTable = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("cherner-dining-table", "Cherner Dining Table", 135, 100, 200, Convert.ToDecimal(20), "in", 30, 72, 34, "", pts.Items[0].Id));
            var createdLancasterTable = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("lancaster-dining-table", "Lancaster Dining Table", 2245, null, 45, Convert.ToDecimal(57), "in", 30, 48, 48, "", pts.Items[0].Id));
            var createdLancasterChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("lancaster-dining-chair", "Lancaster Dining Chair", 575, null, 500, Convert.ToDecimal(18), "in", 30, 20, 18, "", pts.Items[0].Id));
            var createdLancasterStool = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("lancaster_barstool", "Lancaster Barstool", 650, null, 1000, Convert.ToDecimal(15), "in", 43, 22, 18, "", pts.Items[0].Id));
            var createdEamesChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("eames-dining-chair", "Eames Dining Chair", 160, 130, 900, Convert.ToDecimal(15), "in", 29, 22, 19, "", pts.Items[0].Id));
            var createdFucsiaLamp = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("fucsia-dining-lamp", "Fucsia Dining Lamp", 2545, null, 30, Convert.ToDecimal(15), "in", 13, 6, 3, "", pts.Items[0].Id));
            var createdProfileChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("profile-dining-chair", "Profile Dining Chair", 499, 399, 900, Convert.ToDecimal(15), "in", 30, 18, 20, "", pts.Items[0].Id));
            var createdBottegaChair = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("bottega-dining-chair", "Bottega Dining Chair", 865, null, 80, Convert.ToDecimal(20), "in", 37, 22, 24, "", pts.Items[0].Id));
            var createdLC6Table = ProductFactory.AddProduct(ApiMsgHandler, GenerateProduct("lc6-dining-table", "LC6 Dining Table", 2590, null, 45, Convert.ToDecimal(55), "in", 29, 89, 34, "", pts.Items[0].Id));
        }


        public static void RestoreQuantitiesForFurnitureProducts(ServiceClientMessageHandler handler)
        {
            Dictionary<string, int> products = new Dictionary<string, int>
                { { "artichoke-dining-lamp", 30 }, { "case-study-sofa-bed", 50 }, { "helix-coffee-table", 50 }, { "metropolitan-chair", 65 }, 
            { "nelson-coconut-chair", 90 }, { "ph-floor-lamp", 250 }, { "raleigh-sofa", 50 }, { "skagen-coffee-table", 200 }, { "bantam-sofa", 50 }, { "tripod-lamp", 200 }, { "cellula-dining-chandelier", 25 }, 
            { "cherner-dining-table", 200 }, { "lancaster-dining-table", 45 }, { "lancaster-dining-chair", 500 }, { "lancaster_barstool", 1000 }, { "eames-dining-chair", 900 }, { "fucsia-dining-lamp", 30 }, 
            { "profile-dining-chair", 900 }, { "bottega-dining-chair", 80 }, { "lc6-dining-table", 45 } };

        }


        public static void RestoreQuantitiesForOldSiteProducts(ServiceClientMessageHandler handler)
        {
            Dictionary<string, int> products = new Dictionary<string, int>
                { { "Cagny Sofa", 100 }, { "Walsh Sofa", 10 }, { "Amani Sofa", 50 }, { "Burton Sofa", 80 }, { "Cagny Wood Table" , 100 }, 
            { "Amani Plastic Table", 90 }, { "Flats", 65 }, { "Sandals", 80 }, { "HighHeels", 55 }, { "Cowboy Hat", 120 }, { "Baseball Hat", 85 }, { "Straw Hat", 75 }, { "Newsboy Hat", 110 } };

        }


        public static void RestoreProductPrice(ServiceClientMessageHandler handler, string productCode, decimal price, decimal? saleprice = null)
        {
            var getProduct = ProductFactory.GetProduct(handler, productCode);
            getProduct.Price.Price = price;
            getProduct.Price.SalePrice = saleprice;
            var updateProduct = ProductFactory.UpdateProduct(handler, product: getProduct, productCode: getProduct.ProductCode);
        }

        #endregion
        public enum CarrierType
        {
            custom,
            fedex,
            ups,
            usps,
            invalidcarrier
        }
    }
    public class AuthorizeDotNetCreditCard
    {
        private string CardNumber { get; set; }
        public string SavePart { get; private set; }
        public string SendPart { get; private set; }

        public AuthorizeDotNetCreditCard(string type = null)
        {
            CardNumber = AuthorizeNet_CreditCard(type);
            SavePart = CardNumber.Remove(12) + "****";
            SendPart = "************" + CardNumber.Remove(0, 12);
        }


        //used for testing authorize.net --> for error case, type = null
        private static string AuthorizeNet_CreditCard(string type)
        {
            string cardId = null;
            switch (type)
            {
                case "American Express":
                    {
                        cardId = "370000000000002";
                        break;
                    }
                case "Visa":
                    {
                        //cardId = "4007000000027";
                        cardId = "4111111111111111";
                        break;
                    }
                case "MasterCard":
                    {
                        cardId = "5424000000000015";
                        break;
                    }
                case "Discover":
                    {
                        cardId = "6011000000000012";
                        break;
                    }
                default:
                    {
                        cardId = "4222222222222";
                        //cardType = "Visa";
                        break;
                    }
            }
            return (cardId);
        }
    }
}