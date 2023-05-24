using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public IntVariable Score;

    public void AddScore(int points)
    {
        Score.Value += points;
    }
}
