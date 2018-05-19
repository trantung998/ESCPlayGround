using System.Collections;
using System.Collections.Generic;
using PathologicalGames;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform firePoint;
	public int totalBalls = 10;
	public float delay = 0.1f;
	public float speed = 5;
	
	private SpawnPool pool;

	[SerializeField]
	private int remainBalls = 10;
	// Use this for initialization
	void Start ()
	{
		pool = PoolManager.Pools["Ball"];
		Timing.RunCoroutine(Util._EmulateUpdate(MyUpdate, this));
	}
	
	// Update is called once per frame
	IEnumerable<float> Fire ()
	{
		var ball = pool.Spawn("Ball", firePoint.position, firePoint.rotation);
		ball.GetComponent<Rigidbody2D>().velocity = firePoint.up * speed;
		
	}
	
	public IEnumerator<float> _EmulateUpdate(System.Action func, MonoBehaviour scr)
	{
		yield return Timing.WaitForOneFrame;
		while (scr.gameObject != null)
		{
			if (scr.gameObject.activeInHierarchy && scr.enabled)
				func();
 
			yield return Timing.WaitForOneFrame;
		}
	}
}
