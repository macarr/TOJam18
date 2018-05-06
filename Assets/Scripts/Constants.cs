using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    //tag constants
    public const string Skeleton = "Skeleton";

    //add to or update this as necessary when new scenes are added
    public const string Title = "Title";
    public const string Level1 = "Level1";
    public const string Level2 = "level2";
    public const string Level3 = "level3";
    public const string Level4 = "Level4";
    public const string Level5 = "Level5";
    public const string Level6 = "Level6";
    public const string Level7 = "Level7";
    public const string Level8 = "Level8";
    public const string EndScreen = "EndScreen";

    //other cross-class constants
    public const float WaitAfterDeath = 5f;
    public const float WaitAfterExplode = 1.5f;
    public const string LevelManager = "LevelManager";

    public static Quaternion ClampRotationToY(Quaternion rotation)
    {
        rotation.x = 0;
        rotation.z = 0;
        return rotation;
    }
}
