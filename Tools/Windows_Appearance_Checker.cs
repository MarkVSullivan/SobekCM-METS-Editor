using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace DLC.Tools
{
    public class Windows_Appearance_Checker
    {
        private static bool checkedTheme;
        private static bool isXP;
        static Windows_Appearance_Checker()
        {
            checkedTheme = false;
            isXP = false;
        }

        public static bool is_XP_Theme
        {
            get
            {
                if (checkedTheme)
                {
                    return isXP;
                }
                else
                {
                    try
                    {
                        string keyName = @"Control Panel\Appearance";
                        RegistryKey regKey = Registry.CurrentUser.CreateSubKey(keyName);
                        if (regKey.GetValue("Current", "Windows Standard").ToString() == "Windows Standard")
                        {
                            isXP = false;
                        }
                        else
                        {
                            isXP = true;
                        }
                    }
                    catch
                    {
                        isXP = false;
                    }

                    return isXP;
                }
            }
        }
    }
}
