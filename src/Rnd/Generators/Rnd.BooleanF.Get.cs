// Rnd: Generate random values.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace Rnd.Generators;

public static partial class Rnd
{
	public static partial class BooleanF
	{
		/// <summary>
		/// Returns a random true or false value
		/// </summary>
		public static bool Get() =>
			NumberF.GetInt64(0, 1) switch
			{
				0 =>
					false,

				_ =>
					true
			};
	}
}
