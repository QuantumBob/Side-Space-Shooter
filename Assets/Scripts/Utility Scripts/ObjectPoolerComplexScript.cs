using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerComplexScript : MonoBehaviour {
	
	public static ObjectPoolerComplexScript current;//instance of this class for easy access
	
	public struct ObjectPool
	{
		public List<GameObject> pooledObjects;
		//public int poolSize;
		public GameObject pooledObject;
		public bool willGrow;
		// Constructor
		public ObjectPool(GameObject go, bool grow)
		{
			pooledObjects = new List<GameObject>();
			pooledObject = go;
			willGrow = grow;
		}
	}
	// helper struct to allow inspector assignment of the pool objects
	[Serializable]
	public struct PoolHelper
	{
		public int poolSize;
		public GameObject pooledObject;
		public bool willGrow;
	}
	
	public List<PoolHelper> poolInfo;
	private List<ObjectPool> pooledPools;
	
	void Awake ()
	{
		current = this;
	}
	// Use this for initialization
	void Start () 
	{
		if (poolInfo.Count == 0)
		{
			print ("No objects defined in ObjectPoolerComplexScript Component");
			return;
		}
		// Instantiate the list of pools
		pooledPools = new List<ObjectPool>();
		// run through each element from the inspectors ObjectPool list
		foreach (PoolHelper ph in poolInfo)
		{
			// create a new instance of ObjectPool. Constructor instantiates list pooledObjects
			ObjectPool pool = new ObjectPool(ph.pooledObject, ph.willGrow);
			// the pool helper from the inspector has the size of each pool
			for (int i =0; i < ph.poolSize; i++)
			{ 
				GameObject obj = (GameObject) Instantiate(pool.pooledObject);// instantiate one gameobject
				obj.name = pool.pooledObject.name; // don't want it to say (clone) after every name
				obj.SetActive(false); //at start of game all pools are inactive
				pool.pooledObjects.Add(obj);//add game object to the pool's list of pooled objects
			}
			pooledPools.Add(pool);//now add the pool into the list of pools
		}
	}
	//return an instance of the parameter string
	//add new instance if able or return null
	public GameObject GetPooledObject(string objectName)
	{
		GameObject obj = null;
		//step through each pool we have
		foreach (ObjectPool pool in pooledPools)
		{
			//if the pool name equals the asked for object name
			if (pool.pooledObject.name == objectName)// this is where (clone) in the name would be bad!
			{
				//find an available object in our list
				for (int i =0; i < pool.pooledObjects.Count; i++)
				{
					if (!pool.pooledObjects[i].activeInHierarchy)
						obj = pool.pooledObjects[i];
					
				}
				//if we have no gameobjects and we can grow the list
				if (obj == null && pool.willGrow)
				{
					//create another object of that type, add it and return it
					obj = (GameObject) Instantiate(pool.pooledObject);
					obj.name = pool.pooledObject.name;
					pool.pooledObjects.Add(obj);
				}
				return obj;
			}
		}
		//we haven't found a pool corresponding to the object name parameter
		return null;
	}
}
