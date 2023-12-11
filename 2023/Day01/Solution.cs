using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day01;

[ProblemName("Trebuchet?!")]
class Solution : Solver
{

	public object PartOne(string input)
	{
		int sum = 0;

		foreach (string line in input.Split("\n"))
		{
			var digits = line.Where(char.IsDigit);
			var firstDigit = digits.First() - '0';
			var secondDigit = digits.Last() - '0';
			sum += (10 * firstDigit) + secondDigit;

		}

		return sum;
	}

	public object PartTwo(string input)
	{
		string regex = @"\d|one|two|three|four|five|six|seven|eight|nine";
		int sum = 0;


		foreach (string line in input.Split("\n"))
		{
			var firstDigit = ParseDigit(Regex.Match(line, regex).Value);
			var secondDigit = ParseDigit(Regex.Match(line, regex, RegexOptions.RightToLeft).Value);
			var value = (10 * firstDigit) + secondDigit;
			sum += value;
		}

		return sum;

		static int ParseDigit(string input) => input switch
		{
			"one" => 1,
			"two" => 2,
			"three" => 3,
			"four" => 4,
			"five" => 5,
			"six" => 6,
			"seven" => 7,
			"eight" => 8,
			"nine" => 9,
			_ => int.Parse(input)
		};
	}
}
