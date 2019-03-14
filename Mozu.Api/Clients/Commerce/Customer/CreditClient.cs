
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Mozu.Api.Clients.Commerce.Customer
{
	/// <summary>
	/// Use the Customer Credits resource to manage the store credit associated with a customer account. Store credit can represent a static amount the customer can redeem at any of the tenant's sites, or a gift card registered for a customer account. At this time, gift card functionality is reserved for future use.
	/// </summary>
	public partial class CreditClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.Credit.CreditCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCredits( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var creditCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.Credit.CreditCollection> GetCreditsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.GetCreditsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.Credit.CreditCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code that identifies the store credit to retrieve.</param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.Credit.Credit"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetCredit( code,  responseFields);
		///   var creditClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit> GetCreditClient(string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.GetCreditUrl(code, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <param name="credit">Properties of the store credit to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.Credit.Credit"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AddCredit( credit,  userId,  responseFields);
		///   var creditClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit> AddCreditClient(Mozu.Api.Contracts.Customer.Credit.Credit credit, string userId =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.AddCreditUrl(userId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.Credit.Credit>(credit);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">The code that represents the credit to claim for the shopper.</param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.Credit.Credit"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AssociateCreditToShopper( code,  responseFields);
		///   var creditClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit> AssociateCreditToShopperClient(string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.AssociateCreditToShopperUrl(code, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code"></param>
		/// <param name="userId"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ResendCreditCreatedEmail( code,  userId);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient ResendCreditCreatedEmailClient(string code, string userId =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.ResendCreditCreatedEmailUrl(code, userId);
			const string verb = "PUT";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code of the store credit to update.</param>
		/// <param name="responseFields"></param>
		/// <param name="credit">Properties of the store credit to update.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.Credit.Credit"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateCredit( credit,  code,  responseFields);
		///   var creditClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit> UpdateCreditClient(Mozu.Api.Contracts.Customer.Credit.Credit credit, string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.UpdateCreditUrl(code, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.Credit.Credit>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.Credit.Credit>(credit);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code of the store credit to delete.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteCredit( code);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteCreditClient(string code)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.CreditUrl.DeleteCreditUrl(code);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}


