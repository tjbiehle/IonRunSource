#pragma strict
@script RequireComponent(BoxCollider);

public var objectToHide:GameObject;
public var destroyMeAfterwards:boolean;

function Start () {
	GetComponent(BoxCollider).isTrigger = true;
	
}

function OnTriggerEnter(){
	objectToHide.SetActive(false);
	
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}


