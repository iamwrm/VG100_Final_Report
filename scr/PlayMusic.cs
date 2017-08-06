void PlayMusic1()
	{
	if (GUI.Button(new Rect(0, 800, 150, 150), "Reset Acc")) {
		InitialGravityAccForX = Input.acceleration;
	}
	if (GUI.Button(new Rect(200, 800, 150, 150), "Clear AccForX")) {
		musicScoreX.Clear();
	}
	if (GUI.Button(new Rect(600, 1050, 150, 150), "Change Scene to 1")) {
		SceneManager.LoadScene(1); 
	}
	if (GUI.Button(new Rect(600, 1200, 150, 150), "Change Scene to 2")) {
		SceneManager.LoadScene(2); 
	}
	for (int i = 0; i < 8; i++) {
		if (GUI.Button(new Rect(60 * i, 650 + 50, 55, 80), (i).ToString())) {
			musicScoreX.Add(i);
		}
	}
	Vector3 nowDev = Input.acceleration - InitialGravityAccForX;