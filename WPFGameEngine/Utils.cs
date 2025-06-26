using System.Reflection;
using System.Windows;

namespace WPFGameEngine
{
    public static class Utils
    {
        public static void SetDropDownMenuToBeRightAligned()
        {
            var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
            setAlignmentValue();

            SystemParameters.StaticPropertyChanged += (sender, e) => setAlignmentValue();

            void setAlignmentValue()
            {
                if (SystemParameters.MenuDropAlignment && menuDropAlignmentField != null)
                    menuDropAlignmentField.SetValue(null, false);
            }
        }
    }
}
