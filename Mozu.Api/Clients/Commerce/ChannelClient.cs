
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

namespace Mozu.Api.Clients.Commerce
{
	/// <summary>
	/// Use the Channels resource to manage the channels a company uses to create logical commercial business divisions based on region or types of sales, such as "US Online," "Amazon," or "EMEA Retail." All orders include a channel association that enables the company to perform financial reporting for each defined channel. Because channels are managed at the tenant level, you must associate all the tenant's sites with a channel. Sites that do not have a defined channel association cannot successfully submit orders.
	/// </summary>
	public partial class ChannelClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Channels.ChannelCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetChannels( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		///   var channelCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.ChannelCollection> GetChannelsClient(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.ChannelUrl.GetChannelsUrl(startIndex, pageSize, sortBy, filter, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.ChannelCollection>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code that identifies the channel to retrieve.</param>
		/// <param name="responseFields"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Channels.Channel"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetChannel( code,  responseFields);
		///   var channelClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel> GetChannelClient(string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.ChannelUrl.GetChannelUrl(code, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="channel">Properties of the channel to create.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Channels.Channel"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateChannel( channel,  responseFields);
		///   var channelClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel> CreateChannelClient(Mozu.Api.Contracts.CommerceRuntime.Channels.Channel channel, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.ChannelUrl.CreateChannelUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel>(channel);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code that identifies the channel to update.</param>
		/// <param name="responseFields"></param>
		/// <param name="channel">Properties of a the channel to update.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.CommerceRuntime.Channels.Channel"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateChannel( channel,  code,  responseFields);
		///   var channelClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel> UpdateChannelClient(Mozu.Api.Contracts.CommerceRuntime.Channels.Channel channel, string code, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.ChannelUrl.UpdateChannelUrl(code, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.CommerceRuntime.Channels.Channel>(channel);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">User-defined code that identifies the channel to delete.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteChannel( code);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteChannelClient(string code)
		{
			var url = Mozu.Api.Urls.Commerce.ChannelUrl.DeleteChannelUrl(code);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}


