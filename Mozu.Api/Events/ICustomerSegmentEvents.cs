
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Event;


namespace Mozu.Api.Events
{
	public interface ICustomerSegmentEvents
	{
		[Obsolete("This method is obsolete; use the async method instead")]
		void Created(IApiContext apiContext, Event eventPayLoad);

		Task CreatedAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void CustomerAdded(IApiContext apiContext, Event eventPayLoad);

		Task CustomerAddedAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void CustomerRemoved(IApiContext apiContext, Event eventPayLoad);

		Task CustomerRemovedAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Deleted(IApiContext apiContext, Event eventPayLoad);

		Task DeletedAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Updated(IApiContext apiContext, Event eventPayLoad);

		Task UpdatedAsync(IApiContext apiContext, Event eventPayLoad);

	}

}