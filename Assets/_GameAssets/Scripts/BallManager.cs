using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // textmeshpro yazılarını kullanabilmek için ekledik

public class BallManager : MonoBehaviour
{
    [SerializeField] private int _requiredScore; // diğer bölüme geçmek için gereken skoru oluşturduk
    [SerializeField] private float _movementSpeed; // hız değerini oluşturduk
    [SerializeField] private TextMeshProUGUI _pointText; // puanı göstereceğimiz yazıyı oluşturduk
    [SerializeField] private TextMeshProUGUI _messageText; // "yeterli puan yok" gibi mesajları göstereceğimiz yazıyı oluşturduk

    private float _horizontal, _vertical; // kontroller için floatlar oluşturduk
    private int _point = 0; // puanı tutacak değişken, 0'dan başlıyor

    private Rigidbody _playerRb; // referans rigidbodymizi oluşturduk


    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>(); // playerdan rigidbodyi çektik kendimizinkine eşitledik
    }

    private void Start()
    {
        UpdateScoreText(); // seviye başlar başlamaz "Puan: 0 / hedef" yazısını ekrana bastık
    }

    private void Update()
    {
        // Klavye girdilerini her karede (Update) alıyoruz
        _horizontal = Input.GetAxisRaw("Horizontal"); // A-D ve sağ-sol oklarını okuduk
        _vertical = Input.GetAxisRaw("Vertical"); // W-S ve yukarı-aşağı okları okuduk
    }

    private void FixedUpdate()
    {
        Movement(); // fizikle ilgili şeyler FixedUpdate'te yapılır, o yüzden hareketi burada çağırdık
    }

    private void Movement()
    {
        // girdileri tek bir yön vektörüne çevirdik, normalized yaptık ki çaprazda daha hızlı gitmesin
        Vector3 movementDirection = new Vector3(_horizontal, 0f, _vertical).normalized;

        _playerRb.AddForce(movementDirection * _movementSpeed, ForceMode.Force); // yönümüze hız çarpanıyla kuvvet uyguladık
    }

    private void OnTriggerEnter(Collider other) // trigger bir collider'a girince otomatik çalışıyor
    {
        if (other.CompareTag("Finish")) // girdiğimiz objenin tagi Finish mi diye baktık
        {
            LoadLevel(); // bitişe geldiysek seviye kontrolü yapan fonksiyonu çağırdık
        }

        if (other.CompareTag("GreenBall")) // yeşil topa mı girdik
        {
            _point += 10; // yeşil top 10 puan ekliyor
            UpdateScoreText(); // puan değiştiği için yazıyı güncelledik
            Destroy(other.gameObject); // topu yok ettik ki tekrar puan vermesin
        }
        else if (other.CompareTag("RedBall")) // kırmızı topa mı girdik
        {
            _point = Mathf.Max(0, _point - 5); // 5 puan düşürdük, Mathf.Max ile de 0'ın altına inmesini engelledik
            UpdateScoreText(); // puan değiştiği için yazıyı güncelledik
            Destroy(other.gameObject); // kırmızı topu da yok ettik
        }
    }

    private void UpdateScoreText()
    {
        _pointText.text = "Puan: " + _point + " / " + _requiredScore; // puanı ve hedef puanı yazıya bastık
    }

    private void LoadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex; // şu anki sahnenin index'ini aldık
        int nextLevel = currentLevel + 1; // sıradaki sahne bir fazlası

        if (nextLevel < SceneManager.sceneCountInBuildSettings && _point >= _requiredScore) 
        {
            SceneManager.LoadScene(nextLevel); // sonraki sahneyi yükledik
        }
        // sonraki sahne yok ama puan yeterli, yani son bölümdeyiz ve oyunu bitirdik
        else if ( !(nextLevel < SceneManager.sceneCountInBuildSettings) && _point >= _requiredScore)
        {
            _messageText.text = "Oyunu Tamamladınız!"; // mesajı ekranda da gösterdik
        }
        else // puan yetmediyse
        {
            SceneManager.LoadScene(currentLevel); // aynı sahneyi tekrar yükleyip baştan başlatıyoruz
        }
    }
}
