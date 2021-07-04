using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed = 1;
    public int xMove = 1;
    // 1  = ขวา -1 = ซ้าย
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(xMove,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * speed;
        if (hit.distance < 0.7f)
        {
            Flip();
            if (hit.collider.tag=="Player")
            {
                Destroy(hit.collider.gameObject);
                Application.LoadLevel("Death");
            }
        }
    }
    void Flip()
    {
        if (xMove>0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    }
}
