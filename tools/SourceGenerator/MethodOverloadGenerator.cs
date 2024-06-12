using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerator;

[Generator]
internal sealed class MethodOverloadGenerator : ISourceGenerator
{
    /// <inheritdoc />
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new OverloadSyntaxReceiver());
    }

    /// <inheritdoc />
    public void Execute(GeneratorExecutionContext context)
    {
        var syntaxReceiver = (OverloadSyntaxReceiver)context.SyntaxReceiver!;
        IReadOnlyList<MethodDeclarationSyntax> candidateMethods = syntaxReceiver.CandidateMethods;
        // TODO implement
    }
}
