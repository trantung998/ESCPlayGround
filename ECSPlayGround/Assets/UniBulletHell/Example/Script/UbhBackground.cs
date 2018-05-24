﻿using UnityEngine;
using UnityEngine.Serialization;

public class UbhBackground : UbhMonoBehaviour
{
    private const string TEX_OFFSET_PROPERTY = "_MainTex";

    [SerializeField, FormerlySerializedAs("_Speed")]
    private float m_speed = 0.1f;

    private Vector2 m_offset = Vector2.zero;
    private Material currentMaterial;
    private float offset;
    private void Start()
    {
        currentMaterial = renderer.material;
        UbhManager manager = FindObjectOfType<UbhManager>();
        if (manager != null && manager.m_scaleToFit)
        {
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
            Vector2 scale = max * 2f;
            transform.localScale = scale;
        }       
    }

//    private void Update()
//    {
//
//        float y = Mathf.Repeat(Time.time * m_speed, 1f);
//        m_offset.x = 0f;
//        m_offset.y = y;
//        renderer.sharedMaterial.SetTextureOffset(TEX_OFFSET_PROPERTY, m_offset);
//    }

    private void Update()
    {
        offset += Time.deltaTime * m_speed;
        m_offset.x = 0f;
        m_offset.y = offset % 1.0f;
        currentMaterial.mainTextureOffset = m_offset;
    }
}
