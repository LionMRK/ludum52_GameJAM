using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HarvestCard", menuName = "cards/HarvestCard")]
public class HarvestCards : Cards
{

    public TetrisBlocks direction;

    public List<PlantCards> cards;

    public int multiplier;
    public int multiplier_plague;

    public int points;
    public int points_plague;

    public bool repel;

    public Vector2 position;

}
