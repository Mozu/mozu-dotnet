
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

namespace Mozu.Api.Clients.Platform
{
	/// <summary>
	/// Use the user data subresource to store user-level data required for a third-party application in the  database.
	/// </summary>
	public partial class UserDataClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{string}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDBValue( dbEntryQuery,  responseFields);
		///   var stringClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<string> GetDBValueClient(string dbEntryQuery, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.UserDataUrl.GetDBValueUrl(dbEntryQuery, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<string>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateDBValue( value,  dbEntryQuery);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> CreateDBValueClient(string value, string dbEntryQuery)
		{
			var url = Mozu.Api.Urls.Platform.UserDataUrl.CreateDBValueUrl(dbEntryQuery);
			const string verb = "POST";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(value);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <param name="value">The value string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateDBValue( value,  dbEntryQuery);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> UpdateDBValueClient(string value, string dbEntryQuery)
		{
			var url = Mozu.Api.Urls.Platform.UserDataUrl.UpdateDBValueUrl(dbEntryQuery);
			const string verb = "PUT";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(value);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbEntryQuery">The database entry string to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteDBValue( dbEntryQuery);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteDBValueClient(string dbEntryQuery)
		{
			var url = Mozu.Api.Urls.Platform.UserDataUrl.DeleteDBValueUrl(dbEntryQuery);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}


