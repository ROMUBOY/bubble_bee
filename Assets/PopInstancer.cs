using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopInstancer : MonoBehaviour
{
    float count;
    private void Start()
    {
        count = 0f;
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
