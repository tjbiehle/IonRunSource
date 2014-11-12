using UnityEngine;
using System.Collections;

public class ClickLoadLevelCS : MonoBehaviour {
	public string sceneFileName = "Level2";
	public bool destroyMeAfterwards;
	
	
	IEnumerator OnMouseUpEvent(){
	
	Application.LoadLevel(sceneFileName);
	
	if (destroyMeAfterwards == true){
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
}
