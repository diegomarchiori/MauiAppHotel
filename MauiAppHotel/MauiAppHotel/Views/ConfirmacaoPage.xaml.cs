using System;

namespace MauiAppHotel.Views;

public partial class ConfirmacaoPage : ContentPage
{
    public ConfirmacaoPage()
    {
        InitializeComponent();
    }

    private void BtnVoltarInicio_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
