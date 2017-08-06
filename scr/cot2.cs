	if (GUI.Button(new Rect(InstrumentControlx0 + SizeX / 3 + 70, 
	InstrumentControly0, SizeX / 3, SizeY - 30), "3"))
	{ 
		InstrumentType = 4; 
	}	
	int PitchingControlx0 = 0;
	int PitchingControly0 = StartY + 110;
	if (GUI.Button(new Rect(PitchingControlx0, PitchingControly0,
	 150, 50), "Toggle Pitching"))
	{
		if (PitchingLocal == 0)
		{
			PitchingLocal = 1;
			AudioSourceInputed.loop = true;
		}
		else
		{
			PitchingLocal = 0;
			AudioSourceInputed.loop = false;
		}
		Debug.Log(PitchingLocal);
	}

	int PitchingSlidex0 = PitchingControlx0 + 200;
	int PitchingSlidey0 = PitchingControly0 + 30;
	if (PitchingLocal == 1)
	{
		float musicPitch;
		musicPitch = GUI.HorizontalSlider(new Rect(PitchingSlidex0, 
		PitchingSlidey0, 300, 50),
		(float)(System.Math.Pow(2.9, Input.acceleration.x)), 0.0F, 3.0F);
		AudioSourceInputed.pitch = musicPitch;
	}
}