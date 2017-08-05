using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class scr2 : MonoBehaviour
{

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

	static List<double> musicScore1 = new List<double>();
	static List<double> musicScore2 = new List<double>();
	static List<double> musicScore3 = new List<double>();

	List<Vector3> AccRecorded1 = new List<Vector3>(50000);
	List<float> AccRecorded1NonVector = new List<float>();
	List<Vector3> AccRecorded2 = new List<Vector3>(50000);
	List<Vector3> AccRecorded3 = new List<Vector3>(50000);

	int isAccRecording1;
	int isAccRecording2;
	int isAccRecording3;

	int InstrumentType1;
	int InstrumentType2;
	int InstrumentType3;


	Vector3 InitialGravityAcc;


	// easy part

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
		InstrumentType3 = 1;


	}
	void OnGUI()
	{

		if (GUI.Button(new Rect(600, 900, 150, 150), "Change Scene"))
		{
			SceneManager.LoadScene(0);
		}

		CreateOneTrack(audioSource1, ref musicScore1, 000, ref isAccRecording1, ref AccRecorded1, ref InstrumentType1);
		CreateOneTrack(audioSource2, ref musicScore2, 300, ref isAccRecording2, ref AccRecorded2, ref InstrumentType2);
		CreateOneTrack(audioSource3, ref musicScore3, 600, ref isAccRecording3, ref AccRecorded3, ref InstrumentType3);
	}


	void CreateOneTrack(AudioSource AudioSourceInputed,
						ref List<double> MusicScoreInputed,
						int StartY,
						ref int isAccRecording,
						ref List<Vector3> AccRecordedInputed,
						ref int InstrumentType)
	{

		ShowDouble(MusicScoreInputed, 0, 0 + StartY);

		for (int i = 0; i < 8; i++)
		{
			if (GUI.Button(new Rect(60 * i, StartY + 50, 55, 80), (i).ToString()))
			{
				MusicScoreInputed.Add(i);
			}
		}

		if (GUI.Button(new Rect(0 + 600, StartY + 0, 100, 150), "Play Music"))
		{
			// NOTE: 1,2 stands for different musical instruments
			CombineScore(MusicScoreInputed, AudioSourceInputed, InstrumentType);
			AudioSourceInputed.Play();
		}
		if (GUI.Button(new Rect(0 + 600, StartY + 170, 100, 80), "Stop Music"))
		{
			if (AudioSourceInputed.isPlaying)
			{
				AudioSourceInputed.Stop();
			}
		}

		int XGap = 120;
		int YGap = 180;
		int SizeX = 100;
		int SizeY = 60;
		if ((GUI.Button(new Rect(0, StartY + YGap, SizeX, SizeY), "Motion start")) || (isAccRecording == 1))
		{
			if (isAccRecording == 0)
			{
				InitialGravityAcc = Input.acceleration;
				isAccRecording = 1;
			}
			AccRecordedInputed.Add((Input.acceleration - InitialGravityAcc));
		}



		if (GUI.Button(new Rect(XGap, StartY + YGap, SizeX, SizeY), "Motion end"))
		{
			isAccRecording = 0;
			MusicScoreInputed = MakeScoreFromMotionTuner(AccRecordedInputed, 10, 8);
			CombineScore(MusicScoreInputed, AudioSourceInputed, InstrumentType);
		}

		if (GUI.Button(new Rect(XGap * 2, StartY + YGap, SizeX + 50, SizeY), "Record Clear"))
		{
			AccRecordedInputed.Clear();
			MusicScoreInputed.Clear();
		}
		for (int i = 1; i < 3; i++)
		{
			if (GUI.Button(new Rect(80 * (i) + 350, StartY + YGap, 70, 80), (i).ToString()))
			{
				InstrumentType = i;
			}
		}

	}
	
	List<double> MakeScoreFromMotionTuner(List<Vector3> AccInputedInVector, int KeyNumber, int ToneStepNumber)
	{
		List<double> LocalScore = new List<double>();

		var AccInputed = new List<float>();

		foreach (Vector3 AccInForEachLoop in AccInputedInVector)
		{
			AccInputed.Add(AccInForEachLoop.magnitude);
		}

		float Max = 3;
		float Min = 0;

		for (int i = 0; i < AccInputed.Count; i++)
		{
			if (AccInputed[i] > Max)
			{
				Max = AccInputed[i];
			}
			if (AccInputed[i] < Min)
			{
				Min = AccInputed[i];
			}
		}
		float Step = (Max - Min) / (ToneStepNumber - 1);

		int TimeStep = AccInputed.Count / KeyNumber;

		for (int i = 0; i < KeyNumber + 1; i++)
		{
			float tempMax = 0;
			for (int j = TimeStep * i; j < TimeStep * (i + 1); j++)
			{
				if (j >= AccInputed.Count)
				{
					break;
				}
				if (AccInputed[j] > tempMax)
				{
					tempMax = AccInputed[j];
				}
			}

			int tempscore;
			if (Step != 0)
			{
				tempscore = (int)((tempMax - Min) / Step);
			}
			else
			{
				tempscore = 0;
			}
			LocalScore.Add(tempscore);
		}

		return LocalScore;
	}

	void ShowDouble(double InputValue, int xForLabel, int yForLabel)
	{
		string output = "";
		output += InputValue.ToString();
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}

	void ShowDouble(List<double> ListInputed, int xForLabel, int yForLabel)
	{
		if (ListInputed.Count == 0)
		{
			return;
		}
		string output = "";
		for (int i = 0; i < ListInputed.Count; i++)
		{
			output += ListInputed[i].ToString();
		}
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}

	public void CombineScore(List<double> MusicScoreInputed, AudioSource AudioSourceInThisFunction, int InstrumentType)
	{
		if (InstrumentType == 0)
		{
			Debug.Log("the Instrument Type input is 0 , it should begin from 1");
		}
		AudioClip tempc = new AudioClip();

		for (int i = 0; i < MusicScoreInputed.Count; i++)
		{
			AudioClip clippp = AudioClipColletion[
				(int)(MusicScoreInputed[i])
				+ (InstrumentType - 1) * 7
				];
			tempc = ACCombine(tempc, clippp);
		}

		AudioSourceInThisFunction.clip = tempc;

	}
	public static AudioClip ACCombine(params AudioClip[] clips)
	{
		if (clips == null || clips.Length == 0)
			return null;

		int length = 0;
		for (int i = 0; i < clips.Length; i++)
		{
			if (clips[i] == null)
				continue;

			length += clips[i].samples * clips[i].channels;
		}

		float[] data = new float[length];
		length = 0;
		for (int i = 0; i < clips.Length; i++)
		{
			if (clips[i] == null)
				continue;

			float[] buffer = new float[clips[i].samples * clips[i].channels];
			clips[i].GetData(buffer, 0);
			//System.Buffer.BlockCopy(buffer, 0, data, length, buffer.Length);
			buffer.CopyTo(data, length);
			length += buffer.Length;
		}

		if (length == 0)
			return null;

		AudioClip result = AudioClip.Create("Combine", length / 2, 2, 44100, false, false);
		result.SetData(data, 0);

		return result;
	}
}