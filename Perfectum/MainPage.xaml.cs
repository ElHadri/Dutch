using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Perfectum
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Werkwoorden Werkwoorden;
        Werkwoorden MoeilijkWerkwoorden;
        private int _position;
        private int _position2;
        private readonly Random _random = new Random();

        public MainPage()
        {
            this.InitializeComponent();
            Werkwoorden = new Werkwoorden();
            MoeilijkWerkwoorden = new Werkwoorden(); MoeilijkWerkwoorden.WerkwoordenList = new List<Werkwoord>(); // empty

            _position = _random.Next(0, Werkwoorden.WerkwoordenList.Count - 1);
            _infinitief.Text = Werkwoorden.WerkwoordenList[_position].Infinitief;
            _perfectum.Text = " ? ";

            _infinitief2.Text = "";
            _perfectum2.Text = "";
        }

        private void OnSeePerfectum(object sender, RoutedEventArgs e)
        {
            _perfectum.Text = Werkwoorden.WerkwoordenList[_position].Perfectum;
        }

        private void OnNext(object sender, RoutedEventArgs e)
        {
            _position++;
            if (_position >= Werkwoorden.WerkwoordenList.Count)
            {
                _position = 0;
            }

            _infinitief.Text = Werkwoorden.WerkwoordenList[_position].Infinitief;
            _perfectum.Text = " ? ";
        }

        private void OnRandom(object sender, RoutedEventArgs e)
        {
            _position = _random.Next(0, Werkwoorden.WerkwoordenList.Count - 1);
            _infinitief.Text = Werkwoorden.WerkwoordenList[_position].Infinitief;
            _perfectum.Text = " ? ";
        }


        private void OnSeePerfectum2(object sender, RoutedEventArgs e)
        {
            _perfectum2.Text = MoeilijkWerkwoorden.WerkwoordenList[_position2].Perfectum;
        }

        private void OnNext2(object sender, RoutedEventArgs e)
        {
            _position2++;
            if (_position2 >= MoeilijkWerkwoorden.WerkwoordenList.Count)
            {
                _position2 = 0;
            }

            _infinitief2.Text = MoeilijkWerkwoorden.WerkwoordenList[_position2].Infinitief;
            _perfectum2.Text = " ? ";
        }

        private void OnRandom2(object sender, RoutedEventArgs e)
        {
            _position2 = _random.Next(0, MoeilijkWerkwoorden.WerkwoordenList.Count - 1);
            _infinitief2.Text = MoeilijkWerkwoorden.WerkwoordenList[_position2].Infinitief;
            _perfectum2.Text = " ? ";
        }

        private void OnKeep(object sender, RoutedEventArgs e)
        {
            if (MoeilijkWerkwoorden.WerkwoordenList.Exists(werkwoord => werkwoord.Infinitief == Werkwoorden.WerkwoordenList[_position].Infinitief))
                return;

            MoeilijkWerkwoorden.WerkwoordenList.Add(Werkwoorden.WerkwoordenList[_position]);
            _position2 = MoeilijkWerkwoorden.WerkwoordenList.Count-1;
            _infinitief2.Text = MoeilijkWerkwoorden.WerkwoordenList[_position2].Infinitief;
            _perfectum2.Text = " ? ";

        }
    }
}
