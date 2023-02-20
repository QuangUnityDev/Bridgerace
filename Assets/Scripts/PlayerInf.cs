using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInf : MonoBehaviour
{
    [Header("Color Player")]
    public TypePlayer typePlayerColor = TypePlayer.PlayerGreen;

    public enum TypePlayer
    {
        PlayerRed = 0,
        PlayerBlue = 1,
        PlayerGreen = 2,
        PlayerYellow = 3
    }
}
