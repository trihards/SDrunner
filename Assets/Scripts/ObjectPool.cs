﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectPool : MonoBehaviour {

	public RecycleGameObject prefab;

	private List<RecycleGameObject> poolInstance = new List<RecycleGameObject>();

	private RecycleGameObject CreateInstace(Vector3 pos) {
	
		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;

		poolInstance.Add (clone);

		return clone;

			
	}

	public RecycleGameObject NextObject(Vector3 pos){
		RecycleGameObject instance = null;

		foreach (var go in poolInstance) {
			if (go.gameObject.activeSelf != true) {
				instance = go;
				instance.transform.position = pos;

			}
		}

		if(instance == null)
			instance = CreateInstace (pos);

		instance.Restart ();

		return instance;
	}

}
