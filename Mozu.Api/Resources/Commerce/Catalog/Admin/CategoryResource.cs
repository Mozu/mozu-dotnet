
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

namespace Mozu.Api.Resources.Commerce.Catalog.Admin
{
	/// <summary>
	/// Use the Categories resource to organize products and control where they appear on the storefront. Create and maintain a hierarchy of categories and subcategories where the site will store properties.
	/// </summary>
	public partial class CategoryResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		private readonly DataViewMode _dataViewMode;
		
		public CategoryResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
			_dataViewMode = DataViewMode.Live;
		}

		public CategoryResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CategoryResource(_apiContext.CloneWith(contextModification), _dataViewMode);
		}

		public CategoryResource(IApiContext apiContext, DataViewMode dataViewMode) 
		{
			_apiContext = apiContext;
			_dataViewMode = dataViewMode;
		}
				
		/// <summary>
		/// Retrieves a list of categories according to any specified filter criteria and sort options.
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">The number of results to display on each page when creating paged results from a query. The maximum value is 200.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var categoryPagedCollection = category.GetCategories(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection GetCategories(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetCategoriesClient(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves a list of categories according to any specified filter criteria and sort options.
		/// </summary>
		/// <param name="filter">A set of filter expressions representing the search parameters for a query. This parameter is optional. Refer to [Sorting and Filtering](../../../../Developer/applications/sorting-filtering.htm) for a list of supported filters.</param>
		/// <param name="pageSize">The number of results to display on each page when creating paged results from a query. The maximum value is 200.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var categoryPagedCollection = await category.GetCategoriesAsync(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection> GetCategoriesAsync(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CategoryPagedCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetCategoriesClient(_dataViewMode,  startIndex,  pageSize,  sortBy,  filter,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves the list of subcategories within a category.
		/// </summary>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CategoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var categoryCollection = category.GetChildCategories( categoryId,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.CategoryCollection GetChildCategories(int categoryId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CategoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetChildCategoriesClient( categoryId,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves the list of subcategories within a category.
		/// </summary>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.CategoryCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var categoryCollection = await category.GetChildCategoriesAsync( categoryId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.CategoryCollection> GetChildCategoriesAsync(int categoryId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.CategoryCollection> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetChildCategoriesClient( categoryId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Retrieves the details of a single category.
		/// </summary>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = category.GetCategory(_dataViewMode,  categoryId,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.Category GetCategory(int categoryId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetCategoryClient(_dataViewMode,  categoryId,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Retrieves the details of a single category.
		/// </summary>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = await category.GetCategoryAsync(_dataViewMode,  categoryId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Category> GetCategoryAsync(int categoryId, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.GetCategoryClient(_dataViewMode,  categoryId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Adds a new category to the site's category hierarchy. Specify a ParentCategoryID to determine where to place the category in the hierarchy. If no ParentCategoryID is specified, the new category is a top-level category.
		/// </summary>
		/// <param name="incrementSequence">If true, when adding a new product category, set the sequence number of the new category to an increment of one integer greater than the maximum available sequence number across all product categories. If false, set the sequence number to zero.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="useProvidedId"></param>
		/// <param name="category">A descriptive container that groups products. A category is merchant defined with associated products and discounts as configured. GThe storefront displays products in a hierarchy of categories. As such, categories can include a nesting of sub-categories to organize products and product options per set guidelines such as color, brand, material, and size.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = category.AddCategory( category,  incrementSequence,  useProvidedId,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.Category AddCategory(Mozu.Api.Contracts.ProductAdmin.Category category, bool? incrementSequence =  null, bool? useProvidedId =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.AddCategoryClient( category,  incrementSequence,  useProvidedId,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Adds a new category to the site's category hierarchy. Specify a ParentCategoryID to determine where to place the category in the hierarchy. If no ParentCategoryID is specified, the new category is a top-level category.
		/// </summary>
		/// <param name="incrementSequence">If true, when adding a new product category, set the sequence number of the new category to an increment of one integer greater than the maximum available sequence number across all product categories. If false, set the sequence number to zero.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="useProvidedId"></param>
		/// <param name="category">A descriptive container that groups products. A category is merchant defined with associated products and discounts as configured. GThe storefront displays products in a hierarchy of categories. As such, categories can include a nesting of sub-categories to organize products and product options per set guidelines such as color, brand, material, and size.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = await category.AddCategoryAsync( category,  incrementSequence,  useProvidedId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Category> AddCategoryAsync(Mozu.Api.Contracts.ProductAdmin.Category category, bool? incrementSequence =  null, bool? useProvidedId =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.AddCategoryClient( category,  incrementSequence,  useProvidedId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Validates the precomputed dynamic category expression.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dynamicExpressionIn">Mozu.ProductAdmin.Contracts.DynamicExpression ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DynamicExpression"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var dynamicExpression = category.ValidateDynamicExpression( dynamicExpressionIn,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.DynamicExpression ValidateDynamicExpression(Mozu.Api.Contracts.ProductAdmin.DynamicExpression dynamicExpressionIn, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.ValidateDynamicExpressionClient( dynamicExpressionIn,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Validates the precomputed dynamic category expression.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dynamicExpressionIn">Mozu.ProductAdmin.Contracts.DynamicExpression ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DynamicExpression"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var dynamicExpression = await category.ValidateDynamicExpressionAsync( dynamicExpressionIn,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> ValidateDynamicExpressionAsync(Mozu.Api.Contracts.ProductAdmin.DynamicExpression dynamicExpressionIn, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.ValidateDynamicExpressionClient( dynamicExpressionIn,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Validates the realtime dynamic expression.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dynamicExpressionIn">Mozu.ProductAdmin.Contracts.DynamicExpression ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DynamicExpression"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var dynamicExpression = category.ValidateRealTimeDynamicExpression( dynamicExpressionIn,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.DynamicExpression ValidateRealTimeDynamicExpression(Mozu.Api.Contracts.ProductAdmin.DynamicExpression dynamicExpressionIn, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.ValidateRealTimeDynamicExpressionClient( dynamicExpressionIn,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Validates the realtime dynamic expression.
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dynamicExpressionIn">Mozu.ProductAdmin.Contracts.DynamicExpression ApiType DOCUMENT_HERE </param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.DynamicExpression"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var dynamicExpression = await category.ValidateRealTimeDynamicExpressionAsync( dynamicExpressionIn,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> ValidateRealTimeDynamicExpressionAsync(Mozu.Api.Contracts.ProductAdmin.DynamicExpression dynamicExpressionIn, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.DynamicExpression> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.ValidateRealTimeDynamicExpressionClient( dynamicExpressionIn,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Update the properties of a defined category or move it to another location in the category hierarchy. Because this operation replaces the defined resource,include all the information to maintain for the category in the request.
		/// </summary>
		/// <param name="cascadeVisibility">If true, when changing the display option for the category, change it for all subcategories also. The default value is false.</param>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="category">A descriptive container that groups products. A category is merchant defined with associated products and discounts as configured. GThe storefront displays products in a hierarchy of categories. As such, categories can include a nesting of sub-categories to organize products and product options per set guidelines such as color, brand, material, and size.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = category.UpdateCategory( category,  categoryId,  cascadeVisibility,  responseFields);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual Mozu.Api.Contracts.ProductAdmin.Category UpdateCategory(Mozu.Api.Contracts.ProductAdmin.Category category, int categoryId, bool? cascadeVisibility =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.UpdateCategoryClient( category,  categoryId,  cascadeVisibility,  responseFields);
			client.WithContext(_apiContext);
			response = client.Execute();
			return response.Result();

		}

		/// <summary>
		/// Update the properties of a defined category or move it to another location in the category hierarchy. Because this operation replaces the defined resource,include all the information to maintain for the category in the request.
		/// </summary>
		/// <param name="cascadeVisibility">If true, when changing the display option for the category, change it for all subcategories also. The default value is false.</param>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <param name="category">A descriptive container that groups products. A category is merchant defined with associated products and discounts as configured. GThe storefront displays products in a hierarchy of categories. As such, categories can include a nesting of sub-categories to organize products and product options per set guidelines such as color, brand, material, and size.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ProductAdmin.Category"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   var category = await category.UpdateCategoryAsync( category,  categoryId,  cascadeVisibility,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ProductAdmin.Category> UpdateCategoryAsync(Mozu.Api.Contracts.ProductAdmin.Category category, int categoryId, bool? cascadeVisibility =  null, string responseFields =  null)
		{
			MozuClient<Mozu.Api.Contracts.ProductAdmin.Category> response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.UpdateCategoryClient( category,  categoryId,  cascadeVisibility,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();
			return await response.ResultAsync();

		}

		/// <summary>
		/// Deletes the category specified by its category ID.
		/// </summary>
		/// <param name="cascadeDelete">Specifies whether to also delete all subcategories associated with the specified category.If you set this value is false, only the specified category is deleted.The default value is false.</param>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="forceDelete">Specifies whether the category, and any associated subcategories, are deleted even if there are products that reference them. The default value is false.</param>
		/// <param name="reassignToParent">Specifies whether any subcategories of the specified category are reassigned to the parent of the specified category.This field only applies if the cascadeDelete parameter is false.The default value is false.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   category.DeleteCategoryById( categoryId,  cascadeDelete,  forceDelete,  reassignToParent);
		/// </code>
		/// </example>
		[Obsolete("This method is obsolete; use the async method instead")]
		public virtual void DeleteCategoryById(int categoryId, bool? cascadeDelete =  null, bool? forceDelete =  null, bool? reassignToParent =  null)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.DeleteCategoryByIdClient( categoryId,  cascadeDelete,  forceDelete,  reassignToParent);
			client.WithContext(_apiContext);
			response = client.Execute();

		}

		/// <summary>
		/// Deletes the category specified by its category ID.
		/// </summary>
		/// <param name="cascadeDelete">Specifies whether to also delete all subcategories associated with the specified category.If you set this value is false, only the specified category is deleted.The default value is false.</param>
		/// <param name="categoryId">Unique identifier of the category to modify.</param>
		/// <param name="forceDelete">Specifies whether the category, and any associated subcategories, are deleted even if there are products that reference them. The default value is false.</param>
		/// <param name="reassignToParent">Specifies whether any subcategories of the specified category are reassigned to the parent of the specified category.This field only applies if the cascadeDelete parameter is false.The default value is false.</param>
		/// <returns>
		/// 
		/// </returns>
		/// <example>
		/// <code>
		///   var category = new Category();
		///   await category.DeleteCategoryByIdAsync( categoryId,  cascadeDelete,  forceDelete,  reassignToParent);
		/// </code>
		/// </example>
		public virtual async Task DeleteCategoryByIdAsync(int categoryId, bool? cascadeDelete =  null, bool? forceDelete =  null, bool? reassignToParent =  null)
		{
			MozuClient response;
			var client = Mozu.Api.Clients.Commerce.Catalog.Admin.CategoryClient.DeleteCategoryByIdClient( categoryId,  cascadeDelete,  forceDelete,  reassignToParent);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync();

		}


	}

}


