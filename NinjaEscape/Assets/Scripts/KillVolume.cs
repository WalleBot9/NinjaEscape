using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)       {        Debug.Log("collision");        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision Player");
            SceneManager.LoadScene("level1");        }    }

}
