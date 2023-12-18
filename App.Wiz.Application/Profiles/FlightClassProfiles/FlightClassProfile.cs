using App.Wiz.Common.ServiceViewModels.FlightClassesViewModels;

namespace App.Wiz.Application.Profiles.FlightClassProfiles;

public static class FlightClassProfile
{
    public static FlightClassViewModel PrepareViewModel(Infrastructure.Entities.FlightClasses flight)
    {
        return new()
        {
            ID = flight.ID,
            Description = flight.Description,
            FlightClassCategoryId = flight.FlightClassCategoryId,
            FlightClassCategory = flight.FlightClassCategory?.FlightClass,
            Title = flight.Title,
        };
    }

    public static FlightClassCategoryViewModel PrepareViewModel(Infrastructure.Entities.FlightClassCategory flight)
    {
        return new()
        {
            ID = flight.ID,
            FlightClass = flight.FlightClass,
        };
    }

}
