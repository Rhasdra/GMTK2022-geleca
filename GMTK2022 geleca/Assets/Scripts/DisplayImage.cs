using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisplayImage : MonoBehaviour
{
    [SerializeField] int totalWalls = 2;

    public int CurrentWall {
        get { return currentWall; }
        set
        {
            if (value == totalWalls + 1)
            currentWall = 1;
            else if(value == 0)
            currentWall = totalWalls;
            else
            currentWall = value;


        }
    }

private int currentWall;
private int previousWall;

void Start(){
    previousWall = 0;
    currentWall = 1;
}

void Update(){

    if(currentWall != previousWall){
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());




    }

    //Debug.Log(currentWall);
    previousWall = currentWall;
}

}
