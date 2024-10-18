// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <see cref="int.MaxValue"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static int GetInt32() =>
			GetInt32(0, int.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static int GetInt32(int max) =>
			GetInt32(0, max);

		/// <summary>
		/// Returns a random positive integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="min">Minimum acceptable value (must be at least <see langword="0"/>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		/// <exception cref="MinimumLessThanZeroException"/>
		public static int GetInt32(int min, int max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetInt32), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetInt32), min);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = Math.Round(range * Get());
			return (int)(min + add);
		}
	}
}
