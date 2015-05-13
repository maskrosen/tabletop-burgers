using System;

namespace Drag_and_Drop
{
    public class Tag
    {
        public int id { get; private set; }
        public int trainNumber { get; private set; }
        public String destination { get; private set; }
        public DateTime time { get; private set; }
        public int track { get; private set; }
        public bool orderPlaced { get; private set; }
        public int timeLeft { get; private set; }

        public Tag(int id, int trainNumber, String destination, DateTime time, int track, bool orderPlaced, int timeLeft)
        {
            this.id = id;
            this.trainNumber = trainNumber;
            this.destination = destination;
            this.time = time;
            this.track = track;
            this.orderPlaced = orderPlaced;
            this.timeLeft = timeLeft;
        }
    }
}
