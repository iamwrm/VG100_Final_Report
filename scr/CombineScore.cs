	public void CombineScore(List<double> MusicScoreInputed, AudioSource AudioSourceInThisFunction, int InstrumentType)
	{
		if (InstrumentType == 0)
		{
			Debug.Log("the Instrument Type input is 0 , it should begin from 1");
		}
		AudioClip tempc = new AudioClip();

		for (int i = 0; i < MusicScoreInputed.Count; i++)
		{
			AudioClip clippp = AudioClipColletion[(int)(MusicScoreInputed[i]) + (InstrumentType - 1) * 8];
			tempc = ACCombine(tempc, clippp);
		}

		AudioSourceInThisFunction.clip = tempc;

	}