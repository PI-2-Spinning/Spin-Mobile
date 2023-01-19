using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
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
            StartCoroutine(RemoveAfterSeconds(2));
        } else
        {
            myRenderer.material.color = inactiveColor;
        }
    }

    IEnumerator RemoveAfterSeconds (int seconds){
        yield return new WaitForSeconds(seconds);

        if(isGazed){
            myRenderer.material.color = gazedAtColor;
            gameObject.SetActive(false);
        }
    }
}
