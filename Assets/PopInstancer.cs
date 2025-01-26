using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopInstancer : MonoBehaviour
{
    float count;
    [SerializeField] AudioSource sfx;
    private void Start()
    {
        count = 0f;
        sfx.Play();        
    }
    private void Update()
    {
        if (count >40)
        {
            Destroy(gameObject);
        }
        count++;
    }
}
