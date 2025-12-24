using Simulator;
using Simulator.Maps;
using Point = Simulator.Point;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSingleton<SimulationLog>(_ =>
{
    Map map = new SmallTorusMap(8, 6);

    List<IMappable> actors =
    [
        new Elf("Elrond", level: 4, agility: 9),
        new Orc("Azog", level: 4, rage: 8),
        new Animals { Description = "Rabbits", Size = 6 },
        new Birds { Description = "Eagles", Size = 6, CanFly = true },
        new Birds { Description = "Ostriches", Size = 6, CanFly = false },
    ];

    List<Point> positions =
    [
        new Point(0, 0),
        new Point(2, 2),
        new Point(4, 1),
        new Point(7, 5),
        new Point(3, 4),
    ];

    string moves = "dlrludluddlrulr";

    var sim = new Simulation(map, actors, positions, moves);
    return new SimulationLog(sim);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
