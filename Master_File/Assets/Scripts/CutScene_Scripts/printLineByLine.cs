using UnityEngine;
using System.Collections;

public class printLineByLine : MonoBehaviour 
{
	public float letterPause = 0.01f;
	public AudioClip sound;
	public GUIStyle font;

	public string nextLevel = "";
	public string message =  "Hello there! Finally an engineer alive in here!\n" +
			"We don’t really have much time, so I’m gonna be as brief as I can get OK?\n" +
			"So as you might’ve notice, we are not on earth now,\n" +
			"that’s because the goddamned aliens took it!\n" +
			"Anyway, after all the combats, struggles, sacrifices and blah blah blah\n" +
			"all that cliche you might have heard for a million times in movies,\n" +
			"we end up in this planet M49D3.";
	string text;
	bool finishedTyping = false;
	void Start () 
	{
		text = "";
		StartCoroutine(TypeText());
	}
	
	IEnumerator TypeText () 
	{
		if (sound)
			audio.PlayOneShot (sound);

		string []words = message.Split (' ');
		foreach (string letter in words) 
		{
			text += letter + ' ';
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		finishedTyping = true;
	}
	
	void OnGUI()
	{
		
		guiText.text = text;   
	}
	
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Return))
		{
			StopAllCoroutines();
			text = message;
		}
	}
}
