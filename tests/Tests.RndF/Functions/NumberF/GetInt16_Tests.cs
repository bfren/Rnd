// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt16_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt16(), 0, short.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<short> Max =>
			new() { { Rnd.Sht } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(short max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt16(max), (short)0, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt16), () => Rnd.Sht, Rnd.NumberF.GetInt16);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt16), () => (short)(Rnd.Sht * -1), () => Rnd.Sht, Rnd.NumberF.GetInt16);
		}

		public static TheoryData<short, short> MinAndMax
		{
			get
			{
				var min = Rnd.Sht;
				var max = (short)(min + 1 + Rnd.Sht);
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(short min, short max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt16(min, max), min, max);
	}
}
