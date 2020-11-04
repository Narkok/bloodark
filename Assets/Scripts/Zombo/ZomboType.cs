using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZomboType
{
    Default
}


public static class ZomboTypeExtension
{

    public static string ZomboPath(this ZomboType type)
    {
        switch (type)
        {
            case ZomboType.Default: { return Constants.Resources.Zomb; }
            default: return "";
        }
    }
}