using System;

namespace Fomrcosniewiem
{
    public partial class MainPage : ContentPage
    {
        private int[] KrupTab = new int[2];
        private int[] GraczTab = new int[15];
        private string kartyGracza = "";
        private int licznik = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void KrupierLos()
        {
            Random rnd = new Random();
            KrupTab[0] = rnd.Next(1,10);
            KrupTab[1] = rnd.Next(1,10);
            KrupCard1Lbl.Text = KrupTab[0].ToString();
            SemanticScreenReader.Announce(KrupCard1Lbl.Text);
        }
        private void GraczLos()
        {
            Random rnd = new Random();
            GraczTab[0] = rnd.Next(1, 10);
            licznik++;
            GraczTab[1] = rnd.Next(1, 10);
            licznik++;
            kartyGracza += GraczTab[0].ToString() + '\t';
            kartyGracza += GraczTab[1].ToString() + '\t';
            KartyGraczaLbl.Text = kartyGracza;
            TwPktLbl.Text = "Twoje Punkty: " + (GraczTab.Sum(x => x)).ToString();
            SemanticScreenReader.Announce(TwPktLbl.Text);
            SemanticScreenReader.Announce(KartyGraczaLbl.Text);
        }
        private void OnPassClicked(object sender, EventArgs e)
        {
            KrupCard2Lbl.Text = KrupTab[1].ToString();
            if((GraczTab.Sum(x => x)) > KrupTab.Sum(x=>x))
            {
                WygranaLbl.Text = "Wygrałeś! Wygrał gracz.";
                SemanticScreenReader.Announce(WygranaLbl.Text);
                DobierzBtn.IsEnabled = false;
                GrajBtn.IsEnabled = true;
                GrajBtn.Text = "Zagraj Ponownie";
                SemanticScreenReader.Announce(GrajBtn.Text);
            }
            else
            {
                WygranaLbl.Text = "Przegrałeś. Wygrał krupier";
                SemanticScreenReader.Announce(WygranaLbl.Text);
                DobierzBtn.IsEnabled = false;
                GrajBtn.IsEnabled = true;
                GrajBtn.Text = "Zagraj Ponownie";
                SemanticScreenReader.Announce(GrajBtn.Text);
            }
        }
        private void OnDobierzClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            GraczTab[licznik] = rnd.Next(1, 10);
            licznik++;
            if((GraczTab.Sum(x => x)) > 21) {
                kartyGracza += GraczTab[licznik - 1].ToString() + '\t';
                KartyGraczaLbl.Text = kartyGracza;
                SemanticScreenReader.Announce(KartyGraczaLbl.Text);
                TwPktLbl.Text = "Twoje Punkty: " + (GraczTab.Sum(x => x)).ToString();
                PassBtn.IsEnabled = false;
                DobierzBtn.IsEnabled = false;
                WygranaLbl.Text = "Przegrałeś. Wygrał krupier.";
                SemanticScreenReader.Announce(WygranaLbl.Text);
                GrajBtn.IsEnabled = true;
                GrajBtn.Text = "Zagraj Ponownie";
                SemanticScreenReader.Announce(GrajBtn.Text);
                KrupCard2Lbl.Text = KrupTab[1].ToString();
                SemanticScreenReader.Announce(KrupCard2Lbl.Text);
            }
            else
            {
                kartyGracza += GraczTab[licznik-1].ToString() + '\t';
                KartyGraczaLbl.Text = kartyGracza;
                SemanticScreenReader.Announce(KartyGraczaLbl.Text);
                TwPktLbl.Text = "Twoje Punkty: " + (GraczTab.Sum(x =>x)).ToString();
                SemanticScreenReader.Announce(TwPktLbl.Text);
            }
        }
        private void OnGrajClicked(object sender, EventArgs e)
        {
            GraczTab = new int[15];
            kartyGracza = "";
            licznik = 0;
            KrupierLos();
            KrupCard2Lbl.Text = "Ukryta karta nr. 2";
            GraczLos();
            h1Stack.IsVisible = true;
            h2Stack.IsVisible = true;
            h3Stack.IsVisible = true;
            GrajBtn.IsEnabled = false;
            PassBtn.IsEnabled = true;
            DobierzBtn.IsEnabled = true;
            WygranaLbl.Text = "";
            GrajBtn.Text = "Graj";
        }
    }
}