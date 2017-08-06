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
	int aa, ab, ac;
	aa = nowDev.x >= 0 ? 1 : 0;
	ab = nowDev.y >= 0 ? 1 : 0;
	ac = nowDev.z >= 1 ? 1 : 0;
	int[] WRmap = { 3, 4, 2, 1, 0, 7, 5, 6 };
	if (GUI.Button(new Rect(400, 800, 150, 150), " Start Motion")) {
		RecordingX = 1;
	}
	if (GUI.Button(new Rect(400 + 150, 800, 150 / 2, 150), " Stop")) {
		RecordingX = 0;
	}
	if (RecordingX == 1) {
		if ((nowDev).magnitude > 0.5) {
			if (!audioSourceX.isPlaying) {
				audioSourceX.clip = 
				AudioClipColletion[WRmap[aa + ab * 2 + ac * 4]];
				musicScoreX.Add(WRmap[aa + ab * 2 + ac * 4]);
				audioSourceX.Play();
			}
		}
	}