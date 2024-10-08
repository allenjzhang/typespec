// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Tests.Common;
using NUnit.Framework;

namespace Microsoft.Generator.CSharp.ClientModel.Tests.Providers.ClientProviders
{
    public class ClientProviderCustomizationTests
    {
        [Test]
        public async Task CanAddMethod()
        {
            var inputOperation = InputFactory.Operation("HelloAgain", parameters:
            [
                InputFactory.Parameter("p1", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var inputClient = InputFactory.Client("TestClient", operations: [inputOperation]);
            var plugin = await MockHelpers.LoadMockPluginAsync(
                clients: () => [inputClient],
                compilation: async () => await Helpers.GetCompilationFromDirectoryAsync());

            // Find the client provider
            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.SingleOrDefault(t => t is ClientProvider);
            Assert.IsNotNull(clientProvider);

            var clientProviderMethods = clientProvider!.Methods;
            Assert.AreEqual(4, clientProviderMethods.Count);
            Assert.IsFalse(clientProviderMethods.Any(m => m.Signature.Name == "NewMethod"));

            // The custom code view should contain the method
            var customCodeView = clientProvider.CustomCodeView;
            Assert.IsNotNull(customCodeView);
            var customMethods = customCodeView!.Methods;
            Assert.AreEqual(1, customMethods.Count);
            Assert.AreEqual("NewMethod", customMethods[0].Signature.Name);
            Assert.AreEqual(customMethods[0].Signature.Parameters.Count, 2);
            Assert.IsNull(customMethods[0].BodyExpression);
            Assert.AreEqual(string.Empty, customMethods[0].BodyStatements!.ToDisplayString());
        }

        [Test]
        public async Task CanAddMultipleMethods()
        {
            var inputOperation = InputFactory.Operation("HelloAgain", parameters:
            [
                InputFactory.Parameter("p1", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var inputClient = InputFactory.Client("TestClient", operations: [inputOperation]);
            var plugin = await MockHelpers.LoadMockPluginAsync(
                clients: () => [inputClient],
                compilation: async () => await Helpers.GetCompilationFromDirectoryAsync());

            // Find the client provider
            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.SingleOrDefault(t => t is ClientProvider);
            Assert.IsNotNull(clientProvider);

            var clientProviderMethods = clientProvider!.Methods;
            Assert.AreEqual(4, clientProviderMethods.Count);

            // The custom code view should contain the method
            var customCodeView = clientProvider.CustomCodeView;
            Assert.IsNotNull(customCodeView);
            var customMethods = customCodeView!.Methods;
            Assert.AreEqual(4, customMethods.Count);
            Assert.AreEqual("NewMethodOne", customMethods[0].Signature.Name);
            Assert.AreEqual(customMethods[0].Signature.Parameters.Count, 2);
            Assert.AreEqual("NewMethodTwo", customMethods[1].Signature.Name);
            Assert.AreEqual(customMethods[1].Signature.Parameters.Count, 0);
            Assert.AreEqual("NewMethodThree", customMethods[2].Signature.Name);
            Assert.AreEqual(customMethods[2].Signature.Parameters.Count, 1);
            Assert.AreEqual("NewMethodFour", customMethods[3].Signature.Name);
            Assert.AreEqual(customMethods[3].Signature.Parameters.Count, 1);
        }

        // Validates that the custom method is added when the method has the same name as an existing method but different parameters
        [Test]
        public async Task CanAddMethodSameName()
        {
            var inputOperation = InputFactory.Operation("HelloAgain", parameters:
            [
                InputFactory.Parameter("p1", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var inputClient = InputFactory.Client("TestClient", operations: [inputOperation]);
            var plugin = await MockHelpers.LoadMockPluginAsync(
                clients: () => [inputClient],
                compilation: async () => await Helpers.GetCompilationFromDirectoryAsync());

            // Find the client provider
            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.SingleOrDefault(t => t is ClientProvider);
            Assert.IsNotNull(clientProvider);

            var clientProviderMethods = clientProvider!.Methods;
            Assert.AreEqual(4, clientProviderMethods.Count);

            var helloAgainMethod = clientProviderMethods.FirstOrDefault(m
                => m.Signature.Name == "HelloAgain" && m.Signature.Parameters.Count > 0 && m.Signature.Parameters[0].Name == "p1");
            Assert.IsNotNull(helloAgainMethod);
            Assert.AreEqual(1, helloAgainMethod!.Signature.Parameters.Count);

            // The custom code view should contain the method
            var customCodeView = clientProvider.CustomCodeView;
            Assert.IsNotNull(customCodeView);
            var customMethods = customCodeView!.Methods;
            Assert.AreEqual(1, customMethods.Count);
            Assert.AreEqual("HelloAgain", customMethods[0].Signature.Name);
            Assert.AreEqual(customMethods[0].Signature.Parameters.Count, 2);
            Assert.IsNull(customMethods[0].BodyExpression);
            Assert.AreEqual(string.Empty, customMethods[0].BodyStatements!.ToDisplayString());
        }
    }
}
