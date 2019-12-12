using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public static Color KNIFECOLOR = new Color(0.796f, 0.82f, 0.859f);
    public static Color MORTARCOLOR = new Color(0.118f, 0.396f, 0.627f);
    public static Color GRATERCOLOR = new Color(0.988f, 0.318f, 0.369f);
    public static Color HANDCOLOR = new Color(0.996f, 0.843f, 0.69f);
    public static float MAXSCREENWIDTH = 9.3f;
    public static float MAXSCREENHEIGHT = 4.8f;
    public static string PLAYER_PREF_HIGHSCORE_KEY = "Highscore";
    public static string HIGHSCORES_TEXT = "Current highscore: ";
    public static string RECIPE_0 = "Napolitana";
    public static string RECIPE_1 = "Bolognese";
    public static string RECIPE_2 = "Carbonara";
    public static string RECIPE_3 = "Aglio e Olio";
    public enum TOOLTYPE
    { 
        Knife,
        Mortar,
        Grater,
        Hand
    }
}
