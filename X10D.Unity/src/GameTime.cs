namespace X10D.Unity
{
    using System;
    using UnityEngine;

    /// <summary>
    ///     Represents a struct which contains game timing information.
    /// </summary>
    public readonly struct GameTime
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
        ///     Creates a new instance of the <see cref="GameTime" /> struct by creating a snapshot of values offered by <see cref="Time" />.
        /// </summary>
        /// <returns>An instance of <see cref="GameTime" />.</returns>
        public static GameTime CreateFromCurrentTimes()
        {
            return new GameTime(Time.time, Time.deltaTime, Time.fixedDeltaTime, Time.frameCount, Time.timeScale);
        }
    }
}
