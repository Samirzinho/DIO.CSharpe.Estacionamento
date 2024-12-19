using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime DataHoraEntrada { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa.ToUpper();
            DataHoraEntrada = DateTime.Now;
        }
    }
}
