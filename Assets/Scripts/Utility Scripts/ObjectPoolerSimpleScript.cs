using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerSimpleScript : MonoBehaviour
{
	public static ObjectPoolerSimpleScript current;//instance of this class for easy access

	public GameObject pooledObject;
	public int poolAmount;
	public bool willGrow = true;
	
	private List<GameObject> pooledObjects;

	void Awake()
	{
		current = this;
	}
	// Use this for initialization
	void Start () {
		if (pooledObject == null)
		{
			print ("No objects defined in ObjectPoolerScript Component");
			return;
		}

		pooledObjects = new List<GameObject>();

		for (int i =0; i < poolAmount; i++)
		{
			GameObject obj = (GameObject) Instantiate(pooledObject);
			obj.SetActive(false);
			obj.name = pooledObject.name;
			pooledObjects.Add(obj);
		}
	}
	public void AddPooledObject()
	{
		if (pooledObject == null)
		{
			print ("No objects defined in ObjectPoolerScript Component");
			return;
		}
		GameObject obj = (GameObject) Instantiate(pooledObject);
		obj.SetActive(false);
		obj.name = pooledObject.name;
		pooledObjects.Add(obj);

	}
	// get any object out of the pool
	public GameObject GetPooledObject()
	{
		//find an available object in our list
		for (int i =0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
				return pooledObjects[i];
		}
		//if we have no gameobjects and we can grow the list
		if (willGrow)
		{
			GameObject obj = (GameObject) Instantiate(pooledObject);
			pooledObjects.Add(obj);
			obj.name = pooledObject.name;
			return obj;
		}

		return null;
	}
	// returns a specific indexed object from the pool
	public GameObject GetPooledObject(int index)
	{
		if (index < pooledObjects.Count)
			return pooledObjects[index];
		else
			return null;
	}
	// as there are no params reduce by one
	public void ReducePoolSize()
	{
		if (pooledObjects.Count > 1)
			pooledObjects.RemoveAt(pooledObjects.Count);
	}
	// make the pool smaller
	public void ReducePoolSize(int newPoolSize)
	{
		// check the pool has more than one member
		if (pooledObjects.Count > newPoolSize)
		{
			int count = pooledObjects.Count - newPoolSize;
			pooledObjects.RemoveRange(newPoolSize, count);
		}
	}
	public void RemovePooledObject(int index)
	{
		if (pooledObjects.Count > index)
			pooledObjects.RemoveAt(index);
	}
	public void SetPoolSize(int size)
	{
		if (pooledObjects.Count > size)
		{
			ReducePoolSize(size);
			return;
		}
		while (pooledObjects.Count < size)
		{
			AddPooledObject();
		}
	}
	public int GetPoolSize()
	{
		return pooledObjects.Count;
	}
}
