using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCube : MonoBehaviour
{
    public int lives =20;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && PlayerStats.Lives >0)
        {
            PlayerStats.Lives--;
            Destroy(other.gameObject);
        }
        else
        {
            SceneManager.LoadScene(2);
            //Game over sahnesini aç
        }
        
    }
}
