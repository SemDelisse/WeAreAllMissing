using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class ChessCamPlacementPuzzle : MonoBehaviour
{
    public static ChessCamPlacementPuzzle Instance { get; private set; }

    [SerializeField] float camSpeed = 1f;
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] Canvas canvas;
    public bool canStartGame = true;

    private PlayerMovement _playerMovement;
    private InteractPieces _InteractPieces;
    private Coroutine _cameraRoutine;

    [Header("Note")]
    private Note _Note;
    [SerializeField] Sprite spriteNote;

    private void Start()
    {
        Instance = this;

        _playerMovement = FindFirstObjectByType<PlayerMovement>();
        _InteractPieces = FindFirstObjectByType<InteractPieces>();
        _Note = FindFirstObjectByType<Note>();
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V) && canStartGame)
        //{
        //    StartCameraTransition(endPoint, lockPlayer: true);
        //    _InteractPieces.startGame();
        //}
        if (Input.GetKeyDown(KeyCode.Escape) && ChessInteract.instance.interacting)
        {
            ChessInteract.instance.interacting = false;
            ChessInteract.instance.ToggleCollider(true);

            _InteractPieces.stopGame();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _Note.ShowNote("Chess", "It looks like a simple game with a simple answer. 1 move, 1 pion, 1 final position. But can you find it?", spriteNote);
        }
    }

    public void StartCameraTransition(Transform target, bool lockPlayer)
    {
        if (_cameraRoutine != null)
            StopCoroutine(_cameraRoutine);

        _playerMovement.lockMovement = lockPlayer;

        _cameraRoutine = StartCoroutine(CameraTransitionCoroutine(target, lockPlayer));
    }

    private IEnumerator CameraTransitionCoroutine(Transform target, bool lockPlayer)
    {
        Vector3 initialPos = transform.position;
        Quaternion initialRot = transform.rotation;

        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += camSpeed * Time.deltaTime;
            float t = Mathf.Clamp01(elapsed);

            transform.position = Vector3.Lerp(initialPos, target.position, t);
            transform.rotation = Quaternion.Slerp(initialRot, target.rotation, t);

            yield return null;
        }

        //transform.position = target.position;
        //transform.rotation = target.rotation;

        MainCamPos.Instance.inPuzzle = lockPlayer;

        _playerMovement.lockMovement = lockPlayer;
        _cameraRoutine = null;
    }
}
