using System.Reflection;
using System.Text;

namespace BlazorApp.Data
{
	public class EmployeeService
	{

		public bool IsInitialized { get; private set; }

		public List<Employee>? employeelist;

		public Employee primary;

        public Employee? up;

        public List<Employee>? downs;

        // Run the CSVGrabber to get the list of employees

        private readonly List<Employee> processemployees = new CSVGrabber().OriginalCSVGRAB();

		//private readonly List<Employee> employees = new CSVGrabber().NewCSVGRAB();

		public Task<List<Employee>> GetEmployeesAsync()
		{
			if (File.Exists("C:\\Users\\Carson\\source\\repos\\BlazorApp\\BlazorApp\\employees.csv")) return Task.FromResult(new CSVGrabber().NewCSVGRAB().ToList());
			// If the CSV file doesn't exist, then create it
			//
			// This takes a while but only needs to be done once
			//
			foreach (Employee? employee in processemployees)
			{
				// Get employee's Up, assign employee's Up the employee's ID in the Up's Down field
				// If the employee's Up is null, then the employee is the CEO
				if (employee.Up == null) employee.Up = "CEO";
				else processemployees.Find(x => x.ID == employee.Up)?.Downs?.Add(employee.ID);
			}
			// Write the list of employees to a CSV file
			var csvline = new StringBuilder();
			foreach (Employee employ in processemployees)
			{
				csvline.Append($"\"{employ.ID}\",");
				csvline.Append($"\"{employ.Name}\",");
				csvline.Append($"\"{employ.Email}\",");
				csvline.Append($"\"{employ.Position}\",");
				csvline.Append($"\"{employ.Location}\",");
				csvline.Append($"\"{employ.Anniversary}\",");
				csvline.Append($"\"{employ.Up}\",");
				string downs = employ.Downs == null ? "" : string.Join(",", employ.Downs);
				csvline.Append($"\"{downs}\"\r\n");
            }
			csvline.Remove(csvline.Length - 2, 2);
			File.WriteAllLinesAsync("C:\\Users\\Carson\\source\\repos\\BlazorApp\\BlazorApp\\employees.csv", new List<string> { csvline.ToString() });

			return Task.FromResult(new CSVGrabber().NewCSVGRAB().ToList());
			// return what we actually need; this is just the formatted data and only needs to be run once to create the modified CSV file
		}
	}
}