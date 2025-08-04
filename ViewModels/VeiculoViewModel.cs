using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPessoaMVVM.Models;
using WpfPessoaMVVM.Services;

namespace WpfPessoaMVVM.ViewModels
{
    public class VeiculoViewModel : INotifyPropertyChanged
    {
        private string _marca;
        public string Marca
        {
            get => _marca;
            set
            {
                if (_marca != value)
                {
                    _marca = value;
                    NotifyPropertyChanged("Marca");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        public ICommand BuscarVeiculos { get; set; }

        

        public VeiculoViewModel()
        {
            BuscarVeiculos = new RelayCommand(ObterVeiculos);
        }

        private void ObterVeiculos(object obj)
        {
            var veiculosList = new Veiculo().ObterVeiculos(Marca);
            Veiculos = new ObservableCollection<Veiculo>(veiculosList);
            NotifyPropertyChanged("Veiculos");
        }

        public void NotifyPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
