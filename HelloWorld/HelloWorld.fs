namespace HelloWorld

open Samples.FSharp.ProvidedTypes
open System.Reflection
open Microsoft.FSharp.Core.CompilerServices
open Microsoft.FSharp.Quotations

[<TypeProvider>]
type HelloWorld() as this = 
    inherit TypeProviderForNamespaces()

    do
        let assembly = Assembly.GetExecutingAssembly()
        let ns = "TypeProvider.Samples"
        let t = ProvidedTypeDefinition(assembly, ns, "Container", None)
        let p = ProvidedProperty(propertyName = "Message", 
                                 propertyType = typeof<string>, 
                                 IsStatic = true,
                                 GetterCode = (fun args -> <@@ "Hello World" @@>))
        t.AddMember(p)

        let all = [t]
        this.AddNamespace(ns, all)

