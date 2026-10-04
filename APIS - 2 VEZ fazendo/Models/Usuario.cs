using System;
using System.Collections.Generic;

namespace APIS___2_VEZ_fazendo.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;
    public int Idade { get; set; }

    public int Serie { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;
}
