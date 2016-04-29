using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System;

namespace Blank
{
	class MainClass
	{
		public static string[] Read(string fileName){
			var assembly = Assembly.GetExecutingAssembly();
			using (Stream stream = assembly.GetManifestResourceStream (fileName))
			using (StreamReader reader = new StreamReader (stream)) {
				return reader.ReadToEnd ().Split ('\n');
			}
		}
		public static void Main (string[] args)
		{
			Console.Write ("Enter times: ");
			int userIter = int.Parse(Console.ReadLine());

			//Google forms link with "formResponce?" appended
			string sourceUrl = "https://docs.google.com/forms/d/1XGGGWvIOb3EO_UpDJjXFYAlW0JjLcT4kUVVXhocMSyc/formResponse?";
			Dictionary<string,string[]> entry = new Dictionary<string, string[]> ();

			//Question ID with ansers

			//Scale question
			entry.Add ("entry.1435525762", new string[]{"6","7","8","9","10"}); //{"1","2","3","4","5",

			//Simple questions with radio buttons
			entry.Add ("entry.910908450", new string[]{"Простота"}); //,"Контроль"});
			entry.Add ("entry.111358378", new string[]{ "Успех", "Понимание"});
			entry.Add ("entry.1386376791", new string[]{ "20 тыс. руб. - 40 тыс. руб"
				, "40 тыс. руб. - 60 тыс. руб", "60 тыс. руб. - 120 тыс. руб", "120 тыс. руб. - 200 тыс. руб",
				"200 тыс. руб. - 250 тыс. руб" });
			entry.Add ("entry.655317939", new string[]{ "Коротко, чтобы я сам доработал механизм работы задачи", 
				"Во всех подробностях, чтобы я меньше думал о том, как это должно работать", 
				"Мне все равно" });

			//Question with checkbox (only one answer)
			entry.Add ("entry.460075870", new string[]{ "Честность", "Оптимизм","Харизма", 
				"Экстраверсия"}); //"Скупость", "Пессимизм",, "Интроверсия"

			//Free question
			entry.Add ("entry.1081606326", Read("it_directions.txt"));

			//And so forth
			entry.Add ("entry.175228581", new string[]{ "Нравятся, не посещаю"
				, "Не нравятся, но посещаю", "Не нравятся, не посещаю" }); //"Нравятся, посещаю",
			entry.Add ("entry.365841133", new string[]{"Нет"}); // "Да", 
			entry.Add ("entry.773043306", new string[]{ "Да", "Нет"});
			entry.Add ("entry.1729923847", new string[]{ "1", "2", "3", "4", "5", "6" }); //,"7","8","9","10"});
			entry.Add ("entry.1034640367", new string[]{ "Положительное"}); //, "Отрицательное"});
			entry.Add ("entry.531646578", new string[]{ "Быстро и хорошо" }); //, "Быстро и плохо"
			//, "Медленно и хорошо", "Медленно и плохо" });
			entry.Add ("entry.615045785", new string[]{ "Нет"}); //"Да",
			entry.Add ("entry.1755180738", Read ("jobs.txt"));
			entry.Add ("entry.2087425572", new string[]{ "Да" }); //, "Нет"});
			entry.Add ("entry.244215671", new string[]{ "Да" }); //, "Нет"});
			entry.Add ("entry.522151309", Read("friends.txt"));
			entry.Add ("entry.1630819879", new string[]{ "От 18 до 20", "От 20 до 30" }); //, "От 30 и выше"});
			entry.Add ("entry.461761138", new string[]{ "Мужской" });//, "Женский"});

			for (int i = 0; i < userIter; i++) {
				StringBuilder sb = new StringBuilder ();
				sb.Append (sourceUrl);

				foreach (var item in entry) {
					sb.Append (item.Key + "=" + item.Value [new Random ().Next (item.Value.Length)] + "&");
				}

				//Remove last '&'
				sb.Remove (sb.Length - 1, 1);
				Process.Start (sb.ToString ());

				//Sleep for specified milliseconds
				Thread.Sleep (500);
			}

			Console.WriteLine ("ezpz");
		}
	}
}
