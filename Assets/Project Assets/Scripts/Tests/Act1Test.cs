using NUnit.Framework;
using UnityEngine;

public class Act1Test
{
    [Test]
    public void ResultadoEvento_CreaEventoConDatosCorrectos()
    {
        // Arrange
        string competencia = "Persistencia";
        string situacion = "Feedback negativo";
        string comportamiento = "Corrigio proyecto";
        float tiempo = 10f;
        string tendencia = "fortaleza";

        // Act
        ResultadoEvento resultado = new ResultadoEvento(
            competencia,
            situacion,
            comportamiento,
            tiempo,
            tendencia
        );

        // Assert
        Assert.That(resultado.competencia, Is.EqualTo(competencia));
        Assert.That(resultado.tiempoReaccion, Is.EqualTo(tiempo));
    }


    [Test]
    public void Interact_CuandoPuedeInteractuar_EjecutaEvento()
    {
        // Arrange
        GameObject obj = new GameObject();
        InteractableObject interactable = obj.AddComponent<InteractableObject>();
        interactable.onInteract = new UnityEngine.Events.UnityEvent();

        bool eventoEjecutado = false;

        interactable.canInteract = true;
        interactable.onInteract.AddListener(() => eventoEjecutado = true);

        // Act
        interactable.Interact();

        // Assert
        Assert.That(eventoEjecutado, Is.True);

        Object.DestroyImmediate(obj);
    }


    [Test]
    public void Interact_CuandoNoPuedeInteractuar_NoEjecutaEvento()
    {
        // Arrange
        GameObject obj = new GameObject();
        InteractableObject interactable = obj.AddComponent<InteractableObject>();
        interactable.onInteract = new UnityEngine.Events.UnityEvent();

        bool eventoEjecutado = false;

        interactable.canInteract = false;
        interactable.onInteract.AddListener(() => eventoEjecutado = true);

        // Act
        interactable.Interact();

        // Assert
        Assert.That(eventoEjecutado, Is.False);

        Object.DestroyImmediate(obj);
    }


    [Test]
    public void Interact_CuandoEsUnaSolaVez_NoSeEjecutaSegundaVez()
    {
        // Arrange
        GameObject obj = new GameObject();
        InteractableObject interactable = obj.AddComponent<InteractableObject>();
        interactable.onInteract = new UnityEngine.Events.UnityEvent();

        int cantidadInteracciones = 0;

        interactable.canInteract = true;
        interactable.interactableOnce = true;
        interactable.onInteract.AddListener(() => cantidadInteracciones++);

        // Act
        interactable.Interact();
        interactable.Interact();

        // Assert
        Assert.That(cantidadInteracciones, Is.EqualTo(1));

        Object.DestroyImmediate(obj);
    }

    [Test]
    public void Show_ActivaElPanelCorrectamente()
    {
        // Arrange
        GameObject objeto = new GameObject("Objeto");
        ShowInfoPanel infoPanel = objeto.AddComponent<ShowInfoPanel>();

        GameObject panel = new GameObject("Panel");
        infoPanel.panel = panel;

        panel.SetActive(false);

        // Act
        infoPanel.Show();

        // Assert
        Assert.That(panel.activeSelf, Is.True);

        Object.DestroyImmediate(objeto);
        Object.DestroyImmediate(panel);
    }

}