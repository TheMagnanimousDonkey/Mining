using System.Collections;
using UnityEngine;

public class TileDropController : MonoBehaviour
{

    public ItemClass itm;
    private void OnTriggerEnter2D(Collider2D col)
    {
        //destroy the object
        if (col.gameObject.CompareTag("Player"))
        {
            if(col.GetComponent<Inventory>().Add(itm))
            Destroy(this.gameObject);
        }
       
    }
}
