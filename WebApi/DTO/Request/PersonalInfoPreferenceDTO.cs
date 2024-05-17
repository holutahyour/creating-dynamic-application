using Application.Core.Domain;

namespace WebApi.DTO.Request
{
    public class PersonalInfoPreferenceDTO
    {
        public FieldPreference Phone { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
        public FieldPreference Nationality { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
        public FieldPreference CurrentResidence { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
        public FieldPreference IdNumber { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
        public FieldPreference DateOfBirth { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
        public FieldPreference Gender { get; set; } = new FieldPreference { Mandatory = false, Internal = false, Hide = false };
    }
}
