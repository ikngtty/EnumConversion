using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ikngtty.EnumConversion
{
	/// <summary>
	/// A converter about an enum.
	/// </summary>
	/// <typeparam name="TEnum">An enum type to convert.</typeparam>
	public static class EnumConverter<TEnum> where TEnum : IConvertible
	{
		// All conversion patterns of the enum are set here.
		// Using an enum hash key is slower than using a converted int hash key,
		// because of the boxing.
		private static readonly Dictionary<int, string> enumToValueDict = new Dictionary<int, string>();
		private static readonly Dictionary<string, TEnum> valueToEnumDict = new Dictionary<string, TEnum>();
		
		/// <summary>
		/// Constracts this class.
		/// </summary>
		/// <remarks>
		/// Reads all conversion patterns of the enum and creates hashes to convert fast at later.
		/// 
		/// Called as following.
		/// <code>
		/// EnumConverter{Foo}.ToValue(Foo.A);	// Call this constractor.
		/// EnumConverter{Foo}.ToEnum("FooA");
		/// EnumConverter{Bar}.ToValue(Bar.A);	// Call this constractor.
		/// EnumConverter{Bar}.ToEnum("BarA");
		/// EnumConverter{Foo}.ToValue(Foo.B);
		/// </code>
		/// </remarks>
		static EnumConverter()
		{
			// Get all fields of the enum.
			IEnumerable<FieldInfo> allFields =
				typeof(TEnum).GetFields()
				.Where(
					field => field.FieldType == typeof(TEnum)
				);
			
			foreach (FieldInfo field in allFields)
			{
				var enumValue = (TEnum)field.GetValue(null);
				int intValue = enumValue.ToInt32(null);
				
				// Get the value from the attribute.
				var valueAttr = (EnumValueAttribute)field.GetCustomAttribute(typeof(EnumValueAttribute));
				if (valueAttr != null)
				{
					string value = valueAttr.Value;
					
					// Add the hashes.
					enumToValueDict[intValue] = value;
					valueToEnumDict[value] = enumValue;
				}
			}
		}
		
		public static string ToValue(TEnum enumValue)
		{
			int intValue = enumValue.ToInt32(null);
			
			return enumToValueDict.ContainsKey(intValue) ?
				enumToValueDict[intValue] : "";
		}
		
		public static TEnum ToEnum(string value)
		{
			return valueToEnumDict.ContainsKey(value) ?
				valueToEnumDict[value] : default(TEnum);
		}
	}
}
