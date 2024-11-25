namespace MauiAppEvento.Views;

public partial class InformacaoEvento : ContentPage
{
	public InformacaoEvento()
	{
		InitializeComponent();
      /*  PropriedadesApp = (App)Application.Current;
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;*/
        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        {
            try
            {

                double numero = Convert.ToDouble(txt_numero.Text);
                double preco = Convert.ToDouble(txt_preco.Text);
                string nome = txt_nome.Text;
                string local = txt_local.Text;
                double resultado = numero * preco;
                string msg = "";


                msg = "Cadastro finalizado, para o evento:" + nome + " localizado no: " + local + " total a pagar: R$" + resultado;

                DisplayAlert("Pronto", msg, "OK");
            }

            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

}