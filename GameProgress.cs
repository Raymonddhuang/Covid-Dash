using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private static GameProgress progress;
    public Vector2 lastCP;

    void Awake()
    {
        if (progress == null)
        {
            progress = this;
            DontDestroyOnLoad(progress);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}