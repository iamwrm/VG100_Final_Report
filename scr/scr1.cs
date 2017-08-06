



	

	// ------------ Audio Source for Violin
	public AudioClip pv_01;
	public AudioClip pv_02;
	public AudioClip pv_03;
	public AudioClip pv_04;
	public AudioClip pv_05;
	public AudioClip pv_06;
	public AudioClip pv_07;

	public AudioClip pv_08;
	public AudioClip pv_09;
	public AudioClip pv_10;
	public AudioClip pv_11;
	public AudioClip pv_12;
	public AudioClip pv_13;
	public AudioClip pv_14;

	public AudioClip pv_15;
	public AudioClip pv_16;
	public AudioClip pv_17;
	public AudioClip pv_18;
	public AudioClip pv_19;
	public AudioClip pv_20;
	public AudioClip pv_21;

	public AudioClip m_01;
	public AudioClip m_02;
	public AudioClip m_03;
	public AudioClip m_04;
	public AudioClip m_05;
	public AudioClip m_06;
	public AudioClip m_07;
	// ------------------------------------

	List<AudioClip> AudioClipColletion = new List<AudioClip>();

	List<double> musicScore1 = new List<double>();
	List<double> musicScore2 = new List<double>();
	List<double> musicScore3 = new List<double>();
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

	
		// 7 sources
		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(pv_01);
		AudioClipColletion.Add(pv_02);
		AudioClipColletion.Add(pv_03);
		AudioClipColletion.Add(pv_04);
		AudioClipColletion.Add(pv_05);
		AudioClipColletion.Add(pv_06);
		AudioClipColletion.Add(pv_07);
		// 7 sources

		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(pv_08);
		AudioClipColletion.Add(pv_09);
		AudioClipColletion.Add(pv_10);
		AudioClipColletion.Add(pv_11);
		AudioClipColletion.Add(pv_12);
		AudioClipColletion.Add(pv_13);
		AudioClipColletion.Add(pv_14);


		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(pv_15);
		AudioClipColletion.Add(pv_16);
		AudioClipColletion.Add(pv_17);
		AudioClipColletion.Add(pv_18);
		AudioClipColletion.Add(pv_19);
		AudioClipColletion.Add(pv_20);
		AudioClipColletion.Add(pv_21);


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
		CreateOneTrack(audioSource1, ref musicScore1, 000, ref isAccRecording1, ref InstrumentType1, ref Pitching1);
		CreateOneTrack(audioSource2, ref musicScore2, 170, ref isAccRecording2, ref InstrumentType2, ref Pitching2);
		CreateOneTrack(audioSource3, ref musicScore3, 340, ref isAccRecording3, ref InstrumentType3, ref Pitching3);

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
		if (GUI.Button(new Rect(600, 1050, 150, 150), "Change Scene to 1"))
		{
			SceneManager.LoadScene(1);
		}
		if (GUI.Button(new Rect(600, 1200, 150, 150), "Change Scene to 2"))
		{
			SceneManager.LoadScene(2);
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
		aa = nowDev.x >= 0 ? 1 : 0;
		ab = nowDev.y >= 0 ? 1 : 0;
		ac = nowDev.z >= 1 ? 1 : 0;

		int[] WRmap = { 3, 4, 2, 1, 0, 7, 5, 6 };

		// ShowDouble(nowDev.x, 0, 250 - 50);
		// ShowDouble(nowDev.y, 0, 300 - 50);
		// ShowDouble(nowDev.z, 0, 350 - 50);

		ShowDouble(WRmap[aa + ab * 2 + ac * 4], 0, 500);
		ShowDouble(musicScoreX.Count, 0, 550);
		ShowDouble(musicScoreX, "SoureXInputed: ", 0, 20 + 600);

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
			if ((nowDev).magnitude > 0.5)
			{
				if (!audioSourceX.isPlaying)
				{
					audioSourceX.clip = AudioClipColletion[WRmap[aa + ab * 2 + ac * 4]];
					musicScoreX.Add(WRmap[aa + ab * 2 + ac * 4]);
					audioSourceX.Play();
				}
			}
		}

		if (GUI.Button(new Rect(400 - 50, 800 - 300, 130 + 50, 100), "Play Together"))
		{
			if ((!audioSource1.isPlaying) && (!audioSource2.isPlaying) && (!audioSource3.isPlaying))
			{
				// audioSource1.Play();
				// audioSource2.Play();
				// audioSource3.Play();
				ctrlWR1.control.audioSource1.Play();
				ctrlWR1.control.audioSource2.Play();
				ctrlWR1.control.audioSource3.Play();
				ctrlWR.control.audioSource1.Play();
				ctrlWR.control.audioSource2.Play();
				ctrlWR.control.audioSource3.Play();
			}
		}

	}


	
	public static void ShowDouble(double InputValue, int xForLabel, int yForLabel)
	{
		string output = "";
		output += InputValue.ToString();
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}
	public static void ShowDouble(double InputValue, string information, int xForLabel, int yForLabel)
	{
		string output = "";
		output += information;
		output += InputValue.ToString();
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}

	public static void ShowDouble(List<double> ListInputed, int xForLabel, int yForLabel)
	{

		string output = "";
		for (int i = 0; i < ListInputed.Count; i++)
		{
			output += ListInputed[i].ToString();
		}
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}

	public static void ShowDouble(List<double> ListInputed, string information, int xForLabel, int yForLabel)
	{

		string output = "";
		output += information;
		for (int i = 0; i < ListInputed.Count; i++)
		{
			output += ListInputed[i].ToString();
		}
		GUI.Label(new Rect(xForLabel, yForLabel, 200, 20), output);
	}

}