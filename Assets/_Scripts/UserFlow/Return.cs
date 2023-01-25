using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject previousPage;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color gazedAtColor;
    public bool isGazed = false;

    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = inactiveColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnPointerEnter()
    {
        GazeAt(true);
        isGazed = true;
    }

    public void OnPointerExit()
    {
        GazeAt(false);
        isGazed = true;
    }

    public void GazeAt(bool gazing)
    {
        if(gazing)
        {   
            myRenderer.material.color = gazedAtColor;
            StartCoroutine(GoToPageAfterSeconds(2));
        } else
        {
            myRenderer.material.color = inactiveColor;
        }
    }

    IEnumerator GoToPageAfterSeconds (int seconds){
    yield return new WaitForSeconds(seconds);

    var father = gameObject.transform.parent.gameObject;

    father.SetActive(false);

    if(isGazed){
        for (int i = 0; i < father.transform.childCount; i++){
            var child = father.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }

        father.SetActive(false);
        }
    }
}
