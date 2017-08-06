	void OnGUI()
	{
		CreateOneTrack(audioSource1, ref musicScore1, 000, 
		ref isAccRecording1, ref InstrumentType1, ref Pitching1);
		CreateOneTrack(audioSource2, ref musicScore2, 170, 
		ref isAccRecording2, ref InstrumentType2, ref Pitching2);
		CreateOneTrack(audioSource3, ref musicScore3, 340, 
		ref isAccRecording3, ref InstrumentType3, ref Pitching3);
		PlayMusic1();
	}