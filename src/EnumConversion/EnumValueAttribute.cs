using System;

namespace Ikngtty.EnumConversion
{
	/// <summary>
	/// An attribute to indicate an enum field's value.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumValueAttribute : Attribute
	{
		private readonly string value;
		
		public string Value { get { return this.value; } }
		
		public EnumValueAttribute(string value)
		{
			this.value = value;
		}
	}
}
