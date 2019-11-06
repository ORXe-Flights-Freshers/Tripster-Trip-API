using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts;
using Xunit;

namespace Tavisca.Tripster.Tests
{
    public class BaseRepositoryTests
    {
       
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
        private Trip otherTrip = new Trip
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
                   },
                    new Stop
                   {
                       StopId = "123456",
                       Name = "Khandala",
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
        //[Fact]
        //public void Create_Trip_Calls_AddTrip()
        //{
        //    var mockTripRepository = new Mock<BaseRepository<Trip>>();
        //    mockTripRepository.Setup(x => x.Add(_trip));
        //    mockTripRepository.Object.Add(_trip);
        //    mockTripRepository.Verify(x => x.Add(_trip), Times.Once);
        //}
        //[Fact]
        //public void Get_All_Returns_All_Trips()
        //{
        //    var expectedTripList = new List<Trip>();
        //    expectedTripList.Add(_trip);
        //    var mockTripRepository = new Mock<BaseRepository<Trip>>();
        //    mockTripRepository.Setup(x => x.Add(_trip));
        //    var baseRepo = new BaseRepository<Trip>();
        //    baseRepo.Add(_trip);
        //    var Trips = TripCollection.GetTrips();
        //    mockTripRepository.Setup(x => x.GetAllTrips()).Returns(Trips);
        //    baseRepo.GetAllTrips().ShouldBe(expectedTripList);
        //}
        //[Fact]
        //public void Get_Trip_By_Id()
        //{
        //    var mockTripRepository = new Mock<BaseRepository<Trip>>();
        //    mockTripRepository.Setup(x => x.Add(_trip));
        //    mockTripRepository.Object.Add(_trip);
        //    var Id = _trip.Id;
        //    mockTripRepository.Setup(x => x.GetTrip(Id)).Returns(_trip);
        //    mockTripRepository.Object.GetTrip(Id).ShouldBe(_trip);
        //    mockTripRepository.Verify(x => x.GetTrip(Id), Times.Once);
        //}

        //[Fact]
        //public void Delete_Trip_By_Id()
        //{
        //    var mockTripRepository = new Mock<BaseRepository<Trip>>();
        //    mockTripRepository.Setup(x => x.Add(_trip));
        //    mockTripRepository.Object.Add(_trip);
        //    var Id = _trip.Id;
        //    mockTripRepository.Setup(x => x.Delete(Id));
        //    mockTripRepository.Object.Delete(Id);
        //    mockTripRepository.Setup(x => x.GetTrip(Id));
        //    mockTripRepository.Object.GetTrip(Id).ShouldBe(null);
        //    mockTripRepository.Verify(x => x.Delete(Id), Times.Once);
        //    mockTripRepository.Verify(x => x.GetTrip(Id), Times.Once);
        //}
        //[Fact]
        //public void Update_Trip_Using_Trip_Id()
        //{
        //    var mockTripRepository = new Mock<BaseRepository<Trip>>();
        //    mockTripRepository.Setup(x => x.Add(_trip));
        //    mockTripRepository.Object.Add(_trip);
        //    var Id = _trip.Id;
        //    mockTripRepository.Setup(x => x.Update(Id, otherTrip));
        //    mockTripRepository.Object.Update(Id, otherTrip);
        //    mockTripRepository.Setup(x => x.GetTrip(Id)).Returns(otherTrip);
        //    mockTripRepository.Object.GetTrip(Id).ShouldBe(otherTrip);
        //    mockTripRepository.Verify(x => x.Update(Id, otherTrip), Times.Once);
        //    mockTripRepository.Verify(x => x.GetTrip(Id), Times.Once);
        //}
    }
}
