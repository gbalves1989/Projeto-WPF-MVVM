using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfPessoaMVVM.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public short Ano { get; set; }

        public List<Veiculo> ObterVeiculos()
        {
            return new List<Veiculo>
            {
                new Veiculo { Id = 1, Nome = "FUSCA", Modelo = "VOLKSWAGEN", Ano = 1975 },
                new Veiculo { Id = 2, Nome = "CIVIC", Modelo = "HONDA", Ano = 2020 },
                new Veiculo { Id = 3, Nome = "ONIX", Modelo = "CHEVROLET", Ano = 2019 },
                new Veiculo { Id = 4, Nome = "COROLLA", Modelo = "TOYOTA", Ano = 2021 }
            };
        }

        public List<Veiculo> ObterVeiculos(string filtro)
        {
            var listaVeiculos = ObterVeiculos();
            var listaFiltrada = from c in listaVeiculos where c.Nome.ToUpper().Contains(filtro.ToUpper()) select c;
        
            return listaFiltrada.ToList();
        }
    }
}
