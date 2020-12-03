using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SuperheroesTriggers
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Superheroe> superheroes;

        private int _indice;
        int Indice
        {
            get
            {
                return _indice;
            }
            set
            {
                if (value >= 0 && value < superheroes.Count)
                {
                    _indice = value;
                    DataContext = superheroes[_indice];
                }
            }
        }

        public MainWindow()
        {
            superheroes = Superheroe.GetSamples();
            Indice = 0;
            InitializeComponent();
            ActualizaContador();
        }

        private void Flecha_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Indice += int.Parse((sender as Image).Tag.ToString());
            ActualizaContador();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            superheroes.Add(Resources["nuevoSuperheroe"] as Superheroe);
            Resources.Remove("nuevoSuperheroe");
            Resources.Add("nuevoSuperheroe", new Superheroe());
            ActualizaContador();
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            NombreTextBox.Text = "";
            ImagenTextBox.Text = "";
            HeroeRadioButton.IsChecked = true;
            VengadoresCheckBox.IsChecked = false;
            XmenCheckBox.IsChecked = false;
        }

        private void ActualizaContador()
        {
            ContadorTextBlock.Text = $"{Indice + 1}/{superheroes.Count}";
        }
    }
}