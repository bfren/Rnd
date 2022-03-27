// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt32_Tests
{
	[Fact]
	public void Min_GreaterThan_Max_Throws_ArgumentOutOfRangeException()
	{
		// Arrange
		const int min = 3;
		const int max = 2;

		// Act
		var action = void () => Rnd.NumberF.GetInt64(min, max);

		// Assert
		var ex = Assert.Throws<ArgumentOutOfRangeException>(action);
		Assert.Equal($"Minimium value must be less than the maximum value. (Parameter 'min'){Environment.NewLine}Actual value was 3.", ex.Message);
	}

	[Fact]
	public void Min_LessThan_Zero_Throws_ArgumentException()
	{
		// Arrange
		const int min = int.MinValue;

		// Act
		var action = void () => Rnd.NumberF.GetInt32(min: min, max: Rnd.Int);

		// Assert
		var ex = Assert.Throws<ArgumentException>(action);
		Assert.Equal("Minimum value must be at least 0. (Parameter 'min')", ex.Message);
	}

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		const int iterations = 1000000;
		const int min = 1;
		const int max = 10;
		var numbers = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetInt32(min, max));
		}

		// Assert
		Assert.True(numbers.Min() >= min);
		Assert.True(numbers.Max() <= max);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time()
	{
		// Arrange
		const int iterations = 10000;
		var numbers = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetInt32());
		}

		var unique = numbers.Distinct();

		// Assert
		Assert.InRange(unique.Count(), numbers.Count - 2, numbers.Count);
	}
}
