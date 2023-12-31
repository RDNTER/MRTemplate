﻿using UnityEngine;

public class ObjectLauncher : MonoBehaviour
{
    [Header("LTouchかRTouchを選択する")]
    [SerializeField] OVRInput.Controller _controller;
    [Header("発射する強さ")]
    [SerializeField] float _force = 500f;
    [SerializeField] GameObject _objPrefab;

    void OnValidate()
    {
        if(_objPrefab && _objPrefab.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("ObjectLauncher: 発射するオブジェクトにはRigidbodyがアタッチされている必要があります");
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, _controller))
        {
            var obj = Instantiate(
                _objPrefab,
                transform.position,
                transform.rotation
            );
            obj.GetComponent<Rigidbody>().AddForce(transform.forward * _force);
        }
    }
}
