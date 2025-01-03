using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
	public static Main main;

	public static GameCanvas canvas;

	public static mGraphics g;

	public static GameMidlet midlet;

	public static string res = "res";

	public static string mainThreadName;

	public static bool started;

	public static bool isIpod;

	public static bool isAppTeam;

	public static bool isPC;

	public static bool isWp;

	public static bool IphoneVersionApp;

	public static string IMEI;

	public static int versionIp;

	public static int level;

	public bool isWorldver;

	private int updateCount;

	private int paintCount;

	private Vector2 lastMousePos = default(Vector2);

	public static int a = 1;

	public static bool isCompactDevice = true;

	private void Start()
	{
		if (!started)
		{
			level = RMS.loadRMSInt("levelScreenKN");
			if (level == 1)
			{
				Screen.SetResolution(480, 320, false);
			}
			else
			{
				Screen.SetResolution(1024, 600, false);
			}
			if (Thread.CurrentThread.Name != "Main")
			{
				Thread.CurrentThread.Name = "Main";
			}
			mainThreadName = Thread.CurrentThread.Name;
			if (iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen)
			{
				isIpod = true;
			}
			Screen.orientation = (ScreenOrientation)3;
			Application.runInBackground = true;
			Application.targetFrameRate = 30;
			((MonoBehaviour)this).useGUILayout = false;
			isCompactDevice = detectCompactDevice();
			if ((Object)(object)main == (Object)null)
			{
				main = this;
			}
			started = true;
			ScaleGUI.initScaleGUI();
			IMEI = SystemInfo.deviceUniqueIdentifier;
			isPC = true;
			isWp = false;
			isAppTeam = false;
			IphoneVersionApp = false;
			if (isPC)
			{
				Screen.fullScreen = false;
			}
			g = new mGraphics();
			midlet = new GameMidlet();
			canvas = new GameCanvas();
			TileMap.loadTileMapArr();
			SplashScr.gI().switchToMe();
			Sound.init();
		}
	}

	public void doClearRMS()
	{
		if (isPC)
		{
			int num = RMS.loadRMSInt("lastZoomlevel");
			if (num != mGraphics.zoomLevel)
			{
				RMS.clearRMS();
				RMS.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
				RMS.saveRMSInt("levelScreenKN", level);
			}
		}
	}

	private void OnGUI()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		checkInput();
		Session_ME.update();
		EventType type = Event.current.type;
		if (((object)(EventType)(ref type)/*cast due to .constrained prefix*/).Equals((object)(EventType)7) && paintCount <= updateCount)
		{
			canvas.paint(g);
			paintCount++;
			g.reset();
		}
	}

	private void FixedUpdate()
	{
		ipKeyboard.update();
		canvas.update();
		RMS.update();
		Image.update();
		DataInputStream.update();
		SMS.update();
		Net.update();
		updateCount++;
		Sound.update();
	}

	private void Update()
	{
		if (!isPC)
		{
			int num = 1 / a;
		}
	}

	private void checkInput()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Invalid comparison between Unknown and I4
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Invalid comparison between Unknown and I4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Invalid comparison between Unknown and I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Invalid comparison between Unknown and I4
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			canvas.pointerPressed((int)(mousePosition.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition.y) / (float)mGraphics.zoomLevel));
			lastMousePos.x = mousePosition.x / (float)mGraphics.zoomLevel;
			lastMousePos.y = mousePosition.y / (float)mGraphics.zoomLevel;
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition2 = Input.mousePosition;
			canvas.pointerDragged((int)(mousePosition2.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition2.y) / (float)mGraphics.zoomLevel));
			lastMousePos.x = mousePosition2.x / (float)mGraphics.zoomLevel;
			lastMousePos.y = mousePosition2.y / (float)mGraphics.zoomLevel;
		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 mousePosition3 = Input.mousePosition;
			lastMousePos.x = mousePosition3.x / (float)mGraphics.zoomLevel;
			lastMousePos.y = mousePosition3.y / (float)mGraphics.zoomLevel;
			canvas.pointerReleased((int)(mousePosition3.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition3.y) / (float)mGraphics.zoomLevel));
		}
		if (Input.anyKeyDown && (int)Event.current.type == 4)
		{
			int num = MyKeyMap.map(Event.current.keyCode);
			if (Input.GetKey((KeyCode)304) || Input.GetKey((KeyCode)303))
			{
				KeyCode keyCode = Event.current.keyCode;
				if ((int)keyCode != 50)
				{
					if ((int)keyCode == 45)
					{
						num = 95;
					}
				}
				else
				{
					num = 64;
				}
			}
			if (num != 0)
			{
				canvas.keyPressed(num);
			}
		}
		if ((int)Event.current.type == 5)
		{
			int num2 = MyKeyMap.map(Event.current.keyCode);
			if (num2 != 0)
			{
				canvas.keyReleased(num2);
			}
		}
	}

	private void OnApplicationQuit()
	{
		Debug.LogWarning((object)"APP QUIT");
		GameCanvas.bRun = false;
		Session_ME.gI().close();
		if (isPC)
		{
			Application.Quit();
		}
	}

	public static void exit()
	{
		if (isPC)
		{
			main.OnApplicationQuit();
		}
		else
		{
			a = 0;
		}
	}

	public static bool detectCompactDevice()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone || iPhoneSettings.generation == iPhoneGeneration.iPhone3G || iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen || iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen)
		{
			return false;
		}
		return true;
	}

	public static bool checkCanSendSMS()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen)
		{
			return true;
		}
		return false;
	}
}
