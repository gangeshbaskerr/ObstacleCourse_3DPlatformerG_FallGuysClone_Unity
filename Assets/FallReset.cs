using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    public float threshold = -50f;


    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < threshold)
        {
            GameManager.inst.gameOver();
        } 
    }
}
