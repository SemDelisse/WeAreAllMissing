using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ChessInteract : MonoBehaviour, Iinteractable
{
    public static ChessInteract instance { get; private set; }

    /// Interaction
    private void Awake()
    {
        instance = this;
    }

    public bool interacting = false;
    public void Interact(Transform interactorTransform)
    {
        MainCamPos.Instance.inPuzzle = true;
        interacting = true;
        ToggleCollider(false);
        ChessCamPlacementPuzzle.Instance.StartCameraTransition(ChessCamPlacementPuzzle.Instance.endPoint, lockPlayer: true);
        InteractPieces.instance.startGame();
    }

    public string GetInteractText()
    {
        return "Play Game";
    }

    public void ToggleCollider(bool enable)
    {
        Collider col = GetComponent<Collider>();
        col.enabled = enable;
    }
}
