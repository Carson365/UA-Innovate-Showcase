using BlazorApp.Data;
using FileHelpers;

namespace BlazorApp.Data
{
	public class Places
	{
	}
}






////
///

//public List<Employee> OriginalCSVGRAB()
//{
//	// Tell the CSV parser what the format of the CSV file is
//	// Ensure it ignores the first line of the CSV file
//	var engine = new FileHelperEngine<CSVEmployee> { Options = { IgnoreFirstLines = 1 } };
//	//var records = engine.ReadFile("..\\Data\\orgchart_faux.csv");
//	CSVEmployee?[] records = engine.ReadFile("C:\\Users\\Carson\\source\\repos\\BlazorApp\\BlazorApp\\Data\\orgchart_faux.csv");

//	List<Employee>? employees = new();
//	foreach (CSVEmployee? record in records)
//	{
//		if (record != null)
//		{
//			Employee? employee = new()
//			{
//				ID = record.Emp34Id,
//				Name = $"{record.EmpFirstName} {record.EmpLastName}",
//				Email = record.EmpEmailAddress,
//				Position = record.EmpPositionDesc,
//				Location = int.Parse(record.EmpLocationCode),
//				Anniversary = record.EmpAnnivDate == "" ? null : record.EmpAnnivDate, // Accomodate the CEO who has no anniversary
//				Up = record.Mgr34Id,
//				Downs = new List<string>()
//			};
//			employees.Add(employee);
//		}
//	}
//	return employees;
//}