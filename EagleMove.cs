using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    public float runSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * runSpeed * Time.deltaTime;
    }
}
