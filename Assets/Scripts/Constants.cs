using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    //tag constants
    public const string Skeleton = "Skeleton";

    //add to or update this as necessary when new scenes are added
    public const string Title = "Title";
    public const string LevelOne = "Level1";
    public const string LevelTwo = "Level2";
    public const string LevelThree = "Level3";
    public const string LevelFour = "Level4";
    public const string EndGame = "EndGame";

    //other cross-class constants
    public const float WaitAfterDeath = 5f;
    public const string LevelManager = "LevelManager";

    public static Quaternion ClampRotationToY(Quaternion rotation)
    {
        rotation.x = 0;
        rotation.z = 0;
        return rotation;
    }
}
