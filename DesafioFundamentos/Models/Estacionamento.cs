using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine() ?? string.Empty;
            veiculos.Add(new Veiculo(placa));
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            //ToDo: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            string placa = Console.ReadLine() ?? string.Empty;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                // Localiza o veículo correspondente
                var veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());
                
                // Calcula o tempo estacionado em horas
                TimeSpan duracao = DateTime.Now - veiculo.DataHoraEntrada;
                
                // Arredonda para cima se houver fração de horas
                int horas = (int)Math.Ceiling(duracao.TotalHours); 
                
                // ToDo: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                // (horas <= 1) Cobrar apenas o valor do estacionamento, a partir de 1 hora, cobrar valores adicionais
                decimal valorTotal = precoInicial + (horas <= 1 ? 0 : precoPorHora) * horas;
                veiculos.RemoveAll(x => x.Placa.ToUpper() == placa.ToUpper());

                // Exibe o resultado
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido.");
                Console.WriteLine($"Tempo estacionado: {horas} hora(s).");
                Console.WriteLine($"Preço total: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui./n Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            //Verifica se há veiculos no estacionamento
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Todo: Realizar um laço de repetição, exibindo os veiculos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- Placa: {veiculo.Placa}, Entrada: Dia: {veiculo.DataHoraEntrada.ToString("dd/MM/yyyy")} Horas: {veiculo.DataHoraEntrada.ToString("HH:mm")}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
