// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Security.Cryptography;
using System.Text;

namespace RndF.Properties.Resources_Tests;

public class eff_short_word_list_Tests
{
	public static string ShortWordListHash { get; } = "vfU56xafgYeDBBWYcvGcjd4izEn8nJaItRXsSmd8tjU=";

	[Fact]
	public void returns_correct_values()
	{
		// Arrange
		var list = Resources.eff_short_word_list.ReplaceLineEndings(string.Empty);
		var bytes = Encoding.UTF8.GetBytes(list);
		var expected = Convert.FromBase64String(ShortWordListHash);

		// Act
		var result = SHA256.HashData(bytes);

		// Assert
		Assert.Equal(expected, result);
	}
}
