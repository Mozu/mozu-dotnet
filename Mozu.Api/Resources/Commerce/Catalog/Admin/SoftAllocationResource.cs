
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin
{
	/// <summary>
	/// 
	/// </summary>
	public partial class SoftAllocationResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public SoftAllocationResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public SoftAllocationResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new SoftAllocationResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="responseFields"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.SoftAllocationCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var softAllocationCollection = await softallocation.GetSoftAllocationsAsync( startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.SoftAllocationCollection> GetSoftAllocationsAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.SoftAllocationCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.GetSoftAllocationsClient( startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="softAllocationId"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.SoftAllocation"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var softAllocation = await softallocation.GetSoftAllocationAsync( softAllocationId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.SoftAllocation> GetSoftAllocationAsync(int softAllocationId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.SoftAllocation> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.GetSoftAllocationClient( softAllocationId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="softAllocationsIn"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.ProductAdmin.SoftAllocation"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var softAllocation = await softallocation.AddSoftAllocationsAsync( softAllocationsIn);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> AddSoftAllocationsAsync(List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation> softAllocationsIn, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.AddSoftAllocationsClient( softAllocationsIn);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="softAllocations"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.ProductAdmin.ProductReservation"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var productReservation = await softallocation.ConvertToProductReservationAsync( softAllocations);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.ProductAdmin.ProductReservation>> ConvertToProductReservationAsync(List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation> softAllocations, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.ProductAdmin.ProductReservation>> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.ConvertToProductReservationClient( softAllocations);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="softAllocationRenew"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.ProductAdmin.SoftAllocation"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var softAllocation = await softallocation.RenewSoftAllocationsAsync( softAllocationRenew);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> RenewSoftAllocationsAsync(Mozu.Api.Contracts.ProductAdmin.SoftAllocationRenew softAllocationRenew, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.RenewSoftAllocationsClient( softAllocationRenew);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <param name="softAllocations"></param>
		/// <returns>
		/// List{<see cref="Mozu.Api.Contracts.ProductAdmin.SoftAllocation"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var softAllocation = await softallocation.UpdateSoftAllocationsAsync( softAllocations);
		/// </code>
		/// </example>
		public virtual async Task<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> UpdateSoftAllocationsAsync(List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation> softAllocations, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.ProductAdmin.SoftAllocation>> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.UpdateSoftAllocationsClient( softAllocations);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="softAllocationId"></param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var softallocation = new SoftAllocation();
		///   var stream = await softallocation.DeleteSoftAllocationAsync( softAllocationId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteSoftAllocationAsync(int softAllocationId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.SoftAllocationClient.DeleteSoftAllocationClient( softAllocationId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


