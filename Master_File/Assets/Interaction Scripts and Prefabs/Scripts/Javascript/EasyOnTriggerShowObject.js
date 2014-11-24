#pragma strict
@script RequireComponent(BoxCollider);

public var objectToShow:GameObject;
public var hideBeforeShow:boolean = true;
public var destroyMeAfterwards:boolean;


function Start () {
	GetComponent(BoxCollider).isTrigger = true;
	if(hideBeforeShow == true){
		objectToShow.SetActive(false);
	}
}

function OnTriggerEnter(){
	objectToShow.SetActive(true);
	if (destroyMeAfterwards == true){
		Destroy(gameObject);
	}
}


