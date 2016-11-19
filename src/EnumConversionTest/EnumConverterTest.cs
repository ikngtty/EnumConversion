using System;
using Ikngtty.EnumConversion;
using NUnit.Framework;

namespace Ikngtty.EnumConversionTest
{
	[TestFixture]
	public class EnumConverterTest
	{
		/// <summary>
		/// An enum for the test.
		/// </summary>
		private enum Department
		{
			[EnumValue("")]
			None,
			
			[EnumValue("MNG")]
			Management,
			
			[EnumValue("DEV")]
			Development1,
			
			[EnumValue("DEV")]
			Development2,
			
			
			Personnel,
		}
		
		[Test]
		public void ConvertTest()
		{
			// Test the "ToValue" method.
			Assert.AreEqual("", EnumConverter<Department>.ToValue(Department.None));
			Assert.AreEqual("MNG", EnumConverter<Department>.ToValue(Department.Management));
			Assert.AreEqual("DEV", EnumConverter<Department>.ToValue(Department.Development1));
			Assert.AreEqual("DEV", EnumConverter<Department>.ToValue(Department.Development2));
			Assert.AreEqual("", EnumConverter<Department>.ToValue(Department.Personnel));
			
			// Test the "ToEnum" method.
			Assert.AreEqual(Department.None, EnumConverter<Department>.ToEnum(""));
			Assert.AreEqual(Department.Management, EnumConverter<Department>.ToEnum("MNG"));
			Assert.AreEqual(Department.None, EnumConverter<Department>.ToEnum("FOO"));
			// When depulicated values are defined, the latest definition is used.
			// (This situation is unexpected.)
			Assert.AreEqual(Department.Development2, EnumConverter<Department>.ToEnum("DEV"));
		}
	}
}
