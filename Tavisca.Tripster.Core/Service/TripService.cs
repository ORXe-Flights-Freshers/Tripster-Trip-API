using FluentValidation;
using System;
using System.Collections.Generic;
using Tavisca.Tripster.Contracts;
using Tavisca.Tripster.Dal;

namespace Tavisca.Tripster.Core
{
    public class TripService : ITripService
    {
        private TripUnitOfWork _tripUnitOfWork;
        private IValidator<Trip> _validator;
        public TripService(TripUnitOfWork tripUnitOfWork, RequestValidator requestValidator) 
        {
            _validator = requestValidator;
            _tripUnitOfWork = tripUnitOfWork;
        }


        public Response Add(Trip trip)
        {
            FluentValidation.Results.ValidationResult results = _validator.Validate(trip);
            if (results.IsValid)
            {
               if(_tripUnitOfWork.ValidateConnection())
                {
                    try
                    {
                        _tripUnitOfWork.Trips.Add(trip);
                        return new SucessResponse<Successinfo>(new Successinfo(SuccessCode.Created, SuccessMessage.Created));
                    }
                    catch(Exception e)
                    {  // e for logiing
                        return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
                    }

                }
                return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
            }
            return new FailureResponse<Errorinfo>( new Errorinfo(ErrorCode.BadRequest,ErrorMessages.BadRequest));
        }

       public Response Delete(Guid id)
            {
            FluentValidation.Results.ValidationResult result_id = _validator.Validate(new Trip { Id = id }, "id");
 
            if ( result_id.IsValid)
            {
                if (_tripUnitOfWork.ValidateConnection())
                {
                    try
                    {
                        _tripUnitOfWork.Trips.Delete(id);
                        return new SucessResponse<Successinfo>(new Successinfo(SuccessCode.Accepted, SuccessMessage.Accepted));
                    }
                    catch (Exception e)
                    {  // e for logiing

                        if (e.GetType() == new NotFoundException().GetType())
                        {
                            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.NotFound, ErrorMessages.NotFound));
                        }

                        return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
                    }

                }
                return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));

            }
            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.BadRequest, ErrorMessages.BadRequest));
        }
    
       public Response Get(Guid id)
          {
            FluentValidation.Results.ValidationResult results = _validator.Validate(new Trip { Id = id}, "id");
            if (results.IsValid)
            {
                if (_tripUnitOfWork.ValidateConnection())
                {
                    try
                    {
                        var result =_tripUnitOfWork.Trips.Get(id);
                        return new SucessResponse<Trip>(result);
                    }
                    catch (Exception e)
                    {  // e for logiing
                        if (e.GetType() == new NotFoundException().GetType())
                        {
                            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.NotFound, ErrorMessages.NotFound));
                        }

                        return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
                    }

                }
                return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
            }
            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.BadRequest, ErrorMessages.BadRequest));
       
            //var trip = _tripUnitOfWork.Trips.Get(id);
            //_validator.Entity = trip;
            //_validator.ID = id;
            //var transferObject = _validator.GetTransferObject();
            //return transferObject;

        }

       public Response GetAll()
            {
            if (_tripUnitOfWork.ValidateConnection())
            {
                try
                {
                   var Result= _tripUnitOfWork.Trips.GetAll();
                   return  new SucessResponse<IEnumerable<Trip>>(Result);
                }
                catch (Exception e)
                {  // e for logiing
                    return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
                }

            }
            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));

             }

       public Response Update(Guid id, Trip trip)
        {
            FluentValidation.Results.ValidationResult result_id = _validator.Validate(new Trip { Id = id }, "id");
            FluentValidation.Results.ValidationResult results = _validator.Validate(trip);
            if (results.IsValid && result_id.IsValid)
            {
                if (_tripUnitOfWork.ValidateConnection())
                {
                    try
                    {
                       _tripUnitOfWork.Trips.Update(id, trip);
                        return new SucessResponse<Successinfo>(new Successinfo(SuccessCode.Accepted, SuccessMessage.Accepted));
                    }
                    catch (Exception e)
                    {  // e for logiing
                        if(e.GetType() == new NotFoundException().GetType())
                        {
                            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.NotFound, ErrorMessages.NotFound));
                        }

                        return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));
                    }

                }
              return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.InternalServerError, ErrorMessages.InternalServerError));

            }
            return new FailureResponse<Errorinfo>(new Errorinfo(ErrorCode.BadRequest, ErrorMessages.BadRequest));
        }
    }
}

