using System.Collections;
using UnityEngine;

public class GPS : MonoBehaviour
{
	public static string Latitude = string.Empty;

	public static string Longitude = string.Empty;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(StartLocationService());
	}

	private void Update()
	{
	}

	private IEnumerator StartLocationService()
	{
		if (Input.location.isEnabledByUser)
		{
			Input.location.Start(1f, 1f);
			int maxWait = 20;
			while ((int)Input.location.status == 1 && maxWait > 0)
			{
				yield return (object)new WaitForSeconds(1f);
				maxWait--;
			}
			if (maxWait > 0 && (int)Input.location.status != 3)
			{
				LocationInfo lastData = Input.location.lastData;
				Latitude = ((LocationInfo)(ref lastData)).latitude + string.Empty;
				LocationInfo lastData2 = Input.location.lastData;
				Longitude = ((LocationInfo)(ref lastData2)).longitude + string.Empty;
				((MonoBehaviour)this).StartCoroutine(TrackLocation());
			}
		}
	}

	private IEnumerator TrackLocation()
	{
		while (true)
		{
			yield return (object)new WaitForSeconds(5f);
			if ((int)Input.location.status == 2)
			{
				LocationInfo lastData = Input.location.lastData;
				Latitude = ((LocationInfo)(ref lastData)).latitude + string.Empty;
				LocationInfo lastData2 = Input.location.lastData;
				Longitude = ((LocationInfo)(ref lastData2)).longitude + string.Empty;
			}
			Debug.LogWarning((object)"VO DAY ");
		}
	}
}
