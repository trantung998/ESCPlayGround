using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HitEvent
{
	
}

public class BulletDestroyEvent
{
	
}

public class CountHit : MonoBehaviour
{
	[SerializeField]
	private Text hitText;
	
	[SerializeField]
	private Text bulletDestroyedText;
	
	private IntReactiveProperty hitCount;
	private IntReactiveProperty bulletDestroyedCount;
	
	private void Awake()
	{
		MessageBroker.Default.Receive<HitEvent>().Subscribe(OnGetHitEvent).AddTo(this);
		MessageBroker.Default.Receive<BulletDestroyEvent>().Subscribe(OnGetBulletDestroyedEvent).AddTo(this);
		hitCount = new IntReactiveProperty(0);
		bulletDestroyedCount = new IntReactiveProperty(0);

		hitCount.SubscribeToText(hitText);
		bulletDestroyedCount.SubscribeToText(bulletDestroyedText);
	}

	private void OnGetBulletDestroyedEvent(BulletDestroyEvent bulletDestroyEvent)
	{
		bulletDestroyedCount.Value += 1;
	}

	private void OnGetHitEvent(HitEvent hitEvent)
	{
		hitCount.Value += 1;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
