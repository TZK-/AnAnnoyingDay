﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController {

    public float dashLength = 1f;
    public float speed = 0.10f;

    public Rigidbody rb;

    void Dash()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        float newMoveX = move.x;
        float newMoveY = move.y;
        float newPosX = transform.position.x;
        float newPosY = transform.position.y;
        if (newMoveX != 0)
        {
            if (move.x > 0)
            {
                newMoveX += dashLength;
                newPosX += dashLength;
            }
            else
            {
                newMoveX -= dashLength;
                newPosX -= dashLength;
            }
        }
        if (newMoveY != 0)
        {
            if (move.y > 0)
            {
                newMoveY += dashLength;
                newPosY += dashLength;
            }
            else
            {
                newMoveY -= dashLength;
                newPosY -= dashLength;
            }
        }

        //rb.AddForce( new Vector3(newMoveX, newMoveY, 0), ForceMode.Force);
        //Debug.Log("Dash");

        transform.Translate(new Vector2(newMoveX, newMoveY));

        //rigidbody.velocity = new Vector2(rigidbody.velocity.x * 3f, rigidbody.velocity.y);
    }

    void Moving()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(moveHorizontal, moveVertical);
        Vector3 rotation = new Vector3(0, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Moving();
        if (Input.GetButtonDown("Dash"))
            Dash();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
