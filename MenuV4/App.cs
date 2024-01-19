

internal class App : IApp
{
	private readonly MenuDbContext _menuDbContext;
	private readonly ICreatingToDatabase _iCreatingToDatabase;
    private readonly IReadingFromDatabase _iReadingFromDatabase;
    private readonly IUpdatingDatabase _iUpdatingDatabase;
    private readonly IDeletingFromDatabase _iDeletingFromDatabase;
	public App(
		MenuDbContext menuDbContext,
		ICreatingToDatabase iCreatingToDatabase,
        IReadingFromDatabase iReadingFromDatabase,
        IUpdatingDatabase iUpdatingDatabase,
        IDeletingFromDatabase iDeletingFromDatabase
        )
    {
		_iCreatingToDatabase = iCreatingToDatabase;
        _iReadingFromDatabase = iReadingFromDatabase;
        _iUpdatingDatabase = iUpdatingDatabase;
        _iDeletingFromDatabase = iDeletingFromDatabase;
		_menuDbContext = menuDbContext;
		_menuDbContext.Database.EnsureCreated();
	}
    public void Run()
	{
        //Console.WriteLine("Running App");
		bool isWroking = true;
		while (isWroking)
		{
			Console.Clear();
			MenuGreetingMethod();
			string optionSelected = UserStringInputMethod();
			isWroking = SelectingUserChoiceMethod(isWroking, optionSelected);
			Console.ReadKey();
		}
	}

	private void MenuGreetingMethod()
	{
		Console.WriteLine(
			$"Welcome to Soylent Green Cafe where our Customer is our specialty!! {Environment.NewLine}" +
			$"I will be your host Jenna {Environment.NewLine}" +
			$"{Environment.NewLine}" +
			$"How may I assist you from the following options? {Environment.NewLine}" +
			$"{Environment.NewLine}" +
			$"[View] the Menu {Environment.NewLine}" +
			$"[Add] new item to the menu {Environment.NewLine}" +
			$"[Update] an item on the menu {Environment.NewLine}" +
			$"[Remove] an item from the menu {Environment.NewLine}" +
			$"[Exit] Soylent Green Cafe {Environment.NewLine}" +
			$"{Environment.NewLine}" +
			$"Input preferred choice within []?"
			);
	}

	private string UserStringInputMethod() => Console.ReadLine().ToLower();

	private bool SelectingUserChoiceMethod(bool isWroking, string optionSelected)
	{
		switch (optionSelected)
		{
			case "view":
				//Console.WriteLine("In View");
				_iReadingFromDatabase.Run();
				break;
			case "add":
				//Console.WriteLine("In Add");
				_iCreatingToDatabase.Run();
				
				break;
			case "remove":
				//Console.WriteLine("In Remove");
				_iDeletingFromDatabase.Run();
				break;
			case "update":
				//Console.WriteLine("In Update");
				_iUpdatingDatabase.Run();
				break;
			case "exit":
				Console.WriteLine("Thank you for trying Soylent Green Cafe where our Customers are our specialty!");
				isWroking = false;
				break;
			default:
				Console.WriteLine("Incorrect input, please try again.");
				break;

		}
		return isWroking;
	}

}

