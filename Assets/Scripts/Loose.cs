using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loose : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D any)

    {
        if (any.gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
