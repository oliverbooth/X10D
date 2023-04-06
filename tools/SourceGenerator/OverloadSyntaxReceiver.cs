using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using X10D.MetaServices;

namespace SourceGenerator;

public class OverloadSyntaxReceiver : ISyntaxReceiver
{
    private readonly List<MethodDeclarationSyntax> _candidateMethods = new();

    public IReadOnlyList<MethodDeclarationSyntax> CandidateMethods
    {
        get => _candidateMethods.AsReadOnly();
    }

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not MethodDeclarationSyntax methodDeclarationSyntax)
        {
            return;
        }

        if (methodDeclarationSyntax.AttributeLists.Count == 0)
        {
            return;
        }

        string attributeName = nameof(AutoOverloadAttribute).Replace("Attribute", string.Empty);
        foreach (AttributeListSyntax attributeListSyntax in methodDeclarationSyntax.AttributeLists)
        {
            foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
            {
                if (attributeSyntax.Name.ToString() == attributeName)
                {
                    _candidateMethods.Add(methodDeclarationSyntax);
                    break;
                }
            }
        }
    }
}
