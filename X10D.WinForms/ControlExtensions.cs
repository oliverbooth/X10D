namespace X10D.WinForms
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Control"/>.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Gets all controls and child controls of a specified control.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <returns>Returns a collection of controls.</returns>
        public static IEnumerable<Control> GetAllControls(this Control control)
        {
            return control.GetAllControls<Control>();
        }

        /// <summary>
        /// Gets all controls and child controls of a specified control, which match the specified type.
        /// </summary>
        /// <typeparam name="TControl">A <see cref="Control"/> type.</typeparam>
        /// <param name="control">The parent control.</param>
        /// <returns>Returns a collection of controls.</returns>
        public static IEnumerable<TControl> GetAllControls<TControl>(this Control control)
            where TControl : Control
        {
            return control.GetAllControls(typeof(TControl)).Cast<TControl>();
        }

        /// <summary>
        /// Gets all controls and child controls of a specified control, which match the specified type.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <param name="type">The type to match.</param>
        /// <returns>Returns a collection of controls.</returns>
        public static IEnumerable<Control> GetAllControls(this Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(c => GetAllControls(c, type))
                           .Concat(controls)
                           .Where(c => c.GetType() == type);
        }

        /// <summary>
        /// Thread-safe method invocation. Calls <see cref="Control.Invoke(System.Delegate)"/> if
        /// <see cref="Control.InvokeRequired"/> returns <see langword="true"/>.
        /// </summary>
        /// <param name="control">The control from which to invoke.</param>
        /// <param name="action">The action to invoke.</param>
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control?.InvokeRequired ?? false)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
