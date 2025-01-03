using UnityEngine;

internal class Net
{
	public static WWW www;

	public static HTTPHandler h;

	public static void update()
	{
		if (www != null && www.isDone)
		{
			string s = string.Empty;
			if (www.error == null || www.error.Equals(string.Empty))
			{
				s = www.text;
			}
			www = null;
			h.onGetText(s);
		}
	}

	public static void connectHTTP(string link, HTTPHandler h)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (www != null)
		{
			Debug.LogError((object)"GET HTTP BUSY");
		}
		Debug.LogWarning((object)("REQUEST " + link));
		www = new WWW(link);
		Net.h = h;
	}
}
