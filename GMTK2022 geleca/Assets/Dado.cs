using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class Dado : MonoBehaviour, IPointerClickHandler
{
    Rigidbody2D rb;
    [SerializeField] Image pips;
    [SerializeField] Image pipsCrypto;

    [SerializeField] Sprite[] spritePips;
    [SerializeField] Sprite[] spriteCrypto;
    [SerializeField] Transform otherDice;
    [SerializeField] float force;

    [SerializeField] float cooldown = 1f;
    
    float lastTick;
    int value = 6;
    int lastValue = 6;
    bool isRolling = false;

    public UnityEvent<int> Roll;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(rb.velocity.magnitude > 0.5f)
        {
            isRolling = true;
            RandomizeValue();
        }
        else
        {
            StopRolling();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RollDice();
    }

    void RollDice()
    {
        if(isRolling == true)
        {return;}

        float randomForce = Random.Range(force/1.5f, force);

        Vector2 dir = otherDice.transform.position - transform.position;
        dir = dir.normalized;

        rb.AddForce(dir * randomForce);

        rb.AddTorque(force/100f);

        lastTick = Time.time;   
    }

    void RandomizeValue()
    {
        float cd = cooldown / Mathf.Abs(rb.velocity.magnitude);

        if (Time.time - lastTick > cd)
        {
            while (value == lastValue)
            {
                value = Random.Range(0,5);
            }

            pips.sprite = spritePips[value];
            pipsCrypto.sprite = spriteCrypto[value];            

            lastTick = Time.time;
            lastValue = value;
        }
    }

    void StopRolling()
    {
        if(isRolling == false)
        {return;}

        isRolling = false;
        Roll.Invoke(value);
    }
}
