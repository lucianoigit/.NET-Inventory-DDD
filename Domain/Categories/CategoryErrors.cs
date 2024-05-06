using Domain.SharedKernel.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories
{
    public static class CategoryErrors
    {
        public static Error CategoryNotFound = Error.NotFound("Category.NotFound", "The category with the specified identifier was not found");
        public static Error SameToSubcategory = Error.Validation("Category.SameToSubcategory", "Category and Subcategory are the same.");
        public static Error SubCategoryAlreadyHaveParentCategory = Error.Validation("Category.SubCategoryAlreadyHaveParentCategory", "The sub category already have a parent category.");
    }
}
