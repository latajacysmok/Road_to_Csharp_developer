namespace AutomaticTests
{
    public class HomeViewXPath
    {
        #region Overview

        public static readonly string detailsButton = "//Button[@automationid = 'DetailsButton']";
        public static readonly string backToProductMatrixButton = "//Button[@automationid = 'BackToProductMatrixButton']";
        public static readonly string errorStatusText = "//TextBlock[@automationid = 'StatusValue']";
        public static readonly string vinNumberText = "//TextBlock[@automationid = 'VinNumber']";
        public static readonly string productNameText = "//TextBlock[@automationid = 'ProductName']";

        #endregion

        #region System messages

        public static readonly string moreButton = "//Button[@automationid = 'MoreBtn']";
        public static readonly string troubleshootingButton = "//Button[@automationid = 'TroubleshootingButton']";
        public static readonly string faultMessagesText = "//TileView/MessageItem/TextBlock[contains(text(), 'Fault messages')]"; 
        public static readonly string faultIconImg = "//TileView/MessageItem/ErrorIcon]"; 
        public static readonly string warningMessagesText = "//TileView/MessageItem/TextBlock[contains(text(), 'Warning messages')]"; 
        public static readonly string warningIconImg = "//TileView/MessageItem/WarningIcon]";
        public static readonly string serviceMessagesText = "//TileView/MessageItem/TextBlock[contains(text(), 'Service messages')]";
        public static readonly string serviceIconImg = "//TileView/MessageItem/ServiceIcon]";
        public static readonly string informationMessagesText = "//TileView/MessageItem/TextBlock[contains(text(), 'Information messages')]";
        public static readonly string informationIconImg = "//TileView/MessageItem/InfoIcon]";
        public static readonly string statusMessagesText = "//TileView/MessageItem/TextBlock[contains(text(), 'Status messages')]";
        public static readonly string statusIconImg = "//TileView/MessageItem/StatusIcon]";

        #endregion
    }
}
