using UnityEngine;

public abstract class MySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance { get { return instance; } }

	[SerializeField]
	protected bool dontDestroyOnLoad = true;

	#region MonoBehaviour Lifecycle
	protected void Awake()
	{
		InitSingleton(dontDestroyOnLoad);
	}

	protected virtual void OnApplicationQuit()
	{
		//instance = null;
	}
	#endregion

	private void InitSingleton(bool dontDestroyOnLoad = true)
	{
		// Ensure only one instance is kept (the first that was born)
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}

		instance = this.GetComponent<T>();

		if (dontDestroyOnLoad && transform.parent == null)
			DontDestroyOnLoad(gameObject);

		Init();
	}

	protected virtual void Init() { }
}