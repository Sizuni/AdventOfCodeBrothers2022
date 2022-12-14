using Util;

namespace Day09RopeBridge.Domain
{
    public interface IRope
    {
        public Coordinate2D HeadPosition { get; }
        public Coordinate2D TailPosition { get; }
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
    }
}
