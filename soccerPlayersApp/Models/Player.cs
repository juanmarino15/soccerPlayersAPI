using System;
using System.Collections.Generic;

namespace soccerPlayersApp.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Name { get; set; }

    public int? JerseyNumber { get; set; }
}
