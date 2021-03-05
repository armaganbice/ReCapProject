using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // DRY - Dont Repeat Yourself
        public static string Added = " added";
        public static string Deleted = " deleted";
        public static string Updated = " updated";
        public static string Listed = " listed";
        public static string ById = " by Id";

        public static string CarText = "Car";
        public static string CarAdded = CarText+Added;
        public static string CarDeleted = CarText+Deleted;
        public static string CarUpdated = CarText+Updated;
        public static string CarListed =  CarText+Listed;
        public static string CarById =    CarText+ById;
        public static string CarNameInvalid = CarText + " Name is invalid";
        public static string CarDailyPriceInvalid = CarText + " Daily Price is is invalid";

        public static string MaintenanceTime = "Maintenance Time";

        public static string BrandText = "Brand";
        public static string BrandAdded = BrandText+Added;
        public static string BrandDeleted = BrandText+Deleted;
        public static string BrandUpdated = BrandText+Updated;
        public static string BrandListed = BrandText+Listed;
        public static string BrandById = BrandText+ById;

        public static string ColorAdded = "Color"+Added;
        public static string ColorDeleted = "Color"+Deleted;
        public static string ColorUpdated = "Color"+Updated;
        public static string ColorListed = "Color"+Listed;
        public static string ColorById = "Color"+ById;

        public static string UserAdded = "User" + Added;
        public static string UserDeleted = "User" + Deleted;
        public static string UserUpdated = "User" + Updated;
        public static string UserListed = "User" + Listed;
        public static string UserById = "User" + ById;

        public static string CustomerAdded = "Customer" + Added;
        public static string CustomerDeleted = "Customer" + Deleted;
        public static string CustomerUpdated = "Customer" + Updated;
        public static string CustomerListed = "Customer" + Listed;
        public static string CustomerById = "Customer" + ById;

        public static string RentalAdded = "Rental" + Added;
        public static string RentalDeleted = "Rental" + Deleted;
        public static string RentalUpdated = "Rental" + Updated;
        public static string RentalListed = "Rental" + Listed;
        public static string RentalById = "Rental" + ById;

        public static string CarImageAdded = "Car Image" + Added;
        public static string CarImageDeleted = "Car Image" + Deleted;
        public static string CarImageUpdated = "Car Image" + Updated;
        public static string CarImageListed = "Car Image" + Listed;
        public static string CarImageById = "Car Image" + ById;

        public static string CarImageCarIdInvalid = "Car Image Car Id is Invalid " ;
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded";
        public static string CarImageCountOfCarError = "Car Image Count of Car Error";
    }
}
