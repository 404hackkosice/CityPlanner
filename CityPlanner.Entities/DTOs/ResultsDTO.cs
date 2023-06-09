﻿using CityPlanner.Entities.Entities;

namespace CityPlanner.Entities.DTOs
{
    public class ResultsDTO
    {
        public double Score { get; set; }

        public PerTypeResultsDTO PostOfficeResults { get; set; } = new();
        public PerTypeResultsDTO ChemistResults { get; set; } = new();
        public PerTypeResultsDTO PublicTransportResults { get; set; } = new();
        public PerTypeResultsDTO PharmacyResults { get; set; } = new();
        public PerTypeResultsDTO SupermarketResults { get; set; } = new();
        public PerTypeResultsDTO GeneralClinicForAdultsResults { get; set; } = new();
        public PerTypeResultsDTO DentalClinicResults { get; set; } = new();
        public PerTypeResultsDTO ParcelLockerResults { get; set; } = new();
        public PerTypeResultsDTO ConvenienceResults { get; set; } = new();
        public PerTypeResultsDTO RestaurantResults { get; set; } = new();
        public PerTypeResultsDTO BarResults { get; set; } = new();
        public PerTypeResultsDTO PubResults { get; set; } = new();
        public PerTypeResultsDTO FastFoodResults { get; set; } = new();
        public PerTypeResultsDTO CafeResults { get; set; } = new();
        public PerTypeResultsDTO DogEnclosuresResults { get; set; } = new();
        public PerTypeResultsDTO GymResults { get; set; } = new();
        public PerTypeResultsDTO OutsideGymResults { get; set; } = new();
        public PerTypeResultsDTO PublicElementarySchoolResults { get; set; } = new();
        public PerTypeResultsDTO PrivateElementarySchoolResults { get; set; } = new();
        public PerTypeResultsDTO ReligiousElementarySchoolResults { get; set; } = new();
        public PerTypeResultsDTO PublicKindergartenResults { get; set; } = new();
        public PerTypeResultsDTO PrivateKindergartenResults { get; set; } = new();
        public PerTypeResultsDTO ReligiousKindergartenResults { get; set; } = new();
        public PerTypeResultsDTO PlaygroundResults { get; set; } = new();
        public PerTypeResultsDTO GeneralClinicForChildrenResults { get; set; } = new();

        public bool NightLife { get; set; }
        public bool ForKids { get; set; }
        public bool PetLovers { get; set; }
    }
}
