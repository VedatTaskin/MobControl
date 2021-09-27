using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MultiplyPoint : MonoBehaviour
{

    public int multiplierNumber;
    public TextMeshProUGUI multiplyText;
    

    // Start is called before the first frame update
    void Awake()
    {
        multiplyText.text = 'X' + multiplierNumber.ToString(); 
        
    }


    private void OnTriggerEnter(Collider other)
    {
        int index = 0;

        if (other.gameObject.name== "Stickman(Clone)" || other.gameObject.name == "Bigman(Clone)")
        {
            for (int i = 0; i < multiplierNumber; i++)
            {
                index++;
                Vector3 newPos = new Vector3(other.transform.position.x + 0.4f * index, other.transform.position.y, other.transform.position.z);
                Instantiate(other.gameObject, newPos,Quaternion.identity);
                
            }
        }
    }

}
