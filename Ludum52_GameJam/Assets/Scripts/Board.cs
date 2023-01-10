using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour 
{
    public static Board board;

    public GameObject[,] map;
    public GameObject[,] ground;

    private void Awake()
    {
        board = this;
        map = new GameObject[4, 4];
        ground = new GameObject[4, 4];
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 4; x++)
        {
            for(int y = 0; y < 4; y++)
            {
                ground[x, y] = board.transform.GetChild(x+y).gameObject;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanPlace(GameObject location)
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (location == ground[x,y])
                {
                    if (map[x, y] == null)
                    {
                        return true;
                    }

                }
            }
        }
        return false;
    }

    public void AddCard(GameObject card, GameObject location)
    {

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if(location == ground[x,y])
                {
                    map[x, y] = card;
                }

            }
        }
    }
}
