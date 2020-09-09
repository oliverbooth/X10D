namespace X10D.Unity
{
    using System;
    using UnityEngine;

    /// <summary>
    ///     Represents a struct which contains game timing information.
    /// </summary>
    public readonly struct GameTime : IEquatable<GameTime>
    {
        private GameTime(float totalTime, float deltaTime, float fixedDeltaTime, int frameCount, float timeScale)
        {
            this.TotalTime = TimeSpan.FromSeconds(totalTime);
            this.DeltaTime = TimeSpan.FromSeconds(deltaTime);
            this.FixedDeltaTime = TimeSpan.FromSeconds(fixedDeltaTime);
            this.FrameCount = frameCount;
            this.TimeScale = timeScale;
        }

        /// <summary>
        ///     Gets the time since the last frame was rendered.
        /// </summary>
        public TimeSpan DeltaTime { get; }

        /// <summary>
        ///     Gets the time since the last physics time step.
        /// </summary>
        public TimeSpan FixedDeltaTime { get; }

        /// <summary>
        ///     Gets the total number of frames which have been rendered.
        /// </summary>
        public int FrameCount { get; }

        /// <summary>
        ///     Gets the total time for which the game has been running.
        /// </summary>
        public TimeSpan TotalTime { get; }

        /// <summary>
        ///     Gets the time scale.
        /// </summary>
        public float TimeScale { get; }

        /// <summary>
        ///      Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true" /> if the objects are considered equal; otherwise, <see langword="false" />.</returns>
        public static bool operator ==(GameTime left, GameTime right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether the specified object is not equal to the current object.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns> <see langword="true" /> if the objects are considered not equal; otherwise, <see langword="false" />.</returns>
        public static bool operator !=(GameTime left, GameTime right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="GameTime" /> struct by creating a snapshot of values offered by <see cref="Time" />.
        /// </summary>
        /// <returns>An instance of <see cref="GameTime" />.</returns>
        public static GameTime CreateFromCurrentTimes()
        {
            return new GameTime(Time.time, Time.deltaTime, Time.fixedDeltaTime, Time.frameCount, Time.timeScale);
        }

        /// <inheritdoc/>
        public override bool Equals(object other)
        {
            return this.Equals((GameTime)other);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.FixedDeltaTime.GetHashCode() ^
                   this.DeltaTime.GetHashCode() ^
                   this.TotalTime.GetHashCode() ^
                   this.TimeScale.GetHashCode() ^
                   this.FrameCount;
        }

        /// <inheritdoc/>
        public bool Equals(GameTime other)
        {
            return this.DeltaTime == other.DeltaTime ||
                   this.FixedDeltaTime == other.FixedDeltaTime ||
                   this.FrameCount == other.FrameCount ||
                   Math.Abs(this.TimeScale - other.TimeScale) < float.Epsilon;
        }
    }
}
