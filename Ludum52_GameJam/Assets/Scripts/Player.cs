using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CardObject[] hand;
    public Transform[] hand_positions;

    public GameObject holded_card;
    public bool is_holdind;

    public RaycastHit2D raycast;
    // Start is called before the first frame update
    void Start()
    {
        is_holdind = false;

        hand = new CardObject[6];
    }

    // Update is called once per frame
    void Update()
    {

        

        raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward);

        if (raycast)
        {
            if (raycast.collider.gameObject.CompareTag("Card"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Click(raycast.collider.gameObject);
                }

            }
        }


        if(is_holdind)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            holded_card.transform.position = pos;
        }
    }

    void Click(GameObject card)
    {
        //foi clicado

        holded_card = card;
        is_holdind = true;
    }
}
