# UnitConversion

A C# library used to convert between lengths(Miles, Feet, Inches, Meters),Temperatures (Celsius, Fahrenheit), and data (bits, bytes).

The UnitConversion class requires an input of (String input - Number Unit format) & (Target - Unit format) and returns an output String.
Example:
Input: 1 kilometer
Target: inches
Output: 39370 inch

The class supports all si prefixes, which are also useable for different inputs.
E.g. 1 kiloinch (1000 inches), 1 centicelsius, etc.
