using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    //https://www.youtube.com/watch?v=ofCLJsSUom0

    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

}
