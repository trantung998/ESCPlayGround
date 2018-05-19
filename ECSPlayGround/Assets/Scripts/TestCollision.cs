using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour 
{
	
	private void OnTriggerExit2D(Collider2D other)
	{

	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("OnTriggerEnter2D");
		if (other.tag == "Ball")
		{
			
			//Ball center
			var ball_center = other.transform.position;
			//Box center
			var box_half_extents = GetComponent<BoxCollider2D>().bounds.extents;
			var box_center = transform.position;
			// Get difference vector between both centers
			var difference = ball_center - box_center;
			
			//
			
			
			
			
			
			var ball = other.GetComponent<UbhBullet>();
			ball.Angle =  - ball.Angle;
			var angel = Vector2.Angle(transform.up, ball.transform.up);
			print(angel);
			
			ContactPoint2D[] fContacts = new ContactPoint2D[1];
			int Array1Length = other.GetContacts(fContacts);
			print("GetContacts Size 1: " + fContacts[0].point + "Array Length: " + Array1Length);
		}
	}
}
