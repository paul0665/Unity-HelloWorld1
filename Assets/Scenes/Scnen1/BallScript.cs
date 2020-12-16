using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    public float speed = 0.01f;
    private void OnTriggerExit(Collider other)
    {
        ball.GetComponent<Renderer>().material.color = Color.white;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("GreenZone"))
            ball.GetComponent<Renderer>().material.color = Color.green;
        if (other.tag.Equals("RedZone"))
            ball.GetComponent<Renderer>().material.color = Color.red;
    }
    void Update()
    {
        InputManager();
    }
    
    private void InputManager()
    {
        if (Input.GetKey (KeyCode.W))
            ball.transform.Translate (0,1* speed, 0);
        if (Input.GetKey (KeyCode.S))
            ball.transform.Translate (0,-1* speed, 0);
        if (Input.GetKey (KeyCode.A))
            ball.transform.Translate (-1* speed ,0,0);
        if (Input.GetKey (KeyCode.D))
            ball.transform.Translate (1* speed ,0,0);
    }
}
