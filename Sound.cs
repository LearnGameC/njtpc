using System.Threading;
using UnityEngine;

public class Sound
{
	private const int INTERVAL = 5;

	private const int MAXTIME = 100;

	public static int status;

	public static int postem;

	public static int timestart;

	private static string filenametemp;

	private static float volumetem;

	public static bool isSound = true;

	public static AudioSource SoundWater;

	public static AudioSource SoundRun;

	public static AudioSource SoundBGLoop;

	public static AudioClip[] mysound;

	public static GameObject[] player;

	public static string[] fileName = new string[34]
	{
		"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
		"10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
		"29", "21", "22", "23", "24", "25", "26", "27", "28", "29",
		"30", "31", "32", "33"
	};

	public static sbyte MLogin = 0;

	public static sbyte MBClick = 1;

	public static sbyte MTone = 2;

	public static sbyte MSanzu = 3;

	public static sbyte MChakumi = 4;

	public static sbyte MChai = 5;

	public static sbyte MOshin = 6;

	public static sbyte MEchigo = 7;

	public static sbyte MKojin = 8;

	public static sbyte MHaruna = 9;

	public static sbyte MHirosaki = 10;

	public static sbyte MOokaza = 11;

	public static sbyte MGiotuyet = 12;

	public static sbyte MHangdong = 13;

	public static sbyte MDeKeu = 14;

	public static sbyte MChimKeu = 15;

	public static sbyte MBuocChan = 16;

	public static sbyte MNuocChay = 17;

	public static sbyte MBomMau = 18;

	public static sbyte MKiemGo = 19;

	public static sbyte MKiem = 20;

	public static sbyte MTieu = 21;

	public static sbyte MKunai = 22;

	public static sbyte MCung = 23;

	public static sbyte MDao = 24;

	public static sbyte MQuat = 25;

	public static sbyte MCung2 = 26;

	public static sbyte MTieu2 = 27;

	public static sbyte MTieu3 = 28;

	public static sbyte MKiem2 = 29;

	public static sbyte MKiem3 = 30;

	public static sbyte MDao2 = 31;

	public static sbyte MDao3 = 32;

	public static sbyte MCung3 = 33;

	public static bool bMuzikDisable;

	public static void stop()
	{
		for (int i = 0; i < player.Length; i++)
		{
			if ((Object)(object)player[i] != (Object)null)
			{
				player[i].GetComponent<AudioSource>().Pause();
			}
		}
	}

