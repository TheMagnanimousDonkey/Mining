using System.Collections;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    private IronUpdate ironUpdate;
    private void Start()
    {
        ironUpdate = GetComponentInParent<IronUpdate>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        //destroy the object
        if (col.gameObject.CompareTag("Player"))
        {
            
            ironUpdate.IronDrop(col.GetComponent<Inventory>().Remove());
                
        }

    }
}
