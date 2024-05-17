using Application.Core.Domain;

namespace WebApi.DTO.Request
{
    public class ProgramApplicationDTO
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public PersonalInfoPreferenceDTO PersonalInfoPreference { get; set; }
        public QuestionCollection Questions { get; set; }
    }
}
