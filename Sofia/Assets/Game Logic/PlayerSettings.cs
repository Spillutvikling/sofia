using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * In the future the purpose of this class is to load and store presistent player settings. But atm it only last during the runtime of the application. = P
 * TODO: Serialize
 */
public static class PlayerSettings
{

    public static string Game_Nick = "Loldude";
    public static int Game_Players = 2;
    public static int Graphics_MaxFPS = 200;

    public static string MM_Server = "eu1-mm.unet.unity3d.com";


    public static void Load()
    {
        throw new NotImplementedException();
    }

    public static void Save()
    {
        throw new NotImplementedException();
    }

}
