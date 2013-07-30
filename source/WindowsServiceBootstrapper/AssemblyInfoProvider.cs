// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoProvider.cs" company="Yin Zhang">
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
//   The assembly info provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WindowsServiceBootstrapper
{
    using System;
    using System.Reflection;

    using WindowsServiceBootstrapper.Interfaces;

    /// <summary>
    /// The assembly info provider.
    /// </summary>
    public class AssemblyInfoProvider : IWindowsServiceInfoProvider
    {
        /// <summary>
        /// The assembly.
        /// </summary>
        private readonly Assembly assembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyInfoProvider"/> class.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The assembly is null.
        /// </exception>
        public AssemblyInfoProvider(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            this.assembly = assembly;
        }

        /// <summary>
        /// Gets the service name of Windows service from assembly name.
        /// </summary>
        /// <returns>
        /// The Windows service name.
        /// </returns>
        public string GetServiceName()
        {
            return this.assembly.GetName().Name;
        }

        /// <summary>
        /// Gets the service display name of Windows service.
        /// </summary>
        /// <remarks>
        /// The service display name is a combination of assembly company attribute, product attribute
        /// and version attribute in the format of {Company} {Product} {Version}
        /// </remarks>
        /// <returns>
        /// The Windows service display name.
        /// </returns>
        public string GetServiceDisplayName()
        {
            var companyInfo = this.assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            var productInfo = this.assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
            var assemblyVersion = this.assembly.GetName().Version;

            return string.Format("{0} {1} {2}", companyInfo, productInfo, assemblyVersion);
        }

        /// <summary>
        /// Gets the service description of Windows service from assembly description.
        /// </summary>
        /// <returns>
        /// The Windows service description.
        /// </returns>
        public string GetServiceDescription()
        {
            return this.assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
        }
    }
}