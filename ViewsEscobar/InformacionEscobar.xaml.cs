using EscobarMoyanoExamenP3.ModelEscobar;
using Microsoft.Maui.Controls;
using System.Text.Json.Serialization;

namespace EscobarMoyanoExamenP3.ViewsEscobar;

public partial class InformacionEscobar : ContentPage
{
	public InformacionEscobar()
	{
		InitializeComponent();
	}


    private async void Button_Clicked(object sender, EventArgs e)

    {
        string Nombre = nom.Text;
        string Planeta = pla.Text;

        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {

            using (var client = new HttpClient())
            {
                string url = $"https://swapi.dev/api/people/4/" + nombre + planeta ;

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var name = JsonConverter.DeserializeObject<Rootobject>(json);

                    filmsLabel.Text = name.films[0].main;
                    genderLabel.Text = name.gender[0].main;
                    heightLabel.Text = name.height[0].main;

                }

            }
        }
    }
}