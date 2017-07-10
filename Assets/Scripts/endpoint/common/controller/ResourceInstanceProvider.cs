using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.framework.api;
using System;

namespace endpoint
{
	public class ResourceInstanceProvider : IInstanceProvider
	{
		//The GameObject instantiated from the prefab
		GameObject prototype;

		//The name of the resource in Unity's resources folder
		private string resourceName;
		//The render layer to which the GameObjects will be assigned
		private int layer;
		//An id tacked on to the name to make it easier to track individual instances
		private int id = 0;

		//This provider is instantiated multiple times in GameContext.
		//Each time, we provide the name of the prefab we're loading from
		//a resources folder, and the layer to which the resulting instance
		//
		public ResourceInstanceProvider(string name, int layer)
		{
			resourceName = name;
			this.layer = layer;
		}

        public T GetInstance<T>()
        {
			object instance = GetInstance(typeof(T));
			T retv = (T)instance;
			return retv;
        }

        public object GetInstance(Type key)
        {
			if (prototype == null)
			{
				//Get the resource from Unity
				prototype = Resources.Load<GameObject>(resourceName);
				prototype.transform.localScale = Vector3.one;
			}

			//Copy the prototype
			GameObject go = GameObject.Instantiate(prototype) as GameObject;
			//go.layer = layer;
			go.name = resourceName + "_" + id++;

			return go;
        }
    }
}