using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int coins;
    public static int id;

    public static int firstMap;
    public static int secondMap;
    public static int thirdMap;

    public static bool firstMapOwned;
    public static bool secondMapOwned;
    public static bool thirdMapOwned;

    public static int firstMapPrice;
    public static int secondMapPrice;
    public static int thirdMapPrice;

    public static bool LoggedIn {get {return username != null;}}
    public static bool LoggedInCoins {get {return coins != null;}}
    public static bool LoggedInId {get {return id != null;}}

    public static void LogOut()
    {
        username = null;
    }

}
