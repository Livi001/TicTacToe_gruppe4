using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using tictactoe_gruppe4;

[TestClass]
public class GameControllerTests
{
    [TestMethod]
    public void SwitchPlayer_ShouldSwitchCurrentPlayer()
    {
        // Arrange
        var controller = GameController.Instance;

        // Zugriff auf die private CurrentPlayer-Eigenschaft mittels Reflection
        var currentPlayerField = typeof(GameController).GetProperty("CurrentPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
        var firstPlayer = currentPlayerField.GetValue(controller); // Aktuellen Spieler ermitteln

        // Act
        var switchMethod = typeof(GameController).GetMethod("SwitchPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
        switchMethod.Invoke(controller, null); // SwitchPlayer-Methode aufrufen

        // Zweiten Spieler ermitteln
        var secondPlayer = currentPlayerField.GetValue(controller);

        // Assert
        Assert.AreNotEqual(firstPlayer, secondPlayer); // Überprüfen, ob die Spieler gewechselt wurden
    }
}
