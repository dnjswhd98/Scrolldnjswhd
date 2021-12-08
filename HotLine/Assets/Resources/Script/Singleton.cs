using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton Instance = null;
    public static Singleton GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new Singleton();

            return Instance;
        }
    }

    public enum Weapone
    {
        NONE,
        BAT,
        CLUB,
        KNIFE,
        KATANA,
        PIPE,
        CREWBAR,
        M16,
        SHOTGUN,
        DOUBLEBARREL,
        UZI
    };
}
