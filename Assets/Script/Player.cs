using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 max;
    public float maxSpeed;
    public float power;
    public GameObject gauge;

    float v = 0;
    float x = 0;


    public Rigidbody2D rb;


    void Start()
    {
        //max = transform.position;
        rb = GetComponent<Rigidbody2D>();
        maxSpeed=3;
        //rb.AddForce(Vector2.down * 0.01f);
        power = 2;
        gauge = transform.GetChild(0).GetChild(0).gameObject;
    }

    void Update()
    {
        if(max.y < transform.position.y)
        {
            max.y = transform.position.y;
        }
        HorizontalMove();
        Jump();
    }

    void HorizontalMove()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(h, rb.velocity.y);
        
    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            gauge.GetComponent<Image>().fillAmount = v;
            if(!gauge.activeSelf)
            {
                gauge.SetActive(true);
            }
            //print("점프");
            x = x + Time.deltaTime;
            v = math.abs(math.sin(x));
            //print(v.ToString());


        }
        else if(Input.GetButtonUp("Jump"))
        {
            print("점프");
            rb.AddForce(Vector2.down * v * power,ForceMode2D.Impulse);
            v = 0;
            x = 0;
            gauge.SetActive(false);
        }
    }
}
