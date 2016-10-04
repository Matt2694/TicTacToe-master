using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToeTests
{
    [TestClass]
    public class GameWinnerServiceTests
    {

        IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;
        private char expected = 'X';

        [TestInitialize]
        public void SetupUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3]{ {' ', ' ', ' '},
                                         {' ', ' ', ' '},
                                         {' ', ' ', ' '}};
        }

        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            expected = ' ';
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameBoard[0, i] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInBottomRowIsWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameBoard[2, i] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInMiddleRowIsWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                _gameBoard[1, i] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 0] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInThirdColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 2] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithAllSpacesInSecondColumnIsWinner()
        {
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 1] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, cellIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyTopAndToLeftIsWinner()
        {
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameBoard[cellIndex, (2 - cellIndex)] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}