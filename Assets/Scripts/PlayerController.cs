﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count = 0; // count of objects collected

	void Start() {
        rb = GetComponent<Rigidbody>();
        setCountText();
        winText.text = "";
	}

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    private void setCountText() 
    {
        countText.text = "Count: " + count;
        if (count == 12) {
            winText.text = "You win!";
        }
    }
}
