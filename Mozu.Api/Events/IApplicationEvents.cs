
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
	public interface IApplicationEvents
	{
		[Obsolete("This method is obsolete; use the async method instead")]
		void Disabled(IApiContext apiContext, Event eventPayLoad);

		Task DisabledAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Enabled(IApiContext apiContext, Event eventPayLoad);

		Task EnabledAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Installed(IApiContext apiContext, Event eventPayLoad);

		Task InstalledAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Uninstalled(IApiContext apiContext, Event eventPayLoad);

		Task UninstalledAsync(IApiContext apiContext, Event eventPayLoad);

		[Obsolete("This method is obsolete; use the async method instead")]
		void Upgraded(IApiContext apiContext, Event eventPayLoad);

		Task UpgradedAsync(IApiContext apiContext, Event eventPayLoad);

	}

}