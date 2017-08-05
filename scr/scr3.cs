using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class scr3 : MonoBehaviour
{

	public AudioSource audioSourceX; // sound track 1
	public AudioSource audioSource1; // sound track 1
	public AudioSource audioSource2; // sound track 2 
	public AudioSource audioSource3; // sound track 3


	// ------------ Audio Source for Piano

	public AudioClip blank;
	public AudioClip p_01;
	public AudioClip p_02;
	public AudioClip p_03;
	public AudioClip p_04;
	public AudioClip p_05;
	public AudioClip p_06;
	public AudioClip p_07;

	// ------------ Audio Source for Violin
	public AudioClip v_01;
	public AudioClip v_02;
	public AudioClip v_03;
	public AudioClip v_04;
	public AudioClip v_05;
	public AudioClip v_06;
	public AudioClip v_07;

	public AudioClip m_01;
	public AudioClip m_02;
	public AudioClip m_03;
	public AudioClip m_04;
	public AudioClip m_05;
	public AudioClip m_06;
	public AudioClip m_07;
	// ------------------------------------

	List<AudioClip> AudioClipColletion = new List<AudioClip>();


	List<double> musicScoreX = new List<double>();



	int isAccRecording1;
	int isAccRecording2;
	int isAccRecording3;

	int InstrumentType1;
	int InstrumentType2;
	int InstrumentType3;


	Vector3 InitialGravityAccForX;

	int RecordingX;
	int Pitching1;
	int Pitching2;
	int Pitching3;

	void Start()
	{
		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(p_01);
		AudioClipColletion.Add(p_02);
		AudioClipColletion.Add(p_03);
		AudioClipColletion.Add(p_04);
		AudioClipColletion.Add(p_05);
		AudioClipColletion.Add(p_06);
		AudioClipColletion.Add(p_07);
		// 7 sources
		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(v_01);
		AudioClipColletion.Add(v_02);
		AudioClipColletion.Add(v_03);
		AudioClipColletion.Add(v_04);
		AudioClipColletion.Add(v_05);
		AudioClipColletion.Add(v_06);
		AudioClipColletion.Add(v_07);
		// 7 sources
		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(m_01);
		AudioClipColletion.Add(m_02);
		AudioClipColletion.Add(m_03);
		AudioClipColletion.Add(m_04);
		AudioClipColletion.Add(m_05);
		AudioClipColletion.Add(m_06);
		AudioClipColletion.Add(m_07);
		// 7 sources
		isAccRecording1 = 0;
		isAccRecording2 = 0;
		isAccRecording3 = 0;
		InstrumentType1 = 1;
		InstrumentType2 = 1;
		InstrumentType3 = 2;

		InitialGravityAccForX = Input.acceleration;
		// InitialGravityAccForX.x = 0;
		// InitialGravityAccForX.y = 0;
		// InitialGravityAccForX.z = 0;

		RecordingX = 0;

		Pitching1 = 0;
		Pitching2 = 0;
		Pitching3 = 0;

	}
	void OnGUI()
	{
		PlayMusic1();
	}

	void PlayMusic1()
	{

		if (GUI.Button(new Rect(0, 800, 150, 150), "Reset Acc"))
		{
			InitialGravityAccForX = Input.acceleration;
		}
		if (GUI.Button(new Rect(200, 800, 150, 150), "Clear AccForX"))
		{
			musicScoreX.Clear();
		}
		if (GUI.Button(new Rect(600, 1200, 150, 150), "Change Scene back to 0"))
		{
			SceneManager.LoadScene(0);
		}
		for (int i = 0; i < 8; i++)
		{
			if (GUI.Button(new Rect(60 * i, 650 + 50, 55, 80), (i).ToString()))
			{
				//MusicScoreInputed.Add(i);
				musicScoreX.Add(i);
			}
		}
		Vector3 nowDev = Input.acceleration - InitialGravityAccForX;

		int aa, ab, ac;
		aa = (nowDev.x >= 0) ? 1 : 0;
		ab = (nowDev.magnitude >= 1.5) ? 1 : 0;
		ac = nowDev.z >= 1 ? 1 : 0;

		int[] WRmap = { 3, 4, 2, 1, 0, 7, 5, 6 };

		scr1.ShowDouble(nowDev.x, 0, 250 - 50);
		scr1.ShowDouble(nowDev.y, 0, 300 - 50);
		scr1.ShowDouble(nowDev.z, 0, 350 - 50);

		scr1.ShowDouble(WRmap[aa + ab * 2 + ac * 4], 0, 500);
		scr1.ShowDouble(musicScoreX.Count, 0, 550);
		scr1.ShowDouble(musicScoreX, "SoureXInputed: ", 0, 20 + 600);

		if (GUI.Button(new Rect(400, 800, 150, 150), " Start Motion"))
		{
			RecordingX = 1;
		}

		if (GUI.Button(new Rect(400 + 150, 800, 150 / 2, 150), " Stop"))
		{
			RecordingX = 0;
		}

		if (RecordingX == 1)
		{
			if (System.Math.Abs(nowDev.x) > 0.3)
			{
				if (!audioSourceX.isPlaying)
				{
					audioSourceX.clip = AudioClipColletion[WRmap[aa + ab * 2 + ac * 4]];
					musicScoreX.Add(WRmap[aa + ab * 2 + ac * 4]);
					audioSourceX.Play();
				}
			}
		}


	}



}