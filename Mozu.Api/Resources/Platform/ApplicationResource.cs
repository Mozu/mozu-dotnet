
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

namespace Mozu.Api.Resources.Platform
{
	/// <summary>
	/// Use the Developer resource to view and update information and files related to application packages.
	/// </summary>
	public partial class ApplicationResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public ApplicationResource() 
		{
			_apiContext = null;
		}
		 public ApplicationResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public ApplicationResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ApplicationResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.PackageNamesCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var packageNamesCollection = await application.GetAppPackageNamesAsync( applicationKey,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.PackageNamesCollection> GetAppPackageNamesAsync(string applicationKey, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.PackageNamesCollection> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.GetAppPackageNamesClient( applicationKey,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="nsAndAppId">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.ApplicationVersionsCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var applicationVersionsCollection = await application.GetAppVersionsAsync( nsAndAppId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.ApplicationVersionsCollection> GetAppVersionsAsync(string nsAndAppId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.ApplicationVersionsCollection> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.GetAppVersionsClient( nsAndAppId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="filepath">Represents the file name and location.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.FileMetadata"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var fileMetadata = await application.GetPackageFileMetadataAsync( applicationKey,  filepath,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.FileMetadata> GetPackageFileMetadataAsync(string applicationKey, string filepath, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.FileMetadata> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.GetPackageFileMetadataClient( applicationKey,  filepath,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.FolderMetadata"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var folderMetadata = await application.GetPackageMetadataAsync( applicationKey,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.FolderMetadata> GetPackageMetadataAsync(string applicationKey, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.FolderMetadata> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.GetPackageMetadataClient( applicationKey,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="filepath">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="lastModifiedTime">The date and time of the last file insert or update. This parameter is optional.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.FileMetadata"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var fileMetadata = await application.UpsertPackageFileAsync( applicationKey,  filepath,  lastModifiedTime,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.FileMetadata> UpsertPackageFileAsync(string applicationKey, string filepath, string lastModifiedTime =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.FileMetadata> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.UpsertPackageFileClient( applicationKey,  filepath,  lastModifiedTime,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="renameInfo">Information required to update the name of a file in a package, which consists of the original name and the new name.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AppDev.FileMetadata"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var fileMetadata = await application.RenamePackageFileAsync( renameInfo,  applicationKey,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AppDev.FileMetadata> RenamePackageFileAsync(Mozu.Api.Contracts.AppDev.RenameInfo renameInfo, string applicationKey, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AppDev.FileMetadata> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.RenamePackageFileClient( renameInfo,  applicationKey,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationKey">The application key uniquely identifies the developer namespace, application ID, version, and package in Dev Center. The format is {Dev Account namespace}.{Application ID}.{Application Version}.{Package name}.</param>
		/// <param name="filepath">Represents the file name and location.</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var application = new Application();
		///   var stream = await application.DeletePackageFileAsync( applicationKey,  filepath);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeletePackageFileAsync(string applicationKey, string filepath, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.ApplicationClient.DeletePackageFileClient( applicationKey,  filepath);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


