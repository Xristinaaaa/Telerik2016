using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mines
{
	public class Mines
	{
		public class Points
		{
			string name;
			int points;

			public string Name
			{
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			public int PointsIn
			{
				get
				{
					return this.points;
				}
				set
				{
					this.points = value;
				}
			}

			public Points() { }

			public Points(string name, int points)
			{
				this.name = name;
				this.points = points;
			}
		}

		static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] field = CreateField();
			char[,] bombs = PlaceBombs();
			int counter = 0;
			bool crash = false;
			List<Points> winners = new List<Points>(6);
			int row = 0;
			int col = 0;
			bool flag = true;
			const int max = 35;
			bool flag2 = false;

			do
			{
				if (flag)
				{
					Console.WriteLine("Lets play. You should find the fields without mines." +
					" Command 'top' shows the ranking, 'restart' starts a new game, 'exit' finishes the game!");
                    Input(field);
					flag = false;
				}

				Console.Write("Row and Col: ");
				command = Console.ReadLine().Trim();

				if (command.Length >= 3 && 
                    int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    row <= field.GetLength(0) && col <= field.GetLength(1))
				{
						command = "turn";
				}

				switch (command)
				{
					case "top":
                        Ranking(winners);
						break;
					case "restart":
						field = CreateField();
						bombs = PlaceBombs();
                        Input(field);
						crash = false;
						flag = false;
						break;
					case "exit":
						Console.WriteLine("Bye!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
                                OnTurn(field, bombs, row, col);
								counter++;
							}
							if (max == counter)
							{
								flag2 = true;
							}
							else
							{
                                Input(field);
							}
						}
						else
						{
							crash = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Wrong command!\n");
						break;
				}

				if (crash)
				{
                    Input(bombs);
					Console.Write("\nExit game with {0} points. " + "Nickname: ", counter);
					string nickname = Console.ReadLine();
					Points player = new Points(nickname, counter);

					if (winners.Count < 5)
					{
						winners.Add(player);
					}
					else
					{
						for (int i = 0; i < winners.Count; i++)
						{
							if (winners[i].PointsIn < player.PointsIn)
							{
								winners.Insert(i, player);
								winners.RemoveAt(winners.Count - 1);
								break;
							}
						}
					}

					winners.Sort((Points player1, Points player2) => player2.Name.CompareTo(player1.Name));
					winners.Sort((Points player1, Points player2) => player2.PointsIn.CompareTo(player1.PointsIn));
                    Ranking(winners);

					field = CreateField();
					bombs = PlaceBombs();
					counter = 0;
					crash = false;
					flag = true;
				}
				if (flag2)
				{
					Console.WriteLine("\nCongrats!");
                    Input(bombs);

					Console.WriteLine("Name: ");
					string name = Console.ReadLine();

					Points points = new Points(name, counter);

					winners.Add(points);
                    Ranking(winners);

					field = CreateField();
					bombs = PlaceBombs();

					counter = 0;
					flag2 = false;
					flag = true;
				}
			}
			while (command != "exit");

			Console.Read();
		}

		private static void Ranking(List<Points> points)
		{
			Console.WriteLine("\nPoints:");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} boxes",
						i + 1, points[i].Name, points[i].PointsIn);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No ranking!\n");
			}
		}

		private static void OnTurn(char[,] field, char[,] bombs, int row, int col)
		{
			char numOfBombs = Counter(bombs, row, col);
			bombs[row, col] = numOfBombs;
			field[row, col] = numOfBombs;
		}

		private static void Input(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);

			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int rows = 5;
			int columns = 10;
			char[,] playingField = new char[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					playingField[i, j] = '-';
				}
			}

			List<int> list = new List<int>();

			while (list.Count < 15)
			{
				Random random = new Random();
				int number = random.Next(50);

				if (!list.Contains(number))
				{
					list.Add(number);
				}
			}

			foreach (int element in list)
			{
				int col = (element / columns);
				int row = (element % columns);

				if (row == 0 && element != 0)
				{
					col--;
					row = columns;
				}
				else
				{
					row++;
				}

				playingField[col, row - 1] = '*';
			}

			return playingField;
		}

		private static void Sum(char[,] field)
		{
			int col = field.GetLength(0);
			int row = field.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (field[i, j] != '*')
					{
						char inIt = Counter(field, i, j);
						field[i, j] = inIt;
					}
				}
			}
		}

		private static char Counter(char[,] field, int row, int col)
		{
			int count = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (row - 1 >= 0)
			{
				if (field[row - 1, col] == '*')
				{
					count++; 
				}
			}
			if (row + 1 < rows)
			{
				if (field[row + 1, col] == '*')
				{
					count++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (field[row, col - 1] == '*')
				{
					count++;
				}
			}
			if (col + 1 < cols)
			{
				if (field[row, col + 1] == '*')
				{
					count++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (field[row - 1, col - 1] == '*')
				{
					count++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (field[row - 1, col + 1] == '*')
				{
					count++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (field[row + 1, col - 1] == '*')
				{
					count++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (field[row + 1, col + 1] == '*')
				{
					count++; 
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
