using FileHelpers;

namespace BlazorApp.Data
{

	public class Employee
    { // Store only the data that we need
		public string? ID { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Position { get; set; }
		public int? Location { get; set; }
		public string? Anniversary { get; set; }
		public string? Up { get; set; }
		public List<string>? Downs { get; set; }
	}
	[DelimitedRecord(",")]
	public class NewCSVEmployee
	{ // Store only the data that we need
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? ID { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Name { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Email { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Position { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public int? Location { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Anniversary { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Up { get; set; }
		[FieldQuoted('"', QuoteMode.OptionalForWrite)]
		public string? Downs { get; set; }
	}

	[DelimitedRecord(",")]
    public class CSVEmployee
    { // The "FieldQuoted" attribute is used to tell the parser that the name is enclosed in quotes.
        public string? Emp34Id { get; set; }
        public string? EmpLastName { get; set; }
        public string? EmpFirstName { get; set; }
        public string? EmpEmailAddress { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string? EmpPositionDesc { get; set; }
        public string? EmpLocationCode { get; set; }
        public string? EmpLocationDesc { get; set; }
        public string? Mgr34Id { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string? MgrName { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string? MgrTitle { get; set; }
        public string? MgrEmailAddress { get; set; }
        public string? EmpAnnivDate { get; set; }
        public string? EmpPositionIsSuper { get; set; }
    }
}