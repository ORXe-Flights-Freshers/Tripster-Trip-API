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
            Id = new Guid("c17366eb-76e8-409b-a80c-e99e30e14944"),
            Source = new Stop
            {
                StopId = "ChIJL_P_CXMEDTkRw0ZdG-0GVvw",
                Name = "Delhi",
                Location = new Location
                {
                    Latitude = 28.686273800000009,
                    Longitude = 77.221783100000039
                },
                Arrival = "Fri Nov 22 2019 11:28:52 GMT+0530 (India Standard Time)",
                Departure = "Fri Nov 22 2019 11:28:52 GMT+0530 (India Standard Time)",
                Hotels = {},
                Attractions = {}
            },
            Destination = new Stop
            {
                StopId = "ChIJSecWkj2v5jkRCUy4AqpbDgE",
                Name = "Assam",
                Location = new Location
                {
                    Latitude = 27.283924,
                    Longitude = 88.659355
                },
                Arrival = "Sat Nov 23 2019 15:42:04 GMT+0530 (India Standard Time)",
                Departure = "Mon Nov 13 2090 11:37:09 GMT+0530 (India Standard Time)",
                Hotels = {},
                Attractions = {}
            },
            Stops = { },
            Mileage = 25,
            UserId = null
        };

        [Fact]
        public void GetTripById_WithValidID_Returns_a_valid_trip()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("c17366eb-76e8-409b-a80c-e99e30e14944");
            var trip =  _tripService.GetTripById(id).Result;
            trip.IsSuccess.ShouldBeTrue();
        }
        [Fact]
        public void GetTripById_WithInvalidID_Returns_null()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("d12366eb-76e8-409b-a80c-e99e30e14944");
            var trip = _tripService.GetTripById(id).Result;
            trip.IsSuccess.ShouldBeFalse();
        }
        [Fact]
        public void UpdateTrip_WithValidID_And_Model_Returns_a_valid_trip()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("c17366eb-76e8-409b-a80c-e99e30e14944");
            var updatedTrip = _tripService.UpdateTrip(id, _trip).Result;
            updatedTrip.IsSuccess.ShouldBeTrue();
        }
        [Fact]
        public void UpdateTrip_WithValidID_And_Model_Returns_null()
        {
            DatabaseSettings.ConnectionString = "mongodb://3.14.69.62:27017";
            DatabaseSettings.DatabaseName = "TripDB";
            _tripResponse = new TripResponse();
            _tripRepository = new TripRepository();
            _tripService = new TripService(_tripRepository, _tripResponse);
            var id = new Guid("f89fa128-ec74-4172-9eb4-5817b17b6aee");
            var updatedTrip = _tripService.UpdateTrip(id, _trip).Result;
            updatedTrip.IsSuccess.ShouldBeFalse();
        }
    }
}
