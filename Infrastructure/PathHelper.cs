using System;

namespace crm_tgui.Infrastructure;

public static class PathHelper
{
    public static string GetPath()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var appPath = Path.Combine(path, "crm-tgui");

        if (!Directory.Exists(appPath))
        {
            Directory.CreateDirectory(appPath);
        }

        var dbPath = Path.Combine(appPath, "crm-tgui.db");

        return dbPath;
    }
}
