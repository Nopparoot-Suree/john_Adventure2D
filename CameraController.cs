using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //ตัวออพเจคที่กล้องจะตาม
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player")!=null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

 
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            float x = Mathf.Clamp(player.transform.position.x,xMin,xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y,gameObject.transform.position.z);
        }
    }
}
