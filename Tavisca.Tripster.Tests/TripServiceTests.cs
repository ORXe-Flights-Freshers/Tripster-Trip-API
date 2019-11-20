using Shouldly;
using System;
using System.Collections.Generic;
using Tavisca.Tripster.Contracts.Entity;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;
using Xunit;

namespace Tavisca.Tripster.Tests
{
    public class TripServiceTests
    {
        private TripService _tripService;
        private TripResponse _tripResponse;
        private TripRepository _tripRepository;
        private Trip _trip = new Trip
        {
            Id = new Guid("f89fa128-ec74-4172-9eb4-5817b17b6aef"),
            Source = new Stop
            {
                StopId = "ChIJwe1EZjDG5zsRaYxkjY_tpF0",
                Name = "Mumbai",
                Location = new Location
                {
                    Latitude = 19.0759837,
                    Longitude = 72.877655900000036
                },
                Arrival = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                Departure = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                Hotels = new List<Hotel>
                    {
                        new Hotel
                        {
                            PlaceId = null,
                            Name = "शिव स्मारक",
                            Description = "Mumbai",
                            Location = new Location
                            {
                                Latitude = 19.0759836,
                                Longitude = 2.877655799999957
                            },
                            PlaceType = "Attraction",
                            Arrival = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            Departure = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            ImageUrl = null
                        },
                         new Hotel
                        {
                            PlaceId = "3828088",
                            Name = "FabHotel Palace Residency",
                            Description = "L.G.C. 17, 1/1, Lal Bahadur Shastri Marg,",
                            Location = new Location
                            {
                                Latitude = 19.07154,
                                Longitude = 72.87595
                            },
                            PlaceType = null,
                            Arrival = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            Departure = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            ImageUrl = null
                        },
                         new Hotel
                        {
                            PlaceId = "2077668",
                            Name = "GSK Hotel",
                            Description = "162-A Lal Bahadur Shastri Marg,",
                            Location = new Location
                            {
                                Latitude = 19.0674,
                                Longitude = 72.87489
                            },
                            PlaceType = null,
                            Arrival = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            Departure = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            ImageUrl = null
                        },
                         new Hotel
                        {
                            PlaceId = "3828088",
                            Name = "FabHotel Palace Residency",
                            Description = "L.G.C. 17, 1/1, Lal Bahadur Shastri Marg,",
                            Location = new Location
                            {
                                Latitude = 19.07154,
                                Longitude = 72.87595
                            },
                            PlaceType = null,
                            Arrival = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            Departure = "Mon Nov 11 2019 11:00:23 GMT+0530 (India Standard Time)",
                            ImageUrl = null
                        }
                    },
                Attractions = {}
            },
            Destination = new Stop
            {
                StopId = "hIJZ_YISduC-DkRvCxsj-Yw40M",
                Name = "Kolkata",
                Location = new Location
                {
                    Latitude = 22.572646,
                    Longitude = 88.363894999999957
                },
                Arrival = "Wed Nov 13 2019 04:48:13 GMT+0530 (India Standard Time)",
                Departure = "Wed Nov 13 2019 04:48:13 GMT+0530 (India Standard Time)",
                Hotels = { },
                Attractions = {}
            },
            Stops = new List<Stop>
            {
              new Stop
              {
                   StopId = "ChIJRYHfiwkB6DsRWIbipWBKa2k",
                   Name = "Lonavla",
                   Location = new Location
                   {
                      Latitude = 18.7557237,
                      Longitude = 73.409075700000017
                   },
                   Arrival = "Mon Nov 11 2019 12:44:05 GMT+0530 (India Standard Time)",
                   Departure = "Mon Nov 11 2019 12:44:04 GMT+0530 (India Standard Time)",
                   Hotels = { },
                   Attractions = {}
                }    
              },
            Mileage = 22
        };

        [Fact]
        public void GetTripById_returns_a_valid_trip()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("f89fa128-ec74-4172-9eb4-5817b17b6aef");
            var trip =  _tripService.GetTripById(id).Result;
            trip.IsSuccess.ShouldBe(true);
        }
        [Fact]
        public void GetTripById_returns_null()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("f89fa128-ec74-4172-9eb4-5817b17b6aee");
            var trip = _tripService.GetTripById(id).Result;
            trip.IsSuccess.ShouldBe(false);
        }
    }
}
