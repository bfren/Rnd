// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt16_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt16(), (ushort)0, ushort.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<ushort> Max =>
			new() { { Rnd.USht } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(ushort max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt16(max), (ushort)0, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt16), () => Rnd.USht, Rnd.NumberF.GetUInt16);
		}

		public static TheoryData<ushort, ushort> MinAndMax
		{
			get
			{
				var min = Rnd.USht;
				var max = (ushort)(min + 1 + Rnd.USht);
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(ushort min, ushort max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt16(min, max), min, max);
	}
}
