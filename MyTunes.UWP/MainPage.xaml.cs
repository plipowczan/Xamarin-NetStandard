#region usings

using Windows.UI.Xaml.Navigation;

#endregion

namespace MyTunes
{
    public sealed partial class MainPage
    {
        #region Constructors

        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public methods

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //SongLoader.Loader = new StreamLoader();
            //this.DataContext = await SongLoader.Load();

            this.DataContext = await SongLoader.ImprovedLoad();
        }

        #endregion
    }
}