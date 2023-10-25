namespace Fomrcosniewiem
{
    public partial class MainPage : ContentPage
    {
        private int[] KrupTab = new int[2];
        private int[] GraczTab = new int[2];
        public MainPage()
        {
            InitializeComponent();
            KrupierLos();
            GraczLos();
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
            GraczTab[1] = rnd.Next(1, 10);
            GraczCard1Lbl.Text = KrupTab[0].ToString();
            GraczCard2Lbl.Text = KrupTab[1].ToString();
            SemanticScreenReader.Announce(GraczCard1Lbl.Text);
            SemanticScreenReader.Announce(GraczCard2Lbl.Text);
        }
        private void OnDoubleClicked(object sender, EventArgs e)
        {

        }
        private void OnHitClicked(object sender, EventArgs e)
        {

        }
        private void OnStandClicked(object sender, EventArgs e)
        {

        }
        private void OnGrajClicked(object sender, EventArgs e)
        {
            h1Stack.IsVisible = true;
            h2Stack.IsVisible = true;
            h3Stack.IsVisible = true;
        }
    }
}