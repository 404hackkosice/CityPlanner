namespace CityPlanner.Entities.DTOs
{
    public class UserDTO
    {
        public bool WantsRestaurant { get; set; }

        public bool WantsBar { get; set; }

        public bool WantsPub { get; set; }

        public bool WantsCafe { get; set; }

        public bool WantsFastFood { get; set; }

        public bool WantsDogEnclosure { get; set; }

        public bool WantsGym { get; set; }

        public bool WantsOutsideGym { get; set; }

        public bool WantsPublicElementarySchool { get; set; }

        public bool WantsPrivateElementarySchool { get; set; }

        public bool WantsReligiousElementarySchool { get; set; }

        public bool WantsPublicKindergarten { get; set; }

        public bool WantsPrivateKindergarten { get; set; }

        public bool WantsReligiousKindergarten { get; set; }

        public ChildAspirations Children { get; set; }
    }
}
