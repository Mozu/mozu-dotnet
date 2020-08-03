
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


namespace Mozu.Api.Contracts.InstalledApplications
{
		///
		///	Properties of an app installed in a tenant.
		///
		public class Application
		{
			///
			///Unique identifier of an app available in your  tenant or within  Dev Center. This ID is unique across all apps installed, initialized, and enabled in the  and those in development through the Dev Center Console.
			///
			public string AppId { get; set; }

			///
			///Unique identifier of an app or theme available in your  tenant or within  Dev Center. An appKey is composed of Developer Account namespace, app/theme ID, version, and package (e.g., devAccount.helloWorld.1.0.0.Release). 
			///
			public string AppKey { get; set; }

			///
			///List of capabilities installed in a tenant.
			///
			public List<Capability> Capabilities { get; set; }

			///
			///Indicates if a capability, function tied to an Arc.js action, application, or price list is enabled for the tenant/site. If true, the capability/application/function/price list is enabled for the tenant. System-supplied and read-only with the exception of functions tied to an Arc.js action and price lists.
			///
			public bool? Enabled { get; set; }

			///
			///Indicates if an app is initialized and capable of being enabled in the tenant and site. Apps will need to be installed and configured to become initialized, such as validating credentials and/or API keys with a third-party service. If true, the app is initialized and can be enabled for usage.
			///
			public bool? Initialized { get; set; }

			///
			///Indicates if the installed application is of type extension. An extension is an application that extends upon the  infrastructure. Examples of extensions include Arc.js applications and applications that integrate third-party services.
			///
			public bool? IsExtension { get; set; }

			///
			///Indicates if an Arc.js application is certified to run on tenants that lack a full installation of the Arc.js framework.
			///
			public bool? IsExtensionCertified { get; set; }

			///
			///The URL defined for the application that represents the configuration website for the capability. This value is used by installed applications or the site.
			///
			public string UiConfigurationUrl { get; set; }

		}

}