using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections;
using System.Collections.ObjectModel;


namespace wp7ShareWords
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const string conn = @"isostore:/Frases.sdf";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            CategoriasStart();
            //   this.Loaded += new RoutedEventHandler(ConsultarServer);

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public void CategoriasStart()
        {
            using (var ctx = new wp7ShareWordsDataContext(conn))
            {
                ListaCategorias.ItemsSource = ctx.Categorias.ToList();
            }
        }

        //Get data server
        private void ConsultarServer(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri("http://localhost:51108/api/values"));
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string data = e.Result;
            Console.Write(data);
            Console.ReadLine();
            // do something with the feed here
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;


            var fraseId = ((wp7ShareWords.ItemViewModel)(MainListBox.SelectedItem)).LineId;



            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + fraseId, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.Items = new ObservableCollection<ItemViewModel>();

            using (var ctx = new wp7ShareWordsDataContext(conn))
            {
                Random rnd = new Random();

                var frases = ctx.Frases.OrderBy(x => rnd.Next()).ToList().Take(8);

                foreach (var item in frases.ToList())
                {
                    this.Items.Add(new ItemViewModel()
                {
                    LineId = item.Id,
                    LineOne = item.Titulo,
                    LineTwo = item.Autor
                });
                }
            }



            if (!App.ViewModel.IsDataLoaded)
            {

                App.ViewModel.LoadData(Items.ToList());
            }
        }

        private void ListaCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaCategorias.SelectedIndex == -1)
                return;

            if (ListaCategorias.SelectedIndex > 0)
            {
                var code = ListaCategorias.SelectedIndex;
                var categoriaSelected = ((wp7ShareWords.Categoria)(ListaCategorias.SelectedItem)).Nome;


                this.Items = new ObservableCollection<ItemViewModel>();

                using (var ctx = new wp7ShareWordsDataContext(conn))
                {
                    var listWords = ctx.Frases.Where(x => x.Categoria_Id == Convert.ToInt32(code));

                    var count = listWords.Count();

                    foreach (var item in listWords.ToList())
                    {
                        this.Items.Add(new ItemViewModel()
                        {
                            LineId = item.Id,
                            LineOne = item.Titulo,
                            LineTwo = item.Autor,
                        });
                    }

                    MainListBox.ItemsSource = this.Items;
                }
            }

        }
    }



}