using UnityEngine;
using System.Collections;

public class ClickHideObjectCS : MonoBehaviour {
	
	public GameObject objectToHide;
	public bool destroyMeAfterwards;
	
	IEnumerator OnMouseUpEvent(){
	
		objectToHide.SetActive(false);
		
		if (destroyMeAfterwards == true){
			yield return new WaitForSeconds(2);
			Destroy(gameObject);
		}
	}
}
