﻿using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShipPlacementTests
    {
        [Test]
        public void CanNotOverlapShips()
        {
            var board = new Board();

            // let's put a carrier at (10,10), (9,10), (8,10), (7,10), (6,10)
            var carrierRequest = new PlaceShipRequest
            {
                Coordinate = new Coordinate(1, 1),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            var carrierResponse = board.PlaceShip(carrierRequest);

            Assert.AreEqual(ShipPlacement.Ok, carrierResponse);

            // now let's put a destroyer overlapping the y coordinate
            var destroyerRequest = new PlaceShipRequest
            {
                Coordinate = new Coordinate(2, 1),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Destroyer
            };

            var destroyerResponse = board.PlaceShip(destroyerRequest);

            Assert.AreEqual(ShipPlacement.Overlap, destroyerResponse);
        }

        [Test]
        public void CanNotPlaceShipOffBoard()
        {
            var board = new Board();
            var request = new PlaceShipRequest
            {
                Coordinate = new Coordinate(15, 10),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Destroyer
            };

            var response = board.PlaceShip(request);

            Assert.AreEqual(ShipPlacement.NotEnoughSpace, response);
        }

        [Test]
        public void CanNotPlaceShipPartiallyOnBoard()
        {
            var board = new Board();
            var request = new PlaceShipRequest
            {
                Coordinate = new Coordinate(10, 10),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            var response = board.PlaceShip(request);

            Assert.AreEqual(ShipPlacement.NotEnoughSpace, response);
        }
    }
}