# EnumConversion
A converter between an enum and a related text which is defined by an attribute.

## Attention
* This program needs .NET framwork 4.0 or later.
* This program is tested with NUnit 2.6.4.
* This program is created with Sharp Develop 5.1.

## Example of use
```cs
private enum Department
{
  [EnumValue("")]
  None,

  [EnumValue("DEV")]
  Development,

  [EnumValue("MNG")]
  Management,
}

public static void Main(string[] args)
{
  string developmentCode = EnumConverter<Department>.ToValue(Department.Development);
  string managementCode = EnumConverter<Department>.ToValue(Department.Management);
  // → "DEV"
  // → "MNG"

  Department development = EnumConverter<Department>.ToEnum("DEV");
  Department management = EnumConverter<Department>.ToEnum("MNG");
  // → Department.Development
  // → Department.Management
}
```

## License
MIT License (see [LICENSE.txt](LICENSE.txt))

## Used Library
### NUnit 2.6.4 ([src/lib/NUnit-2_6_4](src/lib/NUnit-2_6_4))
* Author  
Portions Copyright © 2002-2014 Charlie Poole  
or Copyright © 2002-2004 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov  
or Copyright © 2000-2002 Philip A. Craig

* License  
NUnit License (see [license/NUnit-2_6_4.txt](license/NUnit-2_6_4.txt))
