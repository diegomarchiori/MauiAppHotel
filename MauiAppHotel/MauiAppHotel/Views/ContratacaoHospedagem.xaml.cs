using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date?.AddDays(1) ?? DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date?.AddMonths(6) ?? DateTime.Now.AddMonths(6);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem == null)
            {
                throw new Exception("Por favor, selecione uma suíte.");
            }

            if (stp_adultos.Value == 0 && stp_criancas.Value == 0)
            {
                throw new Exception("Por favor, selecione pelo menos um hóspede.");
            }

            DateTime checkin = dtpck_checkin.Date ?? DateTime.Now;
            DateTime checkout = dtpck_checkout.Date ?? DateTime.Now.AddDays(1);

            if (checkout <= checkin)
            {
                throw new Exception("A data de check-out deve ser posterior à data de check-in.");
            }

            Quarto quarto = (Quarto)pck_quarto.SelectedItem;
            int adultos = (int)stp_adultos.Value;
            int criancas = (int)stp_criancas.Value;
            int estadia = (checkout - checkin).Days;

            double valorTotal = (estadia * (quarto.ValorDiariaAdulto * adultos)) + 
                                (estadia * (quarto.ValorDiariaCrianca * criancas));

            Navigation.PushAsync(new HospedagemContratada(quarto, adultos, criancas, checkin, checkout, estadia, valorTotal));
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (e.NewDate is DateTime data_selecionada_checkin)
        {
            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
        }
    }
}