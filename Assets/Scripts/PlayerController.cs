using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player movement speed
    public float speed = 10f;
    // Boundary limits for player movement on the Z axis
    public float minZ; // Minimum Z-boundary
    public float maxZ; // Maximum Z-boundary
    // Reference to the player's Rigidbody component
    public Rigidbody rb;
    // UI Text element to display the current score
    public TextMeshProUGUI score;
    // Score counter
    private int count = 0;

    // UI Text element for the start game instruction
    public TextMeshProUGUI TapToStart;

    // UI Text element to display the final score when game ends
    public TextMeshProUGUI finalScore;

    // Panel that appears when game is over
    public GameObject gameOverPanel;
    // Audio sources for different game sounds
    public AudioSource collectSound;    // Sound when collecting targets
    public AudioSource gameOverSound;   // Sound when game ends
    public AudioSource backgroundMusic; // Background music during gameplay

    // Called when the script instance is being loaded
    void Start()
    {
        // Start playing background music
        backgroundMusic.Play();
        // Pause the game at start
        Time.timeScale = 0f;
        // Hide the game over panel initially
        gameOverPanel.SetActive(false);
        // Initialize the score display
        score.text = count.ToString();
        // Get a reference to the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Restrict rotation and vertical movement of the player
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    // Called once per frame
    void Update()
    {
        // Handle pause/unpause functionality with Space or Enter keys
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;  // Pause the game
                TapToStart.text = "Tap to Start !";
            }
            else
            {
                Time.timeScale = 1f;  // Unpause the game
                TapToStart.text = "";
            }
        }

        // Get current position of the player
        Vector3 position = transform.position;

        // Handle left movement using A or Left Arrow keys
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            position.z += speed * Time.deltaTime;
        }

        // Handle right movement using D or Right Arrow keys
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            position.z -= speed * Time.deltaTime;
        }

        // Restrict player movement within defined boundaries
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        // Apply the new position
        transform.position = position;
    }

    // Called at fixed time intervals (for physics calculations)
    void FixedUpdate()
    {
        // Apply constant forward movement using physics
        // Maintains Y velocity while setting X to constant speed and Z to 0
        rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, 0);
    }

    // Called when the player collides with another object
    void OnCollisionEnter(Collision other)
    {
        // Check if player hit a wall that ends the game
        if (other.gameObject.tag == "ProperWall" || other.gameObject.tag == "LoseWall")
        {
            // Stop the background music
            backgroundMusic.Stop();
            // Show the game over panel
            gameOverPanel.SetActive(true);
            // Play game over sound effect
            gameOverSound.Play();
            // Display the final score
            finalScore.text = finalScore.text + " " + count.ToString();
            // Log the game over message to console
            Debug.Log("Game Over!!");

            // Disable the player controller to prevent further input
            this.enabled = false;
        }
    }

    // Called when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if player collected a target
        if (other.gameObject.tag == "Target")
        {
            // Play collection sound effect
            collectSound.Play();
            // Remove the collected target from the scene
            Destroy(other.gameObject);
            // Increment score
            count++;
            // Update score display
            score.text = count.ToString();
        }
    }

    // Called when the restart button is clicked
    public void RestartButton()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene("MyGame");
    }

    // Called when the quit button is clicked
    public void QuitButton()
    {
        // Exit the application
        Application.Quit();
    }
}