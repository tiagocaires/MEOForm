namespace Web.UI.Models
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}
