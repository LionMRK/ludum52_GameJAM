using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public Cards card_info;

    //se a carta já foi plantada

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = card_info.image;
    }

    // Update is called once per frame
    void Update()
    {

       
      
    }

    

}
