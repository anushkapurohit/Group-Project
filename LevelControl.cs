using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
