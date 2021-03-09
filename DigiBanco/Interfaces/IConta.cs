using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBanco.Interfaces
{
    public interface IConta
    {
        void Deposita(double valor);
        bool Saca(double valor);
        double ConsultaSaldo();
        string GetCodigoBanco();
        string GetNumeroAgencia();
        string GetNumeroConta();


    
    }
}
