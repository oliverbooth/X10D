namespace X10D.Unity
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using UnityEngine;

    /// <summary>
    ///     Represents a class which inherits <see cref="MonoBehaviour" /> to offer wider functionality.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "Unity property")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "Unity property")]
    [SuppressMessage("ReSharper", "SA1300", Justification = "Unity API-compliant property")]
    [SuppressMessage("ReSharper", "CA2007", Justification = "Unnecessary")]
    [SuppressMessage("ReSharper", "RCS1090", Justification = "Unnecessary")]
    [SuppressMessage("ReSharper", "RCS1213", Justification = "Unity method")]
    [SuppressMessage("ReSharper", "UnusedParameter.Global", Justification = "Override method")]
    public abstract class BetterBehavior : MonoBehaviour
    {
        /// <summary>
        ///     Gets the <see cref="Transform" /> component attached to this object.
        /// </summary>
        public new Transform transform { get; private set; }

        /// <summary>
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
            this.transform = this.GetComponent<Transform>();
        }

        /// <summary>
        ///     Frame-rate independent messaging for physics calculations.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        protected virtual void OnFixedUpdate(in GameTime gameTime)
        {
        }

        /// <summary>
        ///     Frame-rate independent messaging for physics calculations.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        /// <returns>Returns a task representing the result of the operation.</returns>
        protected virtual Task OnFixedUpdateAsync(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Called once per frame, after all <c>Update</c> calls.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        protected virtual void OnLateUpdate(in GameTime gameTime)
        {
        }

        /// <summary>
        ///     Called once per frame, after all <c>Update</c> calls.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        /// <returns>Returns a task representing the result of the operation.</returns>
        protected virtual Task OnLateUpdateAsync(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Called once per frame.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        protected virtual void OnUpdate(in GameTime gameTime)
        {
        }

        /// <summary>
        ///     Called once per frame.
        /// </summary>
        /// <param name="gameTime">A snapshot of timing values.</param>
        /// <returns>Returns a task representing the result of the operation.</returns>
        protected virtual Task OnUpdateAsync(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        private async void FixedUpdate()
        {
            var time = GameTime.CreateFromCurrentTimes();
            this.OnFixedUpdate(time);
            await this.OnFixedUpdateAsync(time);
        }

        private async void LateUpdate()
        {
            var time = GameTime.CreateFromCurrentTimes();
            this.OnLateUpdate(time);
            await this.OnLateUpdateAsync(time);
        }

        private async void Update()
        {
            var time = GameTime.CreateFromCurrentTimes();
            this.OnUpdate(time);
            await this.OnUpdateAsync(time);
        }
    }
}
