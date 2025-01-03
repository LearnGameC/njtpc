using System.Collections.Generic;
using UnityEngine;

public class ScaleGUI
{
	public static bool scaleScreen;

	public static float WIDTH;

	public static float HEIGHT;

	private static List<Matrix4x4> stack = new List<Matrix4x4>();

	public static void initScaleGUI()
	{
		Res.println("Init Scale GUI: Screen.w=" + Screen.width + " Screen.h=" + Screen.height);
		WIDTH = Screen.width;
		HEIGHT = Screen.height;
		scaleScreen = false;
		if (Screen.width <= 1200)
		{
		}
	}

	public static void BeginGUI()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (scaleScreen)
		{
			stack.Add(GUI.matrix);
			Matrix4x4 val = default(Matrix4x4);
			float num = Screen.width;
			float num2 = Screen.height;
			float num3 = num / num2;
			float num4 = 1f;
			Vector3 zero = Vector3.zero;
			num4 = ((!(num3 < WIDTH / HEIGHT)) ? ((float)Screen.height / HEIGHT) : ((float)Screen.width / WIDTH));
			((Matrix4x4)(ref val)).SetTRS(zero, Quaternion.identity, Vector3.one * num4);
			GUI.matrix *= val;
		}
	}

	public static void EndGUI()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (scaleScreen)
		{
			GUI.matrix = stack[stack.Count - 1];
			stack.RemoveAt(stack.Count - 1);
		}
	}

	public static float scaleX(float x)
	{
		if (!scaleScreen)
		{
			return x;
		}
		x = x * WIDTH / (float)Screen.width;
		return x;
	}

	public static float scaleY(float y)
	{
		if (!scaleScreen)
		{
			return y;
		}
		y = y * HEIGHT / (float)Screen.height;
		return y;
	}
}
