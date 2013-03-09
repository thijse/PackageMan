using System.Drawing;

namespace PlatformCommon
{
    public class Defaults
    {
        public static string RepositoryUrl    = @"http://qwinapt.googlecode.com/files/appinfodb_en-US.zip";
        public static string ConfigPath       = @"config\";
        public static string DataPath         = @"d:\winApt\";
        public static string RepositoryDbFile = @"appinfodb_en-US.xml";
        public static Bitmap Background1        { get { return Properties.Resources.background1; } }
        public static Icon Icon1                { get { return Properties.Resources.Icon1; } }
        public static string AppName          = "Arduino PackageManager";
    }
}
