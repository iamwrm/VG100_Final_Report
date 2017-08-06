	int PitchingSlidex0 = PitchingControlx0 + 200;
	int PitchingSlidey0 = PitchingControly0 + 30;
	if (PitchingLocal == 1) {
		float musicPitch;
		musicPitch = GUI.HorizontalSlider(new Rect(PitchingSlidex0, 
		PitchingSlidey0, 300, 50),
		(float)(System.Math.Pow(2.9, Input.acceleration.x)), 0.0F, 3.0F);
		AudioSourceInputed.pitch = musicPitch;
	}
}