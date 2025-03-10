//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ./Grammar/C.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public interface ICVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] CParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.preprocessorDirective"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPreprocessorDirective([NotNull] CParser.PreprocessorDirectiveContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.mainFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMainFunction([NotNull] CParser.MainFunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] CParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDeclaration([NotNull] CParser.FunctionDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] CParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] CParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDeclaration([NotNull] CParser.VariableDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.variableDeclarator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDeclarator([NotNull] CParser.VariableDeclaratorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.structDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDeclaration([NotNull] CParser.StructDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.structInstance"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructInstance([NotNull] CParser.StructInstanceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.structAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructAssignment([NotNull] CParser.StructAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.structMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructMember([NotNull] CParser.StructMemberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.unionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnionDeclaration([NotNull] CParser.UnionDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.unionMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnionMember([NotNull] CParser.UnionMemberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.unionInstance"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnionInstance([NotNull] CParser.UnionInstanceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.unionAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnionAssignment([NotNull] CParser.UnionAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] CParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] CParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.getsStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGetsStatement([NotNull] CParser.GetsStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.putsStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPutsStatement([NotNull] CParser.PutsStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionStatement([NotNull] CParser.ExpressionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.printfStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintfStatement([NotNull] CParser.PrintfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.scanfStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScanfStatement([NotNull] CParser.ScanfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.blockStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockStatement([NotNull] CParser.BlockStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] CParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.switchStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchStatement([NotNull] CParser.SwitchStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseStatement([NotNull] CParser.CaseStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.defaultStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefaultStatement([NotNull] CParser.DefaultStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.forDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForDeclaration([NotNull] CParser.ForDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] CParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.forControl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForControl([NotNull] CParser.ForControlContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] CParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.doWhileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoWhileStatement([NotNull] CParser.DoWhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.functionCallStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallStatement([NotNull] CParser.FunctionCallStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStatement([NotNull] CParser.ReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.selectionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelectionStatement([NotNull] CParser.SelectionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.pointerDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPointerDeclaration([NotNull] CParser.PointerDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.ternaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTernaryExpression([NotNull] CParser.TernaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.arrayDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayDeclaration([NotNull] CParser.ArrayDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.matrixDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMatrixDeclaration([NotNull] CParser.MatrixDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.arrayInitializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayInitializer([NotNull] CParser.ArrayInitializerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] CParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.assignmentExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] CParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] CParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.logicalOrExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpression([NotNull] CParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.logicalAndExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpression([NotNull] CParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.equalityExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpression([NotNull] CParser.EqualityExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpression([NotNull] CParser.RelationalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpression([NotNull] CParser.AdditiveExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpression([NotNull] CParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] CParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimaryExpression([NotNull] CParser.PrimaryExpressionContext context);
}
