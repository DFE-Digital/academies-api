namespace TramsDataApi.RequestModels
{
    public class AcademyTransferProjectDatesRequest
    {
        public string TransferFirstDiscussed { get; set; }
        public bool HasTransferFirstDiscussedDate { get; set; } = true;
        public string TargetDateForTransfer { get; set; }
        public bool HasTargetDateForTransfer { get; set; } = true;
        public string HtbDate { get; set; }
        public bool HasHtbDate { get; set; } = true;
    }
}