	public static void init()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject();
		((Object)val).name = "Audio Player Water";
		val.transform.position = Vector3.zero;
		val.AddComponent<AudioListener>();
		SoundWater = val.AddComponent<AudioSource>();
		GameObject val2 = new GameObject();
		((Object)val2).name = "Audio Player";
		val2.transform.position = Vector3.zero;
		val2.AddComponent<AudioListener>();
		SoundBGLoop = val2.AddComponent<AudioSource>();
		GameObject val3 = new GameObject();
		((Object)val3).name = "Audio Player Run";
		val3.transform.position = Vector3.zero;
		val3.AddComponent<AudioListener>();
		SoundRun = val3.AddComponent<AudioSource>();
		player = (GameObject[])(object)new GameObject[34];
		mysound = (AudioClip[])(object)new AudioClip[34];
		for (int i = 0; i < player.Length; i++)
		{
			getAssetSoundFile(fileName[i], i);
		}
		if (Main.isIpod && mGraphics.zoomLevel == 1)
		{
			bMuzikDisable = true;
		}
		else
		{
			bMuzikDisable = false;
		}
	}

	public static void getAssetSoundFile(string fileName, int type)
	{
		stop(type);
		string empty = string.Empty;
		empty = Main.res + "/music/" + fileName;
		load(empty, type);
	}

	public static void stopAll()
	{
		bMuzikDisable = true;
		for (int i = 0; i < mysound.Length; i++)
		{
			stop(i);
		}
	}

	public static void stopAllBg()
	{
		for (int i = 0; i < mysound.Length; i++)
		{
			stop(i);
		}
		sTopSoundBG(0);
		sTopSoundRun();
		stopSoundNatural(0);
	}

	public static void update()
	{
	}

	public static void stopMusic(int x)
	{
		if (!bMuzikDisable)
		{
			stop(x);
		}
	}

	public static void play(int id, float volume)
	{
		if (!bMuzikDisable)
		{
			start(volume, id);
		}
	}

	public static void playSoundRun(int id, float volume)
	{
		if (!bMuzikDisable && !((Object)(object)SoundRun == (Object)null))
		{
			((Component)((Component)SoundRun).GetComponent<AudioSource>()).GetComponent<AudioSource>().clip = mysound[id];
			((Component)((Component)SoundRun).GetComponent<AudioSource>()).GetComponent<AudioSource>().volume = volume;
			((Component)((Component)SoundRun).GetComponent<AudioSource>()).GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundRun()
	{
		((Component)((Component)SoundRun).GetComponent<AudioSource>()).GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSound()
	{
		if ((Object)(object)SoundRun == (Object)null)
		{
			return false;
		}
		return ((Component)((Component)SoundRun).GetComponent<AudioSource>()).GetComponent<AudioSource>().isPlaying;
	}

	public static void playSoundNatural(int id, float volume, bool isLoop)
	{
		if (!bMuzikDisable && !((Object)(object)SoundBGLoop == (Object)null))
		{
			((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().loop = isLoop;
			((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().clip = mysound[id];
			((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().volume = volume;
			((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().Play();
		}
	}

	public static void stopSoundNatural(int id)
	{
		((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundatural(int id)
	{
		if ((Object)(object)SoundWater == (Object)null)
		{
			return false;
		}
		return ((Component)((Component)SoundWater).GetComponent<AudioSource>()).GetComponent<AudioSource>().isPlaying;
	}

	public static void playSoundBGLoop(int id, float volume)
	{
		if (!bMuzikDisable && !((Object)(object)SoundBGLoop == (Object)null))
		{
			((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().loop = true;
			((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().clip = mysound[id];
			((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().volume = volume;
			((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundBG(int id)
	{
		((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundBG(int id)
	{
		if ((Object)(object)SoundBGLoop == (Object)null)
		{
			return false;
		}
		return ((Component)((Component)SoundBGLoop).GetComponent<AudioSource>()).GetComponent<AudioSource>().isPlaying;
	}

	public static void load(string filename, int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__load(filename, pos);
		}
		else
		{
			_load(filename, pos);
		}
	}

	private static void _load(string filename, int pos)
	{
		if (status != 0)
		{
			Out.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + filenametemp);
			return;
		}
		filenametemp = filename;
		postem = pos;
		status = 2;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError((object)("TOO LONG FOR LOAD AUDIO " + filename));
			return;
		}
		Out.Log("Load Audio " + filename + " done in " + i * 5 + "ms");
	}

	private static void __load(string filename, int pos)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		mysound[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
		GameObject.Find("Main Camera").AddComponent<AudioSource>();
		player[pos] = GameObject.Find("Main Camera");
	}

	public static void start(float volume, int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__start(volume, pos);
		}
		else
		{
			_start(volume, pos);
		}
	}

	public static void _start(float volume, int pos)
	{
		if (status != 0)
		{
			Debug.LogError((object)"CANNOT START AUDIO WHEN STARTING");
			return;
		}
		volumetem = volume;
		postem = pos;
		status = 3;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError((object)"TOO LONG FOR START AUDIO");
		}
		else
		{
			Debug.Log((object)("Start Audio done in " + i * 5 + "ms"));
		}
	}

	public static void __start(float volume, int pos)
	{
		if (!((Object)(object)player[pos] == (Object)null))
		{
			((Component)player[pos].GetComponent<AudioSource>()).GetComponent<AudioSource>().PlayOneShot(mysound[pos], volume);
		}
	}

	public static void stop(int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__stop(pos);
		}
		else
		{
			_stop(pos);
		}
	}

	public static void _stop(int pos)
	{
		if (status != 0)
		{
			Debug.LogError((object)"CANNOT STOP AUDIO WHEN STOPPING");
			return;
		}
		postem = pos;
		status = 4;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError((object)"TOO LONG FOR STOP AUDIO");
		}
		else
		{
			Debug.Log((object)("Stop Audio done in " + i * 5 + "ms"));
		}
	}

	public static void __stop(int pos)
	{
		if ((Object)(object)player[pos] != (Object)null)
		{
			((Component)player[pos].GetComponent<AudioSource>()).GetComponent<AudioSource>().Stop();
		}
	}
}
