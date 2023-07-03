namespace AutomaticTests
{
    public class XPath
    {
        #region Introduction

        public static readonly string logoHotel = "//img[@ class = 'hotel-logoUrl']";
        public static readonly string descriptionHotel = "//div[@class = 'row hotel-description']/div[@class = 'col-sm-10']";
        public static readonly string letMeHackButton = "//button[@class = 'btn btn-primary']";

        #endregion

        #region Rooms

        public static readonly string headingBookRoomSection = "//h2[contains(text(), 'Rooms')]";
        public static readonly string imgBookRoomArticle = "//img[@class = 'img-responsive hotel-img']";
        public static readonly string headingBookRoomArticle = "//div[@class = 'col-sm-7']/h3";
        public static readonly string wheelchairIcone = "//span[@class = 'fa fa-wheelchair wheelchair']";     
        public static readonly string contentBookRoomArticle = "//div[@class = 'col-sm-7']/p";
        public static readonly string pointsBookRoomArticle = "//div[@class = 'col-sm-7']/ul"; 
        public static readonly string bookThisRoomButton = "//div[@class = 'col-sm-7']/button";

        #endregion

        #region Hotel contact details

        public static readonly string adressShadyMEadows = "//span[@class = 'fa fa-home']";
        public static readonly string adressTheOldFarmhous = "//div[@class = 'col-sm-5']/p[2]";
        public static readonly string phoneTheOldFarmhous = "//div[@class = 'col-sm-5']/p/span[@class = 'fa fa-phone']";
        public static readonly string mailTheOldFarmhous = "//div[@class = 'col-sm-5']/p/span[@class = 'fa fa-envelope']";

        #endregion

        #region Contact form

        public static readonly string nameClient = "//input[@id = 'name']";
        public static readonly string emailClient = "//input[@id = 'email']";
        public static readonly string phoneClient = "//input[@id = 'phone']";
        public static readonly string subjectClient = "//input[@id = 'subject']";
        public static readonly string descriptionClient = "//input[@id = 'description']";
        public static readonly string submitButton = "//button[@id = 'submitContact']";

        #endregion

        #region Hotel location

        public static readonly string map = "//div[@class = 'map']";

        #endregion

    }
}