// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWindowsServiceController.cs" company="Yin Zhang">
//   Copyright (c) 2013 Yin Zhang
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
//   files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
//   modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the 
//   Software is furnished to do so, subject to the following conditions:
//     
//   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//    
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//   WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   The WindowsServiceController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WindowsServiceBootstrapper.Interfaces
{
    /// <summary>
    /// The WindowsServiceController interface.
    /// </summary>
    public interface IWindowsServiceController
    {
        #region Public Properties

        /// <summary>
        /// Gets current Windows service name.
        /// </summary>
        string ServiceName { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Action to be performed when continuing service.
        /// </summary>
        void OnContinue();

        /// <summary>
        /// Action to be performed when pausing service.
        /// </summary>
        void OnPause();

        /// <summary>
        /// Action to be performed when starting service.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Action to be performed when stopping service.
        /// </summary>
        void OnStop();

        #endregion
    }
}