using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawnCube : MonoBehaviour
{
    //////------------------------ Giriş Kapısı üstündeki küp rengi
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] float _lerpTime ;
    [SerializeField] float _changer;
    private void FixedUpdate()
    {
        SmoothColorTransition();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _meshRenderer.material.color = Color.green;
        }
    }
    ////----------------------------------------------------
    void SmoothColorTransition()
    {
        _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, Color.red, _lerpTime * Time.deltaTime);
        _changer = Mathf.Lerp(_changer, 1f, _lerpTime * Time.deltaTime);
        if (_changer >= 0.9f)
        {
            _changer = 0;
        }
    }
}
