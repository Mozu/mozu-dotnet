
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.Customer
{
		///
		///	The information required to modify a shopper account password.
		///
		public class PasswordInfo
		{
			///
			///If you are importing existing customer accounts to  or using two customer systems simultaneously, you use this property to store an external password hash that helps you migrate existing customer accounts seamlessly into , without having to require shoppers to create new passwords for the platform.  If you set this property, you must use the [embedded.verifyExternalPassword](https://www.mozu.com/docs/arcjs/commerce-customer/actions/verifyexternalpassword.htm) action to verify that the hashed version of a cleartext password provided by a shopper matches the external password hash specified in this property.
			///
			public string ExternalPassword { get; set; }

			///
			///The new password entered and saved by the user of the account. 
			///
			public string NewPassword { get; set; }

			///
			///The previous shopper account password value.
			///
			public string OldPassword { get; set; }

		}

}