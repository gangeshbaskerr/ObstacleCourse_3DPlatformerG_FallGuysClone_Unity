using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    public float threshold = 199f;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > threshold)
        {
            SceneManager.LoadScene("Scene3");
        }
    }
}
