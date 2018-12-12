using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace NotiFit.Helpers
{

    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        #region Setting URL

        private const string url = "url_key";
        private static readonly string urlDefault = string.Empty;




        public static string Url
        {
            get
            {
                return AppSettings.GetValueOrDefault(url, urlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(url, value);
            }
        }
        #endregion      
        #region Setting Name

        private const string name = "name_key";
        private static readonly string nameDefault = string.Empty;




        public static string Name
        {
            get
            {
                return AppSettings.GetValueOrDefault(name, nameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(name, value);
            }
        }
        #endregion
        #region Setting TruckWAStatus

        private const string truckwastatus = "truckwastatus_key";
        private static readonly string truckwastatusDefault = string.Empty;




        public static string TruckWAStatus
        {
            get
            {
                return AppSettings.GetValueOrDefault(truckwastatus, truckwastatusDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(truckwastatus, value);
            }
        }
        #endregion

        #region Setting DestinationLon

        private const string destlon = "destlon_key";
        private static readonly string destlonDefault = string.Empty;

        public static string DestLon
        {
            get
            {
                return AppSettings.GetValueOrDefault(destlon, destlonDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(destlon, value);
            }
        }
        #endregion


        #region Setting DestLat

        private const string destlat = "destlat_key";
        private static readonly string destlatDefault = string.Empty;

        public static string DestLat
        {
            get
            {
                return AppSettings.GetValueOrDefault(destlat, destlatDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(destlat, value);
            }
        }
        #endregion


        #region Setting CurrentLon

        private const string currentlon = "destlon_key";
        private static readonly string currentlonDefault = string.Empty;

        public static string CurrentLon
        {
            get
            {
                return AppSettings.GetValueOrDefault(currentlon, currentlonDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(currentlon, value);
            }
        }
        #endregion


        #region Setting CurrentLat

        private const string currentlat = "currentlat_key";
        private static readonly string currentlatDefault = string.Empty;

        public static string CurrentLat
        {
            get
            {
                return AppSettings.GetValueOrDefault(currentlat, currentlatDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(currentlat, value);
            }
        }
        #endregion


        #region Setting Status

        private const string status = "status_key";
        private static readonly string statusDefault = string.Empty;

        public static string Status
        {
            get
            {
                return AppSettings.GetValueOrDefault(status, statusDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(status, value);
            }
        }
        #endregion

        #region Setting ProjectName

        private const string projectname = "projectname_key";
        private static readonly string projectnameDefault = string.Empty;

        public static string ProjectName
        {
            get
            {
                return AppSettings.GetValueOrDefault(projectname, projectnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(projectname, value);
            }
        }
        #endregion

        #region Setting LicensePlate

        private const string licenseplate = "projectname_key";
        private static readonly string licenseplateDefault = string.Empty;

        public static string LicensePlate
        {
            get
            {
                return AppSettings.GetValueOrDefault(licenseplate, licenseplateDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(licenseplate, value);
            }
        }
        #endregion



        #region Setting SourceLon

        private const string sourcelon = "sourcelon_key";
        private static readonly string sourcelonDefault = string.Empty;

        public static string SourceLon
        {
            get
            {
                return AppSettings.GetValueOrDefault(sourcelon, sourcelonDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(sourcelon, value);
            }
        }
        #endregion


        #region Setting SourceLat

        private const string sourcelat = "sourcelat_key";
        private static readonly string sourcelatDefault = string.Empty;

        public static string SourceLat
        {
            get
            {
                return AppSettings.GetValueOrDefault(sourcelat, sourcelatDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(sourcelat, value);
            }
        }
        #endregion


        #region Setting QRCode

        private const string qrcode = "qrcode_key";
        private static readonly string qrcodeDefault = string.Empty;




        public static string QRCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(qrcode, qrcodeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qrcode, value);
            }
        }
        #endregion
        #region Setting AddressName

        private const string addressname = "address_key";
        private static readonly string addressnameDefault = string.Empty;




        public static string AddressName
        {
            get
            {
                return AppSettings.GetValueOrDefault(addressname, addressnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(addressname, value);
            }
        }
        #endregion

        #region Setting Email

        private const string email = "email_key";
        private static readonly string emailDefault = string.Empty;




        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(email, emailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(email, value);
            }
        }
        #endregion
        #region Setting Password

        private const string password = "password_key";
        private static readonly string passwordDefault = string.Empty;




        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(password, passwordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(password, value);
            }
        }
        #endregion
        #region Setting Gender

        private const string gender = "gender_key";
        private static readonly string genderDefault = string.Empty;




        public static string Gender
        {
            get
            {
                return AppSettings.GetValueOrDefault(gender, genderDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(gender, value);
            }
        }
        #endregion
        #region Setting PhoneNo

        private const string phoneNo = "phoneNo_key";
        private static readonly string phoneNoDefault = string.Empty;




        public static string PhoneNo
        {
            get
            {
                return AppSettings.GetValueOrDefault(phoneNo, phoneNoDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(phoneNo, value);
            }
        }
        #endregion
        #region Setting DOB

        private const string dob = "dob_key";
        private static readonly string dobDefault = string.Empty;

        public static string DOB
        {
            get
            {
                return AppSettings.GetValueOrDefault(dob, dobDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(dob, value);
            }
        }
        #endregion
        #region Setting ProfilePicture

        private const string profilepicture = "profilepicture_key";
        private static readonly string profilepictureDefault = string.Empty;




        public static string ProfilePicture
        {
            get
            {
                return AppSettings.GetValueOrDefault(profilepicture, profilepictureDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(profilepicture, value);
            }
        }
        #endregion      
        #region Setting Address

        private const string address = "address_key";
        private static readonly string addressDefault = string.Empty;




        public static string Address
        {
            get
            {
                return AppSettings.GetValueOrDefault(address, addressDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(address, value);
            }
        }
        #endregion
        #region Setting TokenCode

        private const string tokenCode = "tokenCode_key";
        private static readonly string tokenCodeDefault = string.Empty;




        public static string TokenCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenCode, tokenCodeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenCode, value);
            }
        }
        #endregion             
        #region IsLoggedIn

        private const string isLoggedIn = "isLoggedIn_key";
        private static readonly bool isLoggedInDefault = false;


        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault("isLoggedIn", isLoggedInDefault);
            }
            set
            { AppSettings.AddOrUpdateValue("isLoggedIn", value); }
        }


        #endregion
        #region RememberMe

        private const string rememberme = "rememberme_key";
        private static readonly bool remembermeDefault = false;


        public static bool RememberMe
        {
            get
            {
                return AppSettings.GetValueOrDefault("rememberme", remembermeDefault);
            }
            set
            { AppSettings.AddOrUpdateValue("rememberme", value); }
        }


        #endregion
        #region Setting UserID

        private const string userid = "userid_key";
        private static readonly Int64 useridDefault = 0;




        public static Int64 UserID
        {
            get
            {
                return AppSettings.GetValueOrDefault(userid, useridDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userid, value);
            }
        }
        #endregion

        #region distanceId

        private const string distanceid = "distanceid_key";
        private static readonly int distanceidDefault = 0;
        private const string distancename = "distancename_key";
        private static readonly string distancenameDefault = "null";

        public static string DistanceName
        {
            get
            {
                return AppSettings.GetValueOrDefault(distancename, distancenameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(distancename, value);
            }
        }

        public static int DistanceId
        {
            get
            {
                return AppSettings.GetValueOrDefault(distanceid, distanceidDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(distanceid, value);
            }
        }
        #endregion

        #region weightid

        private const string weightid = "weightid_key";
        private static readonly int weightidDefault = 0;
        private const string weightname = "weightname_key";
        private static readonly string weightnameDefault = "null";

        public static string WeightName
        {
            get
            {
                return AppSettings.GetValueOrDefault(weightname, weightnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(weightname, value);
            }
        }



        public static int WeightId
        {
            get
            {
                return AppSettings.GetValueOrDefault(weightid, weightidDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(weightid, value);
            }
        }
        #endregion

        #region setreminder
        private const string setremindername = "setremindername_key";
        private static readonly string setremindernameDefault = "null";
        private const string setreminderId = "setreminderid_key";
        private static readonly int setreminderIdDefault = 0;
        public static int SetReminderId
        {
            get
            {
                return AppSettings.GetValueOrDefault(setreminderId, setreminderIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(setreminderId, value);
            }
        }
        public static string SetReminderName
        {
            get
            {
                return AppSettings.GetValueOrDefault(setremindername, setremindernameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(setremindername, value);
            }
        }
        #endregion
        #region DeliveryMethod
        private const string deliverymethodname = "deliverymethodname_key";
        private static readonly string deliverymethodDefault = "null";
        private const string deliverymethodId = "deliverymethodid_key";
        private static readonly int deliverymethodIdDefault = 0;
        public static int DeliveryMethodId
        {
            get
            {
                return AppSettings.GetValueOrDefault(deliverymethodId, deliverymethodIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(deliverymethodId, value);
            }
        }
        public static string DeliveryMethodName
        {
            get
            {
                return AppSettings.GetValueOrDefault(deliverymethodname, deliverymethodDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(deliverymethodname, value);
            }
        }
        #endregion

        #region billingreminder
        private const string billingremindername = "billingremindername_key";
        private static readonly string billingremindernameDefault = "null";
        private const string billingreminderId = "billingreminderId_key";
        private static readonly int billingreminderIdDefault = 0;
        public static string BillingReminderName
        {
            get
            {
                return AppSettings.GetValueOrDefault(billingremindername, billingremindernameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(billingremindername, value);
            }
        }
        public static int BillingReminderId
        {
            get
            {
                return AppSettings.GetValueOrDefault(billingreminderId, billingreminderIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(billingreminderId, value);
            }
        }
        #endregion
        #region SubscriptionType
        private const string subscriptionname = "subscriptionname_key";
        private static readonly string subscriptionnameDefault = "null";
        private const string subscriptionId = "subscriptionId_key";
        private static readonly int subscriptionIdDefault = 0;
        public static string SubscriptionTypeName
        {
            get
            {
                return AppSettings.GetValueOrDefault(subscriptionname, subscriptionnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(subscriptionname, value);
            }
        }
        public static int SubscriptionTypeId
        {
            get
            {
                return AppSettings.GetValueOrDefault(subscriptionId, subscriptionIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(subscriptionId, value);
            }
        }
        #endregion

        #region frequency
        private const string frequencyname = "frequencyname_key";
        private static readonly string frequencynameDefault = "null";
        private const string frequencyId = "frequencyId_key";
        private static readonly int frequencyIdDefault = 0;
        public static string FrequencyName
        {
            get
            {
                return AppSettings.GetValueOrDefault(frequencyname, frequencynameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(frequencyname, value);
            }
        }
        public static int FrequencyId
        {
            get
            {
                return AppSettings.GetValueOrDefault(frequencyId, frequencyIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(frequencyId, value);
            }
        }
        #endregion
        #region Duration
        private const string durationname = "durationname_key";
        private static readonly string durationnameDefault = "null";
        private const string durationId = "durationId_key";
        private static readonly int durationIdDefault = 0;
        public static string DurationName
        {
            get
            {
                return AppSettings.GetValueOrDefault(durationname, durationnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(durationname, value);
            }
        }
        public static int DurationId
        {
            get
            {
                return AppSettings.GetValueOrDefault(durationId, durationIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(durationId, value);
            }
        }
        #endregion

        #region price
        private const string pricename = "frequencyname_key";
        private static readonly double pricenameDefault = 0;
        public static double PriceName
        {
            get
            {
                return AppSettings.GetValueOrDefault(pricename, pricenameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(pricename, value);
            }
        }
        #endregion
        
        #region Setting CountryFlag

        private const string countryflag = "countryflag_key";
        private static readonly string countryflagDefault = string.Empty;




        public static string CountryFlag
        {
            get
            {
                return AppSettings.GetValueOrDefault(countryflag, countryflagDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(countryflag, value);
            }
        }
        #endregion

        #region Setting CountryCode

        private const string countrycode = "countrycode_key";
        private static readonly int countrycodeDefault = 0;




        public static int CountryCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(countrycode, countrycodeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(countrycode, value);
            }
        }
        #endregion

        

    }
}


