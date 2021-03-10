using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //https://www.youtube.com/watch?v=ofCLJsSUom0

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

     void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }

    }


}
