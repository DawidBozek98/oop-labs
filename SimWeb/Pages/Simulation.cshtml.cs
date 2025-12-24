using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Point = Simulator.Point;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    private readonly SimulationLog _log;

    public SimulationModel(SimulationLog log) => _log = log;

    [BindProperty(SupportsGet = true)]
    public int? turn { get; set; }

    public int TurnIndex { get; private set; }
    public int MaxTurn => _log.TurnLogs.Count - 1;

    public int SizeX => _log.SizeX;
    public int SizeY => _log.SizeY;

    public string Caption { get; private set; } = "";

    public void OnGet()
    {
        TurnIndex = turn ?? 0;
        if (TurnIndex < 0) TurnIndex = 0;
        if (TurnIndex > MaxTurn) TurnIndex = MaxTurn;

        var t = _log.TurnLogs[TurnIndex];
        Caption = (TurnIndex == 0) ? "Pozycje startowe" : $"{t.Mappable} → {t.Move}";
    }

    public string? GetImageFor(int x, int y)
    {
        var t = _log.TurnLogs[TurnIndex];
        var p = new Point(x, y);

        if (!t.Symbols.TryGetValue(p, out var c))
            return null;

        return c switch
        {
            'O' => "/img/ork.png",
            'E' => "/img/elf.png",
            'A' => "/img/rabbit.png",
            'B' => "/img/eagle.png",
            'b' => "/img/emu.png",
            'X' => "/img/multi.png",
            _ => null
        };
    }
}
