using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    [SerializeField] AlphaJargon Jargon;
    [SerializeField] Collider ArcadeCollider;
    [SerializeField] ComputerManager Computer;
    public string FileData;
    AlphaJargon Instance;
    void OnEnable()
    {
        Eyes.OnRayCastHitEvent += RunGame;
        Eyes.OnRayCastHitEvent += HackArcade;
    }

    void OnDisable()
    {
        Eyes.OnRayCastHitEvent -= RunGame;
        Eyes.OnRayCastHitEvent -= HackArcade;
    }

    void RunGame(RaycastHit hit)
    {
        if(!Input.GetMouseButtonDown(0) || !hit.collider.Equals(ArcadeCollider))
            return;
        if(Instance != null)
            Destroy(Instance.gameObject);

        Instance = Instantiate(Jargon, gameObject.transform);

        Instance.setCabinet(this);
        Instance.Compiler.add(FileData);
        Instance.Compiler.RunScript();

        Instance.AwakeGame();
        Instance.InitializeGame();
        Instance.StartGame();
    }

    void HackArcade(RaycastHit hit)
    {
        if(!Input.GetKeyDown(KeyCode.H))
            return;
        if(hit.collider.Equals(ArcadeCollider) && Computer.gameObject.transform.localPosition.z < -0.5) 
            Computer.gameObject.transform.localPosition -= new Vector3(0,0, 0.5f);
        else if(hit.collider.Equals(Computer.ComputerCollider && Computer.gameObject.transform.localPosition.z > -0.11))
            Computer.gameObject.transform.localPosition += new Vector3(0,0, 0.5f);
    }
}
