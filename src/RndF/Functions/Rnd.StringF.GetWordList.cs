// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Retrieve a modified form of EFF's short word list, with unique three-character prefixes<br/>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		public static readonly Lazy<string[]> ShortWordList = new(
			() => GetWordList(Properties.Resources.eff_short_word_list)
		);

		/// <summary>
		/// Retrieve a modified form of EFF's long word list, with higher entropy for use with fewer words<br/>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		public static readonly Lazy<string[]> LongWordList = new(
			() => GetWordList(Properties.Resources.eff_long_word_list)
		);

		/// <summary>
		/// Convert an input string into a list of words
		/// </summary>
		/// <param name="input">Input string of words</param>
		internal static string[] GetWordList(string input)
		{
			// Return empty array
			if (input.Length == 0)
			{
				return Array.Empty<string>();
			}

			// Split the input string into a list of words
			return input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
		}
	}
}
