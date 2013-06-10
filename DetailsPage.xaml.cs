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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace wp7ShareWords
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        private const string conn = @"isostore:/Frases.sdf";

        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);

                using (var ctx = new wp7ShareWordsDataContext(conn))
                {
                    var frase = ctx.Frases.FirstOrDefault(x => x.Id == index);

                    var item = new ItemViewModel
                    {
                        LineTwo = frase.Titulo,
                        LineThree = String.Format("''{0}'' \n \n {1}", frase.Frases, frase.Autor),
                    };

                    DataContext = item;
                }
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.Subject = this.PageTitle.Text;
            task.Body = ContentText.Text;
            task.Show();
        }

        private void fb_Click(object sender, EventArgs e)
        {

            ShareStatusTask shareLinkTask = new ShareStatusTask();
            shareLinkTask.Status = ContentText.Text;
            //shareLinkTask.Message = ContentText.Text;
            shareLinkTask.Show();
        }

        private void twitter_Click(object sender, EventArgs e)
        {
            ShareStatusTask shareLinkTask = new ShareStatusTask();
            // shareLinkTask.Title = this.PageTitle.Text;
            shareLinkTask.Status = ContentText.Text;
            shareLinkTask.Show();
        }
    }
}