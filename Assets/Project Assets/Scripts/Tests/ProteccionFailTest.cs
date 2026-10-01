using NUnit.Framework;

public class ProteccionFailTest
{
    [Test]
    public void PruebaDeProteccionDebeFallar()
    {
        Assert.Fail("PRUEBA INTENCIONAL: este test debe fallar para comprobar la protección de master.");
    }
}
