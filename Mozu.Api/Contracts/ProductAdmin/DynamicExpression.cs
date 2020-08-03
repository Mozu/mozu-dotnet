
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	The expression that controls the product membership of the dynamic category. This field is only applicable when the categoryType is set to either "DynamicPreComputed" or "DynamicRealTime".Refer to [Dynamic Category Expressions](../../../developer/api-guides/dynamic-category-exp.htm) for more information about writing dynamic expressions using the  API.
		///
		public class DynamicExpression
		{
			///
			///The text view of the dynamic  expression. For example, instead of writing a structure JSON object, you can write a simple string as the dynamic expression.
			///
			public string Text { get; set; }

			///
			///The tree view of the dynamic expression. This is a structure JSON object that gives you greater control and flexibility over the text view when writing the dynamic  expression.
			///
			public Expression Tree { get; set; }

		}

}