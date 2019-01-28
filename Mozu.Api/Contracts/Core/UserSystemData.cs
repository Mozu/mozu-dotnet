
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.Core
{
		///
		///	System-supplied and read-only information about the user.
		///
		public class UserSystemData
		{
			public DateTime? CreatedOn { get; set; }

			public byte FailedLoginAttemptCount { get; set; }

			public DateTime? FirstFailedLoginAttemptOn { get; set; }

			public bool IsLocked { get; set; }

			public bool IsPasswordChangeRequired { get; set; }

			public DateTime? LastLockedOn { get; set; }

			public DateTime? LastLoginOn { get; set; }

			public DateTime? LastPasswordChangeOn { get; set; }

			public int RemainingLoginAttempts { get; set; }

			public DateTime? UpdatedOn { get; set; }

		}

}