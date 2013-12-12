using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using BankGame.Map;

namespace BankGame
{
    class MovementArrow : Sprite
    {
        private Point previousTile;
        private Point currentTile;

        public Direction[,] TileDirection
        {
            get { return tileDirection; }
        }
        private Direction[,] tileDirection;


        public MovementArrow(MapLayout mapLayout)
        {
            tileDirection = new Direction[mapLayout.NumberOfTilesX, mapLayout.NumberOfTilesY];

            initTileDirection();
        }


        private void initTileDirection()
        {
            for (int y = 0; y < tileDirection.GetLength(1); y++)
            {
                for (int x = 0; x < tileDirection.GetLength(0); x++)
                {
                    tileDirection[x, y] = Direction.NONE;
                }
            }
        }
        

        public void setTileDirection(int xCoord, int yCoord, Direction direction)
        {
            if (xCoord >= 0 && xCoord < tileDirection.GetLength(0) && yCoord >= 0 && yCoord < tileDirection.GetLength(1))
            {
                tileDirection[xCoord, yCoord] = direction;
                return;
            }
            Debug.WriteLine("Invalid tile direction: [" + xCoord + ", " + yCoord + "] out of bounds");
        }


    }

    public enum Direction
    {
        NONE,
        SINGLE,
        UP,
        LEFT,
        DOWN,
        RIGHT,
        _UP,
        _LEFT,
        _DOWN,
        _RIGHT,
        UP_LEFT,
        UP_DOWN,
        UP_RIGHT,
        LEFT_DOWN,
        LEFT_RIGHT,
        LEFT_UP,
        DOWN_RIGHT,
        DOWN_UP,
        DOWN_LEFT,
        RIGHT_UP,
        RIGHT_LEFT,
        RIGHT_DOWN
    }
}
