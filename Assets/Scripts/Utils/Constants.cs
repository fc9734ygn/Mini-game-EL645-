using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // Coordinates used in mapping space for leap motion coordinates to application screen.
    public const float SCREEN_START_COORDINATE_X = -17f;
    public const float SCREEN_END_COORDINATE_X = -SCREEN_START_COORDINATE_X;
    public const float LEAP_START_COORDINATE_X = -200f;
    public const float LEAP_END_COORDINATE_X = -LEAP_START_COORDINATE_X;
    public const float SCREEN_START_COORDINATE_Y = -6f;
    public const float SCREEN_END_COORDINATE_Y = 8f;
    public const float LEAP_START_COORDINATE_Y = 45f;
    public const float LEAP_END_COORDINATE_Y = 500f;
}
