void CreateOneTrack(AudioSource AudioSourceInputed,
		ref List<double> MusicScoreInputed,
		int StartY, ref int isAccRecordingLocal,
		ref int InstrumentType, ref int PitchingLocal)
{
	ShowDouble(MusicScoreInputed, "SoureInputed: ", 0, 0 + StartY);
	int x0 = 200;
	int XGap = 150;
	int YGap = 0;
	int SizeX = 130;
	int SizeY = 100;
	if (GUI.Button(new Rect(x0 + 0, StartY, SizeX, SizeY), "Recorded")) {
		for (int i = 0; i < musicScoreX.Count; i++)
		{
			MusicScoreInputed.Add(musicScoreX[i]);
		}
		musicScoreX.Clear();
	}
	if (GUI.Button(new Rect(x0 + XGap, StartY + YGap, SizeX, SizeY), "Play music")) {
		CombineScore(MusicScoreInputed, AudioSourceInputed, InstrumentType);
		if (!AudioSourceInputed.isPlaying){
			AudioSourceInputed.Play();
		}
	}
	if (GUI.Button(new Rect(x0 + 2 * XGap, StartY + YGap, SizeX / 2, SizeY), "Clear")) {
		MusicScoreInputed.Clear();
	}
	int InstrumentControlx0 = 20;
	int InstrumentControly0 = StartY + 20;
	if (GUI.Button(new Rect(InstrumentControlx0, InstrumentControly0, 
	SizeX / 3, SizeY - 30), "1")) {
		InstrumentType = 2;
	}
	if (GUI.Button(new Rect(InstrumentControlx0 + SizeX / 3 + 10,
	 InstrumentControly0, SizeX / 3, SizeY - 30), "2")) { 
		InstrumentType = 3; 
	}
	if (GUI.Button(new Rect(InstrumentControlx0 + SizeX / 3 + 70, 
	InstrumentControly0, SizeX / 3, SizeY - 30), "3"))
	{ 
		InstrumentType = 4; 
	}	
	int PitchingControlx0 = 0;
	int PitchingControly0 = StartY + 110;
	if (GUI.Button(new Rect(PitchingControlx0, PitchingControly0,
	 150, 50), "Toggle Pitching")) {
		if (PitchingLocal == 0) {
			PitchingLocal = 1;
			AudioSourceInputed.loop = true;
		}
		else {
			PitchingLocal = 0;
			AudioSourceInputed.loop = false;
		}
	}	