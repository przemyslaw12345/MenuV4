using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

string connectionString = "Data Source=DESKTOP-GA3KCB6;Initial Catalog=MenuV4;Integrated Security=True;Trust Server Certificate=True";

var service = new ServiceCollection();
service.AddDbContext<MenuDbContext>(
	options => options.UseSqlServer(connectionString));
service.AddTransient<IApp, App>();
service.AddTransient<ICreatingToDatabase, CreatingToDatabase>();
service.AddTransient<IReadingFromDatabase, ReadingFromDatabase>();
service.AddTransient<IUpdatingDatabase, UpdatingDatabse>();
service.AddTransient<IDeletingFromDatabase, DeletingFromDatabase>();
service.AddTransient<IEventHandlerClass, EventHandlerClass>();

var serviceProvider = service.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();
Console.ReadLine();