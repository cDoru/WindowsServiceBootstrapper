// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoProviderTests.cs" company="Yin Zhang">
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
//   The assembly info provider tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WindowsServiceBootstrapper.UnitTests
{
    using System;
    using System.Reflection;

    using WindowsServiceBootstrapper.Interfaces;

    using Xunit;

    /// <summary>
    /// The assembly info provider tests.
    /// </summary>
    public class AssemblyInfoProviderTests
    {
        /// <summary>
        /// Defines assembly service information provider unit test.
        /// </summary>
        public class AssemblyInfoProviderTest
        {
            #region Fields

            /// <summary>
            /// Defines service info provider.
            /// </summary>
            private readonly IWindowsServiceInfoProvider serviceInfoProvider;

            /// <summary>
            /// Defines current assembly.
            /// </summary>
            private Assembly assembly;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="AssemblyInfoProviderTest"/> class.
            /// </summary>
            public AssemblyInfoProviderTest()
            {
                this.assembly = Assembly.GetAssembly(this.GetType());

                this.serviceInfoProvider = new AssemblyInfoProvider(this.assembly);
            }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Test to make sure that <see cref="AssemblyInfoProvider"/> can get service description.
            /// </summary>
            [Fact]
            public void AssemblyInfoProviderCanGetServiceDescription()
            {
                var assemblyDescription = this.assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

                string serviceDescription = null;
                Assert.DoesNotThrow(() => serviceDescription = this.serviceInfoProvider.GetServiceDescription());
                Assert.NotNull(serviceDescription);

                Assert.Equal(assemblyDescription, serviceDescription);
            }

            /// <summary>
            /// Test to make sure that <see cref="AssemblyInfoProvider"/> can get service display name.
            /// </summary>
            [Fact]
            public void AssemblyInfoProviderCanGetServiceDisplayName()
            {
                var company = this.assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
                var product = this.assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
                var version = this.assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

                var expectedServiceName = string.Format("{0} {1} {2}", company, product, version);

                string serviceDisplayName = null;

                Assert.DoesNotThrow(() => serviceDisplayName = this.serviceInfoProvider.GetServiceDisplayName());
                Assert.NotNull(serviceDisplayName);
                Assert.Equal(expectedServiceName, serviceDisplayName);
            }

            /// <summary>
            /// Test to make sure that <see cref="AssemblyInfoProvider"/> can get service name.
            /// </summary>
            [Fact]
            public void AssemblyInfoProviderCanGetServiceName()
            {
                var name = this.assembly.GetName().Name;

                string serviceName = null;
                Assert.DoesNotThrow(() => serviceName = this.serviceInfoProvider.GetServiceName());
                Assert.NotNull(serviceName);

                Assert.Equal(name, serviceName);
            }

            /// <summary>
            /// Test to make sure that <see cref="AssemblyInfoProvider"/> throws exception when
            /// assembly is null.
            /// </summary>
            [Fact]
            public void AssemblyInfoProviderThrowsExceptionWhenAssemblyIsNull()
            {
                this.assembly = null;

                Assert.Throws<ArgumentNullException>(() => new AssemblyInfoProvider(this.assembly));
            }

            #endregion
        }
    }
}