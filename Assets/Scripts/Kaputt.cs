#region

using UnityEngine;

#endregion

// Alls Unnüx
public static class Kaputt
{
	public static T CreateSingleton<T>( T instance, GameObject gameObject ) where T : Component
	{
		if( !instance )
		{
			instance = gameObject.GetComponent<T>();
			if( !instance )
				instance = gameObject.AddComponent<T>();
			return instance;
		}

		if( instance.gameObject != gameObject )
			Object.Destroy( gameObject );
		return instance;
	}

	public static bool IsInLayerMask( GameObject gameObject, LayerMask layerMask ) =>
		( layerMask & ( 1 << gameObject.layer ) ) != 0;

	public static void SetActiveByName( string objectName, bool isActive )
	{
		GameObject obj = GameObject.Find( objectName );
		if( obj != null )
			obj.SetActive( isActive );
		else
			Debug.LogWarning( "GameObject with name " + objectName + " not found." );
	}
}