namespace AutoYahtzee.Business
{
    public class Consts
    {
        public const int PAGE_SIZE = 9;
        public const int MAX_PAGE_BUTTONS = 3;
        public const string STORAGE_ACCOUNT = "autoyahtzeefunctions";
        public const string VIDEO_CONTAINER = "autoyahtzee-processed-video-container";
        public const string IMAGE_CONTAINER = "autoyahtzee-processed-image-container";

        public class PageTitle
        {
            public static string About { get; private set; } = "About";
            public static string LatestRolls { get; private set; } = "Latest Rolls";
            public static string Code { get; private set; } = "Code";
            public static string Hardware { get; private set; } = "Hardware";
            public static string Yahtzees { get; private set; } = "Yahtzees";
            public static string ContactMe { get; private set; } = "Contact Me";
            public static string Stats { get; private set; } = "Stats";
            public static string RollDetails { get; private set; } = "Roll Details";
            public static string Author { get; private set; } = "Author";
        }
    }
}
