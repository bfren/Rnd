// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt64_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt64(), 0UL, ulong.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<ulong> Max =>
			new() { { Rnd.ULng } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(ulong max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt64(max), 0UL, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt64), () => Rnd.ULng, Rnd.NumberF.GetUInt64);
		}

		public static TheoryData<ulong, ulong> MinAndMax
		{
			get
			{
				var min = Rnd.ULng;
				var max = min + 1 + Rnd.ULng;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(ulong min, ulong max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt64(min, max), min, max);
	}
}
