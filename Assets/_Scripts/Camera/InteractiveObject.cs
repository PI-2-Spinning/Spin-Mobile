using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color gazedAtColor;
    [SerializeField] private GameObject nextFlow;
    [SerializeField] private bool isParent;
    [SerializeField] private bool toSimulate = false;
    [SerializeField] private bool isPauseButton = false;
    [SerializeField] private bool isPauseMode = false;
    [SerializeField] private bool isExitButton = false;

    public bool isGazed = false;
    
    private MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = inactiveColor;
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
            StartCoroutine(RemoveAfterSeconds(2));
        } else
        {
            myRenderer.material.color = inactiveColor;
        }
    }

    IEnumerator RemoveAfterSeconds (int seconds){
        yield return new WaitForSeconds(seconds);

        if(isGazed){
            if(isExitButton){
                GeneralController.controllerInstance.getState().handle();
            }
            if(nextFlow != null){
                for (int i = 0; i < gameObject.transform.childCount; i++){
                    var child = gameObject.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }

                if(isParent == false){
                    gameObject.transform.parent.gameObject.SetActive(false);
                }

                gameObject.SetActive(false);
                
                nextFlow.SetActive(true);
                for (int i = 0; i < nextFlow.transform.childCount; i++){
                    var child = nextFlow.transform.GetChild(i).gameObject;
                    child.SetActive(true);
                    if (child != null){
                        for (int j = 0; j < child.transform.childCount; j++){
                            var childOfChild = child.transform.GetChild(j).gameObject;
                            childOfChild.SetActive(true);
                        }
                    }
                }
            } else if (nextFlow == null && toSimulate == false) {
                for (int i = 0; i < gameObject.transform.childCount; i++){
                    var child = gameObject.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }

                if(isParent == false){
                    gameObject.transform.parent.gameObject.SetActive(false);
                }

                gameObject.SetActive(false);

                SceneManager.LoadScene("InsertInfo");

            } else if (toSimulate) {
                Debug.Log("Carregando mapa");
                GeneralController.controllerInstance.getState().handle();
                SceneManager.LoadScene("TheSpinSSPath");
            }
        }
    }
}
