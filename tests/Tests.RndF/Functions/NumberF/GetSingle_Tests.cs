// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetSingle_Tests
{
	[Fact]
	public void Min_GreaterThan_Max_Throws_ArgumentOutOfRangeException()
	{
		// Arrange
		var min = 3f;
		var max = 2f;

		// Act
		var action = void () => Rnd.NumberF.GetSingle(min, max);

		// Assert
		var ex = Assert.Throws<MinimumMoreThanMaximumException>(action);
		Assert.Equal("GetSingle(): Minimium value '3' must be less than maximum value '2'.", ex.Message);
	}

	[Fact]
	public void Min_LessThan_Zero_Throws_ArgumentException()
	{
		// Arrange
		var min = float.MinValue;

		// Act
		var action = void () => Rnd.NumberF.GetSingle(min: min, max: Rnd.Int);

		// Assert
		var ex = Assert.Throws<MinimumLessThanZeroException>(action);
		Assert.Equal($"GetSingle(): Minimum value '{min}' must be at least 0.", ex.Message);
	}

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var min = 1.0653f;
		var max = 10.6984f;
		var numbers = new List<float>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetSingle(min, max));
		}

		// Assert
		Assert.True(numbers.Min() >= min);
		Assert.True(numbers.Max() <= max);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time() =>
		Get_Tests.Returns_Different_Number_With_Acceptable_Duplicate_Rate(Rnd.NumberF.GetSingle, 0.9995f);
}
