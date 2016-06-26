using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncTest.Models
{
    internal class MainModel : BaseModel
    {
        private string _responseText;

        public string ResponseText
        {
            get { return _responseText; }
            set
            {
                _responseText = value;
                OnPropertyChanged();
            }
        }

        protected override async void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
        {
            ResponseText = "Loading, please wait...";

            try
            {
                // Wait for testing...
                await Task.Delay(TimeSpan.FromSeconds(3));

                using (var client = new HttpClient())
                {
                    var responseMessage = await client.GetAsync("http://jsonplaceholder.typicode.com/posts/1");

                    if (responseMessage.IsSuccessStatusCode)
                        ResponseText = await responseMessage.Content.ReadAsStringAsync();
                    else
                        ResponseText = $"StatusCode: {responseMessage.StatusCode}";
                }
            }
            catch (Exception exception)
            {
                ResponseText = exception.ToString();
            }
        }
    }
}