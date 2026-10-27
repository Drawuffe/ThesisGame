using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonClick : MonoBehaviour
{
    public Transform camTrans;
    public float shakeTime = 0.5f;
    public float shakeAmt = 0.05f;

    private Vector3 originalPos;

    public List<Material> materialList;

    private MeshRenderer meshRenderer;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (camTrans == null)
        {
            camTrans = GetComponent(typeof(Transform)) as Transform;
        }
        originalPos = camTrans.localPosition;
        AssignRandomMaterial();
    }


    void Update()
    {
        // Check if the key/button is pressed down
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Shake());
            AssignRandomMaterial();
        }
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        

        while (elapsedTime < shakeTime)
        {
            camTrans.localPosition = originalPos + Random.insideUnitSphere * shakeAmt;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        camTrans.localPosition = originalPos;
    }

    void AssignRandomMaterial()
    {
        int randomIndex = Random.Range(0, materialList.Count);
        Material chosenMaterial = materialList[randomIndex];
        meshRenderer.material = chosenMaterial;
    }
}
