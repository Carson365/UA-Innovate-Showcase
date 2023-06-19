using FileHelpers;

namespace BlazorApp.Data
{
	public class CSVGrabber
	{
		public List<Employee> OriginalCSVGRAB()
		{
			// Tell the CSV parser what the format of the CSV file is
			// Ensure it ignores the first line of the CSV file
			var engine = new FileHelperEngine<CSVEmployee> { Options = { IgnoreFirstLines = 1 } };
			//var records = engine.ReadFile("..\\Data\\orgchart_faux.csv");
			CSVEmployee?[] records = engine.ReadFile("C:\\Users\\Carson\\source\\repos\\BlazorApp\\BlazorApp\\Data\\orgchart_faux.csv");

			List<Employee>? employees = new();
			foreach (CSVEmployee? record in records)
			{
				if (record != null)
				{
					Employee? employee = new()
					{
						ID = record.Emp34Id,
						Name = $"{record.EmpFirstName} {record.EmpLastName}",
						Email = record.EmpEmailAddress,
						Position = record.EmpPositionDesc,
						Location = int.Parse(record.EmpLocationCode),
						Anniversary = record.EmpAnnivDate == "" ? null : record.EmpAnnivDate, // Accomodate the CEO who has no anniversary
						Up = record.Mgr34Id,
						Downs = new List<string>()
					};
					employees.Add(employee);
				}
			}
			return employees;
		}
		public List<Employee> NewCSVGRAB()
		{
			List<Employee>? employees = new();
			foreach (NewCSVEmployee? record in new FileHelperEngine<NewCSVEmployee>().ReadFile("C:\\Users\\Carson\\source\\repos\\BlazorApp\\BlazorApp\\employees.csv").ToList())
			{
				if (record != null)
				{
					Employee? employee = new()
					{
						ID = record.ID,
						Name = record.Name,
						Email = record.Email,
						Position = record.Position,
						Location = record.Location,
						Anniversary = record.Anniversary, // Accomodate the CEO who has no anniversary
						Up = record.Up,
						Downs = record.Downs.Split(',').ToList()
					};
					employees.Add(employee);
				}
			}
			return employees;
		}
	}
}
