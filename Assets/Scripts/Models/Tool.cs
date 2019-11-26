using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public Tool.Type toolType;

    public enum Type
    {
        Knife,
        Mortar,
        Grater,
        Hand
    }
}
