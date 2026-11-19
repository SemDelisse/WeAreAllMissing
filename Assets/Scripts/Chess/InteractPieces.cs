using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPieces : MonoBehaviour
{
    public static InteractPieces instance { get; private set; }

    private LayerMask interactionLayer;
    private Camera cam;
    private float range = 10f;
    private bool chessPuzzleActive = false;
    private int position = 0;
    private bool playerWrong = false;

    private PlayerMovement _PlayerMovements;
    [SerializeField] ChessCamPlacementPuzzle _ChessCamPlacementPuzzle;
    [SerializeField] MeshRenderer playerMesh;
    [SerializeField] Animator anim;
    [SerializeField] GameObject basket;

    //[Header("Note")]
    //private Note _Note;
    //[SerializeField] Sprite spriteNote;

    [Header("Pawns")]
    [SerializeField] GameObject whitePawn;
    [SerializeField] GameObject blackPawn;

    [Header("Materials")]
    [SerializeField] Material white;
    [SerializeField] Material black;

    private void Start()
    {
        instance = this;

        interactionLayer = LayerMask.GetMask("Chess");
        _PlayerMovements = GetComponent<PlayerMovement>();
        //_Note = FindFirstObjectByType<Note>();
        cam = FindFirstObjectByType<Camera>();
        _ChessCamPlacementPuzzle = FindFirstObjectByType<ChessCamPlacementPuzzle>();
        position = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && chessPuzzleActive)
        {
            CheckPlace();
        }
    }

    public void CheckPlace()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, interactionLayer))
        {
            ChessPlace chessPosition = hit.collider.GetComponent<ChessPlace>();
            if (chessPosition != null)
            {
                bool correct = chessPosition.checkPosition(position);
                if (position == 0)
                {
                    if (correct)
                    {
                        var outline = whitePawn.AddComponent<Outline>();
                        outline.OutlineMode = Outline.Mode.OutlineAll;
                        outline.OutlineColor = Color.black;
                        outline.OutlineWidth = 5f;
                        position = 1;
                    }
                    else if (!correct)
                    {
                        ChessInteract.instance.ToggleCollider(true);
                        playerWrong = true;
                        stopGame();
                    }
                }
                else if (position == 1)
                {
                    if (correct)
                    {
                        var outline = whitePawn.GetComponent<Outline>();
                        Destroy(outline);
                        Destroy(blackPawn);
                        Destroy(basket);
                        anim.SetBool("movePawn", true);
                        StartCoroutine(Coroutine(1.5f));
                        _ChessCamPlacementPuzzle.canStartGame = false;
                        stopGame();
                    }
                    else if (!correct)
                    {
                        ChessInteract.instance.ToggleCollider(true);
                        playerWrong = true;
                        stopGame();
                    }
                }
            }
            else
            {
                Debug.Log("Not a chess position");
            }
        }
    }

    public void startGame()
    {
        chessPuzzleActive = true;
        position = 0;
        playerWrong = false;
        // // Showing the player mesh
        //if (playerMesh != null) playerMesh.enabled = false;
    }

    public void stopGame()
    {
        anim.SetBool("movePawn", false);
        var outline = whitePawn.GetComponent<Outline>();
        Destroy(outline);
        chessPuzzleActive = false;
        _ChessCamPlacementPuzzle.StartCameraTransition(_ChessCamPlacementPuzzle.startPoint, lockPlayer: false);
        // // Showing the player mesh
        //if (playerMesh != null) playerMesh.enabled = true;
    }

    IEnumerator Coroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
