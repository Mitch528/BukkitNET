using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;
using BukkitNET.Entities;

namespace BukkitNET.Util
{
    public class BlockIterator : IEnumerator<IBlock>
    {

        private IWorld world;
        private int maxDistance;

        private static int gridSize = 1 << 24;

        private bool end = false;

        private IBlock[] blockQueue = new IBlock[3];
        private int currentBlock = 0;
        private int currentDistance = 0;
        private int maxDistanceInt;

        private int secondError;
        private int thirdError;

        private int secondStep;
        private int thirdStep;

        private BlockFace mainFace;
        private BlockFace secondFace;
        private BlockFace thirdFace;

        public BlockIterator(IWorld world, Vector start, Vector direction, double yOffset, int maxDistance)
        {
            this.world = world;
            this.maxDistance = maxDistance;

            Vector startClone = new Vector(start.X, start.Y, start.Z);

            startClone.Y = (startClone.Y + yOffset);

            currentDistance = 0;

            double mainDirection = 0;
            double secondDirection = 0;
            double thirdDirection = 0;

            double mainPosition = 0;
            double secondPosition = 0;
            double thirdPosition = 0;

            IBlock startBlock = this.world.GetBlockAt((int)Math.Floor(startClone.X), (int)Math.Floor(startClone.Y), (int)Math.Floor(startClone.Z));

            if (GetXLength(direction) > mainDirection)
            {
                mainFace = GetXFace(direction);
                mainDirection = GetXLength(direction);
                mainPosition = GetXPosition(direction, startClone, startBlock);

                secondFace = GetYFace(direction);
                secondDirection = GetYLength(direction);
                secondPosition = GetYPosition(direction, startClone, startBlock);

                thirdFace = GetZFace(direction);
                thirdDirection = GetZLength(direction);
                thirdPosition = GetZPosition(direction, startClone, startBlock);
            }
            if (GetYLength(direction) > mainDirection)
            {
                mainFace = GetYFace(direction);
                mainDirection = GetYLength(direction);
                mainPosition = GetYPosition(direction, startClone, startBlock);

                secondFace = GetZFace(direction);
                secondDirection = GetZLength(direction);
                secondPosition = GetZPosition(direction, startClone, startBlock);

                thirdFace = GetXFace(direction);
                thirdDirection = GetXLength(direction);
                thirdPosition = GetXPosition(direction, startClone, startBlock);
            }
            if (GetZLength(direction) > mainDirection)
            {
                mainFace = GetZFace(direction);
                mainDirection = GetZLength(direction);
                mainPosition = GetZPosition(direction, startClone, startBlock);

                secondFace = GetXFace(direction);
                secondDirection = GetXLength(direction);
                secondPosition = GetXPosition(direction, startClone, startBlock);

                thirdFace = GetYFace(direction);
                thirdDirection = GetYLength(direction);
                thirdPosition = GetYPosition(direction, startClone, startBlock);
            }

            double d = mainPosition / mainDirection;
            double secondd = secondPosition - secondDirection * d;
            double thirdd = thirdPosition - thirdDirection * d;

            secondError = (int)Math.Floor(secondd * gridSize);
            secondStep = (int)Math.Round(secondDirection / mainDirection * gridSize);
            thirdError = (int)Math.Floor(thirdd * gridSize);
            thirdStep = (int)Math.Round(thirdDirection / mainDirection * gridSize);

            if (secondError + secondStep <= 0)
            {
                secondError = -secondStep + 1;
            }

            if (thirdError + thirdStep <= 0)
            {
                thirdError = -thirdStep + 1;
            }

            IBlock lastBlock;

            lastBlock = startBlock.GetRelative(mainFace.GetOppositeFace());

            if (secondError < 0)
            {
                secondError += gridSize;
                lastBlock = lastBlock.GetRelative(secondFace.GetOppositeFace());
            }

            if (thirdError < 0)
            {
                thirdError += gridSize;
                lastBlock = lastBlock.GetRelative(thirdFace.GetOppositeFace());
            }

            // This means that when the variables are positive, it means that the coord=1 boundary has been crossed
            secondError -= gridSize;
            thirdError -= gridSize;

            blockQueue[0] = lastBlock;
            currentBlock = -1;

            Scan();

            bool startBlockFound = false;

            for (int cnt = currentBlock; cnt >= 0; cnt--)
            {
                if (BlockEquals(blockQueue[cnt], startBlock))
                {
                    currentBlock = cnt;
                    startBlockFound = true;
                    break;
                }
            }

            if (!startBlockFound)
            {
                throw new Exception("Start block missed in BlockIterator");
            }

            // Calculate the number of planes passed to give max distance
            maxDistanceInt = (int)Math.Round(maxDistance / (Math.Sqrt(mainDirection * mainDirection + secondDirection * secondDirection + thirdDirection * thirdDirection) / mainDirection));

        }

