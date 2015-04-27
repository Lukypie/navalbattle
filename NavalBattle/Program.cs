using System;

	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Battaglia navale";
			int[,] griglia = new int[15, 15];
			char[,] paral = new char[15, 15];
			int a1, b1, c1, a2, b2, c2, a3, b3, c3, a4, b4, c4;
			int s = 0;
			int x;
			int y;
			int c = 0;
			int k = 0;

			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					paral[i, j] = (char)126;
				}
			}
			do
			{
				for (int i = 0; i < 15; i++)
				{
					for (int j = 0; j < 15; j++)
					{
						griglia[i, j] = 0;
					}
				}
				Random rn = new Random();

				a1 = rn.Next(10);
				b1 = rn.Next(10);
				c1 = rn.Next(2);

				griglia[a1, b1] = 1;
				griglia[a1 + c1, b1 + 1 - c1] = 1;

				a2 = rn.Next(10);
				b2 = rn.Next(10);
				c2 = rn.Next(2);

				griglia[a2, b2] = 1;
				griglia[a2 + c2, b2 + 1 - c2] = 1;

				a3 = rn.Next(10);
				b3 = rn.Next(10);
				c3 = rn.Next(2);

				griglia[a3, b3] = 1;
				griglia[a3 + c3, b3 + 1 - c3] = 1;
				griglia[a3 + 2 * c3, b3 + 2 - 2 * c3] = 1;

				a4 = rn.Next(10);
				b4 = rn.Next(10);
				c4 = rn.Next(2);

				griglia[a4, b4] = 1;
				griglia[a4 + c4, b4 + 1 - c4] = 1;
				griglia[a4 + 2 * c4, b4 + 2 - 2 * c4] = 1;

				s = 0;
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 10; j++)
					{
						s += griglia[i, j];
					}
				}
			} while (s < 10);

			do
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine();
				Console.WriteLine("  | 0 1 2 3 4 5 6 7 8 9 ");
				Console.WriteLine("--+--------------------");
				for (int i = 0; i < 10; i++)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write(i + " * ");
					for (int j = 0; j < 10; j++)
					{
						if (paral[i, j] == (char)126)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write(paral[i, j] + " ");
						}
						else
						{
							if (paral[i, j] == 'X')
							{
								Console.ForegroundColor = ConsoleColor.DarkYellow;
								Console.Write(paral[i, j] + " ");
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Yellow;
								Console.Write(paral[i, j] + " ");
							}
						}
					}
					Console.WriteLine();
				}
				do
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("Insert first coordinate: ");
					x = Convert.ToInt32(Console.ReadLine());
					Console.Write("Insert second coordinate: ");
					y = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine();
				} while (x > 10 || y > 10);
				if (paral[x, y] == 'X')
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.Clear();
					paral[x, y] = 'X';
					Console.WriteLine("Move not permitted");
				}
				else
				{
					if (griglia[x, y] == 1)
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Clear();
						Console.WriteLine("--------------Hit--------------");
						paral[x, y] = 'X';
						c++;
						k++;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						paral[x, y] = 'M';
						Console.Clear();
						Console.WriteLine("--------------Missed--------------");
						k++;
					}
				}
			} while (c < 10);

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("------------------Victory---------------------");
			Console.Title = "Victory";
			Console.WriteLine("You've used " + k + " moves");
			Console.ReadKey();
		}
}