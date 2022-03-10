using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Space pressed");
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            print("A pressed");
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("D pressed");
        }
    }
}