        private bool BlockEquals(IBlock a, IBlock b)
        {
            return a.GetX() == b.GetX() && a.GetY() == b.GetY() && a.GetZ() == b.GetZ();
        }

        private BlockFace GetXFace(Vector direction)
        {
            return ((direction.X > 0) ? BlockFace.East : BlockFace.West);
        }

        private BlockFace GetYFace(Vector direction)
        {
            return ((direction.Y > 0) ? BlockFace.Up : BlockFace.Down);
        }

        private BlockFace GetZFace(Vector direction)
        {
            return ((direction.Z > 0) ? BlockFace.South : BlockFace.North);
        }

        private double GetXLength(Vector direction)
        {
            return Math.Abs(direction.X);
        }

        private double GetYLength(Vector direction)
        {
            return Math.Abs(direction.Y);
        }

        private double GetZLength(Vector direction)
        {
            return Math.Abs(direction.Z);
        }

        private double getPosition(double direction, double position, int blockPosition)
        {
            return direction > 0 ? (position - blockPosition) : (blockPosition + 1 - position);
        }

        private double GetXPosition(Vector direction, Vector position, IBlock block)
        {
            return getPosition(direction.X, position.X, block.GetX());
        }

        private double GetYPosition(Vector direction, Vector position, IBlock block)
        {
            return getPosition(direction.Y, position.Y, block.GetY());
        }

        private double GetZPosition(Vector direction, Vector position, IBlock block)
        {
            return getPosition(direction.Z, position.Z, block.GetZ());
        }

        public BlockIterator(Location loc, double yOffset, int maxDistance)
            : this(loc.World, loc.ToVector(), loc.GetDirection(), yOffset, maxDistance)
        {
        }

        public BlockIterator(Location loc, double yOffset)
            : this(loc.World, loc.ToVector(), loc.GetDirection(), yOffset, 0)
        {
        }

        public BlockIterator(Location loc) : this(loc, 0D)
        {
        }

        public BlockIterator(ILivingEntity entity, int maxDistance) : this(entity.GetLocation(), entity.GetEyeHeight(), maxDistance)
        {
        }

        public BlockIterator(ILivingEntity entity) : this(entity, 0)
        {
        }

        public bool HasNext()
        {
            Scan();
            return currentBlock != -1;
        }

        public void Remove()
        {
            throw new NotImplementedException("[BlockIterator] doesn't support block removal");
        }

        private void Scan()
        {
            if (currentBlock >= 0)
            {
                return;
            }
            if (maxDistance != 0 && currentDistance > maxDistanceInt)
            {
                end = true;
                return;
            }
            if (end)
            {
                return;
            }

            currentDistance++;

            secondError += secondStep;
            thirdError += thirdStep;

            if (secondError > 0 && thirdError > 0)
            {
                blockQueue[2] = blockQueue[0].GetRelative(mainFace);
                if (((long)secondStep) * ((long)thirdError) < ((long)thirdStep) * ((long)secondError))
                {
                    blockQueue[1] = blockQueue[2].GetRelative(secondFace);
                    blockQueue[0] = blockQueue[1].GetRelative(thirdFace);
                }
                else
                {
                    blockQueue[1] = blockQueue[2].GetRelative(thirdFace);
                    blockQueue[0] = blockQueue[1].GetRelative(secondFace);
                }
                thirdError -= gridSize;
                secondError -= gridSize;
                currentBlock = 2;
                return;
            }
            else if (secondError > 0)
            {
                blockQueue[1] = blockQueue[0].GetRelative(mainFace);
                blockQueue[0] = blockQueue[1].GetRelative(secondFace);
                secondError -= gridSize;
                currentBlock = 1;
                return;
            }
            else if (thirdError > 0)
            {
                blockQueue[1] = blockQueue[0].GetRelative(mainFace);
                blockQueue[0] = blockQueue[1].GetRelative(thirdFace);
                thirdError -= gridSize;
                currentBlock = 1;
                return;
            }
            else
            {
                blockQueue[0] = blockQueue[0].GetRelative(mainFace);
                currentBlock = 0;
                return;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            Scan();
            if (currentBlock <= -1)
            {
                throw new Exception();
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IBlock Current
        {
            get
            {
                return blockQueue[currentBlock--];
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
