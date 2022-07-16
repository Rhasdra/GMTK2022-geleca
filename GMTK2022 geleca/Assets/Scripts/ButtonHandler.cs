using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;

    void Start(){
        
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

    }

    public void OnRightClickArrow(){

        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow(){

        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }


}
