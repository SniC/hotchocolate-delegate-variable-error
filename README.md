# hotchocolate-delegate-variable-error

## Issue: Delegating with a variable does not work when Input Type is an object.

## How to reproduce:
- Open in VS2019
- Select all projects as startup projects
- Hit F5
- Run query: 

```graphql
{
  item {
    id
    extraData
  }
}
```

## What happens:
- This stacktrace is returned

```json
{
  "errors": [
    {
      "message": "Unexpected Execution Error",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "item"
      ],
      "extensions": {
        "message": "Unexpected token: $.",
        "stackTrace": "   at HotChocolate.Language.Parser.ParseValueLiteral(ParserContext context, Boolean isConstant)\r\n   at HotChocolate.Language.Parser.ParseObjectField(ParserContext context, Boolean isConstant)\r\n   at HotChocolate.Language.Parser.<>c__DisplayClass71_0.<ParseObject>b__0(ParserContext c)\r\n   at HotChocolate.Language.Parser.ParseMany[T](ParserContext context, TokenKind openKind, Func`2 parser, TokenKind closeKind)\r\n   at HotChocolate.Language.Parser.ParseObject(ParserContext context, Boolean isConstant)\r\n   at HotChocolate.Language.Parser.ParseValueLiteral(ParserContext context, Boolean isConstant)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.ParseValueLiteral(ParserContext context)\r\n   at HotChocolate.Language.Parser.ParseArgument(ParserContext context, Func`2 parseValue)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.ParseArgument(ParserContext context)\r\n   at HotChocolate.Language.Parser.ParseMany[T](ParserContext context, TokenKind openKind, Func`2 parser, TokenKind closeKind)\r\n   at HotChocolate.Language.Parser.ParseArguments(ParserContext context, Func`2 parseArgument)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.ParseArguments(ParserContext context)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.ParseSelectionPathComponent(ParserContext context)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.ParseSelectionPath(ISource source, SyntaxToken start, ParserOptions options)\r\n   at HotChocolate.Stitching.Delegation.SelectionPathParser.Parse(ISource source)\r\n   at HotChocolate.Stitching.Utilities.FieldDependencyResolver.CollectFieldNames(DelegateDirective directive, IHasName type, ISet`1 dependencies)\r\n   at HotChocolate.Stitching.Utilities.FieldDependencyResolver.CollectDelegationDependencies(Context context, IHasName type, IOutputField field)\r\n   at HotChocolate.Stitching.Utilities.FieldDependencyResolver.VisitField(FieldNode node, Context context)\r\n   at HotChocolate.Language.SyntaxVisitor`2.VisitMany[T](IEnumerable`1 items, TContext context, Action`2 action)\r\n   at HotChocolate.Language.QuerySyntaxWalker`1.VisitSelectionSet(SelectionSetNode node, TContext context)\r\n   at HotChocolate.Stitching.Utilities.FieldDependencyResolver.GetFieldDependencies(DocumentNode document, SelectionSetNode selectionSet, INamedOutputType declaringType)\r\n   at HotChocolate.Stitching.Utilities.ExtractFieldQuerySyntaxRewriter.RewriteSelectionSet(SelectionSetNode node, Context context)\r\n   at HotChocolate.Language.SyntaxRewriter`1.Rewrite[TParent,TProperty](TParent parent, TProperty property, TContext context, Func`3 visit, Func`2 rewrite)\r\n   at HotChocolate.Stitching.Utilities.ExtractFieldQuerySyntaxRewriter.RewriteFieldSelectionSet(FieldNode node, IOutputField field, Context context)\r\n   at HotChocolate.Stitching.Utilities.ExtractFieldQuerySyntaxRewriter.RewriteField(FieldNode node, Context context)\r\n   at HotChocolate.Stitching.Utilities.ExtractFieldQuerySyntaxRewriter.ExtractField(NameString sourceSchema, DocumentNode document, OperationDefinitionNode operation, FieldNode field, INamedOutputType declaringType)\r\n   at HotChocolate.Stitching.DelegateToRemoteSchemaMiddleware.CreateQuery(IMiddlewareContext context, NameString schemaName, IImmutableStack`1 path)\r\n   at HotChocolate.Stitching.DelegateToRemoteSchemaMiddleware.InvokeAsync(IMiddlewareContext context)\r\n   at HotChocolate.Execution.ExecutionStrategyBase.ExecuteMiddlewareAsync(ResolverContext resolverContext, IErrorHandler errorHandler)"
      }
    }
  ]
}

```

## What was expected:
The following response

```json
{
  "data": {
    "item": {
      "id": "6fc8ff09-695b-4666-abc9-5f6b2d25dc3f",
      "extraData": "extra data"
    }
  }
}
```