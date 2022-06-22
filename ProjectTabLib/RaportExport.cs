using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHtmlToPdf;
namespace ProjectTabLib
{
    public class RaportExport
    {
		public static void Test() {

				const string html =
			"<!DOCTYPE html>" +
			"<html>" +
			"<head><meta charset='UTF-8'><title>Title</title></head>" +
			"<body>Body text...</body>" +
			"</html>";
			var xd = File.ReadAllLines("htmlsite.html").ToString();
			var pdf = Pdf
				.From(html)
				.OfSize(PaperSize.A4)
				.WithTitle("Title")
				.WithoutOutline()
				.WithMargins(1.25.Centimeters())
				.Portrait()
				.Comressed()
				.Content();

			File.WriteAllBytes("pdf.pdf", pdf);
		}
		public static void generateRaport(string acc,string date1,string date2,double bilans,(string,double,double )[] categories, string path) {
			var htmlh = File.ReadAllLines("htmlh.txt");//ten szajs trzeba wywalic
			var htmlm = File.ReadAllLines("htmlm.txt");
			string htmle = "</body></html >";
			StringBuilder html = new StringBuilder();
			html.Append(String.Concat(htmlh));
			html.Append("<h1>RAPORT</h1>");
			html.Append("<h2>Zyski i wydatki</h2>");
			html.Append("<p>od "+date1+" do "+date2+"</p>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");
			html.Append("<b>konto "+acc+"  BILANS "+bilans+"PLN</b>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");
			html.Append("  <b class = \"xd\"> &ensp; zyski</b>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");
			foreach (var v in categories) { 
			html.Append("&ensp;&ensp;"+v.Item1+" <b class = \"xd\">"+v.Item2+"PLN</b>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");
			}
			html.Append("  <b class = \"xd\"> &ensp; wydatki</b>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");
			foreach (var v in categories)
			{
				html.Append("&ensp;&ensp;" + v.Item1 + " <b class = \"xd\">" + v.Item3 + "PLN</b>");
				html.Append("<hr size=\"\" width=\"\" color=\"\">");
			}


			//html.Append(String.Concat(htmlm));
			html.Append(htmle);

			var pdf = Pdf
			.From(html.ToString())
			.OfSize(PaperSize.A4)
			.WithTitle("Raport " + "od " + date1 + " do " + date2)
			.WithoutOutline()
			.WithMargins(1.25.Centimeters())
			.Portrait()
			.Comressed()
			.Content();

			File.WriteAllBytes(path, pdf);

		}
		public static void generateRaport(string path, string acc, string date1, string date2, Dictionary<string, (List<RaportQueryModel>, List<RaportQueryModel>, double)> records ,List<UserCategoryModel> categories, List<UserAccountModel> accounts)
		{
			var htmlh = File.ReadAllLines("htmlh.txt");//ten szajs trzeba wywalic
			var htmlm = File.ReadAllLines("htmlm.txt");
			string htmle = "</body></html >";
			StringBuilder html = new StringBuilder();
			html.Append(String.Concat(htmlh));
			html.Append("<h1>RAPORT</h1>");
			html.Append("<h2>Zyski i wydatki</h2>");
			html.Append("<p>od " + date1 + " do " + date2 + "</p>");
			html.Append("<p>z kategorii " + String.Join(", ", categories.Select(n=>n.Category_Name)) + "</p>");
			html.Append("<hr size=\"\" width=\"\" color=\"\">");

			foreach (var e in records)
			{
				var tp = e.Value;
				html.Append("<b>konto " + e.Key + "  BILANS " + e.Value.Item3 + "PLN</b>");
				html.Append("<hr size=\"\" width=\"\" color=\"\">");
				html.Append("  <b class = \"xd\"> &ensp; zyski</b>");
				html.Append("<hr size=\"\" width=\"\" color=\"\">");
				foreach (var v in tp.Item1)
				{
					html.Append("&ensp;&ensp;" + v.Name + " <b class = \"xd\">" + v.Amount + "PLN</b>");
					html.Append("<hr size=\"\" width=\"\" color=\"\">");
				}
				html.Append("  <b class = \"xd\"> &ensp; wydatki</b>");
				html.Append("<hr size=\"\" width=\"\" color=\"\">");
				foreach (var v in tp.Item2)
				{
					html.Append("&ensp;&ensp;" + v.Name + " <b class = \"xd\">" + v.Amount + "PLN</b>");
					html.Append("<hr size=\"\" width=\"\" color=\"\">");
				}
			}

			//html.Append(String.Concat(htmlm));
			html.Append(htmle);

			var pdf = Pdf
			.From(html.ToString())
			.OfSize(PaperSize.A4)
			.WithTitle("Raport " + "od " + date1 + " do " + date2)
			.WithoutOutline()
			.WithMargins(1.25.Centimeters())
			.Portrait()
			.Comressed()
			.Content();

			File.WriteAllBytes(path, pdf);

		}
	}
}
