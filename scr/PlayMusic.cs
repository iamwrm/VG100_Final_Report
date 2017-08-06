void PlayMusic1()
	{
	if (GUI.Button(new Rect(0, 800, 150, 150), "Reset Acc")) {
		InitialGravityAccForX = Input.acceleration;
	}
	if (GUI.Button(new Rect(200, 800, 150, 150), "Clear AccForX")) {
		musicScoreX.Clear();
	}