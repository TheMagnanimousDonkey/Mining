using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronUpdate : MonoBehaviour
{
    public GameObject iron;
    public int ironCount;

    private void Start()
    {
        ironCount = 10;
        //ironText = ironText.GetComponent<GameObject>().text;
    }

    public void IronDrop(int quantity)
    {
        
        ironCount += quantity;
        iron.transform.GetChild(1).GetComponent<Text>().text = ironCount.ToString();
        //ironText.text = ironCount.ToString();
    }

    public void IronShoot()
    {
        ironCount = ironCount - 1;
        iron.transform.GetChild(1).GetComponent<Text>().text = ironCount.ToString();
    }
}
