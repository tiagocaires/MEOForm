using Web.UI.Models;

namespace Web.UI.Utils
{
    public static class HttpClientApi
    {
        private static string _uri;

        public static void SetUri(string uri)
        {
            _uri = uri;
        }

        public static async Task<CampaignViewModel> GetCampaignActive()
        {
            CampaignViewModel campaignViewModel = new CampaignViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync($"{_uri}/api/campaign/active");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    campaignViewModel = await response.Content.ReadFromJsonAsync<CampaignViewModel>();
            }
            return campaignViewModel;
        }

        public static async Task<string> PostForm(FormViewModel form)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.PostAsJsonAsync($"{_uri}/api/campaign/{form.CampaignId}/reply-form", form);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    return "Form sent successfully!";
                return "There is a problem. Please try in a moment";
            }
        }

    }
}
