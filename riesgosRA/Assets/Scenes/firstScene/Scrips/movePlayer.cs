using UnityEngine;

public class movePlayer : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 5f;
    [SerializeField] private float velocidadRotacion = 2f;
    [SerializeField] private CharacterController characterController;

    [Header("Referencias")]
    [SerializeField] private Transform cuerpoJugador; // El cuerpo que rota horizontalmente
    [SerializeField] private Camera camaraJugador;    // Cámara para rotación vertical

    private float rotacionVertical = 0f;

    void Update()
    {
        Mover();
        Rotar();
    }

    void Mover()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 direccion = (cuerpoJugador.right * movX + cuerpoJugador.forward * movZ).normalized;
        characterController.Move(direccion * velocidadMovimiento * Time.deltaTime);
    }

    void Rotar()
    {
        float mouseX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float mouseY = Input.GetAxis("Mouse Y") * velocidadRotacion;

        // Rotación vertical (cámara)
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);
        camaraJugador.transform.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);

        // Rotación horizontal (cuerpo)
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}