using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.Repository;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.Data.Utility;
using Xunit;

namespace Tavisca.Tripster.Tests
{
    public class BaseRepositoryTests
    {
        private List<Trip> Trips = TripCollection.GetTrips();
        private Trip _trip = new Trip
        {
            Id = new Guid(),
            Source = new Stop
            {
                StopId = "stop123",
                Name = "Mumbai",
                Location = new Location
                {
                    Latitude = 90.323,
                    Longitude = 100.2341
                },
                Arrival = "10:00",
                Departure = "12:00",
                Places = new List<Place>
                    {
                        new Place
                        {
                            PlaceId = "place12345",
                            Name = "Gateway",
                            Location = new Location
                            {
                                Latitude = 90.1221,
                                Longitude = 100.0232
                            },
                            Description = "Gateway of India",
                            Arrival = "10:15",
                            Departure = "10:30",
                            PlaceType = "Attraction"
                        }
                    }
            },
            Destination = new Stop
            {
                StopId = "stop1234",
                Name = "Pune",
                Location = new Location
                {
                    Latitude = 90.3781,
                    Longitude = 100.2399
                },
                Arrival = "13:00",
                Departure = "14:00",
                Places = new List<Place>
                    {
                        new Place
                        {
                            PlaceId = "place123456",
                            Name = "Fort",
                            Location = new Location
                            {
                                Latitude = 90.37927,
                                Longitude = 100.2402
                            },
                            Description = "Gateway of India",
                            Arrival = "13:15",
                            Departure = "13:30",
                            PlaceType = "Attraction"
                        }
                    }
            },
            Stops = new List<Stop>
                {
                   new Stop
                   {
                       StopId = "123456",
                       Name = "Lonavala",
                       Arrival = "12:15",
                       Departure = "12:30",
                       Location = new Location
                       {
                           Latitude = 90.345678,
                           Longitude = 100.2345612
                       },
                       Places = new List<Place>
                        {
                            new Place
                            {
                                PlaceId = "place12345678",
                                Name = "Tiger Point",
                                Location = new Location
                                {
                                    Latitude = 90.34567821,
                                    Longitude = 100.234561212
                                },
                                Description = "Tiger Fall",
                                Arrival = "12:20",
                                Departure = "12:30",
                                PlaceType = "Attraction"
                            }
                        }
                   }
                },
            Mileage = 20
        };
        [Fact]
        public void Create_Trip_Calls_AddTrip()
        {
            var mockTripRepository = new Mock<BaseRepository<Trip>>();
            mockTripRepository.Setup(x => x.Add(_trip));
            mockTripRepository.Object.Add(_trip);
            mockTripRepository.Verify(x => x.Add(_trip), Times.Once);
        }

    }
}
