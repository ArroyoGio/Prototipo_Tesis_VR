using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeSmokeTest
{
    [UnityTest]
    public IEnumerator GameObject_CreadoEnPlayMode_ExisteYLuegoSeDestruye()
    {
        // Arrange
        GameObject creado = new GameObject("PlayModeSmokeTest_Object");

        // Act
        yield return null;

        // Assert - existe y esta activo durante PlayMode
        Assert.That(creado, Is.Not.Null, "El GameObject no deberia haber sido destruido.");
        Assert.That(creado.activeInHierarchy, Is.True);

        GameObject encontrado = GameObject.Find("PlayModeSmokeTest_Object");
        Assert.That(encontrado, Is.Not.Null, "GameObject.Find no encontro el objeto creado.");

        // Act - destruir
        Object.Destroy(creado);
        yield return null;

        // Assert - ya no existe
        Assert.That(encontrado == null, Is.True, "El GameObject deberia haberse destruido.");
        Assert.That(GameObject.Find("PlayModeSmokeTest_Object"), Is.Null);
    }
}
