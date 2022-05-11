using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            //Kameraçýsýndan dýþarý çýkan enemy ise 
            //Oku belirgin et ok düþmaný takip etsin düþman kareye girince tekrardan ok kaybolsun
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //düþman karede olduðu sürece ok kaybolsun
        }
    }
}
