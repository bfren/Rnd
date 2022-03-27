// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Security.Cryptography;
using System.Text;

namespace RndF.Properties.Resources_Tests;

public class LongWordList_Tests
{
	public const string LongWordListHash = "Gfrw6qIUohOBcjImj3zxIaATS/w8JCnTyd3nFx4hTsE=";

	[Fact]
	public void Returns_Correct_Values()
	{
		// Arrange
		var list = Resources.eff_long_word_list;
		var bytes = Encoding.UTF8.GetBytes(list);
		var expected = Convert.FromBase64String(LongWordListHash);

		// Act
		var result = SHA256.HashData(bytes);

		// Assert
		Assert.Equal(expected, result);
	}
}
