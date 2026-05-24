using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    public HospedagemContratada(Quarto quarto, int adultos, int criancas, DateTime checkin, DateTime checkout, int estadia, double valorTotal)
    {
        InitializeComponent();

        lbl_quarto.Text = quarto.Descricao;
        lbl_adultos.Text = adultos.ToString();
        lbl_criancas.Text = criancas.ToString();
        lbl_checkin.Text = checkin.ToString("dd/MM/yyyy");
        lbl_checkout.Text = checkout.ToString("dd/MM/yyyy");
        lbl_estadia.Text = $"{estadia} {(estadia == 1 ? "dia" : "dias")}";
        lbl_valor_total.Text = valorTotal.ToString("C2");
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void BtnConfirmar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new ConfirmacaoPage());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}