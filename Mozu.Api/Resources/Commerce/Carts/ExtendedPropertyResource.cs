
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

namespace Mozu.Api.Resources.Commerce.Carts
{
	/// <summary>
	/// Use the Cart Extended Properties subresource to store an arbitrary number of cart extended properties such as tracking strings, marketing sources, affiliates, sales personnel/data, and so on, on a per cart basis. Each cart may have none, one, or more than one entry in the extended properties collection, and all values in the extended properties collection are represented as strings. When you create an order from a cart, all extended properties are retained from the cart and copied to the order. Refer to the subresource for more information about order extended properties.
	/// </summary>
	public partial class ExtendedPropertyResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public ExtendedPropertyResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public ExtendedPropertyResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ExtendedPropertyResource(_apiContext.CloneWith(contextModification));
		}

				
		/// <summary>
		/// Retrieves a list of cart extended properties specified in the request.
		/// </summary>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = extendedproperty.GetExtendedProperties();
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> GetExtendedProperties()
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.GetExtendedPropertiesClient();
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves a list of cart extended properties specified in the request.
		/// </summary>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = await extendedproperty.GetExtendedPropertiesAsync();
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> GetExtendedPropertiesAsync()
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.GetExtendedPropertiesClient();
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Adds one or more specified extended properties to the carts extended properties collection.
		/// </summary>
		/// <param name="extendedProperties">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = extendedproperty.AddExtendedProperties( extendedProperties);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> AddExtendedProperties(List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> extendedProperties)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.AddExtendedPropertiesClient( extendedProperties);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Adds one or more specified extended properties to the carts extended properties collection.
		/// </summary>
		/// <param name="extendedProperties">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = await extendedproperty.AddExtendedPropertiesAsync( extendedProperties);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> AddExtendedPropertiesAsync(List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> extendedProperties)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.AddExtendedPropertiesClient( extendedProperties);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Updates one or more details of the extended property specified in the request.
		/// </summary>
		/// <param name="key">Key used for metadata defined for objects, including extensible attributes, custom attributes associated with a shipping provider, and search synonyms definitions. This content may be user-defined depending on the object and usage.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. For example, ) returns only the  and  items inside the  array of the specified product.This paramter should only be used to retrieve data. Attempting to update data using this parmater may cause data loss.</param>
		/// <param name="upsert">Any set of key value pairs to be stored in the extended properties of a cart.</param>
		/// <param name="extendedProperty">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = extendedproperty.UpdateExtendedProperty( extendedProperty,  key,  upsert,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty UpdateExtendedProperty(Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty extendedProperty, string key, bool? upsert =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.UpdateExtendedPropertyClient( extendedProperty,  key,  upsert,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Updates one or more details of the extended property specified in the request.
		/// </summary>
		/// <param name="key">Key used for metadata defined for objects, including extensible attributes, custom attributes associated with a shipping provider, and search synonyms definitions. This content may be user-defined depending on the object and usage.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. For example, ) returns only the  and  items inside the  array of the specified product.This paramter should only be used to retrieve data. Attempting to update data using this parmater may cause data loss.</param>
		/// <param name="upsert">Any set of key value pairs to be stored in the extended properties of a cart.</param>
		/// <param name="extendedProperty">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = await extendedproperty.UpdateExtendedPropertyAsync( extendedProperty,  key,  upsert,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> UpdateExtendedPropertyAsync(Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty extendedProperty, string key, bool? upsert =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.UpdateExtendedPropertyClient( extendedProperty,  key,  upsert,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Updates one or more details of the extended properties specified in the request.
		/// </summary>
		/// <param name="upsert">Any set of key value pairs to be stored in the extended properties of a cart.</param>
		/// <param name="extendedProperties">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = extendedproperty.UpdateExtendedProperties( extendedProperties,  upsert);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> UpdateExtendedProperties(List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> extendedProperties, bool? upsert =  null)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.UpdateExtendedPropertiesClient( extendedProperties,  upsert);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Updates one or more details of the extended properties specified in the request.
		/// </summary>
		/// <param name="upsert">Any set of key value pairs to be stored in the extended properties of a cart.</param>
		/// <param name="extendedProperties">Mozu.CommerceRuntime.Contracts.Commerce.ExtendedProperty ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   var extendedProperty = await extendedproperty.UpdateExtendedPropertiesAsync( extendedProperties,  upsert);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> UpdateExtendedPropertiesAsync(List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty> extendedProperties, bool? upsert =  null)
		{
			MozuClient<List<Mozu.Api.Contracts.CommerceRuntime.Commerce.ExtendedProperty>> response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.UpdateExtendedPropertiesClient( extendedProperties,  upsert);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Deletes the extended properties cart extended properties collection.
		/// </summary>
		/// <param name="keys"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   extendedproperty.DeleteExtendedProperties( keys);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void DeleteExtendedProperties(List<string> keys)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.DeleteExtendedPropertiesClient( keys);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Deletes the extended properties cart extended properties collection.
		/// </summary>
		/// <param name="keys"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   await extendedproperty.DeleteExtendedPropertiesAsync( keys);
		/// </code>
		/// </example>
		public virtual async Task DeleteExtendedPropertiesAsync(List<string> keys)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.DeleteExtendedPropertiesClient( keys);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}

		/// <summary>
		/// Deletes a specific extended property from the cart extended property collection.
		/// </summary>
		/// <param name="key"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   extendedproperty.DeleteExtendedProperty( key);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void DeleteExtendedProperty(string key)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.DeleteExtendedPropertyClient( key);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Deletes a specific extended property from the cart extended property collection.
		/// </summary>
		/// <param name="key"></param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var extendedproperty = new ExtendedProperty();
		///   await extendedproperty.DeleteExtendedPropertyAsync( key);
		/// </code>
		/// </example>
		public virtual async Task DeleteExtendedPropertyAsync(string key)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Carts.ExtendedPropertyClient.DeleteExtendedPropertyClient( key);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}


	}

}


