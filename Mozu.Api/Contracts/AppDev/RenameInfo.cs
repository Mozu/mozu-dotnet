
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.AppDev
{
		///
		///	Information required to update the name of a file in a package, which consists of the original name and the new name.
		///
		public class RenameInfo
		{
			///
			///The destination file location and file name to specify.
			///
			public string NewFullPath { get; set; }

			///
			///The original file location and file name.
			///
			public string OldFullPath { get; set; }

		}

}