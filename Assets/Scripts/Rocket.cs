using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 300f;
    [SerializeField] private float flySpeed = 10f;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    
    enum State
    {
        Playing,
        Dead,
        NextLevel
    };
    
    State _state = State.Playing;
    
    void Start()
    {
        _state = State.Playing;
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.mass = 0.7f;
        _rigidbody.drag = 1.0f;
    }

    void Update()
    {
        if (_state == State.Playing)
        {
            LaunchRocket();
            RotateRocket();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_state != State.Playing)
        {
            return;
        }
        
        switch (collision.gameObject.tag)
        {
            case "Finish" :
                print("finish");
                _state = State.NextLevel;
                Invoke(nameof(LoadNextLevel), 3f);
                break;
            case "Battery" : 
                print("plus energy");
                break;
            case "Barrier":
                print("dead");
                _state = State.Dead;
                Invoke(nameof(LoadFirstLevel), 3f);
                break;
        }
    }


    void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
    
    void LaunchRocket()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(new Vector3(0,0.125f, 0) * flySpeed);
            if (!_audioSource.isPlaying)
            {
                _audioSource.volume = 0.15f;
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Pause();
        }
    }
    
    void RotateRocket()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,0.125f) * rotationSpeed);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0 , -0.125f) * rotationSpeed);
        }
        _rigidbody.freezeRotation = false;
    }
}
