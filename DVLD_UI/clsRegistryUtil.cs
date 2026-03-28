using Microsoft.Win32;

public static class clsRegistryUtil
{
    private static readonly string keyPath = @"Software\DVLDApp";

    public static void SaveLogin(string username, string password)
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);

        key.SetValue("UserName", username);
        key.SetValue("Password", password); // plain text

        key.Close();
    }

    public static bool LoadLogin(ref string username, ref string password)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath);

        if (key == null)
            return false;

        object userObj = key.GetValue("UserName");
        object passObj = key.GetValue("Password");

        if (userObj == null || passObj == null)
            return false;

        username = userObj.ToString();
        password = passObj.ToString();

        key.Close();
        return true;
    }

    public static void ClearLogin()
    {
        try
        {
            Registry.CurrentUser.DeleteSubKey(keyPath, false);
        }
        catch
        {
            throw;
        }
    }
}