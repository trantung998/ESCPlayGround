using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Enemy
{
    public ReactiveProperty<int> hp;
    public ReactiveProperty<bool> isDead;

    public Enemy(int initHp)
    {
        hp = new IntReactiveProperty(initHp);
        isDead = hp.Select(i => i <= 0).ToReactiveProperty();
    }
}
