namespace Web.UI.Models
{
    public class FormViewModel
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public PersonViewModel Person { get; set; }
        public List<AnswerViewModel> Answers { get; set; } = new List<AnswerViewModel>();
    }
}
