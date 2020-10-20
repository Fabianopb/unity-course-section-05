using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1 = null;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds = null;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // references
    AudioSource audioSource;
    Rigidbody2D mRigidbody2D;
 
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchMouseOnClick();
        }
    }

    private void LaunchMouseOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mRigidbody2D.velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(-randomFactor, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
            audioSource.PlayOneShot(clip);
            mRigidbody2D.velocity += velocityTweak;
        }
    }
}
