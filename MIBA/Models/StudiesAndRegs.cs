namespace MIBA.Models
{
    public class StudiesAndRegs
    {
        public Studies Studies { get; set; }
        public RegistrationPhys RegistrationPhys { get; set; }
        public RegistrationJudic RegistrationJudic { get; set; }
        public Feedback Feedback { get; set; }

        public IList<Feedback> Feedbacks { get; set; }
        public IList<Documents> Documents { get; set; }
    }
}
