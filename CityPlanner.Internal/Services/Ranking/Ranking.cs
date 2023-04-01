using System.Collections.Generic;


public float EvaluateFacilities(UserDTO firstUser, UserDTO secondUser)
{
    // Define the more important facilities
    List<string> importantFacilities = new List<string>
        { "PostOffice", "Chemist", "PublicTransportStop", "Pharmacy",
          "Supermarket", "GeneralClinicForAdults", "DentalClinic",
          "ParcelLocker", "Convenience" };

    // Calculate the score
    float score = 0;
    int count = 0;
    foreach (var property in typeof(UserDTO).GetProperties())
    {
        if (property.PropertyType == typeof(bool))
        {
            bool firstValue = (bool)property.GetValue(firstUser);
            bool secondValue = (bool)property.GetValue(secondUser);
            if (firstValue && secondValue)
            {
                count++;
                if (importantFacilities.Contains(property.Name))
                {
                    score += 2;
                }
                else
                {
                    score += 1;
                }
            }
            else if (secondValue)
            {
                if (importantFacilities.Contains(property.Name))
                {
                    score -= 4;
                }
                else
                {
                    score -= 2;
                }
            }
        }
    }

    // Normalize the score between 0 and 10
    if (count > 0)
    {
        score = (score / (count * 2)) * 10;
    }
    else
    {
        score = 10;
    }

    return score;
}
