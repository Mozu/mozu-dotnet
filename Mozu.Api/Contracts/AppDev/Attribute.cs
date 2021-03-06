
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
		///	Properties of an attribute used to describe customers or orders.
		///
		public class Attribute
		{
			///
			///The administrator name associated with the object/data.
			///
			public string AdminName { get; set; }

			///
			///Mozu.AppDev.Contracts.Attribute applicationAttributeId ApiTypeMember DOCUMENT_HERE 
			///
			public int ApplicationAttributeId { get; set; }

			///
			///Mozu.AppDev.Contracts.Attribute attributeId ApiTypeMember DOCUMENT_HERE 
			///
			public int AttributeId { get; set; }

			///
			///Mozu.AppDev.Contracts.Attribute code ApiTypeMember DOCUMENT_HERE 
			///
			public string Code { get; set; }

			///
			///The FQN of the option to which this image group belongs.  Should match the fqn of the option that has a true value for isProductImageGroupSelector.
			///
			public string Fqn { get; set; }

			///
			///The type of input selection used to define a value for the attribute, including Yes/No, Date, DateTime, List, TextBox, or TextArea.
			///
			public string InputType { get; set; }

			///
			///The user supplied name that appears in . You can use this field for identification purposes.
			///
			public string Name { get; set; }

			///
			///The numeric order of objects, used by a vocabulary value defined for an extensible attribute, images, and categories.
			///
			public int Sequence { get; set; }

			///
			///Mozu.AppDev.Contracts.Attribute type ApiTypeMember DOCUMENT_HERE 
			///
			public string Type { get; set; }

			///
			///Mozu.AppDev.Contracts.Attribute vocabularyJson ApiTypeMember DOCUMENT_HERE 
			///
			public string VocabularyJson { get; set; }

			///
			///List of valid vocabulary values defined for an attribute.
			///
			public string VocabularyValues { get; set; }

		}

}