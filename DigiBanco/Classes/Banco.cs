using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBanco.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeDoBanco = "DigiBank";
            this.CodigoDoBanco = "288";
        
        }
        public string NomeDoBanco { get; private set; }
        public string CodigoDoBanco { get; private set; }


    }
}
