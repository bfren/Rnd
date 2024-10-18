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
		/// Returns a random positive integer between <see langword="0"/> and <see cref="nint.MaxValue"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static nint GetIntPtr() =>
			GetIntPtr(0, nint.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static nint GetIntPtr(nint max) =>
			GetIntPtr(0, max);

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
		public static nint GetIntPtr(nint min, nint max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetIntPtr), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetIntPtr), min);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = Math.Round(range * Get());
			return (nint)(min + add);
		}
	}
}
