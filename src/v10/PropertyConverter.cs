using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Extensions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vokseverk {

	public class PartialTextStringConverter : IPropertyValueConverter {

		public bool IsConverter(IPublishedPropertyType propertyType) {
			return propertyType.EditorAlias.Equals("Vokseverk.PartialTextsString");
		}

		public Type GetPropertyValueType(IPublishedPropertyType propertyType) {
			return typeof(string);
		}

		public PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType) {
			return PropertyCacheLevel.Element;
		}

		public bool? IsValue(object value, PropertyValueLevel level) {
			switch (level) {
				case PropertyValueLevel.Source:
					return value != null && value is string;
				default:
					throw new NotSupportedException($"Invalid level: {level}.");
			}
		}

		public object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview) {
			return source ?? null;
		}

		public object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview) {
			if (inter == null) {
				return null;
			}

			return inter.ToString();
		}

		public object ConvertIntermediateToXPath(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview) {
			if (inter == null) {
				return null;
			}

			return inter.ToString();
		}
	}
}
