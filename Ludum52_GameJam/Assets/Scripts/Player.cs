using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player : MonoBehaviour
{
    public List<GameObject> hand;
    public Transform[] hand_positions;
    public GameObject prefabCard;

    public GameObject holded_card;
    public bool is_holdind;

    public RaycastHit2D raycast;

    public Vector2 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        is_holdind = false;

        for(int i = 0; i < 6; i++)
        {
            hand.Add(GameObject.Instantiate(prefabCard));
            hand[i].transform.position = hand_positions[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(mouse.x, mouse.y, 0);

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
            else if (raycast.collider.gameObject.CompareTag("Ground"))
            {
                Debug.Log("raio no chao");
                if (is_holdind)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject ground;
                        ground = raycast.collider.gameObject;
                        if (ground.transform.parent.GetComponent<Board>().CanPlace(ground))
                        {
                            ground.transform.parent.GetComponent<Board>().AddCard(holded_card, ground);
                            holded_card.gameObject.transform.position = ground.transform.position;
                            holded_card = null;
                            is_holdind = false;
                            hand.Remove(holded_card);
                        }

                    }
                }
            }
        }


        if(is_holdind)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            holded_card.transform.position = pos;
            holded_card.GetComponent<BoxCollider2D>().enabled = false;

            if(Input.GetMouseButton(1))
            {
                holded_card.GetComponent<BoxCollider2D>().enabled = true;
                holded_card.transform.position = oldPos;
                is_holdind = false;
                holded_card = null;
            }
        }
    }

    void Click(GameObject card)
    {
        //foi clicado


        if(!is_holdind)
        {
            oldPos = card.transform.position;
            holded_card = card;
            is_holdind = true;
        }

        //if(hand.Contains(card))
        //{
        //    oldPos = hand.transform.position;
        //}
        //oldPos = hand.(card).transform.position


        
    }
}
