using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loose : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D any)

    {
    Enemy enemy = any.GetComponent<Enemy>();
        if (enemy != null)
        {

            SceneManager.LoadScene("Title");
        }

    }

}
