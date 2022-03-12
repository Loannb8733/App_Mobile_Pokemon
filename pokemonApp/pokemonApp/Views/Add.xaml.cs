using Plugin.Media;
using Plugin.Media.Abstractions;
using pokemonApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pokemonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {

        public Add()
        {
            InitializeComponent();
        }

        void Check(object sender, EventArgs args)
        {
            if (NameEntry.Text != "" && WeightEntry.Text != "" && HeightEntry.Text != "" && MovesEntry.Text != "" 
                && HpEntry.Text != "" && AttacksEntry.Text != "" && DefenseEntry.Text != "" && SpecialAttaksEntry.Text != "" 
                && SpecialDefenseEntry.Text != "" && SpeedEntry.Text != "")
            {
                SaveButton.IsEnabled = true;
            }
            else
            {
                SaveButton.IsEnabled = false;
            }
        }

        private async void Signed_Clicked(object sender, EventArgs e)
        {
            Pokemon pokemon = new Pokemon()
            {
                Name = NameEntry.Text,
                Weight = int.Parse(WeightEntry.Text),
                Height = int.Parse(HeightEntry.Text),
                //Picture = selectedImage.Source.GetValue(StreamImageSource.StreamProperty),
                Moves = MovesEntry.Text,
                Hp = int.Parse(HpEntry.Text),
                Attacks = int.Parse(AttacksEntry.Text),
                Defense = int.Parse(DefenseEntry.Text),
                SpecialAttacks = int.Parse(SpecialAttaksEntry.Text),
                SpecialDefense = int.Parse(SpecialDefenseEntry.Text),
                Speed = int.Parse(SpeedEntry.Text),
            };
            Database data = await Database.Instance;


            await data.AddPokemonAsync(pokemon);
            //await data.UpdateDatabseAsync(pokemon);
           
            SeeButton.IsEnabled = true;
            new MainPage();
        }

        async void Show_Clicked(object sender, EventArgs e)
        {
            Database data = await Database.Instance;
            await Navigation.PushAsync(new PokeDetails(await data.GetPokemonByNameAsync(NameEntry.Text)));
        }

        async void Handle_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Non supporté", "Votre telephone ne " +
                    "supporte pas cette fonctionnalitée", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            /*if (selectedImage == null)
            {
                await DisplayAlert("erreur", "ulvezv", "Ok");
                return;
            }*/

            //selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }
    }
}