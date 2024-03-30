﻿using System.Dynamic;

namespace WineSite.Data
{
    public static  class Constants
    {
        public const string errorMessage = "Price per bottle must be a positive number and less than 500 leva!";

        public static  class Wine
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const int CountryMaxLength = 20;
            public const int CountryMinLength = 4;

            public const int ManufucturerMaxLength = 70;
            public const int ManufucturerMinLength = 4;

            public const int ImporterMaxLength = 60;
            public const int ImporterMinLength = 4;

            public const int SortMaxLength = 70;
            public const int SortMinLength = 4;

            public const int MaxPricePerBottle = 500;
        }

        public static class Type
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class More
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const int NameSpecificsMaxLength = 50;
            public const int NameSpecificsMinLength = 10;

            public const int NotesMaxLength = 50;
            public const int NotesMinLength = 5;
        }

        public static class Events
        {
            public const int AdressMaxLength = 50;
            public const int AdressMinLength = 10;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 20;

            public const int WineListMaxLength = 1000;
            public const int WineListMinLength = 20;

            public const int FeaturesMaxLength = 1000;
            public const int FeaturesMinLength = 20;

            public const int PreferencesMaxLength = 1000;
            public const int PreferencesMinLength = 20;

            public const int MoreInformationMaxLength = 200;
            public const int MoreInformationMinLength = 20;

            public const int HostNameMaxLength = 50;
            public const int HostNameMinLength = 5;
        }

        public static class ApplicationUser
        {
            //FirstName
            public const int UserFirstNameMaxLength = 12;
            public const int UserFirstNameMinLength = 1;

            //LastName
            public const int UserLastNameMaxLength = 15;
            public const int UserLastNameMinLength = 3;
        }
    }
}
