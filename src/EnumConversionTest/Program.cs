using System;
using Ikngtty.EnumConversion;

namespace Ikngtty.EnumConversionTest
{
	/// <summary>
	/// The application start point holder.
	/// </summary>
	public static class Program
	{
		public static void Main(string[] args)
		{
			// Example of EnumConversion use
			
			string developmentCode = EnumConverter<Department>.ToValue(Department.Development);
			string managementCode = EnumConverter<Department>.ToValue(Department.Management);
			// → "DEV"
			// → "MNG"
			
			Department development = EnumConverter<Department>.ToEnum("DEV");
			Department management = EnumConverter<Department>.ToEnum("MNG");
			// → Department.Development
			// → Department.Management
			
			
			Console.Write("Press any key to quit...");
			Console.ReadKey(true);
		}
		
		/// <summary>
		/// A sample enum.
		/// </summary>
		private enum Department
		{
			[EnumValue("")]
			None,
			
			[EnumValue("DEV")]
			Development,
			
			[EnumValue("MNG")]
			Management,
		}
	}
}
